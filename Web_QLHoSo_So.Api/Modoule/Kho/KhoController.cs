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
        public IActionResult post(KhoVM dto)
        {
            var Khodto = new KhoDto()
            {
                Id=Guid.NewGuid(),
                Description=dto.Description,
                Location    =dto.Location,
                MaKho=dto.MaKho,
                Name=dto.Name,
                Note=dto.Note,
            };
            try
            {
                if(this.service.getALL_NoQuey().Where(x=>x.Name.Equals(dto.Name) || x.MaKho.Equals(dto.MaKho)).FirstOrDefault()!=null)
                {
                    return ResponseApiCommon.Error("Kho đã tồn tại", CommonHttpStatus.BadRequest);
                }
                if (this.service.Add(Khodto))
                {
                    return ResponseApiCommon.Success(dto, "Tạo mới thành công kho");
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

        [HttpPatch("{id}")]
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
        [HttpDelete("softDelete/{id}")]
        //[HasPermision(Permission.Update)]
        public IActionResult softdelete(Guid id)
        {
            try
            {
                if (this.service.GetById(id) != null)
                {
                    if (this.service.softDelete(id))
                        return ResponseApiCommon.Success(id, "Xóa mềm thành công kho: "+id);
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
        [HttpGet("{id}")]
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
        [HttpPost("softDeleteMutiple")]
        //[HasPermision(Permission.Update)]
        public IActionResult softDeleteMutiple(List<Guid> ids)
        {
            try
            {
                int successCount = 0;
                foreach (var id in ids)
                {
                    if (this.service.softDelete(id))
                    {
                        successCount++;
                    }
                }
                if (successCount > 0)
                {
                    return ResponseApiCommon.Success(ids, "Xóa mềm thành công " + successCount + " kho.");
                }
                else
                {
                    return ResponseApiCommon.Error("Không có kho nào được xóa mềm.", CommonHttpStatus.NotFound);
                }
            }
            catch (Exception ex)
            {
                return ResponseApiCommon.Error(ex.Message, CommonHttpStatus.InternalServerError);
            }
        }
    }
}
