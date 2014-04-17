﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogProyecto.Models
{
    public class Context : DbContext
    {

            public Context()
                : base("DefaultConnection")
            {
            }

            public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<Entrada> Entradas { get; set; }
    }
}