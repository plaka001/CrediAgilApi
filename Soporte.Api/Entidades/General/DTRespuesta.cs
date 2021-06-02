namespace Soporte.Api.Entidades.General
{
   public class DTRespuesta<TEntity>
    {
        public TEntity Data { get; set; }
        public DTMensaje Mensaje { get; set; }
    }
}
