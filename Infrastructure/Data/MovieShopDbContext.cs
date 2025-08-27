using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) 
        {

        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Cast> Casts => Set<Cast>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
        public DbSet<MovieCast> MovieCasts => Set<MovieCast>();
        public DbSet<Trailer> Trailers => Set<Trailer>();
        public DbSet<Favorite> Favorites => Set<Favorite>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<MovieCast>().HasKey(x => new { x.MovieId, x.CastId });
            modelBuilder.Entity<Favorite>().HasKey(x => new { x.MovieId, x.UserId });
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<Review>().HasKey(x => new { x.MovieId, x.UserId });
            modelBuilder.Entity<Purchase>().HasKey(x => new { x.MovieId, x.UserId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(x => x.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(x => x.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(x => x.CastId);

            modelBuilder.Entity<Trailer>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.Trailers)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Favorite>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Favorite>()
                .HasOne(x => x.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Purchase>()
                .HasOne(x => x.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Purchase>()
                .HasOne(x => x.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(x => x.RoleId);
        }

    }
}
