using System;
using Microsoft.EntityFrameworkCore;
using CodeFirstmodel.Models;

namespace CodeFirstmodel
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            db.Database.EnsureCreated();

        }
    }
}
