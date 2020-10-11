CREATE TRIGGER TUTAREKLE
ON FaturaKalems
AFTER INSERT
AS
DECLARE @FaturaID int
DECLARE @Tutar decimal(18,2)
SELECT @FaturaID=FaturaID, @Tutar=Tutar from inserted
update Faturas set Toplam += @Tutar where FaturaID=@FaturaID