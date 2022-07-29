using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegurosSigloXXl.Models;
namespace SegurosSigloXXl.BLSeguroSigloXXl
{
    public class BLCoberturas
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        public BLCoberturas()
        {

        }

        public (string, bool) InsertarCobertura(string pNombre, string pDescripcion, float? pPorcentaje)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = DBSeguros.pa_CoberturaPoliza_Insert(pNombre, pDescripcion, pPorcentaje);
            }
            catch (Exception err)
            {
                resultado = "Ocurrio un erro al insertar la cobertura" + err.Message;

            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado = "Cobertura agregada al catalogo";
                    TF = false;
                }
                else
                {
                    resultado += "No se pudo insertar";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
        public (string, bool) EliminarCobertura(int IdCoberturaPoliza)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = this.DBSeguros.pa_CoberturaPoliza_Delete(IdCoberturaPoliza);
            }
            catch (Exception err)
            {
                resultado = "Ocurrio un erro" + err.Message;

            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado += "La cobuertura ha sido eliminada.";
                    TF = false;
                }
                else
                {
                    resultado += "No se pudo eliminar.";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
        public (string, bool) ModificarCoberturas(int pIdCobertura, string pNombre, string pDescripcion, float? pPorcentaje)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = this.DBSeguros.pa_CoberturaPoliza_Update(pIdCobertura, pNombre, pDescripcion, pPorcentaje);
            }
            catch (Exception err)
            {
                resultado = "Ocurrio un error" + err.Message;

            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado = "La cobertura seleccionada fue modificada";
                    TF = false;
                }
                else
                {
                    resultado += "No se pudo modificar la cobertura seleccioanda";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
    }
}
