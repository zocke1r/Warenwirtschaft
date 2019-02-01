--Stored Procedure [Insert]

--dbo.Adresse
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertAdressRow]
    @Strasse nvarchar(20) = "Not Set",
    @Hausnummer nvarchar(5) = "Not Set",
    @Ort nvarchar(20) = "Not Set",
    @PLZ nvarchar (20) = "Not Set",
    @Adresszusatz (5) = "Not Set"
AS
BEGIN
    INSERT INTO dbo.Adresse (Strasse, Hausnummer, Ort, PLZ, Adresszusatz) 
    VALUES(@Strasse, @Hausnummer, @Ort, @PLZ, @Adresszusatz)
END
--------------------------------------------------------------------------------------------------------------
--dbo.AusgangsRechnung
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertAusgangsrechnungRow]
    @Nummer NVARCHAR(20) = "Not Set",
    @Datum DATE = GetDate(),
    @Status int,
    @Betrag numeric(15,4) = 0
AS
BEGIN
    INSERT INTO dbo.AusgangsRechnung (Nummer, Datum, Status, Betrag)
    VALUES(@Nummer, @Datum, @Status, @Betrag)
END
--------------------------------------------------------------------------------------------------------------
--dbo.AusgangsrechnungPosition
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertAusgangsrechnungPositionRow]
    @Anzahl int = 0,
    @Preis numeric(15,4) = 0,
    @Ausgangsrechnung int,
    @Artikel int
AS
BEGIN
    INSERT INTO dbo.AusgangsrechnungPositiion (Anzahl, Preis, Ausgangsrechnung, Artikel)
    VALUES(@Anzahl, @Preis, @Ausgangsrechnung, @Artikel)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Benutzer
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertBenutzerRow]
    @Name NVARCHAR(50) = "Not Set",
    @Password NVARCHAR(50) = "Not Set",
    @Adresse int,
    @Email NVARCHAR(50) = "NOT Set",
    @Berechtigung int = 0,
    @Telefon NVARCHAR(50) = "Not Set"
AS
BEGIN
    INSERT INTO dbo.Benutzer (Name, Password, Adresse, Email, Berechtigung, Telefon)
    VALUES(@Name, @Password, @Adresse, @Email, @Berechtigung, @Telefon)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Bestellung
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertBestellungRow]
    @Nummer NVARCHAR(50) = "Not Set",
    @Datum Date = GetDate(),
    @Lieferant int,
    @Status int,
    @Betrag NUMERIC(15,4) = 0
AS
BEGIN
    INSERT INTO dbo.Bestellung (Nummer, Datum, Lieferant, Status, Betrag)
    VALUES(@Nummer, @Datum, @Lieferant, @Status, @Betrag)
END
--------------------------------------------------------------------------------------------------------------
--dbo.BestellungPosition
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertbestellungPositionRow]
    @Anzahl int = 0,
    @Preis numeric(15,4) = 0,
    @Bestellung int,
    @Artikel int
AS
BEGIN
    INSERT INTO dbo.Benutzer (Anzahl, Preis, Bestellung, Artikel)
    VALUES(@Anzahl, @Preis, @Bestellung, @Artikel)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Status
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertStatusRow]
    @Numeral int = 0,
    @Bezeichnung nvarchar(50) = "Not Set"
AS
BEGIN
    INSERT INTO dbo.Status (Numeral, Bezeichnung)
    VALUES(@Numeral, @Bezeichnung)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Model
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertModelRow]
    @Hersteller int, 
    @Bezeichnung NVARCHAR(50) = "Not Set"
AS
BEGIN
    INSERT INTO dbo.Model (Hersteller, Bezeichnung)
    VALUES(@Hersteller, @Bezeichnung)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Live_Artikel
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertLiveArtikelRow]   
    @Model int, 
    @Groesse int, 
    @EAN NVARCHAR(255) = "Not Set",    
    @EK numeric(15,4) = 0,
    @VK numeric(15,4) = 0,    
    @Bestand int = 0
AS
BEGIN
    INSERT INTO dbo.Live_Artikel (Model, Groesse, EAN, EK, VK, Bestand)
    VALUES(@Model, @Groesse, @EAN, @EK, @VK, @Bestand)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Kategorie
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertKategorieRow]  
    @Bezeichnung nvarchar(50) = 'Not Set'
AS
BEGIN
    INSERT INTO dbo.Kategorie (Bezeichnung)
    VALUES(@Bezeichnung)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Hersteller
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertHerstellerRow]
    @Adresse int,
    @Name nvarchar(50) = 'Not Set'
AS
BEGIN
    INSERT INTO dbo.Hersteller (Adresse, Name)
    VALUES(@Adresse,@Name)
END
--------------------------------------------------------------------------------------------------------------
--dbo.Groesse
--------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[InsertGroesseRow]
    @US nvarchar(50) = 'Not Set',
    @EU nvarchar(50) = 'Not Set',
    @GB nvarchar(50) = 'Not Set',
    @cm numeric(15,4) = 0
AS
BEGIN
    INSERT INTO dbo.Hersteller (US, EU, GB, cm)
    VALUES(@US,@EU,@GB,@cm)
END
--------------------------------------------------------------------------------------------------------------
