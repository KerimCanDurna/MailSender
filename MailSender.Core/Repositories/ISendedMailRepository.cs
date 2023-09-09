using MailSender.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Repositories
{
    public interface ISendedMailRepository : IGenericRepository<SendedMail>
    {
        Task<List<SendedMail>> GetSendedMailWithEmailAdress();

    }
}
