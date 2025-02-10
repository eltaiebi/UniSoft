using UniSoft.Enums;

namespace UniSoft.Models.Modules
{
    // Module pour les formulaires
    internal class FormComponent : BaseComponent
    {
        internal FormType Type { get; set; }
        internal List<FormField> Fields { get; set; } = new();
        internal DynamicDatabaseTable Table { get; set; } = new();
    }
    // Champ de base pour les formulaires
    internal abstract class FormField : BaseEntity
    {
        internal FieldType Type { get; set; }
        internal int Order { get; set; }
        internal string Regex { get; set; } = string.Empty;
        internal DynamicDatabaseColumn Column { get; set; } = new();
    }

    // Champ texte
    internal class FormFieldText : FormField
    {
        internal int Length { get; set; }
        internal string Value { get; set; } = string.Empty;
    }

    // Champ zone de texte
    internal class FormFieldTextArea : FormField
    {
        internal int Length { get; set; }
        internal string Value { get; set; } = string.Empty;
    }

    // Champ ComboBox
    internal class FormFieldComboBox : FormField
    {
        internal int SelectedValue { get; set; }
        internal DynamicDatabaseTable Table { get; set; } = new();
        internal DynamicDatabaseColumn DisplayColumn { get; set; } = new();
    }

    // Champ à choix multiple
    internal class FormFieldMultipleChoice : FormField
    {
        internal DynamicDatabaseTable Table { get; set; } = new();
        internal DynamicDatabaseColumn DisplayColumn { get; set; } = new();
        internal List<int> SelectedValues { get; set; } = new();
    }
    internal class FormFieldDateTime : FormField
    {
        internal bool HasTime { get; set; }
        internal DateTime Date { get; set; }
    }

    internal class FormFieldNumber : FormField
    {
        internal int Value { get; set; }
    }
}