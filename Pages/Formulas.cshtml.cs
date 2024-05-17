using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios.Pages
{
	public class FormulasModel : PageModel
	{

		[BindProperty]
		public string A { get; set; } = "0";

		[BindProperty]
		public string B { get; set; } = "0";

		[BindProperty]
		public string Y { get; set; } = "0";

		[BindProperty]
		public string X { get; set; } = "0";

		[BindProperty]
		public string N { get; set; } = "0";

		public string Result { get; set; } = "Resultado";


		public void OnGet()
		{
		}


		private static double factorial(int n)
		{
			if (n == 0)
				return 1;
			else
				return n * factorial(n - 1);
		}

		public void OnPost(string a, string b, string y, string x, string n)
		{
			double A = double.Parse(a);
			double B = double.Parse(b);
			double Y = double.Parse(y);
			double X = double.Parse(x);
			int N = int.Parse(n);
			ModelState.Clear();

			Result = BinomialExpansion(A, B, Y, X, N).ToString();
			if (Result == "NaN")
			{
				ModelState.AddModelError("Result", "Error: Resultado no definido");
			}
		}

		private static double BinomialExpansion(double A, double B, double Y, double X, int N)
		{
			double result = 0;
			for (int i = 0; i <= N; i++)
			{
				result += (Factorial(N) / (Factorial(i) * Factorial(N - i))) * Math.Pow(A * X, N - i) * Math.Pow(B * Y, i);
			}
			return result;
		}

		private static double Factorial(int number)
		{
			if (number == 0)
				return 1;
			double result = 1;
			for (int i = 1; i <= number; i++)
			{
				result *= i;
			}
			return result;
		}


	}
}
