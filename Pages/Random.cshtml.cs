using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios.Pages
{
    public class RandomModel : PageModel
    {
        
        public int[] ints = new int[19];

		public int Suma { get; set; }

        public int Promedio { get; set; }

        public int Moda { get; set; }

        public int Mediana { get; set; }



        public void OnGet()
        {
			ints = GenerateRandomNumbers(ints);
            Suma = Sum(ints);
            Promedio = Average(ints);
            Moda = Mode(ints);
            Mediana = Median(ints);



            ModelState.Clear();
		}

		private static int[] GenerateRandomNumbers(int[] ints)
		{
			for (int i = 0; i < 19; i++)
			{
				ints[i] = Random.Shared.Next(1, 101);
			}

			return ints;
		}

        private static int Average(int[] ints)
        {
            int sum = 0;

            foreach (int i in ints)
            {
                sum += i;
            }

            return sum / ints.Length;
        }

        private static int Mode(int[] ints)
        {
            int mode = 0;
            int maxCount = 0;

            for (int i = 0; i < ints.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < ints.Length; j++)
                {
                    if (ints[j] == ints[i])
                    {
                        count++;
                    }
                }

                if (count > maxCount)
                {
                    mode = ints[i];
                    maxCount = count;
                }
            }

            return mode;
        }

        private static int Median(int[] ints)
        {
            Array.Sort(ints);

            if (ints.Length % 2 == 0)
            {
                return (ints[ints.Length / 2] + ints[ints.Length / 2 - 1]) / 2;
            }
            else
            {
                return ints[ints.Length / 2];
            }
        }

        private static int Sum(int[] ints)
		{
            int sum = 0;

            foreach (int i in ints)
			{
                sum += i;
            }

            return sum;
        }
	}
}
