using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitTestWithFakeEF.DataModels.Migrations;

namespace UnitTestWithFakeEF.DataModels
{

    public interface IDataContext
    {
        //From EH When Adding new Tables, please include in TestContent

        DbSet<Album> Albums { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Track> Tracks { get; set; }
        

        //From EH When Adding new Tables, please include in TestContent

        #region Stored Procedures

        #endregion


        #region Methods
        void Dispose();
        //void Dispose(bool disposing);
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        bool Equals(object obj);
        int GetHashCode();
        Type GetType();
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        //void OnModelCreating(DbModelBuilder modelBuilder);
        int SaveChanges();

        //int SaveChanges(object userName);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        //bool ShouldValidateEntity(DbEntityEntry entityEntry);
        string ToString();
        //DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
        void SetModified(object entity);
        void SetDeleted(object entity);

        #endregion

    }
    
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("name=DataContext")
        {

        }

        public void SetInitializer(bool doCodeFirstUpdate = false)
        {
            if (Database.Exists() && doCodeFirstUpdate)
            {
                Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion
                        <DataContext, Configuration>());
            }
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public virtual void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                        
        }
    }
}

