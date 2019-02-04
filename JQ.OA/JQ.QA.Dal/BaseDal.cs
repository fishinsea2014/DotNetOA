using JQ.QA.IDal;
using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JQ.QA.Dal
{
    public class BaseDal<T> where T:class, new()    
    {

        //JasonExerEntities Db = new JasonExerEntities();
        DbContext Db = DbContextFactory.CreateDbContext();
        /// <summary>
        /// Query users
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            //throw new NotImplementedException();
            //Db.Tes
            return Db.Set<T>().Where<T>(whereLambda);
        }

        
        /// <summary>
        /// Paging
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIdex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc">true: increase, false:decrease </param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            //TODO: modify isAsc in database to bool
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc) //When arising
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);
            }
            else //When descending
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;

        }
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool Update(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }

        

        public int DeteachEntities (params T[] entities)
        {
            foreach (var entity in entities)
            {
                Db.Entry(entity).State = System.Data.Entity.EntityState.Detached;
            }

            return entities.Count();
        }
    }
}
