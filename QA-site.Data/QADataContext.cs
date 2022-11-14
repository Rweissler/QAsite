using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QA_site.Data
{
    public class QADataContext : DbContext
    {
        private string _connectionString;
        public  QADataContext(string connectionString)
          {
            _connectionString = connectionString;
          }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<QuestionTag>()
                .HasKey(qt => new { qt.QuestionID, qt.TagID });

            modelBuilder.Entity<Like>()
               .HasKey(l => new { l.QuestionID, l.UserID });
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<QuestionTag> QuestionTag { get; set; }

     
    }
}
