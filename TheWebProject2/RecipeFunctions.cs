using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWebProject2
{
    public static class RecipeFunctions
    {
        public static int idValidator(string id, int max, out string message)
        {
            int number = -1;
            if (id is null || id.Equals(""))
            {
                message = "Please enter numbers as ID between 0 and " + max + "!";
                return number;
            }

            try
            {
                number = Int32.Parse(id);
            }
            catch (Exception)
            {
                message = "Please enter valid numbers as ID!";
                return number;
            }

            if (number < 0 || number > max)
            {
                message = "Please enter numbers as ID between 0 and " + max + "!";
                return -1;
            }
            message = "OK";
            return number;
        }


    }
}