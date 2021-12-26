using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
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

        public AuthenticationController(ManagementApiClient managementApiClient, IUserService userService)
        {
            _managementApiClient = managementApiClient;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthUserDto.Index>> GetUsers()
        {
            var roles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest(), new PaginationInfo());
            var role = roles.Single(role => role.Name == "notverified");
            var users = await _managementApiClient.Roles.GetUsersAsync(role.Id);
            return users.Select(x => new AuthUserDto.Index
            {
                Email = x.Email,
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
    }
}
