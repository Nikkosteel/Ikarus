using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFlotillas.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ProjectFlotillas.Data.EntityFramework
{
   

    public class EntityFrameworkService : IDataRepository, IDisposable
    {

        ProjectFlotillasDatabase _connection;

        /// <summary>
        /// Database Context
        /// </summary>
        public ProjectFlotillasDatabase dbConnection
        {
            get { return _connection; }
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void CommitTransaction(Boolean closeSession)
        {
            dbConnection.SaveChanges();
        }

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void RollbackTransaction(Boolean closeSession)
        {

        }

        public void Save(object entity) { }
        public void CreateSession() 
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectFlotillasDatabase, Configuration>()); 

            _connection = new ProjectFlotillasDatabase(); 
        }
        public void BeginTransaction() { }

        public void CloseSession() { }

        /// <summary>
        /// Dispose of connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
