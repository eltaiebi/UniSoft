namespace UniSoft.Models
{
    internal class DynamicDatabaseTable : BaseEntity
    {
        internal List<DynamicDatabaseColumn> Columns { get; set; } = new();
    }
    internal class DynamicDatabaseColumn : BaseEntity
    {
        internal string DataType { get; set; } = string.Empty;
        internal bool IsNullable { get; set; }
        internal bool IsPrimaryKey { get; set; }
        internal bool IsIndexed { get; set; }
    }
}