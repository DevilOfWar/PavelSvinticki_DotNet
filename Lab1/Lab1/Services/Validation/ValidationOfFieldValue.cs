using Lab1.Services.Exceptions;

namespace Lab1.Services.Validation
{
    public class ValidationOfFieldValue
    {
        public static void Validate(string obj, bool mustBeString)
        {
            if (mustBeString)
            {
                foreach (char element in obj)
                {
                    if (!char.IsLetter(element))
                    {
                        throw new FIOFieldException(" FIO have not a letters");
                    }
                }
            }
            else
            {
                foreach (char element in obj)
                {
                    if (!char.IsDigit(element) || element == '-' || element == '.')
                    {
                        throw new MarkFieldException(" marks must be a positive integer.");
                    }
                }
                if (obj == string.Empty || obj == null)
                {
                    throw new MarkFieldException(" marks can't be emtry");
                }
            }
        }
    }

}
