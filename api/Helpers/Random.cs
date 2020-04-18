using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metal.Helpers
{
    public class Random : IDisposable
    {
        public void Dispose()
        {
            // Dispose();
            GC.SuppressFinalize(this);
        }

        public string GenerateRandom(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, int lengthOfString)
        {
            const string lowerChar = "abcdefghijklmnopqrstuvwxyz";
            const string upperChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numChar = "0123456789";
            const string specialChar = @"!#$&*@";

            string characterSet = "";

            if (includeLowercase)
            {
                characterSet += lowerChar;
            }

            if (includeUppercase)
            {
                characterSet += upperChar;
            }

            if (includeNumeric)
            {
                characterSet += numChar;
            }

            if (includeSpecial)
            {
                characterSet += specialChar;
            }

            char[] password = new char[lengthOfString];
            int characterSetLength = characterSet.Length;

            System.Random random = new System.Random();

            for (int position = 0; position < lengthOfString; position++)
            {
                password[position] = characterSet[random.Next(characterSetLength - 1)];
            }

            return string.Join(null, password);
        }
    }
}