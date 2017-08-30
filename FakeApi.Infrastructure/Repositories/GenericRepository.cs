using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FakeApi.Infrastructure.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<T> collection;

        public GenericRepository() 
            : this("~/App_Data/FakeApi.db")
        {

        }

        public GenericRepository(string connectionString)
        {
            db = new LiteDatabase(connectionString);
            collection = db.GetCollection<T>(typeof(T).Name);
        }

        public int Add(T model)
        {
            return collection.Insert(model);
        }

        public bool Update(T model)
        {
            return collection.Update(model);
        }

        public bool Delete(long Id)
        {
            return collection.Delete(Id);
        }

        public int Delete(Expression<Func<T, bool>> where)
        {
            return collection.Delete(where);
        }

        public T Get(long Id)
        {
            return collection.FindById(Id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return collection.FindOne(where);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return collection.Exists(where);
        }

        public bool Any(long Id)
        {
            return collection.Exists(Query.EQ("_id", Id));
        }

        public IEnumerable<T> List()
        {
            return collection.FindAll();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return collection.Find(where);
        }

        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
}
