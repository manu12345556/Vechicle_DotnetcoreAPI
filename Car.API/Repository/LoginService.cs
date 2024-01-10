using Car.API.DB;
using Car.API.DTO;
using Car.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Car.API.Repository
{

    public class LoginService : ILoginService
    {
       

        private readonly VechicleDbContext _context;
        public LoginService(VechicleDbContext context)
        {
            _context = context;
        }


        public async Task<bool> ValidateCredentialsAsync(UserDto loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginModel.Username && u.Password==loginModel.Password);
            if (user == null)
            {
                return false;
            }
            return true;
        }

    }
}
