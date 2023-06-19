using System;
using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApp.API.Data;

public partial class BookAppDbContext : IdentityDbContext<ApiUser>
{
    public BookAppDbContext()
    {
    }

    public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07BE7E0A56");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC070C83DEC5");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA6C187059").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Name = "User",
                   NormalizedName = "USER",
                   Id = "0d1f348c-3b6d-4ba2-88ea-68e9115555c4"
               },
               new IdentityRole
               {
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",
                   Id = "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7"
               }
           );
        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "9e46c42f-84c5-47b8-aea5-5b292ac363bc",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")

            }, new ApiUser
            {

                Id = "5db797d8-eb31-4d89-a6e3-e21782635fac",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
            
            );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "0d1f348c-3b6d-4ba2-88ea-68e9115555c4",
                   UserId = "5db797d8-eb31-4d89-a6e3-e21782635fac"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "a2a927d3-bfbf-4462-be5c-fbf9f8e219d7",
                   UserId = "9e46c42f-84c5-47b8-aea5-5b292ac363bc"
               }
           );


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
