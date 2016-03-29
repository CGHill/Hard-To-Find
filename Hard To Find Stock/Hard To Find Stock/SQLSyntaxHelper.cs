using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hard_To_Find_Stock
{
    static class SQLSyntaxHelper
    {
        static public string escapeSingleQuotes(string stringToCheck)
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

            return stringToCheck;
        }
    }
}
