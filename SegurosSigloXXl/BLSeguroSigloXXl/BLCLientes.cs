using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegurosSigloXXl.Models;

namespace SegurosSigloXXl.BLSeguroSigloXXl
{
    public class BLCLientes
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        public BLCLientes()
        {

        }

        public (string, bool) InsertarCliente(int pCedula, string pGenero, DateTime pFecha, string pNombre,
                                              string pPrimerApellido, string pSegundoApellido, int pTelefono,
                                              string pCorreo, string pDireccionFisica, int pIdProvincia, int pIdCanton,
                                              int pIdDistrito, string pContrasenia, string pTipoUsuario)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
            try
            {
                RegistrosAfectados = DBSeguros.pa_Clientes_Insert(pCedula, pGenero, pFecha, pNombre, pPrimerApellido,
                                                                  pSegundoApellido, pTelefono, pCorreo, pDireccionFisica,
                                                                  pIdProvincia, pIdCanton, pIdDistrito, pContrasenia, pTipoUsuario);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " Cliente registrado correctamente";
                    e = false;
                }

                else
                {
                    resultado += " No se pudo registrar el cliente";
                    e = true;
                }
            }
            return (resultado, e);
        }

        public (string, bool) EliminarCliente(int IdCliente)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
            try
            {
                RegistrosAfectados = DBSeguros.pa_Clientes_Delete(IdCliente);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " Cliente eliminado correctamente";
                    e = false;
                }

                else
                {
                    resultado += " No se pudo eliminar el cliente";
                    e = true;
                }
            }
            return (resultado, e);
        }

        public (string, bool) ModificarCliente(int pIdCliente, int pCedula, string pGenero, DateTime pFecha, string pNombre,
                                              string pPrimerApellido, string pSegundoApellido, int pTelefono,
                                              string pCorreo, string pDireccionFisica, int pIdProvincia, int pIdCanton,
                                              int pIdDistrito, string pContrasenia, string pTipoUsuario)
        {
            /// Variable que registra la cantidad de registros afectados
            /// si un procedimiento que ejecuta insert, update o delete
            /// no afecta registros implica que huebo un error
            int RegistrosAfectados = 0;
            string resultado = "";
            bool e;
            try
            {
                RegistrosAfectados = DBSeguros.pa_Clientes_Update(pIdCliente, pCedula, pGenero, pFecha, pNombre, pPrimerApellido,
                                                                  pSegundoApellido, pTelefono, pCorreo, pDireccionFisica,
                                                                  pIdProvincia, pIdCanton, pIdDistrito, pContrasenia, pTipoUsuario);
            }
            catch (Exception Error)
            {
                resultado = "Ocurrio un error " + Error.Message;
            }
            finally
            {
                if (RegistrosAfectados > 0)
                {
                    resultado = " Cliente modificado correctamente";
                    e = false;
                }

                else
                {
                    resultado += " No se pudo modificar el cliente";
                    e = true;
                }
            }
            return (resultado, e);
        }
    }
}