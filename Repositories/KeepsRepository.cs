using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)  
        {
            _db = db;
        }
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM Keeps");
            
        }

        public Keep FindById(int id)
        {
            string query = "SELECT * FROM Keeps WHERE id = @Id";
            Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
            
        }

        internal object Create(Keep value)
        {
            
           
        }

        internal object Delete(int id)
        {
            
        }
    }
}
