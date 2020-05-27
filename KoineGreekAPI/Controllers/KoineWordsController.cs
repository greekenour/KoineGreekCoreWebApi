using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Insight.Database;
using Microsoft.Data.SqlClient;

namespace KoineGreekAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/koinewords")]
    public class KoineWordsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<KoineWordsController> _logger;

        public KoineWordsController(IConfiguration configuration, ILogger<KoineWordsController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public List<KoineWords> Get()
        {
            var myDb1ConnectionString = _configuration.GetConnectionString("KoineWords");
            var connection = new SqlConnection(myDb1ConnectionString);
            var result = connection.Query<KoineWords>("get_koine_words").ToList();

            return result;
        }
    }
}
