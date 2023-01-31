using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Api.Models
{
    public class ExchangeDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }

        private string _conn = "";
        public ExchangeDb(string conn)
        {
            _conn = conn;
        }

        public ExchangeDb(DbContextOptions<ExchangeDb> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>().HasData(new Coin
                {
                    Id = 1,
                    Name = "Bitcoin",
                    ShortName = "btc",
                    IsActive  = true,
                    Price = 500000,
                    CreatedDate = DateTime.Now
                }
            );

             modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 1,
                    NameSurname = "Test User",
                    Email = "ksksertac@gmail.com",
                    Phone = "5079144614",
                    DeviceId = "26FB1AB0CA8483866",
                    Password = "26FB1AB0CA8483866F03CA66E2018B0685F3E1E84CACA77B3F5643AE799D9EB4",
                    MinInstructionAmount = 100,
                    MaxInstructionAmount = 20000,
                    StartOfInstructionDay = 1,
                    EndOfInstructionDay = 28,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<NotificationTemplate>().HasData(new NotificationTemplate
                {
                    Id = 1,
                    Type  = 1,
                    Name = "InstructionCompleteEmail",
                    Description = "Talimat işlemi tamamlanınca gönderilir",
                    TemplateTitle = "Talimatınız alındı",
                    TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                    IsActive  = true,
                    CreatedDate = DateTime.Now
                },
                new NotificationTemplate
                {
                    Id = 2,
                    Type  = 2,
                    Name = "InstructionCompleteSms",
                    Description = "Talimat işlemi tamamlanınca gönderilir",
                    TemplateTitle = "Talimatınız alındı",
                    TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                    IsActive  = true,
                    CreatedDate = DateTime.Now
                },
                new NotificationTemplate
                {
                    Id = 3,
                    Type  = 3,
                    Name = "InstructionCompletePush",
                    Description = "Talimat işlemi tamamlanınca gönderilir",
                    TemplateTitle = "Talimatınız alındı",
                    TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                    IsActive  = true,
                    CreatedDate = DateTime.Now
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}