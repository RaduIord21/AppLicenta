using AppLicence.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppLicence.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLicence.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AchieveHubContext context;

        protected DbSet<T> dataSet;

        public GenericRepository(AchieveHubContext context)
        {
            this.context = context;
            dataSet = this.context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return dataSet.ToList();
        }

        public T? GetById(int id)
        {
            return dataSet.Find(id);
        }

        public void Update(T obj)
        {
            dataSet.Update(obj);
        }

        public void Delete(T obj)
        {
            dataSet.Remove(obj);
        }

        public IList<T> Get(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>()
            .Where(expression)
            .ToList();
        }

        public void Add(T entity)
        {
            dataSet.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
