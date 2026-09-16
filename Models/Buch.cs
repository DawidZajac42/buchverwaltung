using System.ComponentModel.DataAnnotations;

namespace Buchverwaltung.Models;

public class Buch
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Titel wird benötigt")]
    [StringLength(200)]
    public string Titel { get; set; } = string.Empty;

    [Required(ErrorMessage = "Autor wird benötigt")]
    [StringLength(100)]
    public string Autor { get; set; } = string.Empty;

    [Range(1500, 2100, ErrorMessage = "Bitte ein gültiges Jahr angeben")]
    public int Erscheinungsjahr { get; set; }

    public bool Gelesen { get; set; }
}
