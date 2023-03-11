using System;
using Microsoft.EntityFrameworkCore;
using CodeFirstmodel.Models;
using System.Collections.Generic;

namespace CodeFirstmodel
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            db.Database.EnsureCreated();

            db.Categories.Add(new Category
            {
                Title = "Sport",
                News = new List<News>
                {
                    new News { Title = "CSKA spechli kupata",
                        Content = "ЦСКА спечели купата на България",
                        Comments = new List<Comment>
                        {
                            new Comment { Author = "Niki", Content = "Bravo momcheta" },
                            new Comment { Author = "Stoyan", Content = "Samo Levski" }
                        }
                    }
                }

            });

            db.SaveChanges();

        }
    }
}
