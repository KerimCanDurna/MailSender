using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Core.Services
{
    public interface IService<T> where T : class
    {
        // .where (x=>x.-- koşul =ture) olanları getirir sonucunu ister listeyebiliriz ister groupby yapabiliriz . Iqueryable çalışmak bize esneklik kazandırıyor
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

    }
}
