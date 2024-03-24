using CommonHelper;
using System.Linq;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Api.seed
{
    public static class SeedData
    {
        public static void Seed(WebDbContext dbContext)
        {
            var user1 = new User { Id = Guid.NewGuid(), Email = "trieu@gmail.com", Password = Helper.hashPassword("t12345678"), Birthday = "29/07/2002", FullName = "Trịnh Công Triệu", Phone = "0941590356", CreateAt = DateTime.Now };
            if(!dbContext.Users.Any())
            {
                dbContext.Users.Add(user1);
                dbContext.SaveChanges();
            }    
        }
    }
}
