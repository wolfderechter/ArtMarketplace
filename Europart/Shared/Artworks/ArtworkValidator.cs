using FluentValidation;
using Microsoft.Extensions.Localization;


namespace EuropArt.Shared.Artworks
{
    public class ArtworkValidator : AbstractValidator<ArtworkDto.Create>
    {
        public ArtworkValidator(IStringLocalizer<Resources.Artworks.Validation> Loc)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(Loc["Title"]);
            RuleFor(p => p.Name).MaximumLength(100).WithMessage(Loc["BuyNow"]);
            RuleFor(p => p.Price).NotEmpty().WithMessage(Loc["Price"]);
                
        }
    }
}
