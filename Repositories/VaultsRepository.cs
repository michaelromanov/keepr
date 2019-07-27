using System;
using System.Data;
using Dapper;
using keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Security.Claims;
namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

    //In Cascading Order:

        public Vault Create(Vault value)
        {
            string query = @"
            INSERT INTO vaults (Name, Description, UserId)
            VALUES (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public IEnumerable<Vault> GetAll(string id)
        {
            //similar to line 35 in keep repository where only get if the user id is the id of the logged in
            return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new {id});
        }

        public Vault FindById(int id)
        {
            string query = "SELECT * FROM vaults WHERE id = @id";
            Vault data = _db.QueryFirstOrDefault<Vault>(query, new { id });
            if (data == null) throw new Exception("Invalid ID, Try Once More User");
            return data;
        }

        public string Delete(int id)
        {
            string query = "DELETE FROM vaults WHERE id = @id;";
            int changedRows = _db.Execute(query, new {id});
            if (changedRows < 1) throw new Exception("Invalid Id Try Again If You Please");
            return "Successfully Deleted The Keep You Requested";
        }




    }
}