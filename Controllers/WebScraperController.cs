using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using web_scrapper.Models;

namespace web_scrapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {

        [EnableCors("AllowOrigin")]
        //[HttpGet("get")]
        public async Task<IActionResult> Get(string url = "")
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            WebScraperModel model = null;
            Response response = new Response(model, "Success", false);

            try
            {

                response.Data = await WebScraperModel.GET(url);
                if (response.Data == null)
                {
                    response.Message = "Invalid URL";
                    response.Error = true;
                    return NotFound(response);
                }

            
            }
            catch (Exception ex)
            {

                return BadRequest(ex);

            }


            return Ok(response);
        }
        //[EnableCors("AllowOrigin")]
        //public IActionResult Get()
        //{
        //    return Ok(new Response(null, "Welcome to the Sraper API", false));

        //}



    }
    public class Response
    {
        public bool Error { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public Response(object data, string msj, bool error)
        {
            this.Error = error;
            this.Message = msj;
            this.Data = data;
        }
    }
}
