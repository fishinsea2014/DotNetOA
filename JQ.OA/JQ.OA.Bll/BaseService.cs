using JQ.OA.DALFactory;
using JQ.QA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public abstract class BaseService<T> where T : class, new()
    {

    
    
        public IDBSession GetCurrentDbSession
        {
            get
            {
                //return new DBSession();
                return DALFactory.DBSessionFactory.CreateDbSession();
            }            
        }

        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount
          , System.Linq.Expressions.Expression<Func<T, bool>> whereLambda
          , System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIdex, pageSize, out toalCount, whereLambda, orderbyLambda, isAsc);
        }


        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return this.GetCurrentDbSession.SaveChange();
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return this.GetCurrentDbSession.SaveChange();
        }

        public T AddEntity (T entity)
        {
            CurrentDal.AddEntity(entity);
            this.GetCurrentDbSession.SaveChange();
            return entity;
        }
    }
}
