using System;
using System.Collections.Generic;
using System.Linq;
using WebAppVet.Interface;

namespace ClientPatientManagement.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> List();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
