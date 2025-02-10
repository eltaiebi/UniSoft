//using System;
//using System.Collections.Generic;

//namespace UniSoft
//{
//    internal abstract class BaseEntity
//    {
//        internal int Id { get; set; } // Identifiant unique obligatoire
//        internal string Name { get; set; } = string.Empty; // Nom obligatoire
//        internal string Label { get; set; } = string.Empty; // Label affiché obligatoire
//        internal string Description { get; set; } = string.Empty; // Description optionnelle
//    }

//    internal sealed class DatabaseTable : BaseEntity
//    {
//        internal List<DatabaseColumn> Columns { get; set; } = new();
//    }

//    internal sealed class DatabaseColumn : BaseEntity
//    {
//        internal string DataType { get; set; } = string.Empty;
//        internal bool IsNullable { get; set; }
//        internal bool IsPrimaryKey { get; set; }
//        internal bool IsIndexed { get; set; }
//    }

//    internal sealed class Application : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal string Version { get; set; } = string.Empty;
//        internal List<MenuElement> MenuElements { get; set; } = new();
//    }

//    internal sealed class MenuElement : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal int Order { get; set; }
//        internal bool IsVisible { get; set; }
//        internal MenuElement? Parent { get; set; }
//        internal Page? Page { get; set; }
//    }

//    internal sealed class Page : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal List<BaseComponent> Components { get; set; } = new();
//    }

//    internal abstract class BaseComponent : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal bool IsVisible { get; set; }
//    }

//    internal sealed class ListComponent : BaseComponent
//    {
//        internal DatabaseTable Table { get; set; } = new();
//    }

//    internal sealed class FormComponent : BaseComponent
//    {
//        internal FormType Type { get; set; }
//        internal List<FormField> Fields { get; set; } = new();
//        internal DatabaseTable Table { get; set; } = new();
//    }

//    internal abstract class FormField : BaseEntity
//    {
//        internal FieldType Type { get; set; }
//        internal int Order { get; set; }
//        internal DatabaseColumn Column { get; set; } = new();
//    }

//    internal sealed class FormFieldText : FormField
//    {
//        internal int Length { get; set; }
//        internal string Value { get; set; } = string.Empty;
//        internal string Regex { get; set; } = string.Empty;
//    }

//    internal sealed class FormFieldTextArea : FormField
//    {
//        internal int Length { get; set; }
//        internal string Value { get; set; } = string.Empty;
//        internal string Regex { get; set; } = string.Empty;
//    }

//    internal sealed class FormFieldComboBox : FormField
//    {
//        internal int SelectedValue { get; set; }
//        internal DatabaseTable Table { get; set; } = new();
//        internal DatabaseColumn DisplayColumn { get; set; } = new();
//    }

//    internal sealed class FormFieldMultipleChoice : FormField
//    {
//        internal DatabaseTable Table { get; set; } = new();
//        internal DatabaseColumn DisplayColumn { get; set; } = new();
//        internal List<int> SelectedValues { get; set; } = new();
//    }

//    internal sealed class FormFieldDateTime : FormField
//    {
//        internal bool HasTime { get; set; }
//        internal DateTime Date { get; set; }
//    }

//    internal sealed class FormFieldNumber : FormField
//    {
//        internal int Value { get; set; }
//    }

    
//    internal sealed class ChartComponent : BaseComponent
//    {
//        internal ChartType Type { get; set; }
//        internal DatabaseTable Table { get; set; } = new();
//        internal DatabaseColumn XAxisColumn { get; set; }
//        internal DatabaseColumn YAxisColumn { get; set; }
//        internal string Title { get; set; } = string.Empty;
//        internal bool ShowLegend { get; set; } = true;
//    }

//    internal enum FormType
//    {
//        Create,
//        Update,
//        Delete,
//        View
//    }

//    internal enum FieldType
//    {
//        Text,
//        TextArea,
//        ComboBox,
//        MultipleChoice,
//        CheckBox,
//        DateTime,
//        Number
//    }

//    internal enum ChartType
//    {
//        Bar,
//        Pie,
//        Line,
//        Scatter,
//        Area
//    }
//}
