using AutoMapper;
using CommonHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_QLHoSo_So.Api.Common;
using Web_QLHoSo_So.Api.PolicyBaseAuthProvider;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Service.common;
using Web_QLHoSo_So.Service.UserService;
namespace Web_QLHoSo_So.Api.Modoule.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.service = userService;
            this.mapper = mapper;
        }
        //[AllowAnonymous]
        [HasPermision(Permission.READ)]
        [HttpGet]
        public IActionResult getAll([FromQuery] UserQuery? query)
        {
            //var id=HttpContext.User.FindFirst(ClaimsConstant.USER_ID)?.Value;
            return ResponseApiCommon.Success(this.service.GetAll(query));
        }
        [HttpPost]
        public IActionResult post(UserDto dto)
        {
            try
            {
                if(!this.service.checkUser(dto.Email))
                {
                    dto.Password = Helper.hashPassword(dto.Password);
                    if (this.service.Add(dto))
                    {
                        return ResponseApiCommon.Success(dto);
                    }
                    else
                    {
                        return ResponseApiCommon.Error("Thêm user thất bại", CommonHttpStatus.InternalServerError);
                    }
                }
                else
                   return ResponseApiCommon.Error("Username đã tồn tại", CommonHttpStatus.BadRequest);
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult put(UserDto dto)
        {
            try
            {
                var user = this.service.GetById(dto.Id);
                if (user!=null)
                {
                    if(user.Email!=dto.Email)
                    {
                        if(this.service.checkUser(dto.Email))
                        {
                            return ResponseApiCommon.Error("Username đã tồn tại", CommonHttpStatus.BadRequest);
                        }    
                    }
                    dto.Password = Helper.hashPassword(dto.Password);
                    if (this.service.Update(dto))
                    {
                        return ResponseApiCommon.Success(dto, "Cập nhập user thành công");
                    }
                    else
                    {
                        return ResponseApiCommon.Error("Cập nhật user thất bại", CommonHttpStatus.InternalServerError);
                    }
                }
                return ResponseApiCommon.Error("User Id không tồn tại", CommonHttpStatus.NotFound);
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message, CommonHttpStatus.InternalServerError);
            }
        }
        [HttpDelete("softDelete")]
        //[HasPermision(Permission.Update)]
        public IActionResult softdelete(Guid id)
        {
            try
            {
                if(this.service.GetById(id)!=null)
                {
                    if (this.service.softDelete(id))
                        return ResponseApiCommon.Success(id);
                    else
                        return ResponseApiCommon.Error("Xóa user thất bại",CommonHttpStatus.InternalServerError);
                }
                return ResponseApiCommon.Error("User Id không tồn tại", CommonHttpStatus.NotFound);
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message, CommonHttpStatus.InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult getById(Guid id)
        {
            try
            {
                var user = this.service.GetById(id);
                if (user != null)
                    return ResponseApiCommon.Success(user);
                else
                    throw new CommonException("Id user không tồn tại", CommonHttpStatus.BadRequest);
            }
            catch(CommonException ex)
            {
                return ResponseApiCommon.Error(ex.Message, ex.StatusCode);
            }
        }
    }
}
