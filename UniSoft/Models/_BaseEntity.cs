namespace UniSoft.Models
{
    internal abstract class BaseEntity
    {
        internal int Id { get; set; } // Obligatoire : identifiant unique
        internal string Name { get; set; } // Obligatoire : nom de l'entité
        internal string Label { get; set; } // Obligatoire : label affiché
        internal string Description { get; set; } = string.Empty; // Description optionnelle
    }
}