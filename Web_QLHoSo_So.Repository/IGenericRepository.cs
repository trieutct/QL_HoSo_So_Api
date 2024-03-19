using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetbyId(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        bool softDelete(Guid id);
        T FindOne(Expression<Func<T, bool>> predicate);
    }
}
