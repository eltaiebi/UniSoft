using UniSoft.Models.Modules;

namespace UniSoft.Models
{
    internal class Application : BaseEntity
    {
        internal string Icon { get; set; } = string.Empty;
        internal string Version { get; set; } = string.Empty;
        internal List<MenuElement> MenuElements { get; set; } = new();
    }
    internal class MenuElement : BaseEntity
    {
        internal string Icon { get; set; } = string.Empty;
        internal int Order { get; set; }
        internal bool IsVisible { get; set; }
        internal MenuElement? Parent { get; set; }
        internal Page? Page { get; set; }
    }

    // Représentation d'une page contenant des modules
    internal class Page : BaseEntity
    {
        internal string Icon { get; set; } = string.Empty;
        internal List<BaseComponent> Components { get; set; } = new();
    }
}