using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectAPI.Models;


namespace ProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            using (var db = new SchoolContext())
            {
                // Console.WriteLine(db.DbPath);
                db.Add(new School { name = "KV Baad" });
                db.SaveChanges();

                var kvBaad = db.Schools.OrderBy(b => b.id)
                .Last();

                Console.WriteLine(kvBaad.name);

                kvBaad.Students.Add(new Student { name = "Kevin" });
                db.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
