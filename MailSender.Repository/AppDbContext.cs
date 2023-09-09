using MailSender.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        { 

        }

        public DbSet<SendedMail> SendedMails { get; set; }
        public DbSet<EmailAdress> EmailAdresses { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       // bu fonksiyonla Iconfiguration  interfaceini kullanan tüm assemblyleri çağırırız
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
