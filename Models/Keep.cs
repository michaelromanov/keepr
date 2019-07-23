namespace keepr.Models
{
    public class Keep
    {
        // Follow (in sequential order) the tests in createtable keeps in db-setup.sql 
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public string userId {get; set;}
        public string img {get; set;}
        public bool isPrivate {get; set;}
        public int views {get; set;}
        public int shares {get; set;}
        public int keeps {get; set;}

    }
}

// -- CREATE TABLE keeps (
// --     id int NOT NULL AUTO_INCREMENT,
// --     name VARCHAR(20) NOT NULL,
// --     description VARCHAR(255) NOT NULL,
// --     userId VARCHAR(255),
// --     img VARCHAR(255),
// --     isPrivate TINYINT,
// --     views INT DEFAULT 0, 
// --     shares INT DEFAULT 0,
// --     keeps INT DEFAULT 0,
// --     INDEX userId (userId),
// --     FOREIGN KEY (userId)
// --         REFERENCES users(id)
// --         ON DELETE CASCADE,  
// --     PRIMARY KEY (id)
// -- );