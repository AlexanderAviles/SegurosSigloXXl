using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text;
namespace SegurosSigloXXl.Clases
{
    public static class NormalizarTexto
    {
        public static string sinTildes(this string texto)
        {
            new String(
                texto.Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()).Normalize(System.Text.NormalizationForm.FormC);
            return texto;
        }
    }
}