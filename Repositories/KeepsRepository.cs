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

        public Keep FindById(string id)
        {
            string query = "SELECT * FROM Keeps WHERE id = @Id";
            Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
            if (data == null) throw new Exception("Invalid ID");
            return data;
            
        }

        internal object Create(Keep value)
        {
            string query = @"
            INSERT INTO keeps (Name, Description, UserId, Img, IsPrivate)
             VALUES (@NAME, @DESCRIPTION, @USERID, @IMG, @ISPRIVATE);
             SELECT LAST_INSERT_ID();
             ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        internal object Delete(int id)
        {
            string query = "DELETE FROM keeps WHERE id = @Id;";
            int changedRows = _db.Execute(query, new int{id});
            if (changedRows < 1) throw new Exception("Invalid Id Try Again If You Please");
            return "Successfully Deleted The Keep You Requested";
        }

    }
}
