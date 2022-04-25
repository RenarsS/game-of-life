namespace GameOfLife
{
    /// <summary>
    /// Public static class contains methods for validating different values.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validates value of the string whether it can be parsed as a integer.
        /// Also checks if the given value is natural number.
        /// </summary>
        /// <param name="checkVal">Value that needs to be checked and validated</param>
        /// <returns>Boolean value: 'true' if given value has passed validation succesfully and 'false' if not.</returns>
        public static bool ValidateNaturalNum(string checkVal)
        {
            try
            {
                int result = int.Parse(checkVal);

                if(result <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Input value can't be smaller than or equal to zero.");
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Input value should contain only integer values.");
                return false;
            }

            return true;
        }
    }
}
