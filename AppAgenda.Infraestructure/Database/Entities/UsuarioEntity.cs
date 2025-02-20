using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgenda.Infraestructure.Database.Entities;

[Table("Usuario", Schema = "AGD")]
public class UsuarioEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("nombre")]
    public string Nombre { get; set; }
    [Column("rol")]
    public string Rol { get; set; }
    
    public virtual ICollection<AgendaEntity> Agenda { get; set; }
}
