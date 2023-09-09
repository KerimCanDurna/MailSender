using MailSender.Core.Model;
using MailSender.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Repository.Repositories
{
    public class SendedMailRepostory : GenericRepository<SendedMail>, ISendedMailRepository
    {
        public SendedMailRepostory(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<SendedMail>> GetSendedMailWithEmailAdress()
        {
           return await _appDbContext.SendedMails.Include(x=> x.emailAdresses).ToListAsync();

            //return await _appDbContext.SendedMails.Include(x => x.emailAdresses).Where(x => x.Id == sendedMailId).SingleAsync();
        }
    }
}
