using Microsoft.AspNetCore.Mvc;
using PixWebhook.Messages;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PixWebHook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixController : ControllerBase
    {
        private readonly IBus bus;

        public PixController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await bus.Send(new PixMessage { Body = "Pix Test Body" });
            return "Message sended!";
        }        
    }
}
