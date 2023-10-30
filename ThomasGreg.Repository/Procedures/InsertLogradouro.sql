CREATE PROCEDURE [dbo].[InsertLogradouro]
    @ClienteId int,
    @Endereco varchar(300)
AS
BEGIN
    SET NOCOUNT ON;

        INSERT INTO [dbo].[Logradouros]([DataCadastro],[ClienteId],[Endereco])
        VALUES(getdate(), @ClienteId, @Endereco)

    SELECT SCOPE_IDENTITY() AS LogradouroId

END
