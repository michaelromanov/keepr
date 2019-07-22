using System.Data;

namespace keepr.Repositories
{
    public class keeps
    {
        private readonly IDbConnection _db;
        public keeps(IDbConnection db)
        {
            _db = db;
        }
    }  
}  