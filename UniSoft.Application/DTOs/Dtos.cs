using System.ComponentModel;

namespace UniSoft.Application.DTOs
{
    // Classe DatabaseTable
    public class DatabaseTableDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<DatabaseColumnDto> Columns { get; set; } = new List<DatabaseColumnDto>();
    }

    // Classe DatabaseColumn
    public class DatabaseColumnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public bool IsNullable { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsIndexed { get; set; }
        public int TableId { get; set; }
    }

    // Classe Application
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public List<MenuElementDto> MenuElements { get; set; } = new List<MenuElementDto>();
    }

    // Classe MenuElement
    public class MenuElementDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsVisible { get; set; }
        public int? ParentId { get; set; }
        public int? PageId { get; set; }
        public PageDto? Page { get; set; }
    }

    // Classe Page
    public class PageDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<ComponentDto> Components { get; set; } = new List<ComponentDto>();
    }

    // Classe Component
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Icon { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public int TableId { get; set; }
        public ComponentType Type { get; set; }
        public bool? HasPagination { get; set; }

        public DatabaseTableDto? Table { get; set; }
        public List<FormComponentFieldDto> Fields { get; set; } = new List<FormComponentFieldDto>();
    }

    public class PageComponentDto
    {
        public int PageId { get; set; }
        public int ComponentId { get; set; }
    }

    // Classe FormField
    public class FormComponentFieldDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public FieldType Type { get; set; }
        public int Order { get; set; }
        public int ColumnId { get; set; }
        public int ComponentId { get; set; }
        public int? Length { get; set; }
        public string? Value { get; set; } = string.Empty;
        public string? Regex { get; set; } = string.Empty;
        public int? DisplayColumnId { get; set; }
        public DatabaseColumnDto? DisplayColumn { get; set; }
        public DatabaseColumnDto? Column { get; set; }
        public ComponentDto? Component { get; set; }

    }
    public enum FieldType
    {
        Text = 0,
        TextArea = 1,
        ComboBox = 2,
        MultipleChoice = 3,
        CheckBox = 4,
        DateTime = 5,
        Number = 6
    }
    public enum ComponentType
    {
        List,
        Form
    }
}