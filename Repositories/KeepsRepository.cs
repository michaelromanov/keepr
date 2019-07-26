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

        //In Cascading Order:
        public Keep Create(Keep value)
        {
            string query = @"
            INSERT INTO keeps (Name, Description, UserId, Img, IsPrivate)
             VALUES (@NAME, @DESCRIPTION, @USERID, @IMG, @ISPRIVATE);
             SELECT LAST_INSERT_ID();
             ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.id = id;
            return value;
        }

        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
        }

        public IEnumerable<Keep> FindKeepsByUserId(string id)
        {
            string query = @"
            SELECT * FROM keeps WHERE UserId = @id
            ";
            return _db.Query<Keep>(query, new{id});
        }

        public Keep FindById(int id)
        {
            string query = "SELECT * FROM keeps WHERE id = @id";
            Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
            if (data == null) throw new Exception("Invalid ID, Try Once More User");
            return data;
        }

        public Keep Update(Keep value)
        {   
            string query = @"
            UPDATE keeps
            SET
            name = @Name

            WHERE id = @Id;
            SELECT * FROM keeps WHERE id = @Id AND userId = @UserId;
            ";
            return _db.QueryFirstOrDefault<Keep>(query, value);
        }

        public string Delete(int id)
        {
            string query = "DELETE FROM keeps WHERE id = @id;";
            int changedRows = _db.Execute(query, new {id});
            if (changedRows < 1) throw new Exception("Invalid Id Try Again If You Please");
            return "Successfully Deleted The Keep You Requested";
        }

    }
}
