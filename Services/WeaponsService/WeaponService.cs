
    using AutoMapper;
    using dotnet_rpg.Dtos.Weapon;
    using System.Security.Claims;
    using System.Threading.Tasks;

    namespace dotnet_rpg.Services.WeaponsService
    {
        public class WeaponService : IWeaponService
        {
            private readonly DataContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IMapper _mapper;
            public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
                _mapper = mapper;
            }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {

                var userIdStr = _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdStr))
                {
                    response.Success = false;
                    response.Message = "User not authenticated.";
                    return response;
                }

                int userId = int.Parse(userIdStr);

      
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.User!.Id == userId);

                if (character is null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                var weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message; 
            }

            return response;
        }


    }
}
