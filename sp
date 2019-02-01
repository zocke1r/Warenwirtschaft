--Stored Procedure [UPDATE]

--dbo.Adresse
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateAdressRow]
    @ID uniqueidentifier,
    @Strasse nvarchar(20) = "Not Set",
    @Hausnummer nvarchar(5) = "Not Set",
    @Ort nvarchar(20) = "Not Set",
    @PLZ nvarchar (20) = "Not Set",
    @Adresszusatz (5) = "Not Set"
AS
BEGIN
    UPDATE dbo.Adresse
    SET Strasse=@Strasse, Hausnummer=@Hausnummer, Ort=@Ort, PLZ=@PLZ, Adresszusatz=@Adresszusatz
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
--dbo.AusgangsRechnung
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateAusgangsrechnungRow]
    @ID uniqueidentifier,
    @Nummer NVARCHAR(20) = "Not Set",
    @Datum DATE = GetDate(),
    @Status INT(20),
    @Betrag numeric(15,4) = 0
AS
BEGIN
    UPDATE dbo.AusgangsRechnung
    SET Nummer=@Nummer, Datum=@Datum, Status=@Status, Betrag=@Betrag
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
--dbo.AusgangsrechnungPosition
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateAusgangsrechnungPositionRow]
    @ID uniqueidentifier,
    @Anzahl INT(20) = 0,
    @Preis numeric(15,4) = 0,
    @Ausgangsrechnung INT(20),
    @Artikel INT(20),
    @Anzahl INT(20) = 0
AS
BEGIN
    UPDATE dbo.AusgangsrechnungPositiion
    SET Anzahl=@Anzahl, Preis=@Preis, Ausgangsrechnung=@Ausgangsrechnung, Artikel=@Artikel, Anzahl=@Anzahl
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
--dbo.Benutzer
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateBenutzerRow]
    @ID uniqueidentifier,
    @Name NVARCHAR(50) = "Not Set",
    @Password NVARCHAR(50) = "Not Set",
    @Adresse INT(20),
    @Email NVARCHAR(50) = "NOT Set",
    @Berechtigung INT(20) = 0,
    @Telefon NVARCHAR(50) = "Not Set"
AS
BEGIN
    UPDATE dbo.Benutzer
    SET Name=@Name, Password=@Password, Adresse=@Adresse, Email=@Email, Berechtigung=@Berechtigung, Telefon=@Telefon
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
--dbo.Bestellung
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateBestellungRow]
    @ID uniqueidentifier,
    @Nummer NVARCHAR(50) = "Not Set",
    @Datum Date = GetDate(),
    @Lieferant INT(20),
    @Status INT(50),
    @Betrag NUMERIC(15,4) = 0
AS
BEGIN
    UPDATE dbo.Benutzer
    SET Nummer=@Nummer, Datum=@Datum, Lieferant=@Lieferant, Status=@Status, Betrag=@Betrag
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
--dbo.BestellungPosition
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdatebestellungPositionRow]
    @ID uniqueidentifier,
    @Anzahl INT(50) = 0,
    @Preis numeric(15,4) = 0,
    @Bestellung INT(20),
    @Artikel INT(50)
AS
BEGIN
    UPDATE dbo.Benutzer
    SET Anzahl=@Anzahl, Preis=@Preis, Bestellung=@Bestellung, Artikel=@Artikel
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
