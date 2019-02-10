﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class WarriorsContext : DbContext
    {
        public WarriorsContext() : base("DBConnection")
        {
        }
        public DbSet<Warrior> Warriors { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}