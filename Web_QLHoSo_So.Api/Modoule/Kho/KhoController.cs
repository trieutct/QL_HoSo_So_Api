using CommonHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_QLHoSo_So.Api.Common;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Service.common;
using Web_QLHoSo_So.Service.KhoService;
using Web_QLHoSo_So.Service.UserService;

namespace Web_QLHoSo_So.Api.Modoule.Kho
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoController : ControllerBase
    {
        private readonly IKhoService service;
        public KhoController(IKhoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getAll([FromQuery] KhoQuery? query)
        {
            //var id=HttpContext.User.FindFirst(ClaimsConstant.USER_ID)?.Value;
            return ResponseApiCommon.Success(this.service.GetAll(query));
        }
        [HttpPost]
        public IActionResult post(KhoDto dto)
        {
            try
            {
                if (this.service.Add(dto))
                {
                    return ResponseApiCommon.Success(dto);
                }
                else
                {
                    return ResponseApiCommon.Error("Thêm Kho thất bại", CommonHttpStatus.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult put(KhoDto dto)
        {
            try
            {
                var user = this.service.GetById(dto.Id);
                if (user != null)
                {
                    if (this.service.Update(dto))
                    {
                        return ResponseApiCommon.Success(dto, "Cập nhập Kho thành công");
                    }
                    else
                    {
                        return ResponseApiCommon.Error("Cập nhật Kho thất bại", CommonHttpStatus.InternalServerError);
                    }
                }
                return ResponseApiCommon.Error("Kho Id không tồn tại", CommonHttpStatus.NotFound);
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
                if (this.service.GetById(id) != null)
                {
                    if (this.service.softDelete(id))
                        return ResponseApiCommon.Success(id);
                    else
                        return ResponseApiCommon.Error("Xóa Kho thất bại", CommonHttpStatus.InternalServerError);
                }
                return ResponseApiCommon.Error("Kho Id không tồn tại", CommonHttpStatus.NotFound);
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message, CommonHttpStatus.InternalServerError);
            }
        }
        [HttpGet(":id")]
        public IActionResult getById(Guid id)
        {
            try
            {
                var user = this.service.GetById(id);
                if (user != null)
                    return ResponseApiCommon.Success(user);
                else
                    throw new CommonException("Id Kho không tồn tại", CommonHttpStatus.BadRequest);
            }
            catch (CommonException ex)
            {
                return ResponseApiCommon.Error(ex.Message, ex.StatusCode);
            }
        }
    }
}
