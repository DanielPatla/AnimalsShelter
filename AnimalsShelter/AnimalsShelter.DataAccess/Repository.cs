using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsShelter.DataAccess.Entities;

namespace AnimalsShelter.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AnimalsShelterStorageContext _context;
        private DbSet<T> entities;

        public Repository(AnimalsShelterStorageContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.SaveChanges();
        }
    }
}
