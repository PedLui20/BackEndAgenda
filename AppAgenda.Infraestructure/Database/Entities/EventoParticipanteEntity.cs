using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgenda.Infraestructure.Database.Entities;

[Table("EventoParticipante", Schema = "AGD")]
public class EventoParticipanteEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("idEvento")]
    public int IdEvento { get; set; }

    [Column("idParticipante")]
    public int IdParticipante { get; set; }

    // Relación con Evento
    [ForeignKey("IdEvento")]
    public virtual EventoEntity Evento { get; set; }

    // Relación con Participante
    [ForeignKey("IdParticipante")]
    public virtual ParticipanteEntity Participante { get; set; }
}