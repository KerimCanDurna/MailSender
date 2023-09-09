using MailSender.Core.DTOs;
using MailSender.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Services
{
    public interface ISendedMailService :IService<SendedMail>
    {

        public Task<CustomResponseDto<List<SendedMailWithEmailsDto>>> GetSendedMailWithEmailAdress();
    }
}
