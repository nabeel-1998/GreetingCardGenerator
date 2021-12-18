using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GreetingCardGenerator.Core;

namespace GreetingCardGenerator.Data
{
    public class GreetingCardGeneratorDbContext : DbContext
    {
        public GreetingCardGeneratorDbContext(DbContextOptions<GreetingCardGeneratorDbContext> options):base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Greetings> Greetings { get; set; }
        public DbSet<Greeting_Draft> GreetingDrafts { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Template_Draft> Template_Drafts { get; set; }
        public DbSet<Sales> Sales { get; set; }


    }
}
