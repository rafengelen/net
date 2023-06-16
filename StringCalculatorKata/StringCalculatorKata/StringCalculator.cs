using System.Linq;
using System.Runtime.CompilerServices;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers) {
            if(numbers.Length == 0) return 0;
            var numbersList = new List<int>(Array.ConvertAll(numbers.Split(','), Convert.ToInt32));

            List<int> negativeNumbers = numbersList.Where(n => n < 0).ToList();
            List<int> LargeNumbers = numbersList.Where(n => n > 1000).ToList();
           
            if (negativeNumbers.Count>0)
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return numbersList.Sum()-LargeNumbers.Sum();
        }

    }
}