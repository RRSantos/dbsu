using System.Collections.Generic;

namespace dbsu.core.DTO
{
    public class DbObjectType:DbBase
    {
        public List<DbScript> Scripts { get; set; }
    }
}
