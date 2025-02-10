-- Insertion de l'application
INSERT INTO Application (Name, Label, Description, Icon, Version)
VALUES ('GestionEntreprise', 'Gestion d''Entreprise', 'Application pour gérer les employés, produits et clients', 'business_icon.png', '1.0.0');

-- Récupération de l'ID de l'application insérée
SELECT last_insert_rowid() AS ApplicationId;

-- Insertion des tables de la base de données
INSERT INTO DatabaseTable (Name, Label, Description)
VALUES 
    ('Employe', 'Employé', 'Table pour stocker les informations des employés'),
    ('Produit', 'Produit', 'Table pour stocker les informations des produits'),
    ('Client', 'Client', 'Table pour stocker les informations des clients');

-- Récupération des IDs des tables insérées
SELECT Id AS EmployeTableId FROM DatabaseTable WHERE Name = 'Employe';
SELECT Id AS ProduitTableId FROM DatabaseTable WHERE Name = 'Produit';
SELECT Id AS ClientTableId FROM DatabaseTable WHERE Name = 'Client';

-- Insertion des colonnes pour la table Employe
INSERT INTO DatabaseColumn (Name, Label, Description, DataType, IsNullable, IsPrimaryKey, IsIndexed, TableId)
VALUES
    ('Id', 'ID', 'Identifiant unique de l''employé', 'INTEGER', 0, 1, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')),
    ('Nom', 'Nom', 'Nom de l''employé', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')),
    ('Prenom', 'Prénom', 'Prénom de l''employé', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')),
    ('Poste', 'Poste', 'Poste occupé par l''employé', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')),
    ('Salaire', 'Salaire', 'Salaire de l''employé', 'REAL', 1, 0, 0, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe'));

-- Insertion des colonnes pour la table Produit
INSERT INTO DatabaseColumn (Name, Label, Description, DataType, IsNullable, IsPrimaryKey, IsIndexed, TableId)
VALUES
    ('Id', 'ID', 'Identifiant unique du produit', 'INTEGER', 0, 1, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')),
    ('Nom', 'Nom', 'Nom du produit', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')),
    ('Prix', 'Prix', 'Prix du produit', 'REAL', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')),
    ('Stock', 'Stock', 'Quantité en stock', 'INTEGER', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit'));

-- Insertion des colonnes pour la table Client
INSERT INTO DatabaseColumn (Name, Label, Description, DataType, IsNullable, IsPrimaryKey, IsIndexed, TableId)
VALUES
    ('Id', 'ID', 'Identifiant unique du client', 'INTEGER', 0, 1, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Client')),
    ('Nom', 'Nom', 'Nom du client', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Client')),
    ('Email', 'Email', 'Adresse email du client', 'TEXT', 0, 0, 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Client')),
    ('Telephone', 'Téléphone', 'Numéro de téléphone du client', 'TEXT', 1, 0, 0, (SELECT Id FROM DatabaseTable WHERE Name = 'Client'));

-- Insertion des pages de l'application
INSERT INTO Page (Name, Label, Description, Icon)
VALUES
    ('GestionEmployes', 'Gestion des Employés', 'Page pour gérer les employés', 'employee_icon.png'),
    ('GestionProduits', 'Gestion des Produits', 'Page pour gérer les produits', 'product_icon.png'),
    ('GestionClients', 'Gestion des Clients', 'Page pour gérer les clients', 'client_icon.png');

-- Récupération des IDs des pages insérées
SELECT Id AS GestionEmployesPageId FROM Page WHERE Name = 'GestionEmployes';
SELECT Id AS GestionProduitsPageId FROM Page WHERE Name = 'GestionProduits';
SELECT Id AS GestionClientsPageId FROM Page WHERE Name = 'GestionClients';

-- Insertion des composants pour chaque page
INSERT INTO Component (Name, Label, Description, "Order", Icon, IsVisible, TableId, Type, HasPagination)
VALUES
    ('ListeEmployes', 'Liste des Employés', 'Affiche la liste des employés', 1, 'list_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe'), 'List', 1),
    ('FormulaireEmploye', 'Formulaire Employé', 'Formulaire pour ajouter/modifier un employé', 2, 'form_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Employe'), 'Form', 0),
    ('ListeProduits', 'Liste des Produits', 'Affiche la liste des produits', 1, 'list_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit'), 'List', 1),
    ('FormulaireProduit', 'Formulaire Produit', 'Formulaire pour ajouter/modifier un produit', 2, 'form_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Produit'), 'Form', 0),
    ('ListeClients', 'Liste des Clients', 'Affiche la liste des clients', 1, 'list_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Client'), 'List', 1),
    ('FormulaireClient', 'Formulaire Client', 'Formulaire pour ajouter/modifier un client', 2, 'form_icon.png', 1, (SELECT Id FROM DatabaseTable WHERE Name = 'Client'), 'Form', 0);

-- Liaison des composants aux pages
INSERT INTO PageComponent (PageId, ComponentId)
VALUES
    ((SELECT Id FROM Page WHERE Name = 'GestionEmployes'), (SELECT Id FROM Component WHERE Name = 'ListeEmployes')),
    ((SELECT Id FROM Page WHERE Name = 'GestionEmployes'), (SELECT Id FROM Component WHERE Name = 'FormulaireEmploye')),
    ((SELECT Id FROM Page WHERE Name = 'GestionProduits'), (SELECT Id FROM Component WHERE Name = 'ListeProduits')),
    ((SELECT Id FROM Page WHERE Name = 'GestionProduits'), (SELECT Id FROM Component WHERE Name = 'FormulaireProduit')),
    ((SELECT Id FROM Page WHERE Name = 'GestionClients'), (SELECT Id FROM Component WHERE Name = 'ListeClients')),
    ((SELECT Id FROM Page WHERE Name = 'GestionClients'), (SELECT Id FROM Component WHERE Name = 'FormulaireClient'));

-- Insertion des champs pour le formulaire Employé
INSERT INTO FormComponentField (Name, Label, Description, Type, "Order", ColumnId, ComponentId)
VALUES
    ('Nom', 'Nom', 'Nom de l''employé', 'Text', 1, (SELECT Id FROM DatabaseColumn WHERE Name = 'Nom' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')), (SELECT Id FROM Component WHERE Name = 'FormulaireEmploye')),
    ('Prenom', 'Prénom', 'Prénom de l''employé', 'Text', 2, (SELECT Id FROM DatabaseColumn WHERE Name = 'Prenom' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')), (SELECT Id FROM Component WHERE Name = 'FormulaireEmploye')),
    ('Poste', 'Poste', 'Poste de l''employé', 'Text', 3, (SELECT Id FROM DatabaseColumn WHERE Name = 'Poste' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')), (SELECT Id FROM Component WHERE Name = 'FormulaireEmploye')),
    ('Salaire', 'Salaire', 'Salaire de l''employé', 'Number', 4, (SELECT Id FROM DatabaseColumn WHERE Name = 'Salaire' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Employe')), (SELECT Id FROM Component WHERE Name = 'FormulaireEmploye'));

-- Insertion des champs pour le formulaire Produit
INSERT INTO FormComponentField (Name, Label, Description, Type, "Order", ColumnId, ComponentId)
VALUES
    ('Nom', 'Nom', 'Nom du produit', 'Text', 1, (SELECT Id FROM DatabaseColumn WHERE Name = 'Nom' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')), (SELECT Id FROM Component WHERE Name = 'FormulaireProduit')),
    ('Prix', 'Prix', 'Prix du produit', 'Number', 2, (SELECT Id FROM DatabaseColumn WHERE Name = 'Prix' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')), (SELECT Id FROM Component WHERE Name = 'FormulaireProduit')),
    ('Stock', 'Stock', 'Quantité en stock', 'Number', 3, (SELECT Id FROM DatabaseColumn WHERE Name = 'Stock' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Produit')), (SELECT Id FROM Component WHERE Name = 'FormulaireProduit'));

-- Insertion des champs pour le formulaire Client
INSERT INTO FormComponentField (Name, Label, Description, Type, "Order", ColumnId, ComponentId)
VALUES
    ('Nom', 'Nom', 'Nom du client', 'Text', 1, (SELECT Id FROM DatabaseColumn WHERE Name = 'Nom' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Client')), (SELECT Id FROM Component WHERE Name = 'FormulaireClient')),
    ('Email', 'Email', 'Email du client', 'Text', 2, (SELECT Id FROM DatabaseColumn WHERE Name = 'Email' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Client')), (SELECT Id FROM Component WHERE Name = 'FormulaireClient')),
    ('Telephone', 'Téléphone', 'Téléphone du client', 'Text', 3, (SELECT Id FROM DatabaseColumn WHERE Name = 'Telephone' AND TableId = (SELECT Id FROM DatabaseTable WHERE Name = 'Client')), (SELECT Id FROM Component WHERE Name = 'FormulaireClient'));


-- Insertion des éléments de menu pour l'application
INSERT INTO MenuElement (Name, Label, Description, Icon, "Order", IsVisible, PageId)
VALUES
    ('Employes', 'Employés', 'Menu pour gérer les employés', 'employee_icon.png', 1, 1, (SELECT Id FROM Page WHERE Name = 'GestionEmployes')),
    ('Produits', 'Produits', 'Menu pour gérer les produits', 'product_icon.png', 2, 1, (SELECT Id FROM Page WHERE Name = 'GestionProduits')),
    ('Clients', 'Clients', 'Menu pour gérer les clients', 'client_icon.png', 3, 1, (SELECT Id FROM Page WHERE Name = 'GestionClients'));
---- Supprime les tables si elles existent déjà (pour éviter les conflits)
--DROP TABLE IF EXISTS SelectedValues;
--DROP TABLE IF EXISTS FormComponentFields;
--DROP TABLE IF EXISTS FormComponents;
--DROP TABLE IF EXISTS ListComponents;
--DROP TABLE IF EXISTS ChartComponents;
--DROP TABLE IF EXISTS Components;
--DROP TABLE IF EXISTS Pages;
--DROP TABLE IF EXISTS MenuElements;
--DROP TABLE IF EXISTS Applications;
--DROP TABLE IF EXISTS DatabaseColumns;
--DROP TABLE IF EXISTS DatabaseTables;

---- Crée les tables

---- Table DatabaseTable
--CREATE TABLE DatabaseTable (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT
--);

---- Table DatabaseColumn
--CREATE TABLE DatabaseColumn (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    DataType TEXT NOT NULL,
--    IsNullable BOOLEAN NOT NULL,
--    IsPrimaryKey BOOLEAN NOT NULL,
--    IsIndexed BOOLEAN NOT NULL,
--    TableId INTEGER,
--    FOREIGN KEY (TableId) REFERENCES DatabaseTable(Id)
--);

---- Table Application
--CREATE TABLE Application (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    Icon TEXT,
--    Version TEXT
--);

---- Table MenuElement
--CREATE TABLE MenuElement (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    Icon TEXT,
--    `Order` INTEGER NOT NULL,
--    IsVisible BOOLEAN NOT NULL,
--    ParentId INTEGER,
--    PageId INTEGER,
--    FOREIGN KEY (ParentId) REFERENCES MenuElement(Id),
--    FOREIGN KEY (PageId) REFERENCES Page(Id)
--);

---- Table Page
--CREATE TABLE Page (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    Icon TEXT
--);

---- Table Component
--CREATE TABLE Component (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    `Order` INTEGER NOT NULL,
--    Icon TEXT,
--    IsVisible BOOLEAN NOT NULL,
--    ListComponentId INTEGER,
--    FormComponentId INTEGER,
--    ChartComponentId INTEGER,
--    FOREIGN KEY (ListComponentId) REFERENCES ListComponent(Id),
--    FOREIGN KEY (FormComponentId) REFERENCES FormComponent(Id),
--    FOREIGN KEY (ChartComponentId) REFERENCES ChartComponent(Id)
--);

---- Table ListComponent
--CREATE TABLE ListComponent (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    TableId INTEGER,
--    FOREIGN KEY (TableId) REFERENCES DatabaseTable(Id)
--);

---- Table FormComponent
--CREATE TABLE FormComponent (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Type TEXT NOT NULL,
--    TableId INTEGER,
--    FOREIGN KEY (TableId) REFERENCES DatabaseTable(Id)
--);

---- Table FormComponentField
--CREATE TABLE FormComponentField (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Name TEXT NOT NULL,
--    Label TEXT NOT NULL,
--    Description TEXT,
--    Type TEXT NOT NULL,
--    `Order` INTEGER NOT NULL,
--    ColumnId INTEGER,
--    FormComponentId INTEGER,
--    FOREIGN KEY (ColumnId) REFERENCES DatabaseColumn(Id),
--    FOREIGN KEY (FormComponentId) REFERENCES FormComponent(Id)
--);

---- Table ChartComponent
--CREATE TABLE ChartComponent (
--    Id INTEGER PRIMARY KEY AUTOINCREMENT,
--    Type TEXT NOT NULL,
--    TableId INTEGER,
--    XAxisColumnId INTEGER,
--    YAxisColumnId INTEGER,
--    Title TEXT,
--    ShowLegend BOOLEAN NOT NULL DEFAULT TRUE,
--    FOREIGN KEY (TableId) REFERENCES DatabaseTable(Id),
--    FOREIGN KEY (XAxisColumnId) REFERENCES DatabaseColumn(Id),
--    FOREIGN KEY (YAxisColumnId) REFERENCES DatabaseColumn(Id)
--);

---- Table SelectedValues (pour FormComponentFieldMultipleChoice)
--CREATE TABLE SelectedValues (
--    FormComponentFieldId INTEGER,
--    SelectedValue INTEGER,
--    PRIMARY KEY (FormComponentFieldId, SelectedValue),
--    FOREIGN KEY (FormComponentFieldId) REFERENCES FormComponentField(Id)
--);

---- Table Components (liaison entre Page et Component)
--CREATE TABLE Components (
--    PageId INTEGER,
--    ComponentId INTEGER,
--    PRIMARY KEY (PageId, ComponentId),
--    FOREIGN KEY (PageId) REFERENCES Page(Id),
--    FOREIGN KEY (ComponentId) REFERENCES Component(Id)
--);

---- Table MenuElements (liaison entre Application et MenuElement)
--CREATE TABLE MenuElements (
--    ApplicationId INTEGER,
--    MenuElementId INTEGER,
--    PRIMARY KEY (ApplicationId, MenuElementId),
--    FOREIGN KEY (ApplicationId) REFERENCES Application(Id),
--    FOREIGN KEY (MenuElementId) REFERENCES MenuElement(Id)
--);

---- Table Columns (liaison entre DatabaseTable et DatabaseColumn)
--CREATE TABLE Columns (
--    TableId INTEGER,
--    ColumnId INTEGER,
--    PRIMARY KEY (TableId, ColumnId),
--    FOREIGN KEY (TableId) REFERENCES DatabaseTable(Id),
--    FOREIGN KEY (ColumnId) REFERENCES DatabaseColumn(Id)
--);

---- Insère les données de démonstration

---- Application
--INSERT INTO Application (Name, Label, Description, Icon, Version)
--VALUES ('ProductManager', 'Product Manager', 'An application to manage products', 'app-icon.png', '1.0.0');

---- DatabaseTable
--INSERT INTO DatabaseTable (Name, Label, Description)
--VALUES ('Products', 'Products Table', 'Stores product information'),
--       ('Categories', 'Categories Table', 'Stores product categories');

---- DatabaseColumn
--INSERT INTO DatabaseColumn (Name, Label, Description, DataType, IsNullable, IsPrimaryKey, IsIndexed, TableId)
--VALUES ('Id', 'Product ID', 'Unique identifier for products', 'INTEGER', FALSE, TRUE, TRUE, 1),
--       ('Name', 'Product Name', 'Name of the product', 'TEXT', FALSE, FALSE, TRUE, 1),
--       ('Price', 'Product Price', 'Price of the product', 'REAL', FALSE, FALSE, TRUE, 1),
--       ('CategoryId', 'Category ID', 'Category of the product', 'INTEGER', TRUE, FALSE, TRUE, 1),
--       ('Id', 'Category ID', 'Unique identifier for categories', 'INTEGER', FALSE, TRUE, TRUE, 2),
--       ('Name', 'Category Name', 'Name of the category', 'TEXT', FALSE, FALSE, TRUE, 2);

---- Page
--INSERT INTO Page (Name, Label, Description, Icon)
--VALUES ('Home', 'Home Page', 'The main page of the application', 'home-icon.png'),
--       ('Products', 'Products Page', 'Page displaying products', 'products-icon.png'),
--       ('Categories', 'Categories Page', 'Page displaying categories', 'categories-icon.png');

---- MenuElement
--INSERT INTO MenuElement (Name, Label, Description, Icon, `Order`, IsVisible, ParentId, PageId)
--VALUES ('MainMenu', 'Main Menu', 'The main menu', 'menu-icon.png', 1, TRUE, NULL, 1),
--       ('ProductsMenu', 'Products Menu', 'Menu for products', 'products-icon.png', 2, TRUE, 1, 2),
--       ('CategoriesMenu', 'Categories Menu', 'Menu for categories', 'categories-icon.png', 3, TRUE, 1, 3);

---- ListComponent
--INSERT INTO ListComponent (TableId)
--VALUES (1);

---- FormComponent
--INSERT INTO FormComponent (Type, TableId)
--VALUES ('Create', 1);

---- FormComponentField
--INSERT INTO FormComponentField (Name, Label, Description, Type, `Order`, ColumnId, FormComponentId)
--VALUES ('ProductName', 'Product Name', 'Name of the product', 'Text', 1, 2, 1),
--       ('ProductPrice', 'Product Price', 'Price of the product', 'Number', 2, 3, 1),
--       ('CategoryId', 'Category', 'Category of the product', 'ComboBox', 3, 4, 1);

---- ChartComponent
--INSERT INTO ChartComponent (Type, TableId, XAxisColumnId, YAxisColumnId, Title, ShowLegend)
--VALUES ('Bar', 1, 2, 3, 'Product Prices', TRUE);

---- Component
--INSERT INTO Component (Name, Label, Description, `Order`, Icon, IsVisible, ListComponentId, FormComponentId, ChartComponentId)
--VALUES ('ProductList', 'Product List', 'Displays a list of products', 1, 'list-icon.png', TRUE, 1, NULL, NULL),
--       ('ProductForm', 'Product Form', 'Form for adding products', 2, 'form-icon.png', TRUE, NULL, 1, NULL),
--       ('ProductChart', 'Product Chart', 'Chart displaying product prices', 3, 'chart-icon.png', TRUE, NULL, NULL, 1);

---- Components (liaison entre Page et Component)
--INSERT INTO Components (PageId, ComponentId)
--VALUES (2, 1),
--       (2, 2),
--       (2, 3);

---- MenuElements (liaison entre Application et MenuElement)
--INSERT INTO MenuElements (ApplicationId, MenuElementId)
--VALUES (1, 1),
--       (1, 2),
--       (1, 3);

---- Columns (liaison entre DatabaseTable et DatabaseColumn)
--INSERT INTO Columns (TableId, ColumnId)
--VALUES (1, 1),
--       (1, 2),
--       (1, 3),
--       (1, 4),
--       (2, 5),
--       (2, 6);