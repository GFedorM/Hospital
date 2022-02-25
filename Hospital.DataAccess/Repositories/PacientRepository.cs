namespace Hospital.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Hospital.DataAccess.Repositories.Abstraction;
    using Hospital.Domain;
    using NHibernate;

    public class PacientRepository : IRepository<Pacient>
    {
        public Pacient Get(ISession session, int id) =>
            session?.Get<Pacient>(id);

        public Pacient Find(ISession session, Expression<Func<Pacient, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Pacient> GetAll(ISession session) =>
            session?.Query<Pacient>();

        public IQueryable<Pacient> Filter(ISession session, Expression<Func<Pacient, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
