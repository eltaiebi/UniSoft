namespace UniSoft.Models.Modules
{
    // Classe de base pour tous les modules
    internal abstract class BaseComponent : BaseEntity
    {
        internal string Icon { get; set; } = string.Empty;
        internal bool IsVisible { get; set; }
    }
}