CREATE TRIGGER SatisStokAzalt
ON SatisHarekets
AFTER INSERT
AS
DECLARE @UrunID int
DECLARE @Adet int
SELECT @UrunID = UrunID, @Adet = Adet FROM inserted
UPDATE Uruns SET Stok = Stok - @Adet WHERE UrunID = @UrunID