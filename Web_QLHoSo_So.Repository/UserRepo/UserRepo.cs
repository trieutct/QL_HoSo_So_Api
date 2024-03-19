using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Repository.UserRepo
{
    public class UserRepo:GenericRepository<User>, IUserRepo
    {
        public UserRepo(WebDbContext context) : base(context)
        {

        }
    }
}
