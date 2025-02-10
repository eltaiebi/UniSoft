namespace UniSoft.Models.Modules
{
    internal class ListComponent : BaseComponent
    {
        internal DynamicDatabaseTable Table { get; set; } = new();
    }
}