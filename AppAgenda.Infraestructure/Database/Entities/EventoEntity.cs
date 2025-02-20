using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgenda.Infraestructure.Database.Entities;

[Table("Evento", Schema = "AGD")]
public class EventoEntity//: BaseEntity, IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("nombre")]
    public string Nombre { get; set; }
    [Column("descripcion")]
    public string Descripcion { get; set; }
    [Column("fecha")]
    public DateTime Fecha { get; set; }
    [Column("lugar")]
    public string Lugar { get; set; }
    [Column("cantidadParticipantes")]
    public int CantidadParticipantes { get; set; }
    
    public virtual ICollection<AgendaEntity> Agenda { get; set; }
    public virtual ICollection<EventoParticipanteEntity> Participantes { get; set; }

}