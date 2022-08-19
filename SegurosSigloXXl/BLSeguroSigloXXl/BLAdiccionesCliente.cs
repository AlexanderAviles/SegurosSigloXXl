using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegurosSigloXXl.Models;

namespace SegurosSigloXXl.BLSeguroSigloXXl
{
    public class BLAdiccionesCliente
    {
        readonly SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        public BLAdiccionesCliente()
        {

        }
        #region INSERTAR ADICCION CLIENTE
        public (string, bool) InsertarAdiccionCliente(int IdAdiccionCliente, int IdAdiccion)
        {
            int RegAfect = 0;
            string Resultado = "";
            bool TF;
            try
            {
                RegAfect = this.BDSeguros.pa_AdiccionesDetalle_Insert(IdAdiccionCliente, IdAdiccion);
            }
            catch (Exception err)
            {
                Resultado = "Error al insertar la adiccion al cliente" + err.Message;
            }
            finally
            {
                if (RegAfect > 0)
                {
                    Resultado += "La adiccion se agrego correctamente";
                    TF = false;
                }
                else
                {
                    Resultado += "No se pudo agregar la adiccion al cliente";
                    TF = true;
                }
            }
            return (Resultado, TF);

        }
        #endregion FIN INSERTAR ADICCION CLIENTE

        #region MODIFICAR ADICCION CLIENTE
        public (string, bool) ModificarAdiccionCliente(int IdAdiccionDetalle, int IdAdiccionCliente, int IdAdiccion)
        {
            int RegAfect = 0;
            string Resultado = "";
            bool TF;
            try
            {
                RegAfect = this.BDSeguros.pa_AdiccionesDetalle_Update(IdAdiccionDetalle, IdAdiccionCliente, IdAdiccion);
            }
            catch (Exception err)
            {
                Resultado = "Error al modificar la adiccion del cliente" + err.Message;
            }
            finally
            {
                if (RegAfect > 0)
                {
                    Resultado += "La modificacion de la adiccion del cliente se completo";
                    TF = false;
                }
                else
                {
                    Resultado += "No se pudo modificar la adiccion del cliente";
                    TF = true;
                }
            }
            return (Resultado, TF);
        }

        #endregion FIN MODIFICAR ADICCION CLIENTE

        #region ELIMINAR ADICCION CLIENTE
        public (string, bool) EliminarAdiccionCliente(int IdAdiccionDetalle)
        {
            int RegAfect = 0;
            string Resultado = "";
            bool TF;
            try
            {
                RegAfect = this.BDSeguros.pa_AdiccionesDetalle_Delete(IdAdiccionDetalle);
            }
            catch (Exception err)
            {
                Resultado += "No se pudo eliminar la adiccion del cliente" + err.Message;
            }
            finally
            {
                if (RegAfect > 0)
                {
                    Resultado += "La adiccion del cliente se elimino";
                    TF = false;
                }
                else
                {
                    Resultado += "No se pudo eliminar la adiccion del cliente";
                    TF = true;
                }
            }
            return (Resultado, TF);
        }

        #endregion FIN ELIMINAR ADICCION CLIENTE




    }
}