using AutoMapper;
using MailSender.Core.DTOs;
using MailSender.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<SendedMail,SendedMailDto>().ReverseMap();
            CreateMap<EmailAdress, EMailAdressDto>().ReverseMap();
            CreateMap<MailDetail, MailDetailDto>().ReverseMap();
            CreateMap<SendedMail, SendedMailWithEmailsDto>().ReverseMap();

        }

    }
}
