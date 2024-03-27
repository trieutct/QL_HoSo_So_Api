using CommonHelper;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Api.seed
{
    public static class SeedData
    {
        public static void Seed(WebDbContext dbContext)
        {
            if(!dbContext.Users.Any())
            {
                var user1 = new User { Id = Guid.NewGuid(), Email = "trieu@gmail.com", Password = Helper.hashPassword("t12345678"), Birthday = "29/07/2002", FullName = "Trịnh Công Triệu", Phone = "0941590356", CreateAt = DateTime.Now };
                dbContext.Users.Add(user1);
                dbContext.SaveChanges();
            }   
            if(!dbContext.Khos.Any())
            {
                List<Kho> danhSachKho = new List<Kho>()
                { 
                    new Kho() { MaKho = "KHO001", Name = "Kho 1", Location = "Location 1", Description = "Description 1", Note = "Note 1",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO002", Name = "Kho 2", Location = "Location 2", Description = "Description 2", Note = "Note 2",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO003", Name = "Kho 3", Location = "Location 3", Description = "Description 3", Note = "Note 3",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO004", Name = "Kho 4", Location = "Location 4", Description = "Description 4", Note = "Note 4",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO005", Name = "Kho 5", Location = "Location 5", Description = "Description 5", Note = "Note 5",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO006", Name = "Kho 6", Location = "Location 6", Description = "Description 6", Note = "Note 6",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO007", Name = "Kho 7", Location = "Location 7", Description = "Description 7", Note = "Note 7",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO008", Name = "Kho 8", Location = "Location 8", Description = "Description 8", Note = "Note 8",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO009", Name = "Kho 9", Location = "Location 9", Description = "Description 9", Note = "Note 9",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO010", Name = "Kho 10", Location = "Location 10", Description = "Description 10", Note = "Note 10",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO011", Name = "Kho 11", Location = "Location 11", Description = "Description 11", Note = "Note 11",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO012", Name = "Kho 12", Location = "Location 12", Description = "Description 12", Note = "Note 12",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO013", Name = "Kho 13", Location = "Location 13", Description = "Description 13", Note = "Note 13",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO014", Name = "Kho 14", Location = "Location 14", Description = "Description 14", Note = "Note 14",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO015", Name = "Kho 15", Location = "Location 15", Description = "Description 15", Note = "Note 15",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO016", Name = "Kho 16", Location = "Location 16", Description = "Description 16", Note = "Note 16",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO017", Name = "Kho 17", Location = "Location 17", Description = "Description 17", Note = "Note 17",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO018", Name = "Kho 18", Location = "Location 18", Description = "Description 18", Note = "Note 18",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO019", Name = "Kho 19", Location = "Location 19", Description = "Description 19", Note = "Note 19",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO020", Name = "Kho 20", Location = "Location 20", Description = "Description 20", Note = "Note 20",CreateAt=DateTime.Now },
                    new Kho() { MaKho = "KHO021", Name = "Kho 21", Location = "Location 21", Description = "Description 21", Note = "Note 21", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO022", Name = "Kho 22", Location = "Location 22", Description = "Description 22", Note = "Note 22", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO023", Name = "Kho 23", Location = "Location 23", Description = "Description 23", Note = "Note 23", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO024", Name = "Kho 24", Location = "Location 24", Description = "Description 24", Note = "Note 24", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO025", Name = "Kho 25", Location = "Location 25", Description = "Description 25", Note = "Note 25", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO026", Name = "Kho 26", Location = "Location 26", Description = "Description 26", Note = "Note 26", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO027", Name = "Kho 27", Location = "Location 27", Description = "Description 27", Note = "Note 27", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO028", Name = "Kho 28", Location = "Location 28", Description = "Description 28", Note = "Note 28", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO029", Name = "Kho 29", Location = "Location 29", Description = "Description 29", Note = "Note 29", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO030", Name = "Kho 30", Location = "Location 30", Description = "Description 30", Note = "Note 30", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO031", Name = "Kho 31", Location = "Location 31", Description = "Description 31", Note = "Note 31", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO032", Name = "Kho 32", Location = "Location 32", Description = "Description 32", Note = "Note 32", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO033", Name = "Kho 33", Location = "Location 33", Description = "Description 33", Note = "Note 33", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO034", Name = "Kho 34", Location = "Location 34", Description = "Description 34", Note = "Note 34", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO035", Name = "Kho 35", Location = "Location 35", Description = "Description 35", Note = "Note 35", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO036", Name = "Kho 36", Location = "Location 36", Description = "Description 36", Note = "Note 36", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO037", Name = "Kho 37", Location = "Location 37", Description = "Description 37", Note = "Note 37", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO038", Name = "Kho 38", Location = "Location 38", Description = "Description 38", Note = "Note 38", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO039", Name = "Kho 39", Location = "Location 39", Description = "Description 39", Note = "Note 39", CreateAt = DateTime.Now },
                    new Kho() { MaKho = "KHO040", Name = "Kho 40", Location = "Location 40", Description = "Description 40", Note = "Note 40", CreateAt = DateTime.Now }
                };
                dbContext.Khos.AddRange(danhSachKho);
                dbContext.SaveChanges();
            }    
        }
    }
}
