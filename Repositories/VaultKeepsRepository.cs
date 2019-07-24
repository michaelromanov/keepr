using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)  
        {
            _db = db;
        }

        public VaultKeeps Create(VaultKeeps value)
        {
            string query = @"
            INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
            VALUES(@VaultId, keepId, UserId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public VaultKeeps FindById(int id)
        {
            string query = "SELECT * FROM vaultkeeps WHERE id = @id";
            VaultKeeps data = _db.QueryFirstOrDefault<VaultKeeps>(query, new { id });
            if (data == null) throw new Exception("Invalid ID, Try Once More User");
            return data;
        }

        // public string Delete(VaultKeeps value)
        // {
        //     string query = @"
            
        //     "
            
        // }
    }

}

// -- -- USE THIS LINE FOR GET KEEPS BY VAULTID
// -- SELECT * FROM vaultkeeps vk
// -- INNER JOIN keeps k ON k.id = vk.keepId 
// -- WHERE (vaultId = @vaultId AND vk.userId = @userId) 


        // public string Delete(VaultKeeps value)
        // {
        //     string query = @"
            
        //     "
            
        // }