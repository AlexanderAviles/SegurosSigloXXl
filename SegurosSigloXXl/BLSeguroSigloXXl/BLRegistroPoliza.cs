using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegurosSigloXXl.Models;

namespace SegurosSigloXXl.BLSeguroSigloXXl
{
    public class BLRegistroPoliza
    {
        readonly SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        public BLRegistroPoliza()
        {

        }
        #region INSERTAR REGISTRO POLIZA
        public (string, bool) InsertarRegistroPoliza(int IdCobertura, int IdCliente, float MontoAsegurado, DateTime FechaVencimiento)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = this.BDSeguros.pa_RegistroPoliza_Insert(IdCobertura, IdCliente, MontoAsegurado, FechaVencimiento);
            }
            catch (Exception err)
            {
                resultado = "El registro de poliza no se pudo insertar" + err.Message;
            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado += "El registro de poliza se agrego correctamente";
                    TF = false;
                }
                else
                {
                    resultado += "El registro de poliza no se pudo agregar";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
        #endregion FIN INSERTAR REGISTRO POLIZA

        #region ELIMINAR REGISTRO POLIZA
        public (string, bool) EliminarRegistroPoliza(int IdRegistroPoliza)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = this.BDSeguros.pa_RegistroPoliza_Delete(IdRegistroPoliza);
            }
            catch (Exception err)
            {
                resultado = "El registro de poliza no se pudo eliminar" + err.Message;

            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado += "El registrod de poliza se elimino correctamente";
                    TF = false;
                }
                else
                {
                    resultado += "El registro de poliza no se pudo eliminar";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
        #endregion FIN ELIMINAR REGISTRO POLIZA

        #region MODIFICIAR REGISTRO POLIZA
        public (string, bool) ModificarRegistroPoliza(int IdRegistroPoliza, int IdCobertura, int IdCliente, float MontoAsegurado, DateTime FechaVencimiento)
        {
            int regAfect = 0;
            string resultado = "";
            bool TF;
            try
            {
                regAfect = this.BDSeguros.pa_RegistroPoliza_Update(IdRegistroPoliza, IdCobertura, IdCliente, MontoAsegurado, FechaVencimiento);
            }
            catch (Exception err)
            {
                resultado = "No se pudo modificar el registro de cobertura" + err.Message;

            }
            finally
            {
                if (regAfect > 0)
                {
                    resultado += "El registro de poliza se modifico correctamente";
                    TF = false;
                }
                else
                {
                    resultado += "El registo de poliza no se pudo modificar";
                    TF = true;
                }
            }
            return (resultado, TF);
        }
        #endregion FIN MODIFICAR REGISTRO POLIZA

    }
}
