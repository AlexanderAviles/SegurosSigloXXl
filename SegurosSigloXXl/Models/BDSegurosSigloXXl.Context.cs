﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SegurosSigloXXl.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class SegurosSigloXXlEntities : DbContext
    {
        public SegurosSigloXXlEntities()
            : base("name=SegurosSigloXXlEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Adicciones> Adicciones { get; set; }
        public DbSet<AdiccionesDetalle> AdiccionesDetalle { get; set; }
        public DbSet<AdiccionesEncabezado> AdiccionesEncabezado { get; set; }
        public DbSet<Canton> Canton { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<CoberturaPoliza> CoberturaPoliza { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<RegistroPoliza> RegistroPoliza { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual int pa_Adicciones_Delete(Nullable<int> idAdiccion)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("IdAdiccion", idAdiccion) :
                new ObjectParameter("IdAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Adicciones_Delete", idAdiccionParameter);
        }
    
        public virtual int pa_Adicciones_Insert(string nombre, string descripcion, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Adicciones_Insert", nombreParameter, descripcionParameter, codigoParameter);
        }
    
        public virtual ObjectResult<pa_Adicciones_Select_Result> pa_Adicciones_Select(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Adicciones_Select_Result>("pa_Adicciones_Select", nombreParameter);
        }
    
        public virtual ObjectResult<pa_Adicciones_Select_Id_Result> pa_Adicciones_Select_Id(Nullable<int> idAdiccion)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("IdAdiccion", idAdiccion) :
                new ObjectParameter("IdAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Adicciones_Select_Id_Result>("pa_Adicciones_Select_Id", idAdiccionParameter);
        }
    
        public virtual int pa_Adicciones_Update(Nullable<int> idAdiccion, string nuevoNombre, string nuevaDescripcion, string nuevoCodigo)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("IdAdiccion", idAdiccion) :
                new ObjectParameter("IdAdiccion", typeof(int));
    
            var nuevoNombreParameter = nuevoNombre != null ?
                new ObjectParameter("NuevoNombre", nuevoNombre) :
                new ObjectParameter("NuevoNombre", typeof(string));
    
            var nuevaDescripcionParameter = nuevaDescripcion != null ?
                new ObjectParameter("NuevaDescripcion", nuevaDescripcion) :
                new ObjectParameter("NuevaDescripcion", typeof(string));
    
            var nuevoCodigoParameter = nuevoCodigo != null ?
                new ObjectParameter("NuevoCodigo", nuevoCodigo) :
                new ObjectParameter("NuevoCodigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Adicciones_Update", idAdiccionParameter, nuevoNombreParameter, nuevaDescripcionParameter, nuevoCodigoParameter);
        }
    
        public virtual int pa_AdiccionesDetalle_Delete(Nullable<int> idAdiccionDetalle)
        {
            var idAdiccionDetalleParameter = idAdiccionDetalle.HasValue ?
                new ObjectParameter("IdAdiccionDetalle", idAdiccionDetalle) :
                new ObjectParameter("IdAdiccionDetalle", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_AdiccionesDetalle_Delete", idAdiccionDetalleParameter);
        }
    
        public virtual int pa_AdiccionesDetalle_Insert(Nullable<int> idAdiccionCliente, Nullable<int> idAdiccion)
        {
            var idAdiccionClienteParameter = idAdiccionCliente.HasValue ?
                new ObjectParameter("IdAdiccionCliente", idAdiccionCliente) :
                new ObjectParameter("IdAdiccionCliente", typeof(int));
    
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("IdAdiccion", idAdiccion) :
                new ObjectParameter("IdAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_AdiccionesDetalle_Insert", idAdiccionClienteParameter, idAdiccionParameter);
        }
    
        public virtual ObjectResult<pa_AdiccionesDetalle_Select_Result> pa_AdiccionesDetalle_Select(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_AdiccionesDetalle_Select_Result>("pa_AdiccionesDetalle_Select", idClienteParameter);
        }
    
        public virtual ObjectResult<pa_AdiccionesDetalle_Select_Id_Result> pa_AdiccionesDetalle_Select_Id(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_AdiccionesDetalle_Select_Id_Result>("pa_AdiccionesDetalle_Select_Id", idClienteParameter);
        }
    
        public virtual int pa_AdiccionesDetalle_Update(Nullable<int> idAdiccionDetalle, Nullable<int> idAdiccionCliente, Nullable<int> idAdiccion)
        {
            var idAdiccionDetalleParameter = idAdiccionDetalle.HasValue ?
                new ObjectParameter("IdAdiccionDetalle", idAdiccionDetalle) :
                new ObjectParameter("IdAdiccionDetalle", typeof(int));
    
            var idAdiccionClienteParameter = idAdiccionCliente.HasValue ?
                new ObjectParameter("IdAdiccionCliente", idAdiccionCliente) :
                new ObjectParameter("IdAdiccionCliente", typeof(int));
    
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("IdAdiccion", idAdiccion) :
                new ObjectParameter("IdAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_AdiccionesDetalle_Update", idAdiccionDetalleParameter, idAdiccionClienteParameter, idAdiccionParameter);
        }
    
        public virtual ObjectResult<pa_AdiccionesEncabezado_Select_Result> pa_AdiccionesEncabezado_Select(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_AdiccionesEncabezado_Select_Result>("pa_AdiccionesEncabezado_Select", idClienteParameter);
        }
    
        public virtual ObjectResult<pa_AdiccionesEncabezado_Select_Id_Result> pa_AdiccionesEncabezado_Select_Id(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_AdiccionesEncabezado_Select_Id_Result>("pa_AdiccionesEncabezado_Select_Id", idClienteParameter);
        }
    
        public virtual int pa_Canton_Delete(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Canton_Delete", id_CantonParameter);
        }
    
        public virtual int pa_Canton_Insert(Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Canton_Insert", id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual ObjectResult<pa_Canton_Select_Result> pa_Canton_Select(string nombre, Nullable<int> id_Provincia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Canton_Select_Result>("pa_Canton_Select", nombreParameter, id_ProvinciaParameter);
        }
    
        public virtual ObjectResult<pa_Canton_Select_Id_Result> pa_Canton_Select_Id(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Canton_Select_Id_Result>("pa_Canton_Select_Id", id_CantonParameter);
        }
    
        public virtual int pa_Canton_Update(Nullable<int> id_Canton, Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Canton_Update", id_CantonParameter, id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual int pa_Clientes_Delete(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Clientes_Delete", idClienteParameter);
        }
    
        public virtual ObjectResult<pa_Clientes_Select_Result> pa_Clientes_Select(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Clientes_Select_Result>("pa_Clientes_Select", nombreParameter);
        }
    
        public virtual ObjectResult<pa_Clientes_Select_Id_Result> pa_Clientes_Select_Id(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Clientes_Select_Id_Result>("pa_Clientes_Select_Id", idClienteParameter);
        }
    
        public virtual int pa_Clientes_Update(Nullable<int> idCliente, Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string nombre, string primerApellido, string segundoApellido, Nullable<int> telefono, string correo, string direccionFisica, Nullable<int> idProvincia, Nullable<int> idCanton, Nullable<int> idDistrito, string contrasenia, string tipoUsuario)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var direccionFisicaParameter = direccionFisica != null ?
                new ObjectParameter("DireccionFisica", direccionFisica) :
                new ObjectParameter("DireccionFisica", typeof(string));
    
            var idProvinciaParameter = idProvincia.HasValue ?
                new ObjectParameter("IdProvincia", idProvincia) :
                new ObjectParameter("IdProvincia", typeof(int));
    
            var idCantonParameter = idCanton.HasValue ?
                new ObjectParameter("IdCanton", idCanton) :
                new ObjectParameter("IdCanton", typeof(int));
    
            var idDistritoParameter = idDistrito.HasValue ?
                new ObjectParameter("IdDistrito", idDistrito) :
                new ObjectParameter("IdDistrito", typeof(int));
    
            var contraseniaParameter = contrasenia != null ?
                new ObjectParameter("Contrasenia", contrasenia) :
                new ObjectParameter("Contrasenia", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Clientes_Update", idClienteParameter, cedulaParameter, generoParameter, fechaNacimientoParameter, nombreParameter, primerApellidoParameter, segundoApellidoParameter, telefonoParameter, correoParameter, direccionFisicaParameter, idProvinciaParameter, idCantonParameter, idDistritoParameter, contraseniaParameter, tipoUsuarioParameter);
        }
    
        public virtual int pa_CoberturaPoliza_Delete(Nullable<int> idCobertura)
        {
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CoberturaPoliza_Delete", idCoberturaParameter);
        }
    
        public virtual int pa_CoberturaPoliza_Insert(string nombreCobertura, string descripcion, Nullable<float> porcentaje)
        {
            var nombreCoberturaParameter = nombreCobertura != null ?
                new ObjectParameter("NombreCobertura", nombreCobertura) :
                new ObjectParameter("NombreCobertura", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var porcentajeParameter = porcentaje.HasValue ?
                new ObjectParameter("Porcentaje", porcentaje) :
                new ObjectParameter("Porcentaje", typeof(float));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CoberturaPoliza_Insert", nombreCoberturaParameter, descripcionParameter, porcentajeParameter);
        }
    
        public virtual ObjectResult<pa_CoberturaPoliza_Select_Result> pa_CoberturaPoliza_Select(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_CoberturaPoliza_Select_Result>("pa_CoberturaPoliza_Select", nombreParameter);
        }
    
        public virtual int pa_CoberturaPoliza_Update(Nullable<int> idCobertura, string nombreCobertura, string descripcion, Nullable<float> porcentaje)
        {
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            var nombreCoberturaParameter = nombreCobertura != null ?
                new ObjectParameter("NombreCobertura", nombreCobertura) :
                new ObjectParameter("NombreCobertura", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var porcentajeParameter = porcentaje.HasValue ?
                new ObjectParameter("Porcentaje", porcentaje) :
                new ObjectParameter("Porcentaje", typeof(float));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CoberturaPoliza_Update", idCoberturaParameter, nombreCoberturaParameter, descripcionParameter, porcentajeParameter);
        }
    
        public virtual ObjectResult<pa_Provincias_Select_Result> pa_Provincias_Select(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Provincias_Select_Result>("pa_Provincias_Select", nombreParameter);
        }
    
        public virtual int pa_RegistroPoliza_Delete(Nullable<int> idRegistro)
        {
            var idRegistroParameter = idRegistro.HasValue ?
                new ObjectParameter("IdRegistro", idRegistro) :
                new ObjectParameter("IdRegistro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_RegistroPoliza_Delete", idRegistroParameter);
        }
    
        public virtual int pa_RegistroPoliza_Insert(Nullable<int> idCobertura, Nullable<int> idCliente, Nullable<float> montoAsegurado, Nullable<int> numeroAdicciones)
        {
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var montoAseguradoParameter = montoAsegurado.HasValue ?
                new ObjectParameter("MontoAsegurado", montoAsegurado) :
                new ObjectParameter("MontoAsegurado", typeof(float));
    
            var numeroAdiccionesParameter = numeroAdicciones.HasValue ?
                new ObjectParameter("NumeroAdicciones", numeroAdicciones) :
                new ObjectParameter("NumeroAdicciones", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_RegistroPoliza_Insert", idCoberturaParameter, idClienteParameter, montoAseguradoParameter, numeroAdiccionesParameter);
        }
    
        public virtual ObjectResult<pa_RegistroPoliza_Select_Result> pa_RegistroPoliza_Select()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_RegistroPoliza_Select_Result>("pa_RegistroPoliza_Select");
        }
    
        public virtual int pa_RegistroPoliza_Update(Nullable<int> idRegistroPoliza, Nullable<int> idCobertura, Nullable<int> idCliente, Nullable<float> montoAsegurado, Nullable<int> numeroAdicciones)
        {
            var idRegistroPolizaParameter = idRegistroPoliza.HasValue ?
                new ObjectParameter("IdRegistroPoliza", idRegistroPoliza) :
                new ObjectParameter("IdRegistroPoliza", typeof(int));
    
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var montoAseguradoParameter = montoAsegurado.HasValue ?
                new ObjectParameter("MontoAsegurado", montoAsegurado) :
                new ObjectParameter("MontoAsegurado", typeof(float));
    
            var numeroAdiccionesParameter = numeroAdicciones.HasValue ?
                new ObjectParameter("NumeroAdicciones", numeroAdicciones) :
                new ObjectParameter("NumeroAdicciones", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_RegistroPoliza_Update", idRegistroPolizaParameter, idCoberturaParameter, idClienteParameter, montoAseguradoParameter, numeroAdiccionesParameter);
        }
    
        public virtual ObjectResult<pa_Usuarios_Select_Result> pa_Usuarios_Select(string nombreUsuario)
        {
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Usuarios_Select_Result>("pa_Usuarios_Select", nombreUsuarioParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<pa_Distritos_Select_Result> pa_Distritos_Select(string nombre, Nullable<int> id_Canton)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Distritos_Select_Result>("pa_Distritos_Select", nombreParameter, id_CantonParameter);
        }
    
        public virtual int pa_Clientes_Insert(Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string nombre, string primerApellido, string segundoApellido, Nullable<int> telefono, string correo, string direccionFisica, Nullable<int> idProvincia, Nullable<int> idCanton, Nullable<int> idDistrito, string contrasenia, string tipoUsuario)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var direccionFisicaParameter = direccionFisica != null ?
                new ObjectParameter("DireccionFisica", direccionFisica) :
                new ObjectParameter("DireccionFisica", typeof(string));
    
            var idProvinciaParameter = idProvincia.HasValue ?
                new ObjectParameter("IdProvincia", idProvincia) :
                new ObjectParameter("IdProvincia", typeof(int));
    
            var idCantonParameter = idCanton.HasValue ?
                new ObjectParameter("IdCanton", idCanton) :
                new ObjectParameter("IdCanton", typeof(int));
    
            var idDistritoParameter = idDistrito.HasValue ?
                new ObjectParameter("IdDistrito", idDistrito) :
                new ObjectParameter("IdDistrito", typeof(int));
    
            var contraseniaParameter = contrasenia != null ?
                new ObjectParameter("Contrasenia", contrasenia) :
                new ObjectParameter("Contrasenia", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_Clientes_Insert", cedulaParameter, generoParameter, fechaNacimientoParameter, nombreParameter, primerApellidoParameter, segundoApellidoParameter, telefonoParameter, correoParameter, direccionFisicaParameter, idProvinciaParameter, idCantonParameter, idDistritoParameter, contraseniaParameter, tipoUsuarioParameter);
        }
    
        public virtual ObjectResult<pa_Distrito_Select_Result> pa_Distrito_Select(string nombre, Nullable<int> id_Canton)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_Distrito_Select_Result>("pa_Distrito_Select", nombreParameter, id_CantonParameter);
        }
    }
}
