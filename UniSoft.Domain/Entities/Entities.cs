namespace UniSoft.Domain.Entities
{
    // Classe DatabaseTable
    public class DatabaseTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<DatabaseColumn> Columns { get; set; } = new List<DatabaseColumn>();
    }

    // Classe DatabaseColumn
    public class DatabaseColumn
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
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public List<MenuElement> MenuElements { get; set; } = new List<MenuElement>();
    }

    // Classe MenuElement
    public class MenuElement
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
        public Page? Page { get; set; }
    }

    // Classe Page
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<Component> Components { get; set; } = new List<Component>();
    }

    // Classe Component
    public class Component
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
        
        public DatabaseTable? Table { get; set; }
        public List<FormComponentField> Fields { get; set; } = new List<FormComponentField>();
    }

    public class PageComponent
    {
        public int PageId { get; set; }
        public int ComponentId { get; set; } 
    }

    // Classe FormField
    public class FormComponentField
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
        public DatabaseColumn? DisplayColumn { get; set; }
        public DatabaseColumn? Column { get; set; }
        public Component? Component { get; set; }

    }
    public enum FieldType
    {
        Text,
        TextArea,
        ComboBox,
        MultipleChoice,
        CheckBox,
        DateTime,
        Number
    }
    public enum ComponentType
    {
        List,
        Form
    }
    //// Classe ListComponent
    //public class ListComponent
    //{
    //    public int Id { get; set; }
    //    public bool HasPagination { get; set; }
    //}
    // Classe FormFieldText
    //public class FormComponentFieldText : FormComponentField
    //{
    //    public int Length { get; set; }
    //    public string Value { get; set; } = string.Empty;
    //    public string Regex { get; set; } = string.Empty;
    //}

    //// Classe FormFieldTextArea
    //public class FormComponentFieldTextArea : FormComponentField
    //{
    //    public int Length { get; set; }
    //    public string Value { get; set; } = string.Empty;
    //    public string Regex { get; set; } = string.Empty;
    //}

    //// Classe FormFieldComboBox
    //public class FormComponentFieldComboBox : FormComponentField
    //{
    //    public int SelectedValue { get; set; }
    //    public int TableId { get; set; }
    //    public DatabaseTable? Table { get; set; }
    //    public int DisplayColumnId { get; set; }
    //    public DatabaseColumn? DisplayColumn { get; set; }
    //}

    //// Classe FormFieldMultipleChoice
    //public class FormComponentFieldMultipleChoice : FormComponentField
    //{
    //    public int TableId { get; set; }
    //    public DatabaseTable? Table { get; set; }
    //    public int DisplayColumnId { get; set; }
    //    public DatabaseColumn? DisplayColumn { get; set; }
    //    public List<int> SelectedValues { get; set; } = new List<int>();
    //}

    //// Classe FormFieldDateTime
    //public class FormComponentFieldDateTime : FormComponentField
    //{
    //    public bool HasTime { get; set; }
    //    public DateTime Date { get; set; }
    //}

    //// Classe FormFieldNumber
    //public class FormComponentFieldNumber : FormComponentField
    //{
    //    public int Value { get; set; }
    //}

    //// Classe ChartComponent
    //public class ChartComponent
    //{
    //    public int Id { get; set; }
    //    public ChartType Type { get; set; }
    //    public int TableId { get; set; }
    //    public DatabaseTable? Table { get; set; }
    //    public int XAxisColumnId { get; set; }
    //    public DatabaseColumn? XAxisColumn { get; set; }
    //    public int YAxisColumnId { get; set; }
    //    public DatabaseColumn? YAxisColumn { get; set; }
    //    public string Title { get; set; } = string.Empty;
    //    public bool ShowLegend { get; set; } = true;
    //}

    //// Enums
    //public enum FormType
    //{
    //    Create,
    //    Update,
    //    Delete,
    //    View
    //}
    //// Classe FormComponent
    //public class FormComponent
    //{
    //    public int Id { get; set; }
    //    public FormType Type { get; set; }
    //    public List<FormComponentField> Fields { get; set; } = new List<FormComponentField>();
    //}



    //public enum ChartType
    //{
    //    Bar,
    //    Pie,
    //    Line,
    //    Scatter,
    //    Area
    //}


}