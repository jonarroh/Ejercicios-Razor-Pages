using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios.Pages
{
    public class ImcModel : PageModel
    {
		[BindProperty]
		public string Masa { get; set; } = "0";

		[BindProperty]
		public string Estatura { get; set; } = "0";

		public string Imc { get; set; } = "0";

		public string Tipo { get; set; } = "0";

		public string UrlI { get; set; } = "0";

		public void OnGet()
		{
		}

		public void OnPost()
		{
			if (!double.TryParse(Masa, out double masaNum) || masaNum <= 0)
			{
				ModelState.AddModelError("Masa", "La masa debe ser un número mayor a 0");
			}

			if (!double.TryParse(Estatura, out double estaturaNum) || estaturaNum <= 0)
			{
				ModelState.AddModelError("Estatura", "La estatura debe ser un número mayor a 0");
			}

			if (ModelState.IsValid)
			{
				double imc = CalcularIMC(masaNum, estaturaNum);
				Imc = imc.ToString();

				Tipo = imc switch
				{
					< 18.5 => "Bajo peso",
					>= 18.5 and < 24.9 => "Normal",
					>= 25 and < 29.9 => "Sobrepeso",
					>= 30 and < 34.9 => "Obesidad I",
					>= 35 and < 39.9 => "Obesidad II",
					>= 40 => "Obesidad III",
					_ => "Error"
				};

				UrlI = imc switch
				{
					< 18.5 => "/img/bajo.png",
					>= 18.5 and < 24.9 => "/img/normal.png",
					>= 25 and < 29.9 => "/img/sobre.png",
					>= 30 and < 34.9 => "/img/grado1.png",
					>= 35 and < 39.9 => "/img/grado2.png",
					>= 40 => "/img/grado3.png",
					_ => "Error"
				};
			}
		}

		private static double CalcularIMC(double masa, double estatura)
		{
			return masa / (estatura * estatura);
		}
	}
}

