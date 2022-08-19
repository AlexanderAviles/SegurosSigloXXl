using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegurosSigloXXl.Models;

namespace SegurosSigloXXl.BLSeguroSigloXXl
{
    public class BLAdicciones
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        public BLAdicciones()
        {

        }

        #region INSERTAR ADICCION
        public (string, bool) InsertarAdiccion(string pNombre, string pDescripcion, string pCodgio)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;

            List<pa_Adicciones_Select_Result> Adicciones = new List<pa_Adicciones_Select_Result>();
            Adicciones = this.DBSeguros.pa_Adicciones_Select(null).ToList();

            foreach (pa_Adicciones_Select_Result fNombre in Adicciones)
            {
                if (fNombre.Nombre.ToLower() == pNombre.ToLower())
                {
                    resultado = "No se puede insertar, ya existe una adiccion con ese nombre";
                    e = true;
                    return (resultado, e);
                }
            }

            try
            {
                RegistrosAfectados = DBSeguros.pa_Adicciones_Insert(pNombre, pDescripcion, pCodgio);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " Adiccion agregada al catálogo";
                    e = false;
                }
                    
                else
                {
                    resultado += " No se pudo insertar";
                    e = true;
                }
            }
            return (resultado,e);
        }
        #endregion FIN INSERTAR ADICCION

        #region ELIMINAR ADICCION
        public (string, bool) EliminarAdiccion(int IdAdiccion)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
            try
            {
                RegistrosAfectados = DBSeguros.pa_Adicciones_Delete(IdAdiccion);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " La adiccion ha sido borrada.";
                    e = false;
                }

                else
                {
                    resultado += " No se puede eliminar";
                    e = true;
                }
            }
            return (resultado, e);
        }
        #endregion FIN ELIMINAR ADICCION

        #region MODIFICAR ADICCION
        public (string, bool) ModificarAdiccion(int pIdAdiccion,string pNombre, string pDescripcion, string pCodgio)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;

            List<pa_Adicciones_Select_Result> Adicciones = new List<pa_Adicciones_Select_Result>();
            Adicciones = this.DBSeguros.pa_Adicciones_Select(null).ToList();

            foreach (pa_Adicciones_Select_Result fNombre in Adicciones)
            {
                if (fNombre.Nombre.ToLower() == pNombre.ToLower() && fNombre.IdAdiccion != pIdAdiccion)
                {
                    resultado = "No se puede modificar, ya existe una adiccion con ese nombre";
                    e = true;
                    return (resultado, e);
                }
            }

            try
            {
                RegistrosAfectados = DBSeguros.pa_Adicciones_Update(pIdAdiccion, pNombre, pDescripcion, pCodgio);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " Adiccion seleccionada modificada";
                    e = false;
                }

                else
                {
                    resultado += " No se pudo modificar la adiccion";
                    e = true;
                }
            }
            return (resultado, e);
        }
        #endregion FIN MODIFICAR ADICCION
    }
}