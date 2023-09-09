using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // .where (x=>x.-- koşul =ture) olanları getirir sonucunu ister listeyebiliriz ister groupby yapabiliriz . Iqueryable çalışmak bize esneklik kazandırıyor
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
   
        void Update(T entity);
        void Remove(T entity);


    }
}
