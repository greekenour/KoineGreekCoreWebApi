using Insight.Database;
using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KoineGreekAPI.Repository.Repositories
{
    public class KoineWordsRepository
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public KoineWordsRepository()
        {
            SqlInsightDbProvider.RegisterProvider();
        }

        private static ILog Logger
        {
            get
            {
                return Log;
            }
        }

        private SqlConnection DBConnection
        {
            get
            {
                return new SqlConnection(GetConnectionString());
            }
        }

        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder;

            try
            {
                builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            }
            catch (Exception)
            {
                //log.LogException(Log, ex, "GetConnectionString");
                return null;
            }

            return builder.ConnectionString;
        }
    }
}
