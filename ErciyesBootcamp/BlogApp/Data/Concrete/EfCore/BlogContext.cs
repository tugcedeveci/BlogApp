using BlogApp.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class BlogContext:DbContext{

        //BlogContext içine BlogContext uygulayarak veritabanı ile eş zamanlı olmasını sağlıyoruz

        //normalde Program.cs de yaptığımız veritabanı ilişkilendirmesini burada yapmış olduk

        public BlogContext(DbContextOptions<BlogContext>options) : base(options){}

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
    }
}

//Db setleri oluşturduk yani Entityleri tablo haline getirdik