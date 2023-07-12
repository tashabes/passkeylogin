using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace PasskeyLoginPOC.API.Data;

public partial class PassKeyUsersDbContext : IdentityDbContext<ApiUser>
{
    public PassKeyUsersDbContext()
    {
    }

    public PassKeyUsersDbContext(DbContextOptions<PassKeyUsersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0755882AC0");

            entity.Property(e => e.MachineName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1"
            },
             new IdentityRole
             {
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR",
                 Id = "63a59036-8ab1-443f-ac74-3b475cfab954"
             }
             );

             modelBuilder.Entity<ApiUser>().HasData(
                 new ApiUser
                 {
                     Id = "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4",
                     MachineName = "ETZ_LAPTOP_01",
                     PhoneNumber = "07717133825",
                     Name = "Admin"
                 },

                  new ApiUser
                  {
                      Id = "282c18e6-292f-4fbc-9265-ac6dc91f0171",
                      MachineName = "USER",
                      PhoneNumber = "07717133825",
                      Name = "User"
                  }
            );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "03152af0-a8d8-4278-bb2c-4b7ebe31c6e1",
                UserId = "282c18e6-292f-4fbc-9265-ac6dc91f0171"
            },
             new IdentityUserRole<string>
             {
                 RoleId = "63a59036-8ab1-443f-ac74-3b475cfab954",
                 UserId = "6ddb6ae6-6fe3-46a0-9530-2504eb3a65c4"
             }
            );
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
