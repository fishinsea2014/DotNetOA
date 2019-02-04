using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.QA.IDal
{
    /// <summary>
    /// Abstract common methods for all DAL access
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T> where T:class, new() //T must be a class and have a construction method without params.
    {
        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambda">This is a specification design pattern</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);

        int DeteachEntities(params T[] entities);
        
        
    }
}
