using System.Collections.Generic;

namespace dbsu.core.DTO
{
    public class DbConnection : DbBase
    {
        public List<DbObjectType> ObjectTypes { get; set; }
    }
}
