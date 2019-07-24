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
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
            VALUES(@vaultId, @keepId, @userId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public IEnumerable<Keep> FindById(int vaultId, string userId)
        {
            string query = @"SELECT * FROM vaultkeeps
             vk INNER JOIN keeps k ON k.id = vk.keepId
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            IEnumerable<Keep> data = _db.Query<Keep>(query, new { vaultId, userId });
            if (data == null) throw new Exception("Invalid, Try Once More User");
            return data;
        }

        public string Del(VaultKeeps value)
        {
            string query = @"DELETE FROM vaultkeeps WHERE
            (vaultId = @vaultId AND keepId = @keepId AND userId = @userId)";

            int deleted = _db.Execute(query, value);
            if (deleted < 1) throw new Exception("Invalid Request");
            return "Delete Complete";
        }
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

        
        // public string Delete(VaultKeeps value)
        // {
        //     string query = @"DELETE FROM vaultkeeps WHERE (VaultId = @VaultId)";
               
        //     "
            
        // }