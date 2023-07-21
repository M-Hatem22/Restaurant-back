using RestaurantApp.BL.DTOs.Login_and_Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.Managers
{
    public interface IUsersManager
    {
        Task<TokenDto> Login(LoginDto login);
        Task<RegisterResult> Register(RegisterDto registerDto);
    }
}
