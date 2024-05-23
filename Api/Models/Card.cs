using System;
using System.ComponentModel.DataAnnotations;
namespace CreditCardValidation.Models
{
    public class CardModel
    {
        [Required]
        public string CardNumber { get; set; }

        public string Name { get; set; }
    }
}
