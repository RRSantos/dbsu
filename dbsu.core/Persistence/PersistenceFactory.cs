using System;
using System.Linq;

namespace dbsu.core.Persistence
{
    public static class PersistenceFactory
    {
        private static string connectionStringTypeNotExpected = "Tipo de connectionstring não esperado [{0}].";

        private static string MsSqlConnectionPrefix = "mssql";
        private static char ConnectionStringSeparator = '-';

        public static IPersistence GetPersistence(string connectionStringName)
        {
            var splittedValue = connectionStringName.Split(ConnectionStringSeparator);
            if (splittedValue.Count() == 1 || string.Compare(splittedValue[0], MsSqlConnectionPrefix, true) == 0)
                return new MsSqlPersistence(connectionStringName);

            throw new ArgumentException(string.Format(connectionStringTypeNotExpected, connectionStringName));
        }
    }
}
