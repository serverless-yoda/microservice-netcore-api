using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeCheater.Application.Service;
using CodeCheater.Domain.Models.Baskets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCheater.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;

        public BasketController(IBasketService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> Post([FromBody] BasketCart basketCart)
        {
            
            var result = await this.service.UpdateAsync(basketCart.UserName, basketCart);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
