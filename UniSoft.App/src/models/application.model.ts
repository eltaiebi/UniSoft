// application.model.ts
export interface Application {
  id: number;
  name: string;
  label: string;
  description: string;
  icon: string;
  version: string;
  menuElements: MenuElement[];
}

export interface MenuElement {
  id: number;
  name: string;
  label: string;
  description: string;
  icon: string;
  order: number;
  isVisible: boolean;
  parentId: number | null;
  pageId: number | null;
  page: Page | null;
}

export interface Page {
  id: number;
  name: string;
  label: string;
  description: string;
  icon: string;
  components: ComponentDB[];
}

export interface ComponentDB {
  id: number;
  name: string;
  label: string;
  description: string;
  order: number;
  icon: string;
  isVisible: boolean;
  tableId: number;
  type: ComponentType;
  hasPagination?: boolean;
  table: DatabaseTable | null;
  fields: FormComponentField[];
}

export interface DatabaseTable {
  id: number;
  name: string;
  label: string;
  description: string;
  columns: DatabaseColumn[];
}

export interface DatabaseColumn {
  id: number;
  name: string;
  label: string;
  description: string;
  dataType: string;
  isNullable: boolean;
  isPrimaryKey: boolean;
  isIndexed: boolean;
  tableId: number;
}

export interface FormComponentField {
  id: number;
  name: string;
  label: string;
  description: string;
  type: FieldType;
  order: number;
  columnId: number;
  componentId: number;
  length?: number | null;
  value?: string;
  regex?: string;
  displayColumnId?: number | null;
  displayColumn?: DatabaseColumn | null;
  column?: DatabaseColumn | null;
  component?: ComponentDB | null;
}

export enum FieldType {
  Text = 0,
  TextArea = 1,
  ComboBox = 2,
  MultipleChoice = 3,
  CheckBox = 4,
  DateTime = 5,
  Number = 6
}

export enum ComponentType {
  List = 0,
  Form = 1
}
export interface DynamicData {
  data: any[]; // Type 'any' car les données sont dynamiques
}

export interface DynamicLine {
  rows: DynamicCol[] 
}
export interface DynamicCol {
  columnName : string;
  value : string;
  typesql: string
}