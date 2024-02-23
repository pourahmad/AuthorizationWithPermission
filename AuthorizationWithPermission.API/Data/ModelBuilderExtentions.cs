
using AuthorizationWithPermission.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace AuthorizationWithPermission.API.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder builder)
        {

            //--------------------  User Data Initial ------------

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    UserName = "nasser",
                    NormalizedUserName = "NASSER",
                    Email = "nasserpourahmad@gmail.com",
                    NormalizedEmail = "NASSERPOURAHMAD@GMAIL.COM",
                    PasswordHash = HashPassword("Nasser@1234")
                },
                new IdentityUser
                {
                    UserName = "pourahmad",
                    NormalizedUserName = "POURAHMAD",
                    Email = "pourahmad@gmail.com",
                    NormalizedEmail = "POURAHMAD@GMAIL.COM",
                    PasswordHash = HashPassword("Pourahmad@1234")
                });

            //--------------------  Permission Data Initial ------------

            List<Permission> permissions = new(){
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1000,
                Name= "GetAllOredrList",
                Title= "دریافت لیست کلیه سفارشات",
                Type= "Get",
                IsActived= true
                },
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1010,
                Name= "GetOrderById",
                Title= "دریافت سفارش با شناسه",
                Type= "Get",
                IsActived= true
                },
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1020,
                Name= "AddOrder",
                Title= "ایجاد سفارش جدید",
                Type= "Post",
                IsActived= true
                },
                new Permission {Id = Guid.NewGuid(),
                Code= 1030,
                Name= "UpdateOrder",
                Title= "ویرایش سفارش موجود",
                Type= "Put",
                IsActived= true
                },
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1040,
                Name= "DeleteOrderById",
                Title= "حذف سفارش موجود",
                Type= "Delete",
                IsActived= true
                },
                new Permission {
                Id = Guid.NewGuid(),
                Code= 1060,
                Name= "GetAllProductList",
                Title= "دریافت لیست کلیه محصولات",
                Type= "Get",
                IsActived= true
                },
                new Permission {
                Id = Guid.NewGuid(),
                Code= 1070,
                Name= "GetProductById",
                Title= "دریافت محصول با شناسه",
                Type= "Get",
                IsActived= true
                },
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1080,
                Name= "AddProduct",
                Title= "ایجاد محصول جدید",
                Type= "Post",
                IsActived= true
                },
                new Permission {
                Id = Guid.NewGuid(),
                Code= 1090,
                Name= "UpdateProduct",
                Title= "ویرایش محصول موجود",
                Type= "Put",
                IsActived= true
                },
                new Permission {
                Id= Guid.NewGuid(),
                Code= 1050,
                Name= "DeleteProductById",
                Title= "حذف محصول موجود",
                Type= "Delete",
                IsActived= true
                }
                };

            builder.Entity<Permission>().HasData(permissions);

            //--------------------  Product Data Initial ------------
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();
            Guid guid5 = Guid.NewGuid();
            Guid guid6 = Guid.NewGuid();

            List<Product> products = new()
            {
                new Product { Id = guid1, Name = "مانیتور سامسونگ مدل LS19A330NH-M سایز 19 اینچ" },
                new Product { Id = guid2, Name = "مچ بند هوشمند شیائومی مدل Mi Band 8 گلوبال" },
                new Product { Id = guid3, Name = "ساعت هوشمند گارمین مدل MARQ ADVENTURER Leather Band" },
                new Product { Id = guid4, Name = "ساعت هوشمند موبووی مدل TicWatch Pro 5 Elite Edition Leather Version" },
                new Product { Id = guid5, Name = "گوشی موبایل تی سی ال مدل 40 SE دو سیم کارت ظرفیت 256 گیگابایت و رم 6 گیگابایت" },
                new Product { Id = guid6, Name = "گوشی موبایل تی سی ال مدل 40R 5G دو سیم کارت ظرفیت 128 گیگابایت و رم 4 گیگابایت" }
            };

            builder.Entity<Product>().HasData(products);

            //--------------------  Order Data Initial ------------
            Guid orderGuid1 = Guid.NewGuid();
            Guid orderGuid2 = Guid.NewGuid();
            Guid orderGuid3 = Guid.NewGuid();

            List<Order> orders = new()
            {
                new Order{ Id = orderGuid1, CreatedDate = DateTime.Now },
                new Order{ Id = orderGuid2, CreatedDate = DateTime.Now },
                new Order{ Id = orderGuid3, CreatedDate = DateTime.Now }
            };

            builder.Entity<Order>().HasData(orders);
        }

        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            return passwordHasher.HashPassword(null, password);
        }
    }
}
