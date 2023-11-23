using BlogApp.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData{

        public static void TestVeriliniDoldur(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){

                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }

                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                    new Entitiy.Tag {Text = "web programlama", Url ="web-programlama" , Color = TagColors.success},
                    new Entitiy.Tag {Text = "Unity", Url ="unity-game", Color = TagColors.warning},
                    new Entitiy.Tag {Text = "php", Url ="php-dersleri", Color = TagColors.primary},
                    new Entitiy.Tag {Text = "sql", Url ="sql-dersleri", Color = TagColors.info}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                    new Entitiy.User{UserName = "tugce", Name="Tuğçe Deveci", Email="info@tugce.com", Password="123456", Image = "p1.jpeg"},
                    new Entitiy.User{UserName = "beyza", Name="Beyza", Email="info@beyza.com", Password="123456", Image = "p2.jpeg"}
                    
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                    new Post{
                        Title = "Asp.net core",
                        Content="Asp.net core dersleri güzeldir",
                        Url ="aspnet-core",
                        IsActive = true,
                        Image = "1.jpeg",
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1,
                        Comments = new List<Comment>{
                            new Comment {Text = "Güzel bir post tebrikler", PublishedOn = new DateTime(),UserId = 1},
                            new Comment {Text = "Güzel bir içerik", PublishedOn = new DateTime(),UserId = 2},
                        }
                    },
                    new Post{
                        Title = "Unity Game",
                        Content="Unity ile oyun geliştirebilirsiniz",
                        Url ="unity-game",
                        IsActive = true,
                        Image = "2.jpeg",
                        PublishedOn = DateTime.Now.AddDays(-20),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1,
                    },
                    new Post{
                        Title = "Php",
                        Content="Php ile web geliştir.",
                        Url ="php-dersleri",
                        IsActive = true,
                        Image = "3.jpeg",
                        PublishedOn = DateTime.Now.AddDays(-15),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1
                    }

                    );
                    context.SaveChanges();
                }
                

            }

        }
    }
}