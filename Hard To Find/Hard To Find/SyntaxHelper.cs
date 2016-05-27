using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find
{
    static class SyntaxHelper
    {
        /*Precondition:
         Postcondition: Adds an extra \ behind a \ to escape it for the sql statements */
        static public string escapeSingleQuotes(string stringToCheck)
        {
            if (stringToCheck != null)
            {
                //Check if it contains a single quotation
                if (stringToCheck.Contains('\''))
                {
                    //Get number of single quotations
                    int numQuotes = stringToCheck.Split('\'').Length - 1;
                    //int num = removedDashes.Count(c => c == '\'');

                    int previousIndex = 0;

                    //Loop over quotations
                    for (int i = 0; i < numQuotes; i++)
                    {
                        //Insert quotation before existing one because it's an escape character in SQLite
                        int indexOfQuote = stringToCheck.IndexOf("'", previousIndex);
                        stringToCheck = stringToCheck.Insert(indexOfQuote, "'");

                        //Move index after quotation that was just fixed to stop repeating on the same one
                        previousIndex = indexOfQuote + 2;
                    }

                }
            }

            return stringToCheck;
        }

        /*Precondition:
         Postcondition: Adds a $ and makes the number contain 2 decimals */
        static public string checkAddDollarSignAndDoubleDecimal(string priceToCheck)
        {
            string returnPrice = priceToCheck;

            try
            {
                double price = Convert.ToDouble(priceToCheck);

                returnPrice = "$" + price.ToString("0.00");
            }
            catch (FormatException)
            {
                if (!priceToCheck.Contains('.'))
                {
                    returnPrice += ".00";
                }
            }

            return returnPrice;
        }
    }
}
