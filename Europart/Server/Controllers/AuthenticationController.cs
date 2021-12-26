using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using EuropArt.Shared.Artists;
using EuropArt.Shared.AuthUsers;
using EuropArt.Shared.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ManagementApiClient _managementApiClient;
        private IUserService userService;
        private IArtistService artistService;

        public AuthenticationController(ManagementApiClient managementApiClient, IUserService userService, IArtistService artistSer)
        {
            _managementApiClient = managementApiClient;
            this.userService = userService;
            this.artistService = artistSer;
        }

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<AuthUserDto.Index>> GetUsers()
        {
            //get all users
            var roles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
            var role = roles.Single(role => role.Name == "notverified");
            var users = await _managementApiClient.Roles.GetUsersAsync(role.Id);
            //check if users have 1 role
            foreach (var user in users)
            {
                var userroles = await _managementApiClient.Users.GetRolesAsync(user.UserId, new PaginationInfo());
                if(userroles.Count != 1)
                {
                    //delete notverified role
                    var rolesdelete = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
                    var roledelete = rolesdelete.Single(role => role.Name == "notverified");
                    var rolesRequestdelete = new AssignRolesRequest();
                    string[] roleListdelete = { roledelete.Id };
                    rolesRequestdelete.Roles = roleListdelete;
                    await _managementApiClient.Users.RemoveRolesAsync(user.UserId, rolesRequestdelete);
                }
            }
            //get users with only notverified role
            roles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
            role = roles.Single(role => role.Name == "notverified");
            users = await _managementApiClient.Roles.GetUsersAsync(role.Id);
            return users.Select(x => new AuthUserDto.Index
            {
                Email = x.Email,
                AuthId = x.UserId.Substring(6),
            });
        }

        [HttpGet("ChangeArtistRole/{authId}")]
        public async Task<ActionResult> ChangeArtistRole(string authId)
        {
            try
            {
                //delete notverified role
                var rolesdelete = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
                var roledelete = rolesdelete.Single(role => role.Name == "notverified");
                var rolesRequestdelete = new AssignRolesRequest();
                string[] roleListdelete = { roledelete.Id };
                rolesRequestdelete.Roles = roleListdelete;
                await _managementApiClient.Users.RemoveRolesAsync("auth0|" + authId, rolesRequestdelete);
                //add artist role
                var rolesadd = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
                var roleadd = rolesadd.Single(role => role.Name == "Artist");
                var rolesRequestadd = new AssignRolesRequest();
                string[] roleList2 = { roleadd.Id };
                rolesRequestadd.Roles = roleList2;
                await _managementApiClient.Users.AssignRolesAsync("auth0|" + authId, rolesRequestadd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet("CheckUser/{authId}")]
        public async Task<ActionResult> CheckUser(string authId)
        {
            try
            {
                //check if auth0 id is a user
                if (!userService.CheckIfUser(authId))
                {
                    return NotFound();
                }
                //check roles contain User role
                var userRoles = await _managementApiClient.Users.GetRolesAsync("auth0|" + authId, new PaginationInfo());
                if (userRoles.Single(x => x.Name == "notverified") == null)
                {
                    return NotFound();
                }
                //delete notverified role
                var rolesdelete = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
                var roledelete = rolesdelete.Single(role => role.Name == "notverified");
                var rolesRequestdelete = new AssignRolesRequest();
                string[] roleListdelete = { roledelete.Id };
                rolesRequestdelete.Roles = roleListdelete;
                await _managementApiClient.Users.RemoveRolesAsync("auth0|" + authId, rolesRequestdelete);
                //add artist role
                var rolesadd = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
                var roleadd = rolesadd.Single(role => role.Name == "User");
                var rolesRequestadd = new AssignRolesRequest();
                string[] roleList2 = { roleadd.Id };
                rolesRequestadd.Roles = roleList2;
                await _managementApiClient.Users.AssignRolesAsync("auth0|" + authId, rolesRequestadd);
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{authId}")]
        public async Task<IActionResult> DeleteUser(string authId)
        {
            //get user by authid
            ArtistRequest.GetDetailByAuthId getReq = new ArtistRequest.GetDetailByAuthId();
            getReq.AuthId = authId;
            var artist = await artistService.GetDetailByAuthIdAsync(getReq);
            //delete artist
            ArtistRequest.Delete req = new ArtistRequest.Delete();
            req.ArtistId = artist.Artist.Id;
            await artistService.DeleteAsync(req);

            //delete user
            await _managementApiClient.Users.DeleteAsync("auth0|" + authId);
            return Ok();
        }
    }
}
