using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Entities;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}