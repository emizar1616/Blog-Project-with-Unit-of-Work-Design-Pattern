using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.DataAccess.Identity;
using Wissen.Istka.BlogProject.App.Entity.Entities;

namespace Wissen.Istka.BlogProject.App.DataAccess.Contexts
{
    public class BlogDbContext : IdentityDbContext<AppUser,AppRole, int>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API Validation
            builder.Entity<Article>().Property("Title").IsRequired().HasMaxLength(200);
            builder.Entity<Article>().Property("Summary").IsRequired().HasMaxLength(500);
            builder.Entity<Category>().Property("Name").IsRequired().HasMaxLength(100);
            builder.Entity<Tag>().Property("Content").IsRequired().HasMaxLength(20);
            builder.Entity<Comment>().Property("Content").IsRequired();

            //Seed Data

            builder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "C#.Net Core Programming", Description = "C#.Net Introduction" },
                new Category() { Id = 2, Name = "Entity Framework Core", Description = "Entity Framework Core ile ORM Teknolojileri" },
                new Category() { Id = 3, Name = "ASP.net Core MVC", Description = "Asp.net core mvc ile web programlama" }
                );
            builder.Entity<Article>().HasData(
                new Article() { Id = 1, Title = "C#Net Core Introduction", Summary = "Visual Studio.net ortamında C#.New Core ile temel seviyeden (veri türleri , değişkenler , if-else , döngüler , diziler) ileri seviyeye (nesneye dayalı programlama-oop , collections , generic collections , interfaces , linq) eğitim programı ...", Content = "Visual Studio.net ortamında C#.New Core ile temel seviyeden (veri türleri , değişkenler , if-else , döngüler , diziler) ileri seviyeye (nesneye dayalı programlama-oop , collections , generic collections , interfaces , linq) eğitim programı ...", CategoryId = 1, UserId = 1, PictureUrl = "~/themes/images/7.jpg" },
                new Article() { Id = 2, Title = "Entity Framework Core ile ORM", Summary = "Visual Studio.net ortamında Entity Framework Core ORM teknolojisini kullanarak veritabanı varlıklarının nesnel olarak yazılım tarafına aktarılması ve yönetilmesi...", Content = "Visual Studio.net ortamında Entity Framework Core ORM teknolojisini kullanarak veritabanı varlıklarının nesnel olarak yazılım tarafına aktarılması ve yönetilmesini gösteren eğitim programı", CategoryId = 2, UserId = 2, PictureUrl = "~/themes/images/6.jpg" },
                new Article() { Id = 3, Title = "Asp.net Core MVC ile Web Programlama", Summary = "Visual Studio.new ortamında Asp.Net Core MVC ile temel düzeyden ileri seviyeye web programlama eğitimi , Asp.net Resfull API's", Content = "Visual Studio.new ortamında Asp.Net Core MVC ile temel düzeyden ileri seviyeye web programlama eğitimi , Asp.net Resfull API's", CategoryId = 3, UserId = 1, PictureUrl = "~/themes/images/2.jpg" }
                );

            base.OnModelCreating(builder);
        }
    }
}
