using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CadatroPessoaWebApi.Exceptions
{
    public class HttpException : HttpResponseException, IHttpException
    {
        public HttpException(string message, HttpStatusCode statusCode) :
            base(new HttpResponseMessage()
            {
                Content = new StringContent(message),
                StatusCode = statusCode
            })
        {

        }

        public ObjectResult HttpMessageException()
        {
            ObjectResult objResult = null;

            switch ((int)Response.StatusCode)
            {
                case 400:
                    objResult = new BadRequestObjectResult(Response.Content.ReadAsStringAsync().Result);
                    break;
                case 404:
                    objResult = new NotFoundObjectResult(Response.Content.ReadAsStringAsync().Result);
                    break;
            }
            return objResult;
        }
    }
}
