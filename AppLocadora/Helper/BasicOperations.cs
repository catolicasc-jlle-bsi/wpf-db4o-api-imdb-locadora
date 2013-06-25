using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Db4objects.Db4o.Config;
using AppLocadora.Model;

namespace AppLocadora.Helper
{
    public class BasicOperations
    {
        public IObjectContainer _database = Session.Current.Database;

        public void Save(object x)
        {
            try
            {
                _database.Store(x);
                _database.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(object x)
        {
            try
            {
                _database.Delete(x);
                _database.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Single<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).SingleOrDefault<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> SelectAll<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).AsEnumerable<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T First<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).FirstOrDefault<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Last<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).LastOrDefault<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        public IEnumerable<T> SelectParamsEspecific<T>(IObjectContainer db)
        {
            IQueryable<T> query = db.AsQueryable<T>();
            return (from q in query
                    where q.
                    select q).AsEnumerable<T>();
        }*/
    }
}
