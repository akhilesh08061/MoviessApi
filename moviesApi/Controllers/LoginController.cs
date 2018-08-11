using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moviesApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace moviesApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost("connect/token")]
        [Consumes("application/x-www-form-urlencoded")]
        public JObject getAccessToken([FromForm] TokenData data)
        {
           return JObject.Parse(RequestTokenFromAuthorizationServer(data).GetAwaiter().GetResult()); 
        }

        private static async Task<string> RequestTokenFromAuthorizationServer(
            [FromForm] TokenData data)
        {
            Uri authorizationServerTokenUri = new Uri("http://localhost:5004/connect/token");
            HttpResponseMessage responseMessage;
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage tokenRequest = new HttpRequestMessage(
                    HttpMethod.Post, authorizationServerTokenUri);
                string content = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new FormUrlEncodedContent(
                    new[] {
                    new KeyValuePair<string,string>("grant_type",data.grant_type),
                    new KeyValuePair<string,string>("client_id",data.client_id),
                    new KeyValuePair<string, string>("scope",data.scope),
                    new KeyValuePair<string, string>("client_secret",data.client_Secret)
                    });

                tokenRequest.Content = httpContent;
                responseMessage = await client.SendAsync(tokenRequest);
            }

            return await responseMessage.Content.ReadAsStringAsync();
        }



    }
}