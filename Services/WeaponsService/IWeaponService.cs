using dotnet_rpg.Dtos.Weapon;

namespace dotnet_rpg.Services.WeaponsService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
