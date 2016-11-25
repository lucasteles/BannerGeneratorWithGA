using BannerGeneratorWithGeneticAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BannerGeneratorWithGeneticAlgorithm.Controllers
{
    public class BannerController : ApiController
    {
        public IHttpActionResult Get()
        {
            var ga = WebApiApplication.BannerGA;
            var ret = ga.Population.Select(
                    (g, i) => new BannerConfig(g) { Id = i }
                ).ToList();
            
            return Json(new {
                    generation = ga.Generation,
                    population = ret
            });
        }

        [HttpGet]
        public IHttpActionResult AddScore(int Id, int score)
        {
            var ga = WebApiApplication.BannerGA;
            var item = ga.Population.ElementAt(Id);

            if (item == null)
                return BadRequest("Id not found");

            item.Score = score;

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Next()
        {
            // step one generation
            WebApiApplication.BannerGA.Epoch();

            return Ok();
        }


    }
}
