﻿using Microsoft.EntityFrameworkCore;
using OneToOne.DataAccess;

namespace OneToOne.Server.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            builder.Services.AddDbContext<MainContext>(options =>
              options.UseSqlServer(connectionString));
        }
    }
}