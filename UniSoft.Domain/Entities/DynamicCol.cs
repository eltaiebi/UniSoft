namespace UniSoft.Domain.Entities
{
    public class DynamicCol
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string TypeSql { get; set; }
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