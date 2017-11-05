using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hw2_Tests.Assignment6and7
{
    class Parallel
    {
        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumberAsync();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumberAsync()
        {
            int sum = await IKnowIGuyWhoKnowsAGuyAsync();
            return sum;
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            int sum = await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
            return sum;
        }
        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            int sum = await FactorialDigitSum(n);
            return sum;
        }

        static async Task<int> FactorialDigitSum(int n)
        {
            int sum = await Task.Run(() => FactSum(n));
            return sum;
        }

        private static int FactSum(int n)
        {
            if (n == 0) return 0;
            int fact = n;
            for (int i = 1; i < n; i++)
            {
                fact *= i;
            }
            int sum = 0;
            while (fact > 0)
            {
                sum += fact % 10;
                fact /= 10;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus oz LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
    }
}
