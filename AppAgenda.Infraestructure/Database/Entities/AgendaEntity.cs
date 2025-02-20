using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgenda.Infraestructure.Database.Entities;

[Table("Agenda", Schema = "AGD")]
public class AgendaEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Column("idEvento")] 
    public int IdEvento { get; set; }

    [ForeignKey("IdUsuario")]
    public virtual UsuarioEntity Usuario { get; set; }

    // Relación con Evento
    [ForeignKey("IdEvento")]
    public virtual EventoEntity Evento { get; set; }
    
}