using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectAPI.Data;


namespace ProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MovieContext())
            {
                // Console.WriteLine("DB Path: " + db.DbPath);
                // db.Add(new User { name = "Alex", surname = "Tenita", email = "alex@deepstash.com", password = "1234", username = "alex" });
                // db.Add(new Movie { title = "Revenant", release_date = "12/12/2020" });
                // db.Add(new Movie { title = "Lucy", release_date = "09/09/2019" });
                // db.Add(new Movie { title = "Transformers", release_date = "06/09/2017" });
                // db.SaveChanges();

                // var lastMovie = db.Movies.OrderBy(b => b.id)
                // .Last();

                // Console.WriteLine(lastMovie.title);

                // lastMovie.Participants.Add(new Participant { name = "Kevin", surname = "Durant", date_of_birth = "03/02/1980" });
                // lastMovie.Participants.Add(new Participant { name = "Bob", surname = "Marley", date_of_birth = "22/04/1973" });

                // db.SaveChanges();
                // var firstUser = db.Users.OrderBy(b => b.id).First();
                // var lastMovie = db.Movies.OrderBy(b => b.id)
                // .Last();
                // var firstMovie = db.Movies.OrderBy(b => b.id).First();
                // firstUser.Movies.Add(lastMovie);
                // firstUser.Movies.Add(firstMovie);
                // Console.WriteLine(" == last and first movie:" + lastMovie.ToString() + " \n\n" + firstMovie.ToString());
                // db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.UseKestrel(options =>
                    // {
                    //     options.Listen(System.Net.IPAddress.Loopback, 5080); // for HTTP
                    //     options.Listen(System.Net.IPAddress.Loopback, 5443); // for HTTPS
                    // });
                    webBuilder.UseStartup<Startup>();
                });
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         // CreateHostBuilder(args).Build().Run();
    //         using (var db = new SchoolContext())
    //         {
    //             // Console.WriteLine(db.DbPath);
    //             db.Add(new School { name = "KV Baad" });
    //             db.SaveChanges();

    //             var kvBaad = db.Schools.OrderBy(b => b.id)
    //             .Last();

    //             Console.WriteLine(kvBaad.name);

    //             kvBaad.Students.Add(new Student { name = "Kevin" });
    //             db.SaveChanges();
    //         }
    //     }

    //     public static IHostBuilder CreateHostBuilder(string[] args) =>
    //         Host.CreateDefaultBuilder(args)
    //             .ConfigureWebHostDefaults(webBuilder =>
    //             {
    //                 webBuilder.UseStartup<Startup>();
    //             });
    // }
}
