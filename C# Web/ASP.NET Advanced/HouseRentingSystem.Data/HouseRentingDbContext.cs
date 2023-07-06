using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data
{
    public class HouseRentingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
            : base(options)
        {
        }
    }
}