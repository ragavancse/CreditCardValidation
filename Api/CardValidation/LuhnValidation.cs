using CreditCardValidation.CardValidation.Interface;
using System.Linq;

namespace CreditCardValidation.CardValidation
{
    public class LuhnValidation : IValidateCard
    {
        public LuhnValidation() { }

        /// <summary>
        /// This method will validate the credit card number by using Luhn algorithm
        /// </summary>
        /// <param name="cardNumber">Credit Card Number</param>
        /// <returns></returns>
        public bool ValidateCard(string cardNumber)
        {
            cardNumber = RemoveWhitespace(cardNumber);
            if (cardNumber.Contains("-"))
            {
                cardNumber = cardNumber.Replace("-", string.Empty);
            }

            int nDigits = cardNumber.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNumber[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits 
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }

        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

    }
}
