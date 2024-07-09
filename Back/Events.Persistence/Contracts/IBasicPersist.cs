using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Contracts
{
    public interface IBasicPersist
    {
        //geral 
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        void DeleteRange<T>(T[] entity) where T:class;
        Task<bool> SaveChangesAsync();
}
}