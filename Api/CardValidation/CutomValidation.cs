using CreditCardValidation.CardValidation.Interface;
using System.Text.RegularExpressions;
using System;

namespace CreditCardValidation.CardValidation
{
    public class CutomValidation : IValidateCard
    {
        public bool ValidateCard(string cardNumber)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");

            if (!cardCheck.IsMatch(cardNumber)) // <1>check card number is valid
                return false;

            return true;
        }
    }
}
