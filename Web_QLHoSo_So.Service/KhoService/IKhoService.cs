using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Service.common;

namespace Web_QLHoSo_So.Service.KhoService
{
    public interface IKhoService
    {
        PageListResultBO<KhoDto> GetAll(KhoQuery? query);
        KhoDto GetById(Guid id);
        bool Add(KhoDto OrderDto);
        bool Update(KhoDto OrderDto);
        bool Delete(Guid id);
        bool softDelete(Guid id);
    }
}
