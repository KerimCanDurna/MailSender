using MailSender.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Repository.Configuration
{
    internal class SendedMailConfiguration : IEntityTypeConfiguration<SendedMail>
    {
        public void Configure(EntityTypeBuilder<SendedMail> builder)
        {
            //  ENTİTYLER ÜZERİNDE BİR OYNAMA YAPILACAKSA FLUENT APİ İLE CONFİG DOSYALARI İÇİNDE YAPIYORUZ Kİ ENTİTY SINIFLARIMIZ TEMİZ KALSIN 

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MailSubject).IsRequired().HasMaxLength(40);

            builder.ToTable("SendedMails");
            builder.HasMany(x => x.emailAdresses).WithMany(x => x.sendedMails);
        }
    }
}
