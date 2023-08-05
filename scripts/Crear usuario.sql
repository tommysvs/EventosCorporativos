CREATE PROCEDURE PR_EVENTOS_NUEVO_USUARIO 
	@Usuario varchar(50),
	@Contrasenia varchar(50),
	@Nombre varchar(50),
	@Correo varchar(100)
AS
BEGIN

	INSERT INTO Usuarios (Usuario, Contrasenia, Nombre, Correo)
	VALUES (@Usuario, HASHBYTES('SHA2_512', @Contrasenia), @Nombre, @Correo)

END
