﻿using GestiuneApi.Net7.Models;
using GestiuneSaliNET7.Interfaces;
using GestiuneSaliNET7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestiuneSaliNET7.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public ApplicationDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<LabRoomModel> Labs { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }

        public DbSet<RequestModel> Requests { get; set; }

        public DbSet<MaterieModel> Materii { get; set; }

        public DbSet<SerieModel> Serii { get; set; }

    }
}
