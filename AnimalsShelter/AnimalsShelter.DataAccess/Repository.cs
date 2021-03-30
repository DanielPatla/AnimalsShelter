﻿using Microsoft.EntityFrameworkCore;
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
        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return _context.SaveChangesAsync();
        }
    }
}
