using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Dto;
using Web_QLHoSo_So.Model.Entities;
using Web_QLHoSo_So.Service.common;

namespace Web_QLHoSo_So.Service.UserService
{
    public interface IUserService
    {
        PageListResultBO<UserDto> GetAll(UserQuery? query);
        UserDto GetById(Guid id);
        bool Add(UserDto OrderDto);
        bool Update(UserDto OrderDto);
        bool Delete(Guid id);
        bool softDelete(Guid id);
        bool checkUser(string username);
    }
}
