using CodeCheater.Application.Service;
using CodeCheater.Domain.Models.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CodeCheater.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;
        private readonly ILogger<BasketController> logger;

        public BasketController(IBasketService service, ILogger<BasketController> logger)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> Post([FromBody] BasketCart basketCart)
        {

            var result = await this.service.UpdateAsync(basketCart.UserName, basketCart);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> Get(string userName)
        {
            var result = await this.service.GetAsync(userName);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> Delete(string userName)
        {
            var result = await this.service.DeleteAsync(userName);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
