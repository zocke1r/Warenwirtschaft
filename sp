Stored Procedure [UPDATE]

dbo.Adresse
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
dbo.Ausgangsrechnung
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[UpdateAusgangsrechnungRow]
    @ID uniqueidentifier,
    @Nummer NVARCHAR(20) = "Not Set",
    @Datum DATE = GetDate(),
    @Status INT(20) = "Not Set",
    @PLZ nvarchar(20) = "Not Set",
    @Adresszusatz (5) = "Not Set"
AS
BEGIN
    UPDATE dbo.Adresse
    SET Strasse=@Strasse, Hausnummer=@Hausnummer, Ort=@Ort, PLZ=@PLZ, Adresszusatz=@Adresszusatz
    WHERE ID=@ID
END
--------------------------------------------------------------------------------------------------------------
