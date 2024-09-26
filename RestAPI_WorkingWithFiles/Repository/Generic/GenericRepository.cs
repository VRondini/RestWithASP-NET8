using Microsoft.EntityFrameworkCore;
using Restapi_WorkingWithFiles.Model;
using Restapi_WorkingWithFiles.Model.Base;
using Restapi_WorkingWithFiles.Model.Context;
using static System.Reflection.Metadata.BlobBuilder;

namespace Restapi_WorkingWithFiles.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlServerContext _context;
        private DbSet<T> dataset;

        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(int id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public void Delete(int Id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(Id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exists(int id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
