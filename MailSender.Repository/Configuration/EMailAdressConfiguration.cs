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
    internal class EMailAdressConfiguration : IEntityTypeConfiguration<EmailAdress>
    {
        public void Configure(EntityTypeBuilder<EmailAdress> builder)
        {
            //  ENTİTYLER ÜZERİNDE BİR OYNAMA YAPILACAKSA FLUENT APİ İLE CONFİG DOSYALARI İÇİNDE YAPIYORUZ Kİ ENTİTY SINIFLARIMIZ TEMİZ KALSIN 

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
          
            builder.ToTable("EmailAdress");
            builder.HasMany(x => x.sendedMails ).WithMany(x => x.emailAdresses);
        }
    }
}
