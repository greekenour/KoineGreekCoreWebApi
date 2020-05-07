using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KoineGreekAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/koinewords")]
    public class KoineWordsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "the word is satisfaction", "the word is niceness", "the prechness is the meaning"
        };

        private readonly ILogger<KoineWordsController> _logger;

        public KoineWordsController(ILogger<KoineWordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<KoineWords> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new KoineWords
            {
                Name = "Greek Word",
                Definition = Summaries[rng.Next(Summaries.Length)],
                Id = Guid.NewGuid()
            })
            .ToArray();
        }
    }
}
