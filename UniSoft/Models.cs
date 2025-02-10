//using System;
//using System.Collections.Generic;

//namespace UniSoft
//{
//    #region Base
//    internal abstract class BaseEntity
//    {
//        internal int Id { get; set; }
//        internal string Name { get; set; } = string.Empty;
//        internal string Label { get; set; } = string.Empty;
//        internal string Description { get; set; } = string.Empty;
//    }
//    #endregion

//    #region Data
//    internal class DynamicDataBaseTable : BaseEntity
//    {
//        internal int ColumnId { get; set; }
//    }
//    internal class DynamicDatabaseColumn : BaseEntity
//    {
//        internal string DataType { get; set; } = string.Empty;
//        internal bool IsNullable { get; set; }
//        internal bool IsPrimaryKey { get; set; }
//        internal bool IsIndexed { get; set; }
//        internal int TableId { get; set; }
//    }
//    #endregion


//    #region Graphique

//    #endregion
//    // Represents an application in the system
//    internal class Application : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal string Version { get; set; } = string.Empty;

//        // Navigation property for related Menus
//        internal List<MenuElement> MenuElements { get; set; } = new();
//    }

//    // Represents a menu or a menu item
//    internal class MenuElement : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;
//        internal int Order { get; set; }

//        // Parent-child hierarchy for menu elements
//        internal int? ParentId { get; set; }
//        internal MenuElement? Parent { get; set; }
//        internal List<MenuElement> Children { get; set; } = new();

//        // Navigation property for linked Page
//        internal int? PageId { get; set; }
//        internal Page? Page { get; set; }
//    }

//    // Represents a page in the system
//    internal class Page : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;

//        // Navigation property for related modules
//        internal List<Module> Modules { get; set; } = new();
//    }

//    // Base class for modules (e.g., Form, List, Chart)
//    internal abstract class Module : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;

//    }

//    // Represents a form module
//    internal class FormModule : Module
//    {
//        // Type of form (e.g., Create, Update)
//        internal FormType Type { get; set; }
//        internal int IdTable { get; set; }
//        // Navigation property for fields
//        internal List<FormField> Fields { get; set; } = new();
//        internal DynamicDataBaseTable Table { get; set; }
//    }

//    // Base class for form fields
//    internal abstract class FormField : BaseEntity
//    {
//        internal string Icon { get; set; } = string.Empty;

//        // Type of field (e.g., Text, ComboBox)
//        internal FieldType Type { get; set; }

//        // Order of the field in the form
//        internal int Order { get; set; }

//        // Regex for validation
//        internal string Regex { get; set; } = string.Empty;
        
//        internal int ColumnId { get; set; }

//    }

//    // Specific field types inheriting from FormField
//    internal class FormFieldText : FormField {

//        internal int Length { get; set; }
//        internal string Value { get; set; }
//    }
//    internal class FormFieldTextArea : FormField {
//        internal int Length { get; set; }
//        internal string Value { get; set; }
//    }
//    internal class FormFieldComboBox : FormField {
//        internal int Value { get; set; }
//        internal bool TableId { get; set; }
//        internal bool SelectColumnId { get; set; }
//        internal bool DisplayColumnId { get; set; }


//    }
//    internal class FormFieldMultipleChoice : FormField { 
    
//    }
//    internal class FormFieldCheckBox : FormField { }

//    // Represents a list module
//    internal class ListModule : Module
//    {
        
//    }

//    // Represents a chart module
//    internal class ChartModule : Module
//    {
//        // Additional properties specific to ChartModule can go here
//    }

//    // Enum for field types
//    internal enum FieldType
//    {
//        Text,
//        TextArea,
//        ComboBox,
//        MultipleChoice,
//        CheckBox
//    }

//    // Enum for form types
//    internal enum FormType
//    {
//        Create,
//        Update
//    }
//}
