using Car.API.DTO;
using Car.API.Model;
using Car.API.Model;
namespace Car.API.Repository
{
    public interface ILoginService
    {
        Task<bool> ValidateCredentialsAsync(UserDto loginModel);
    }
}
