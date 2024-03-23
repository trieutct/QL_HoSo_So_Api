using CommonHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_QLHoSo_So.Api.Common;
using Web_QLHoSo_So.Api.Modoule.Auth.VM;
using Web_QLHoSo_So.Service.Auth;
using Web_QLHoSo_So.Service.UserService;

namespace Web_QLHoSo_So.Api.Modoule.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService Service)
        {
            this.authService = Service;
        }
        [HttpPost("login")]
        public IActionResult login([FromBody]LoginVM login)
        {
            try
            {
                var data = authService.checklogin(login.email, login.password);
                if (data != string.Empty)
                {
                    return ResponseApiCommon.Success(data, "Đăng nhập thành công");
                }
                return ResponseApiCommon.Error("Tài khoản mật khẩu không chính xác",CommonHttpStatus.Unauthorized);
            }
            catch(CommonException ex)
            {
               return ResponseApiCommon.Error(ex.Message, ex.StatusCode);
            }
        }
    }
}
