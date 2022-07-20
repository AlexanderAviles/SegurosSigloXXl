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

        public (string, bool) InsertarAdiccion(string pNombre, string pDescripcion, string pCodgio)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
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

        public (string, bool) ModificarAdiccion(int pIdAdiccion,string pNombre, string pDescripcion, string pCodgio)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
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
    }
}