using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Entities;
using Web_QLHoSo_So.Repository.UserRepo;

namespace Web_QLHoSo_So.Repository.KhoRepo
{
    public class KhoRepo : GenericRepository<Kho>, IKhoRepo
    {
        public KhoRepo(WebDbContext context) : base(context)
        {

        }
    }
}
