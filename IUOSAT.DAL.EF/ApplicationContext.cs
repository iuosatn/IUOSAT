using IUOSAT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
