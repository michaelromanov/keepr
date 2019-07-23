namespace keepr.Models
{
    public class Vault 
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string UserId {get; set;}
    }

    public class VaultKeep 
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public string UserId { get; set; }
    }
}

// -- CREATE TABLE vaults (
// --     id int NOT NULL AUTO_INCREMENT,
// --     name VARCHAR(20) NOT NULL,
// --     description VARCHAR(255) NOT NULL,
// --     userId VARCHAR(255),
// --     INDEX userId (userId),
// --     FOREIGN KEY (userId)
// --         REFERENCES users(id)
// --         ON DELETE CASCADE,  
// --     PRIMARY KEY (id)
// -- );
