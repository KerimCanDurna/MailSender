using MailSender.Core.UnitOFWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }
    }
}
