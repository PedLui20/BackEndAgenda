using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgenda.Infraestructure.Database.Entities;

[Table("Participante", Schema = "AGD")]
public class ParticipanteEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("email")]
    public string Email { get; set; }

    // Relación con eventos a través de la tabla intermedia EventoParticipante
    public virtual ICollection<EventoParticipanteEntity> Eventos { get; set; }
}