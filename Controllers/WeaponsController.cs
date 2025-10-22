using dotnet_rpg.Dtos.Weapon;
using dotnet_rpg.Services.WeaponsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeaponsController :ControllerBase
    {
        private readonly IWeaponService _weaponService;
        public WeaponsController(IWeaponService weaponsService) 
        { 
            _weaponService = weaponsService;    
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
        {
            var response = await _weaponService.AddWeapon(newWeapon);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
