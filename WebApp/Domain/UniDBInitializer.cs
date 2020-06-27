using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Domain
{
    public class UniDBInitializer<T> : DropCreateDatabaseAlways<EcommerceDbContext>
    {
        protected override void Seed(EcommerceDbContext context)
        {
            if (!context.Roles.Any())
            {
                var lstRole = new List<Role>
                {
                    new Role{
                        Name="Admin",
                        Description="Admin"
                    },
                    new Role{
                        Name="Manager",
                        Description="Quản lý"
                    },
                    new Role{
                        Name="Employee",
                        Description="Nhân viên"
                    }
                };
                context.Roles.AddRange(lstRole);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        UserName = "Admin",
                        Password = "123",
                        RoleId = context.Roles.Where(x => x.Name.Equals("Admin")).Select(x => x).FirstOrDefault()?.Id ?? 0
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new List<Category> {
                        new Category{
                            Name="Laptop",
                            Description="",
                            Image="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                        },
                        new Category{
                            Name="Laptop 2",
                            Description="",
                            Image="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                        },
                        new Category{
                            Name="Laptop 3",
                            Description="",
                            Image="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                        },
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new List<Product> {
                        new Product
                    {
                        Name = "Laptop 1",
                        Price = 2000,
                        ProductInStock = 100,
                        CategoryId = context.Categories.FirstOrDefault().Id,
                        UrlImage="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                    },
                     new Product
                     {
                         Name = "Laptop 2",
                         Price = 2000,
                         ProductInStock = 100,
                         CategoryId = context.Categories.FirstOrDefault().Id,
                         UrlImage="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                     },
                      new Product
                      {
                          Name = "Laptop 3",
                          Price = 2000,
                          ProductInStock = 100,
                          CategoryId = context.Categories.FirstOrDefault().Id,
                          UrlImage="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                      },
                       new Product
                       {
                           Name = "Laptop 4",
                           Price = 2000,
                           ProductInStock = 100,
                           CategoryId = context.Categories.FirstOrDefault().Id,
                           UrlImage="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                       },
                        new Product
                        {
                            Name = "Laptop 5",
                            Price = 2000,
                            ProductInStock = 100,
                            CategoryId = context.Categories.FirstOrDefault().Id,
                            UrlImage="https://hanoicomputercdn.com/media/product/250_48820_dell_gaming_g3_3590__8_.png"
                        }
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}