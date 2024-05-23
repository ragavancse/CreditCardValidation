using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CreditCardValidation.CardValidation;
using CreditCardValidation.CardValidation.Interface;
using CreditCardValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Serilog;

namespace CreditCardValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CardController(ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("ValidateCard")]
        public IActionResult ValidateCard(CardModel model)
        {
            if (model == null)
            {
                return BadRequest("Send valid input");
            }

           if (ModelState.IsValid)
            {
                IValidateCard validateCard = new LuhnValidation();
                bool isValid = validateCard.ValidateCard(model.CardNumber);

                if (isValid)
                {
                    return Ok("card number is valid");
                }
            }
            return BadRequest("Invalid credit card number");
        }

    }
}
