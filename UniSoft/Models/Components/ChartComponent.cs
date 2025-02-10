using UniSoft.Enums;

namespace UniSoft.Models.Modules
{
    internal class ChartComponent : BaseComponent
    {
        internal ChartType Type { get; set; }
        internal DynamicDatabaseTable Table { get; set; } = new();
    }
    
}