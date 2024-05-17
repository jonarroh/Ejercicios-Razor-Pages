using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios.Pages
{
    public class CesarEncryptModel : PageModel
    {

       
        [BindProperty]
        public string Nrecorrer { get; set; } = "0";

        [BindProperty]
        public string Texto { get; set; } = "0";

        public string TextoCifrado { get; set; } = "0";

        public void OnGet()
        {
        }

        public void OnPost(string texto, string nrecorrer)
        {
            if (!int.TryParse(nrecorrer, out int nrecorrerNum) || nrecorrerNum < 0)
            {
                ModelState.AddModelError("Nrecorrer", "El número de recorrido debe ser un número mayor o igual a 0");
            }

            if (ModelState.IsValid)
            {
                TextoCifrado = CesarEncrypt(texto, nrecorrerNum);
            }
        }


        private static string CesarEncrypt(string texto, int nrecorrer)
        {
            string[] alfabeto = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
                                               "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"
                                               , "X", "Y", "Z"];
            string textoCifrado = "";
            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    int index = Array.IndexOf(alfabeto, c.ToString().ToUpper());
                    index = (index + nrecorrer) % alfabeto.Length;
                    textoCifrado += alfabeto[index];
                }
                else
                {
                    textoCifrado += c;
                }
            }

            return textoCifrado;
        }   
    }
}
