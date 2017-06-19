USE GD1C2017
GO

PRINT '***************************************'
PRINT '**                                   **'
PRINT '**    script_creacion_inicial.sql    **'
PRINT '**                                   **'
PRINT '**  Gurpo: GESTION_DE_GATOS          **'
PRINT '**  Anio: 2017                       **'
PRINT '**  Integrantes:                     **'
PRINT '**    -Cantero Ezequiel              **'
PRINT '**    -Llopis Ivas Rodrigo           **'
PRINT '**    -Martinez Andres               **'
PRINT '**    -Mico Nicolas                  **'
PRINT '**                                   **'
PRINT '***************************************'

PRINT ''
PRINT ''
PRINT ''
GO
CREATE SCHEMA GESTION_DE_GATOS
GO

PRINT CONCAT(CURRENT_TIMESTAMP, ' - Creando tablas')
PRINT '***************************************************************'
PRINT 'TURNO'
CREATE TABLE GESTION_DE_GATOS.TURNO (
	TURN_ID INT NOT NULL IDENTITY(1,1),
	TURN_INICIO NUMERIC(18,0) NOT NULL,
	TURN_FIN NUMERIC(18,0) NOT NULL,
	TURN_DESCRIPCION VARCHAR(255) NOT NULL,
	TURN_VALOR_KILOMETRO NUMERIC(18,2) NOT NULL,
	TURN_PRECIO_BASE NUMERIC(18,2) NOT NULL,
	TURN_HABILITADO BIT NOT NULL
)

PRINT 'CHOFER'
CREATE TABLE GESTION_DE_GATOS.CHOFER (
	CHOF_ID INT NOT NULL IDENTITY(1,1),
	CHOF_USUARIO INT NOT NULL,
	CHOF_NOMBRE VARCHAR(255) NOT NULL,
	CHOF_APELLIDO VARCHAR(255) NOT NULL,
	CHOF_DNI NUMERIC(18,0) NOT NULL,
	CHOF_DIRECCION VARCHAR(255) NOT NULL,
	CHOF_FECHA_NACIMIENTO DATETIME NOT NULL,
	CHOF_MAIL VARCHAR(50),
	CHOF_TELEFONO NUMERIC(18,0) NOT NULL,
	CHOF_HABILITADO BIT NOT NULL
)

PRINT 'CLIENTE'
CREATE TABLE GESTION_DE_GATOS.CLIENTE (
	CLIE_ID INT NOT NULL IDENTITY(1,1),
	CLIE_USUARIO INT NOT NULL,
	CLIE_NOMBRE VARCHAR(255) NOT NULL,
	CLIE_APELLIDO VARCHAR(255) NOT NULL,
	CLIE_DNI NUMERIC(18,0) NOT NULL,
	CLIE_CP VARCHAR(8),
	CLIE_DIRECCION VARCHAR(255) NOT NULL,
	CLIE_FECHA_NACIMIENTO DATETIME NOT NULL,
	CLIE_MAIL VARCHAR(255),
	CLIE_TELEFONO NUMERIC(18,0) NOT NULL,
	CLIE_HABILITADO BIT NOT NULL
)

PRINT 'USUARIO'
CREATE TABLE GESTION_DE_GATOS.USUARIO (
	USUA_ID INT NOT NULL IDENTITY(1,1),
	USUA_USERNAME VARCHAR(255) NOT NULL,
	USUA_CONTRASENIA VARCHAR(255) NOT NULL,
	USUA_HABILITADO BIT NOT NULL
)

PRINT 'ROL'
CREATE TABLE GESTION_DE_GATOS.ROL (
	ROL_ID INT NOT NULL IDENTITY(1,1),
	ROL_DESCRIPCION VARCHAR(255) NOT NULL,
	ROL_HABILITADO BIT NOT NULL
)

PRINT 'FUNCIONALIDAD'
CREATE TABLE GESTION_DE_GATOS.FUNCIONALIDAD (
	FUNC_ID INT NOT NULL IDENTITY(1,1),
	FUNC_DESCRIPCION VARCHAR(255) NOT NULL
)

PRINT 'VEHICULO'
CREATE TABLE GESTION_DE_GATOS.VEHICULO (
	VEHI_ID INT NOT NULL IDENTITY(1,1),
	VEHI_MODELO INT NOT NULL,
	VEHI_PATENTE VARCHAR(10) NOT NULL,
	VEHI_LICENCIA VARCHAR(26) NOT NULL,
	VEHI_RODADO VARCHAR(10) NOT NULL,
	VEHI_HABILITADO BIT NOT NULL
)

PRINT 'MODELO'
CREATE TABLE GESTION_DE_GATOS.MODELO (
	MODE_ID INT NOT NULL IDENTITY(1,1),
	MODE_DESCRIPCION VARCHAR(255) NOT NULL,
	MODE_MARCA INT NOT NULL
)

PRINT 'MARCA'
CREATE TABLE GESTION_DE_GATOS.MARCA (
	MARC_ID INT NOT NULL IDENTITY(1,1),
	MARC_DESCRIPCION VARCHAR(255) NOT NULL
)

PRINT 'VIAJE'
CREATE TABLE GESTION_DE_GATOS.VIAJE (
	VIAJ_ID INT NOT NULL IDENTITY(1,1),
	VIAJ_CHOFER INT NOT NULL,
	VIAJ_CLIENTE INT NOT NULL,
	VIAJ_VEHICULO INT NOT NULL,
	VIAJ_DISTANCIA NUMERIC(18,0) NOT NULL,
	VIAJ_FECHA_INICIO DATETIME NOT NULL,
	VIAJ_FECHA_FIN DATETIME NOT NULL,
	VIAJ_TURN_INICIO NUMERIC(18,0) NOT NULL,
	VIAJ_TURN_FIN NUMERIC(18,0) NOT NULL,
	VIAJ_TURN_DESCRIPCION VARCHAR(255) NOT NULL,
	VIAJ_TURN_VALOR_KILOMETRO NUMERIC(18,2) NOT NULL,
	VIAJ_TURN_PRECIO_BASE NUMERIC(18,2) NOT NULL
)

PRINT 'FACTURACION'
CREATE TABLE GESTION_DE_GATOS.FACTURACION (
	FACT_ID INT NOT NULL IDENTITY(1,1),
	FACT_CLIENTE INT NOT NULL,
	FACT_NUMERO NUMERIC(18,0) NOT NULL,
	FACT_FECHA DATETIME NOT NULL,
	FACT_FECHA_INICIO DATETIME NOT NULL,
	FACT_FECHA_FIN DATETIME NOT NULL,
	FACT_IMPORTE NUMERIC(18, 2) NOT NULL
)

PRINT 'RENDICION'
CREATE TABLE GESTION_DE_GATOS.RENDICION (
	REND_ID INT NOT NULL IDENTITY(1,1),
	REND_CHOFER INT,
	REND_NUMERO NUMERIC(18,0) NOT NULL,
	REND_FECHA DATETIME NOT NULL,
	REND_IMPORTE NUMERIC(18, 2) NOT NULL
)

PRINT 'FACTURACION_VIAJE'
CREATE TABLE GESTION_DE_GATOS.FACTURACION_VIAJE (
	FV_FACT_ID INT NOT NULL,
	FV_VIAJ_ID INT NOT NULL,
	FV_IMPORTE NUMERIC(18, 2) NOT NULL,
)

PRINT 'RENDICION_VIAJE'
CREATE TABLE GESTION_DE_GATOS.RENDICION_VIAJE (
	RV_REND_ID INT NOT NULL,
	RV_VIAJ_ID INT NOT NULL,
	RV_IMPORTE NUMERIC(18, 2) NOT NULL
)

PRINT 'ROL_USUARIO'
CREATE TABLE GESTION_DE_GATOS.ROL_USUARIO (
	RU_ROL_ID INT NOT NULL,
	RU_USUA_ID INT NOT NULL
)

PRINT 'FUNCIONALIDAD_ROL'
CREATE TABLE GESTION_DE_GATOS.FUNCIONALIDAD_ROL (
	FR_FUNC_ID INT NOT NULL,
	FR_ROL_ID INT NOT NULL
)

PRINT 'VEHICULO_CHOFER'
CREATE TABLE GESTION_DE_GATOS.VEHICULO_CHOFER (
	VC_VEHI_ID INT NOT NULL,
	VC_CHOF_ID INT NOT NULL,
	VC_TURN_ID INT NOT NULL
)
PRINT '***************************************************************'
PRINT ''

PRINT CONCAT(CURRENT_TIMESTAMP, ' - Creando Restricciones')
PRINT '***************************************************************'
PRINT CONCAT(CURRENT_TIMESTAMP, ' - PKs')
PRINT 'PK_TURN_ID'
ALTER TABLE GESTION_DE_GATOS.TURNO ADD CONSTRAINT PK_TURN_ID PRIMARY KEY (TURN_ID)
PRINT 'PK_CHOF_ID'
ALTER TABLE GESTION_DE_GATOS.CHOFER ADD CONSTRAINT PK_CHOF_ID PRIMARY KEY (CHOF_ID)
PRINT 'PK_CLIE_ID'
ALTER TABLE GESTION_DE_GATOS.CLIENTE ADD CONSTRAINT PK_CLIE_ID PRIMARY KEY (CLIE_ID)
PRINT 'PK_USUA_ID'
ALTER TABLE GESTION_DE_GATOS.USUARIO ADD CONSTRAINT PK_USUA_ID PRIMARY KEY (USUA_ID)
PRINT 'PK_ROL_ID'
ALTER TABLE GESTION_DE_GATOS.ROL ADD CONSTRAINT PK_ROL_ID PRIMARY KEY (ROL_ID)
PRINT 'PK_FUNC_ID'
ALTER TABLE GESTION_DE_GATOS.FUNCIONALIDAD ADD CONSTRAINT PK_FUNC_ID PRIMARY KEY (FUNC_ID)
PRINT 'PK_VEHI_ID'
ALTER TABLE GESTION_DE_GATOS.VEHICULO ADD CONSTRAINT PK_VEHI_ID PRIMARY KEY (VEHI_ID)
PRINT 'PK_MODE_ID'
ALTER TABLE GESTION_DE_GATOS.MODELO ADD CONSTRAINT PK_MODE_ID PRIMARY KEY (MODE_ID)
PRINT 'PK_MARC_ID'
ALTER TABLE GESTION_DE_GATOS.MARCA ADD CONSTRAINT PK_MARC_ID PRIMARY KEY (MARC_ID)
PRINT 'PK_VIAJ_ID'
ALTER TABLE GESTION_DE_GATOS.VIAJE ADD CONSTRAINT PK_VIAJ_ID PRIMARY KEY (VIAJ_ID)
PRINT 'PK_FACT_ID'
ALTER TABLE GESTION_DE_GATOS.FACTURACION ADD CONSTRAINT PK_FACT_ID PRIMARY KEY (FACT_ID)
PRINT 'PK_REND_ID'
ALTER TABLE GESTION_DE_GATOS.RENDICION ADD CONSTRAINT PK_REND_ID PRIMARY KEY (REND_ID)
PRINT 'PK_FV'
ALTER TABLE GESTION_DE_GATOS.FACTURACION_VIAJE ADD CONSTRAINT PK_FV PRIMARY KEY (FV_FACT_ID, FV_VIAJ_ID)
PRINT 'PK_RV'
ALTER TABLE GESTION_DE_GATOS.RENDICION_VIAJE ADD CONSTRAINT PK_RV PRIMARY KEY (RV_REND_ID, RV_VIAJ_ID)
PRINT 'PK_RU'
ALTER TABLE GESTION_DE_GATOS.ROL_USUARIO ADD CONSTRAINT PK_RU PRIMARY KEY (RU_ROL_ID, RU_USUA_ID)
PRINT 'PK_FR'
ALTER TABLE GESTION_DE_GATOS.FUNCIONALIDAD_ROL ADD CONSTRAINT PK_FR PRIMARY KEY (FR_FUNC_ID, FR_ROL_ID)
PRINT 'PK_VC'
ALTER TABLE GESTION_DE_GATOS.VEHICULO_CHOFER ADD CONSTRAINT PK_VC PRIMARY KEY (VC_VEHI_ID, VC_CHOF_ID, VC_TURN_ID)
PRINT ''

PRINT CONCAT(CURRENT_TIMESTAMP, ' - FKs')
PRINT 'FK_CHOF_USUA'
ALTER TABLE GESTION_DE_GATOS.CHOFER ADD CONSTRAINT FK_CHOF_USUA FOREIGN KEY (CHOF_USUARIO) REFERENCES GESTION_DE_GATOS.USUARIO(USUA_ID)
PRINT 'FK_CLIE_USUA'
ALTER TABLE GESTION_DE_GATOS.CLIENTE ADD CONSTRAINT FK_CLIE_USUA FOREIGN KEY (CLIE_USUARIO) REFERENCES GESTION_DE_GATOS.USUARIO(USUA_ID)
PRINT 'FK_VEHI_MODE'
ALTER TABLE GESTION_DE_GATOS.VEHICULO ADD CONSTRAINT FK_VEHI_MODE FOREIGN KEY (VEHI_MODELO) REFERENCES GESTION_DE_GATOS.MODELO(MODE_ID)
PRINT 'FK_MODE_MARC'
ALTER TABLE GESTION_DE_GATOS.MODELO ADD CONSTRAINT FK_MODE_MARC FOREIGN KEY (MODE_MARCA) REFERENCES GESTION_DE_GATOS.MARCA(MARC_ID)
PRINT 'FK_VIAJ_CHOF'
ALTER TABLE GESTION_DE_GATOS.VIAJE ADD CONSTRAINT FK_VIAJ_CHOF FOREIGN KEY (VIAJ_CHOFER) REFERENCES GESTION_DE_GATOS.CHOFER(CHOF_ID)
PRINT 'FK_VIAJ_CLIE'
ALTER TABLE GESTION_DE_GATOS.VIAJE ADD CONSTRAINT FK_VIAJ_CLIE FOREIGN KEY (VIAJ_CLIENTE) REFERENCES GESTION_DE_GATOS.CLIENTE(CLIE_ID)
PRINT 'FK_VIAJ_VEHI'
ALTER TABLE GESTION_DE_GATOS.VIAJE ADD CONSTRAINT FK_VIAJ_VEHI FOREIGN KEY (VIAJ_VEHICULO) REFERENCES GESTION_DE_GATOS.VEHICULO(VEHI_ID)
PRINT 'FK_FV_VEHI'
ALTER TABLE GESTION_DE_GATOS.FACTURACION_VIAJE ADD CONSTRAINT FK_FV_VEHI FOREIGN KEY (FV_FACT_ID) REFERENCES GESTION_DE_GATOS.FACTURACION(FACT_ID)
PRINT 'FK_FV_VIAJ'
ALTER TABLE GESTION_DE_GATOS.FACTURACION_VIAJE ADD CONSTRAINT FK_FV_VIAJ FOREIGN KEY (FV_VIAJ_ID) REFERENCES GESTION_DE_GATOS.VIAJE(VIAJ_ID)
PRINT 'FK_RV_REND'
ALTER TABLE GESTION_DE_GATOS.RENDICION_VIAJE ADD CONSTRAINT FK_RV_REND FOREIGN KEY (RV_REND_ID) REFERENCES GESTION_DE_GATOS.RENDICION(REND_ID)
PRINT 'FK_RV_VIAJ'
ALTER TABLE GESTION_DE_GATOS.RENDICION_VIAJE ADD CONSTRAINT FK_RV_VIAJ FOREIGN KEY (RV_VIAJ_ID) REFERENCES GESTION_DE_GATOS.VIAJE(VIAJ_ID)
PRINT 'FK_RU_ROL'
ALTER TABLE GESTION_DE_GATOS.ROL_USUARIO ADD CONSTRAINT FK_RU_ROL FOREIGN KEY (RU_ROL_ID) REFERENCES GESTION_DE_GATOS.ROL(ROL_ID)
PRINT 'FK_RU_USUA'
ALTER TABLE GESTION_DE_GATOS.ROL_USUARIO ADD CONSTRAINT FK_RU_USUA FOREIGN KEY (RU_USUA_ID) REFERENCES GESTION_DE_GATOS.USUARIO(USUA_ID)
PRINT 'FK_FR_FUNC'
ALTER TABLE GESTION_DE_GATOS.FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FR_FUNC FOREIGN KEY (FR_FUNC_ID) REFERENCES GESTION_DE_GATOS.FUNCIONALIDAD(FUNC_ID)
PRINT 'FK_FR_ROL'
ALTER TABLE GESTION_DE_GATOS.FUNCIONALIDAD_ROL ADD CONSTRAINT FK_FR_ROL FOREIGN KEY (FR_ROL_ID) REFERENCES GESTION_DE_GATOS.ROL(ROL_ID)
PRINT 'FK_VC_VEHI'
ALTER TABLE GESTION_DE_GATOS.VEHICULO_CHOFER ADD CONSTRAINT FK_VC_VEHI FOREIGN KEY (VC_VEHI_ID) REFERENCES GESTION_DE_GATOS.VEHICULO(VEHI_ID)
PRINT 'FK_VC_CHOF'
ALTER TABLE GESTION_DE_GATOS.VEHICULO_CHOFER ADD CONSTRAINT FK_VC_CHOF FOREIGN KEY (VC_CHOF_ID) REFERENCES GESTION_DE_GATOS.CHOFER(CHOF_ID)
PRINT 'FK_VC_TURN'
ALTER TABLE GESTION_DE_GATOS.VEHICULO_CHOFER ADD CONSTRAINT FK_VC_TURN FOREIGN KEY (VC_TURN_ID) REFERENCES GESTION_DE_GATOS.TURNO(TURN_ID)
PRINT 'FK_FACT_CLIE'
ALTER TABLE GESTION_DE_GATOS.FACTURACION ADD CONSTRAINT FK_FACT_CLIE FOREIGN KEY (FACT_CLIENTE) REFERENCES GESTION_DE_GATOS.CLIENTE(CLIE_ID)
PRINT 'FK_REND_CHOF'
ALTER TABLE GESTION_DE_GATOS.RENDICION ADD CONSTRAINT FK_REND_CHOF FOREIGN KEY (REND_CHOFER) REFERENCES GESTION_DE_GATOS.CHOFER(CHOF_ID)
PRINT '***************************************************************'
PRINT ''

PRINT CONCAT(CURRENT_TIMESTAMP, ' - Unique fields')
PRINT 'UNIQUE CLIE_DNI'
ALTER TABLE GESTION_DE_GATOS.CLIENTE ADD CONSTRAINT UQ_CLIE_DNI UNIQUE(CLIE_DNI)
PRINT 'UNIQUE CLiE_TELEFONO'
ALTER TABLE GESTION_DE_GATOS.CLIENTE ADD CONSTRAINT UQ_CLIE_TEL UNIQUE(CLIE_TELEFONO)
PRINT 'UNIQUE CHOF_DNI'
ALTER TABLE GESTION_DE_GATOS.CHOFER ADD CONSTRAINT UQ_CHOF_DNI UNIQUE(CHOF_DNI)
PRINT 'UNIQUE CHOF_TELEFONO'
ALTER TABLE GESTION_DE_GATOS.CHOFER ADD CONSTRAINT UQ_CHOF_TEL UNIQUE(CHOF_TELEFONO)
PRINT 'UNIQUE VEHI_PATENTE'
ALTER TABLE GESTION_DE_GATOS.VEHICULO ADD CONSTRAINT UQ_VEHI_PATENTE UNIQUE(VEHI_PATENTE)
PRINT '***************************************************************'
PRINT ''

PRINT CONCAT(CURRENT_TIMESTAMP, ' - Creando objetos necesarios pre migracion')
PRINT '***************************************************************'
PRINT 'Funcion encriptar_contrasenia'
GO

CREATE FUNCTION GESTION_DE_GATOS.f_encriptar_contrasenia(@contrasenia VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
	RETURN HASHBYTES('SHA2_256', @contrasenia)
END
GO

PRINT 'Stored Procedure ejecutar_migracion'
GO

CREATE PROCEDURE GESTION_DE_GATOS.p_ejecutar_migracion
AS
	DECLARE
		@ID_USUA_ADMIN INT,
		
		@ID_ROL_CHOFER INT,
		@ID_ROL_ADMINISTRADOR INT,
		@ID_ROL_CLIENTE INT,

		@ID_FUNC_AMB_ROL INT,
		@ID_FUNC_ABM_CLIE INT,
		@ID_FUNC_ABM_VEHI INT,
		@ID_FUNC_ABM_CHOF INT,
		@ID_FUNC_LOGIN INT,
		@ID_FUNC_REGI_USUA INT,
		@ID_FUNC_REGI_VIAJ INT,
		@ID_FUNC_REND_CHOF INT,
		@ID_FUNC_FACT_CLIE INT,
		@ID_FUNC_ESTAD INT

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Comenzando migracion...')

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando tablas maestras')
	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando TURNO')
	INSERT GESTION_DE_GATOS.TURNO (TURN_INICIO, TURN_FIN, TURN_DESCRIPCION, TURN_VALOR_KILOMETRO, TURN_PRECIO_BASE, TURN_HABILITADO)
	(
		SELECT Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base, CAST(1 AS BIT)
		FROM gd_esquema.Maestra
		GROUP BY Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando MARCA')
	INSERT GESTION_DE_GATOS.MARCA (MARC_DESCRIPCION)
	(
		SELECT Auto_Marca
		FROM gd_esquema.Maestra
		GROUP BY Auto_Marca
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando MODELO')
	INSERT GESTION_DE_GATOS.MODELO (MODE_DESCRIPCION, MODE_MARCA)
	(
		SELECT Auto_Modelo, MARC_ID
		FROM gd_esquema.Maestra JOIN MARCA ON Auto_Marca = MARC_DESCRIPCION
		GROUP BY Auto_Modelo, MARC_ID
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando VEHICULO')
	INSERT GESTION_DE_GATOS.VEHICULO (VEHI_MODELO, VEHI_PATENTE, VEHI_LICENCIA, VEHI_RODADO, VEHI_HABILITADO)
	(
		SELECT MODE_ID, Auto_Patente, Auto_Licencia, Auto_Rodado, CAST(1 AS BIT)
		FROM gd_esquema.Maestra JOIN GESTION_DE_GATOS.MODELO ON Auto_Modelo = MODE_DESCRIPCION
		GROUP BY MODE_ID, Auto_Patente, Auto_Licencia, Auto_Rodado
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando ROL')
	INSERT GESTION_DE_GATOS.ROL (ROL_DESCRIPCION, ROL_HABILITADO) VALUES ('Administrador', CAST(1 AS BIT))
	SET @ID_ROL_ADMINISTRADOR = @@IDENTITY

	INSERT GESTION_DE_GATOS.ROL (ROL_DESCRIPCION, ROL_HABILITADO) VALUES ('Cliente', CAST(1 AS BIT))
	SET @ID_ROL_CLIENTE = @@IDENTITY

	INSERT GESTION_DE_GATOS.ROL (ROL_DESCRIPCION, ROL_HABILITADO) VALUES ('Chofer', CAST(1 AS BIT))
	SET @ID_ROL_CHOFER = @@IDENTITY


	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando USUARIO')
	--Creo usuario administrador
	INSERT GESTION_DE_GATOS.USUARIO (USUA_USERNAME, USUA_CONTRASENIA, USUA_HABILITADO) VALUES ('admin', (SELECT GESTION_DE_GATOS.f_encriptar_contrasenia('w23e')), CAST(1 AS BIT))
	SET @ID_USUA_ADMIN = @@IDENTITY

	--Creo usuarios en base a choferes
	INSERT GESTION_DE_GATOS.USUARIO (USUA_USERNAME, USUA_CONTRASENIA, USUA_HABILITADO)
	(
		SELECT CONVERT(VARCHAR(255), Chofer_Dni), (SELECT GESTION_DE_GATOS.f_encriptar_contrasenia(RTRIM(CONVERT(VARCHAR(255), Chofer_Dni)))), CAST(1 AS BIT)
		FROM gd_esquema.Maestra
		GROUP BY Chofer_Dni
	)

	--Creo usuarios en base a clientes
	INSERT GESTION_DE_GATOS.USUARIO (USUA_USERNAME, USUA_CONTRASENIA, USUA_HABILITADO)
	(
		SELECT CONVERT(VARCHAR(255), Cliente_Dni), (SELECT GESTION_DE_GATOS.f_encriptar_contrasenia(RTRIM(CONVERT(VARCHAR(255), Cliente_Dni)))), CAST(1 AS BIT)
		FROM gd_esquema.Maestra
		WHERE CONVERT(VARCHAR(255), Cliente_Dni) not in (
			SELECT USUA_USERNAME
			FROM GESTION_DE_GATOS.USUARIO	
		)
		GROUP BY Cliente_Dni
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando CHOFER')
	INSERT GESTION_DE_GATOS.CHOFER (CHOF_USUARIO, CHOF_NOMBRE, CHOF_APELLIDO, CHOF_DNI, CHOF_DIRECCION, CHOF_FECHA_NACIMIENTO, CHOF_MAIL, CHOF_TELEFONO, CHOF_HABILITADO)
	(
		SELECT (SELECT USUA_ID FROM GESTION_DE_GATOS.USUARIO WHERE USUA_USERNAME = CONVERT(VARCHAR(255), Chofer_Dni)), Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Direccion, Chofer_Fecha_Nac, Chofer_Mail, Chofer_Telefono, CAST(1 AS BIT)
		FROM gd_esquema.Maestra
		GROUP BY Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Direccion, Chofer_Fecha_Nac, Chofer_Mail, Chofer_Telefono
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando CLIENTE')
	INSERT GESTION_DE_GATOS.CLIENTE (CLIE_USUARIO, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DNI, CLIE_DIRECCION, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_TELEFONO, CLIE_HABILITADO)
	(
		SELECT (SELECT USUA_ID FROM GESTION_DE_GATOS.USUARIO WHERE USUA_USERNAME = CONVERT(VARCHAR(255), Cliente_Dni)), Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Direccion, Cliente_Fecha_Nac, Cliente_Mail, Cliente_Telefono, CAST(1 AS BIT)
		FROM gd_esquema.Maestra
		GROUP BY Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Direccion, Cliente_Fecha_Nac, Cliente_Mail, Cliente_Telefono
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando VEHICULO_CHOFER')
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('ABM de Rol')
	SET @ID_FUNC_AMB_ROL = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('ABM de Cliente')
	SET @ID_FUNC_ABM_CLIE = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('ABM de Automóvil')
	SET @ID_FUNC_ABM_VEHI = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('ABM de Chofer')
	SET @ID_FUNC_ABM_CHOF = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Login y Seguridad')
	SET @ID_FUNC_LOGIN = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Registro de Usuario')
	SET @ID_FUNC_REGI_USUA = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Registro de Viajes')
	SET @ID_FUNC_REGI_VIAJ = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Rendicion de cuenta del chofer')
	SET @ID_FUNC_REND_CHOF = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Facturacion a Cliente')
	SET @ID_FUNC_FACT_CLIE = @@IDENTITY

	INSERT GESTION_DE_GATOS.FUNCIONALIDAD (FUNC_DESCRIPCION) VALUES ('Listado Estadistico')
	SET @ID_FUNC_ESTAD = @@IDENTITY

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando FUNCIONALIDAD_ROL')
	--Migro funcionalidades de rol Administrador
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_AMB_ROL)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_ABM_CLIE)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_ABM_VEHI)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_ABM_CHOF)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_LOGIN)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_REGI_USUA)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_REND_CHOF)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_FACT_CLIE)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_FUNC_ESTAD)

	--Migro funcionalidades de rol Chofer
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_CHOFER, @ID_FUNC_LOGIN)
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_CHOFER, @ID_FUNC_REGI_VIAJ)

	--Migro funcionalidades de rol Cliente
	INSERT GESTION_DE_GATOS.FUNCIONALIDAD_ROL (FR_ROL_ID, FR_FUNC_ID) VALUES (@ID_ROL_CLIENTE, @ID_FUNC_LOGIN)


	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando ROL_USUARIO')
	--Migro al Admin
	INSERT GESTION_DE_GATOS.ROL_USUARIO (RU_ROL_ID, RU_USUA_ID) VALUES (@ID_ROL_ADMINISTRADOR, @ID_USUA_ADMIN)

	--Migro usuarios de Choferes
	INSERT GESTION_DE_GATOS.ROL_USUARIO (RU_ROL_ID, RU_USUA_ID)
	(
		SELECT @ID_ROL_CHOFER, USUA_ID
		FROM gd_esquema.Maestra
			JOIN GESTION_DE_GATOS.USUARIO ON CONVERT(VARCHAR(255), Chofer_Dni) = USUA_USERNAME
		GROUP BY USUA_ID
	)

	--Migro usuarios por Clientes
	INSERT GESTION_DE_GATOS.ROL_USUARIO (RU_ROL_ID, RU_USUA_ID)
	(
		SELECT @ID_ROL_CLIENTE, USUA_ID
		FROM gd_esquema.Maestra
			JOIN GESTION_DE_GATOS.USUARIO ON CONVERT(VARCHAR(255), Cliente_Dni) = USUA_USERNAME
		GROUP BY USUA_ID
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando VEHICULO_CHOFER')
	INSERT GESTION_DE_GATOS.VEHICULO_CHOFER (VC_VEHI_ID, VC_CHOF_ID, VC_TURN_ID)
	(
		SELECT VEHI_ID, CHOF_ID, (SELECT TURN_ID FROM GESTION_DE_GATOS.TURNO WHERE TURN_DESCRIPCION = Turno_Descripcion)
		FROM gd_esquema.Maestra
			JOIN GESTION_DE_GATOS.VEHICULO ON Auto_Patente = VEHI_PATENTE
			JOIN GESTION_DE_GATOS.CHOFER ON Chofer_Dni = CHOF_DNI
		GROUP BY VEHI_ID, CHOF_ID, Turno_Descripcion
	)

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Migrando tablas transaccionales')

	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Insertando VIAJE')
	INSERT INTO GESTION_DE_GATOS.VIAJE (VIAJ_CHOFER, VIAJ_CLIENTE, VIAJ_VEHICULO, VIAJ_DISTANCIA, VIAJ_FECHA_INICIO, VIAJ_FECHA_FIN, VIAJ_TURN_INICIO, VIAJ_TURN_FIN, VIAJ_TURN_DESCRIPCION, VIAJ_TURN_VALOR_KILOMETRO, VIAJ_TURN_PRECIO_BASE)
	SELECT CHOF_ID, CLIE_ID, VEHI_ID, Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base
	FROM
		gd_esquema.Maestra
		JOIN GESTION_DE_GATOS.CHOFER ON Chofer_Dni = CHOF_DNI
		JOIN GESTION_DE_GATOS.CLIENTE ON Cliente_Dni = CLIE_DNI
		JOIN GESTION_DE_GATOS.VEHICULO ON Auto_Patente = VEHI_PATENTE
		JOIN GESTION_DE_GATOS.TURNO ON Turno_Descripcion = TURN_DESCRIPCION AND turno_hora_inicio = TURN_INICIO AND turno_hora_fin = TURN_FIN
	WHERE Rendicion_Nro IS NOT NULL
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - VIAJE Insertado')
	
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Insertando FACTURACION')
	INSERT INTO GESTION_DE_GATOS.FACTURACION (FACT_NUMERO, FACT_FECHA, FACT_FECHA_INICIO, FACT_FECHA_FIN, FACT_IMPORTE, FACT_CLIENTE)
	SELECT Factura_Nro, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin, -999, CLIE_ID
	FROM gd_esquema.Maestra JOIN GESTION_DE_GATOS.CLIENTE ON CLIE_DNI = Cliente_Dni
	WHERE Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin, CLIE_ID;
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - FACTURACION Insertada')
	
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Insertando FACTURACION_VIAJE')
	INSERT INTO GESTION_DE_GATOS.FACTURACION_VIAJE (FV_FACT_ID, FV_VIAJ_ID, FV_IMPORTE)
	SELECT FACT_ID, VIAJ_ID, Viaje_Cant_Kilometros * Turno_Valor_Kilometro + Turno_Precio_Base
	FROM
		gd_esquema.Maestra
		JOIN GESTION_DE_GATOS.CHOFER ON Chofer_Dni = CHOF_DNI
		JOIN GESTION_DE_GATOS.CLIENTE ON Cliente_Dni = CLIE_DNI
		JOIN GESTION_DE_GATOS.VEHICULO ON Auto_Patente = VEHI_PATENTE
		JOIN GESTION_DE_GATOS.TURNO ON Turno_Descripcion = TURN_DESCRIPCION AND turno_hora_inicio = TURN_INICIO AND turno_hora_fin = TURN_FIN
		JOIN GESTION_DE_GATOS.VIAJE ON VIAJ_CHOFER = CHOF_ID AND VIAJ_CLIENTE = CLIE_ID AND VIAJ_VEHICULO = VEHI_ID AND Turno_Descripcion = VIAJ_TURN_DESCRIPCION AND turno_hora_inicio = TURN_INICIO AND turno_hora_fin = TURN_FIN AND Viaje_Cant_Kilometros = VIAJ_DISTANCIA AND Viaje_Fecha = VIAJ_FECHA_INICIO AND Viaje_Fecha = VIAJ_FECHA_FIN
		JOIN GESTION_DE_GATOS.FACTURACION ON FORMAT(FACT_FECHA, 'yyyyMM') = FORMAT(Factura_Fecha, 'yyyyMM') AND Factura_Nro = FACT_NUMERO
	WHERE Factura_Nro IS NOT NULL
	GROUP BY FACT_ID, VIAJ_ID, Viaje_Cant_Kilometros * Turno_Valor_Kilometro + Turno_Precio_Base
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - FACTURACION_VIAJE Insertada')

	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Insertando RENDICION')
	INSERT INTO GESTION_DE_GATOS.RENDICION (REND_NUMERO, REND_FECHA, REND_IMPORTE, REND_CHOFER)
	SELECT Rendicion_Nro, Rendicion_Fecha, -999, CHOF_ID
	FROM gd_esquema.Maestra JOIN GESTION_DE_GATOS.CHOFER ON CHOF_DNI = Chofer_Dni
	WHERE Rendicion_Nro IS NOT NULL
	GROUP BY Rendicion_Nro, Rendicion_Fecha, CHOF_ID;
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - RENDICION Insertada')

	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Insertando RENDICION_VIAJE')
	INSERT INTO GESTION_DE_GATOS.RENDICION_VIAJE (RV_REND_ID, RV_VIAJ_ID, RV_IMPORTE)
	SELECT REND_ID, VIAJ_ID, Rendicion_Importe
	FROM
		gd_esquema.Maestra
		JOIN GESTION_DE_GATOS.CHOFER ON Chofer_Dni = CHOF_DNI
		JOIN GESTION_DE_GATOS.CLIENTE ON Cliente_Dni = CLIE_DNI
		JOIN GESTION_DE_GATOS.VEHICULO ON Auto_Patente = VEHI_PATENTE
		JOIN GESTION_DE_GATOS.TURNO ON Turno_Descripcion = TURN_DESCRIPCION AND turno_hora_inicio = TURN_INICIO AND turno_hora_fin = TURN_FIN
		JOIN GESTION_DE_GATOS.VIAJE ON VIAJ_CHOFER = CHOF_ID AND VIAJ_CLIENTE = CLIE_ID AND VIAJ_VEHICULO = VEHI_ID AND Turno_Descripcion = VIAJ_TURN_DESCRIPCION AND turno_hora_inicio = TURN_INICIO AND turno_hora_fin = TURN_FIN AND Viaje_Cant_Kilometros = VIAJ_DISTANCIA AND Viaje_Fecha = VIAJ_FECHA_INICIO AND Viaje_Fecha = VIAJ_FECHA_FIN
		JOIN GESTION_DE_GATOS.RENDICION ON Rendicion_Fecha = REND_FECHA AND Rendicion_Nro = REND_NUMERO
	WHERE Rendicion_Nro IS NOT NULL
	GROUP BY REND_ID, VIAJ_ID, Rendicion_Importe;
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - RENDICION_VIAJE Insertada')

	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Calculando Importe RENDICION')
	UPDATE GESTION_DE_GATOS.RENDICION
	SET REND_IMPORTE =
		(SELECT SUM(RV_IMPORTE)
		FROM GESTION_DE_GATOS.RENDICION_VIAJE
		WHERE RV_REND_ID = REND_ID)
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Importe RENDICION Calculado')

	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Calculando Importe FACTURACION')
	UPDATE GESTION_DE_GATOS.FACTURACION
	SET FACT_IMPORTE =
		(SELECT SUM(FV_IMPORTE)
		FROM GESTION_DE_GATOS.FACTURACION_VIAJE
		WHERE FACT_ID = FV_FACT_ID)
	PRINT CONCAT(CONVERT(VARCHAR(24), GETDATE(), 121), ' - Importe FACTURACION Calculado')

	PRINT CONCAT(CURRENT_TIMESTAMP, ' - Fin migracion...')
GO
PRINT '***************************************************************'
PRINT ''

PRINT 'Ejecutando migracion'
PRINT '***************************************************************'
EXEC GESTION_DE_GATOS.p_ejecutar_migracion
PRINT '***************************************************************'
PRINT ''

PRINT CONCAT(CURRENT_TIMESTAMP, ' - Creando objetos necesarios post migracion')
PRINT '***************************************************************'
GO

PRINT 'Vistas'
PRINT 'Vista chof_recaudacion'
GO
CREATE VIEW GESTION_DE_GATOS.v_chof_recaudacion
AS
	SELECT
		CHOF_ID 'Chofer',
		CHOF_NOMBRE 'Nombre',
		CHOF_APELLIDO 'Apellido',
		DATEPART(q, VIAJ_FECHA_FIN) 'Trimestre',
		SUM(RV_VIAJ_ID) 'Recaudacion',
		SUM(VIAJ_DISTANCIA) 'Distancia recorruda'
	FROM GESTION_DE_GATOS.CHOFER
		JOIN GESTION_DE_GATOS.VIAJE ON CHOF_ID = VIAJ_CHOFER
		JOIN GESTION_DE_GATOS.RENDICION_VIAJE ON VIAJ_ID = RV_VIAJ_ID
	GROUP BY CHOF_ID, CHOF_NOMBRE, CHOF_APELLIDO, DATEPART(q, VIAJ_FECHA_FIN)
GO

PRINT 'Vista chof_viaje'
GO
CREATE VIEW GESTION_DE_GATOS.v_chof_viaje
AS
	SELECT
		CHOF_ID 'Chofer',
		CHOF_NOMBRE 'Nombre',
		CHOF_APELLIDO 'Apellido',
		VIAJ_TURN_DESCRIPCION 'Turno',
		VIAJ_DISTANCIA 'Distancia recorrida',
		VIAJ_FECHA_INICIO 'Fecha de inicio del viaje',
		VIAJ_FECHA_FIN 'Fecha de fin del viaje',
		DATEPART(q, VIAJ_FECHA_FIN) 'Trimestre',
		VEHI_PATENTE 'Patente',
		VEHI_MODELO 'Modelo del auto'
	FROM GESTION_DE_GATOS.CHOFER
		JOIN GESTION_DE_GATOS.VIAJE ON CHOF_ID = VIAJ_CHOFER
		JOIN GESTION_DE_GATOS.VEHICULO ON VIAJ_VEHICULO = VEHI_ID
GO

PRINT 'Vista clie_consumo'
GO
CREATE VIEW GESTION_DE_GATOS.v_clie_consumo
AS
	SELECT
		CLIE_ID 'Cliente',
		CLIE_NOMBRE 'Nombre',
		CLIE_APELLIDO 'Apellido',
		CLIE_FECHA_NACIMIENTO 'Fecha de nacimiento',
		SUM(FV_IMPORTE) 'Importe',
		DATEPART(q, VIAJ_FECHA_FIN) 'Trimestre'
	FROM GESTION_DE_GATOS.CLIENTE
		JOIN GESTION_DE_GATOS.VIAJE ON CLIE_ID = VIAJ_CLIENTE
		JOIN GESTION_DE_GATOS.FACTURACION_VIAJE ON VIAJ_ID = FV_VIAJ_ID
	GROUP BY CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_FECHA_NACIMIENTO, DATEPART(q, VIAJ_FECHA_FIN)
GO

PRINT 'Vista clie_vehi'
GO
CREATE VIEW GESTION_DE_GATOS.v_clie_vehi
AS
	SELECT
		CLIE_ID 'Cliente',
		CLIE_NOMBRE 'Nombre',
		CLIE_APELLIDO 'Apellido',
		DATEPART(q, VIAJ_FECHA_FIN) 'Trimestre',
		VEHI_PATENTE 'Patente',
		VEHI_MODELO 'Modelo',
		COUNT(VEHI_ID) 'Cant. viajes'
	FROM GESTION_DE_GATOS.CLIENTE
		JOIN GESTION_DE_GATOS.VIAJE ON CLIE_ID = VIAJ_CLIENTE
		JOIN GESTION_DE_GATOS.VEHICULO ON VIAJ_VEHICULO = VEHI_ID
	GROUP BY CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, DATEPART(q, VIAJ_FECHA_FIN), VEHI_PATENTE, VEHI_MODELO
GO

PRINT 'Procedimientos'
PRINT 'Procedimiento rend_viajes'
GO
CREATE PROCEDURE GESTION_DE_GATOS.p_rend_viajes
	@CHOFER INT,
	@FECHA_FACTURACION DATE,
	@IMPORTE_TOTAL NUMERIC(18, 2) OUTPUT
AS
	DECLARE @ID_RENDICION INT

	BEGIN TRANSACTION

	BEGIN TRY
		IF EXISTS (SELECT 1 FROM GESTION_DE_GATOS.CHOFER WHERE CHOF_ID = @CHOFER AND CHOF_HABILITADO = 0)
		BEGIN
			RAISERROR('No se puede generar la rendicion de un chofer deshabilitado', 16, 1)
		END

		--Genero la rendicion para poder insertar rendiciones por viaj. Si no existe el id de rendicion va a romper por la FK.
		INSERT GESTION_DE_GATOS.RENDICION (REND_FECHA, REND_IMPORTE, REND_CHOFER, REND_NUMERO) VALUES (CONVERT(DATETIME, @FECHA_FACTURACION, 126), 0, @CHOFER, 0)
		SET @ID_RENDICION = @@IDENTITY

		IF EXISTS (
			SELECT 1
			FROM GESTION_DE_GATOS.VIAJE
			WHERE CAST(VIAJ_FECHA_FIN AS DATE) = @FECHA_FACTURACION
				AND VIAJ_CHOFER = @CHOFER
		)
		BEGIN
			--Genero las rendiciones por viaje calculando el importe del viaje.
			INSERT GESTION_DE_GATOS.RENDICION_VIAJE (RV_VIAJ_ID, RV_REND_ID, RV_IMPORTE)
			(
				SELECT
					VIAJ_ID,
					@ID_RENDICION,
					(VIAJ_TURN_PRECIO_BASE + VIAJ_TURN_VALOR_KILOMETRO * VIAJ_DISTANCIA) * 0.3
				FROM GESTION_DE_GATOS.VIAJE
				WHERE CAST(VIAJ_FECHA_FIN AS DATE) = @FECHA_FACTURACION
					AND VIAJ_CHOFER = @CHOFER
			)

			--Actualizo la rendicion con el valor total de la suma de los importes de los viajes
			SET @IMPORTE_TOTAL = (
				SELECT SUM(RV_IMPORTE)
				FROM GESTION_DE_GATOS.RENDICION_VIAJE
				WHERE RV_REND_ID = @ID_RENDICION
			)

			UPDATE GESTION_DE_GATOS.RENDICION
			SET REND_IMPORTE = @IMPORTE_TOTAL
			WHERE REND_ID = @ID_RENDICION
		END

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		DECLARE
			@MESSAGE NVARCHAR(4000),
			@SEVERITY INT,
			@STATE INT

		SELECT   
			@MESSAGE = ERROR_MESSAGE(),  
			@SEVERITY = ERROR_SEVERITY(),  
			@STATE = ERROR_STATE()

		RAISERROR(@MESSAGE, @SEVERITY, @STATE)
		ROLLBACK TRANSACTION
		RETURN -1
	END CATCH

	--TODO acomodoar esta tabla a la necesidad de nico
	--Devuelvo la info del chofer y sus viajes
	SELECT
		VIAJ_ID 'Viaje',
		VIAJ_FECHA_INICIO 'Fecha de inicio',
		VIAJ_FECHA_FIN 'Fecha de fin',
		VIAJ_TURN_DESCRIPCION 'Turno',
		RV_IMPORTE 'Importe del viaje'
	FROM GESTION_DE_GATOS.RENDICION
		JOIN GESTION_DE_GATOS.CHOFER ON REND_CHOFER = CHOF_ID
		JOIN GESTION_DE_GATOS.RENDICION_VIAJE ON REND_ID = RV_REND_ID
		JOIN GESTION_DE_GATOS.VIAJE ON RV_VIAJ_ID = VIAJ_ID
	WHERE CAST(REND_FECHA AS DATE) = @FECHA_FACTURACION
			AND REND_CHOFER = @CHOFER
GO

PRINT 'Procedimiento fact_viajes'
GO
CREATE PROCEDURE GESTION_DE_GATOS.p_fact_viajes
	@CLIENTE INT,
	@FECHA_INICIO DATE,
	@FECHA_FIN DATE,
	@IMPORTE_TOTAL NUMERIC(18,2) OUTPUT
AS
	DECLARE @ID_FACTURACION INT

	BEGIN TRANSACTION

	BEGIN TRY
		IF EXISTS (SELECT 1 FROM GESTION_DE_GATOS.CLIENTE WHERE CLIE_ID = @CLIENTE AND CLIE_HABILITADO = 0)
		BEGIN
			RAISERROR('No se puede generar la facturacion de un cliente deshabilitado',16,1)
			ROLLBACK TRANSACTION
			RETURN -1
		END

		--Genero la facturacion para poder insertar facturacion por viaj. Si no existe el id de facturacion va a romper por la FK.
		INSERT GESTION_DE_GATOS.FACTURACION (FACT_IMPORTE, FACT_FECHA, FACT_FECHA_INICIO, FACT_FECHA_FIN, FACT_CLIENTE, FACT_NUMERO)
		VALUES (
			0, 
			CURRENT_TIMESTAMP,
			CONVERT(DATETIME, @FECHA_INICIO, 126),
			CONVERT(DATETIME, @FECHA_FIN, 126),
			@CLIENTE,
			0
		)
		SET @ID_FACTURACION = @@IDENTITY

		IF EXISTS(
			SELECT 1
			FROM GESTION_DE_GATOS.VIAJE
			WHERE  CAST(VIAJ_FECHA_INICIO AS DATE) >= @FECHA_INICIO
				AND CAST(VIAJ_FECHA_FIN AS DATE) <= @FECHA_FIN
				AND VIAJ_CLIENTE = @CLIENTE
		)
		BEGIN

			--Genero las facturacion por viaje calculando el importe del viaje.
			INSERT GESTION_DE_GATOS.FACTURACION_VIAJE (FV_FACT_ID, FV_VIAJ_ID, FV_IMPORTE)
			(
				SELECT
					@ID_FACTURACION,
					VIAJ_ID,
					(VIAJ_TURN_PRECIO_BASE + VIAJ_TURN_VALOR_KILOMETRO * VIAJ_DISTANCIA)
				FROM GESTION_DE_GATOS.VIAJE
				WHERE  CAST(VIAJ_FECHA_INICIO AS DATE) >= @FECHA_INICIO
					AND CAST(VIAJ_FECHA_FIN AS DATE) <= @FECHA_FIN
					AND VIAJ_CLIENTE = @CLIENTE
			)

			--Actualizo la Facturacion con el valor total de la suma de los importes de los viajes
			SET @IMPORTE_TOTAL = (
				SELECT SUM(FV_IMPORTE)
				FROM GESTION_DE_GATOS.FACTURACION_VIAJE
				WHERE FV_FACT_ID = @ID_FACTURACION
			)

			UPDATE GESTION_DE_GATOS.FACTURACION
			SET FACT_IMPORTE = @IMPORTE_TOTAL
			WHERE FACT_ID = @ID_FACTURACION
		END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			DECLARE
			@MESSAGE NVARCHAR(4000),
			@SEVERITY INT,
			@STATE INT

		SELECT   
			@MESSAGE = ERROR_MESSAGE(),  
			@SEVERITY = ERROR_SEVERITY(),  
			@STATE = ERROR_STATE()

		RAISERROR(@MESSAGE, @SEVERITY, @STATE)
		ROLLBACK TRANSACTION
		RETURN -1
	END CATCH

	--TODO acomodoar esta tabla a la necesidad de nico
	--Devuelvo la info del cliente y sus viajes
	SELECT
		VIAJ_ID 'Viaje',
		VIAJ_FECHA_INICIO 'Fecha de inicio',
		VIAJ_FECHA_FIN 'Fecha de fin',
		VIAJ_TURN_DESCRIPCION 'Turno',
		FV_IMPORTE 'Importe del viaje'
	FROM GESTION_DE_GATOS.FACTURACION
		JOIN GESTION_DE_GATOS.CLIENTE ON FACT_CLIENTE = CLIE_ID
		JOIN GESTION_DE_GATOS.FACTURACION_VIAJE ON FACT_ID = FV_FACT_ID
		JOIN GESTION_DE_GATOS.VIAJE ON FV_VIAJ_ID = VIAJ_ID
	WHERE CAST(FACT_FECHA_FIN AS DATE) = @FECHA_FIN
		AND FACT_CLIENTE = @CLIENTE
GO

PRINT 'Triggers'
PRINT 'Trigger validar turno'
GO
CREATE TRIGGER GESTION_DE_GATOS.t_validar_turno ON GESTION_DE_GATOS.TURNO
INSTEAD OF INSERT, UPDATE
AS
BEGIN
	IF EXISTS
		(SELECT 1
		FROM GESTION_DE_GATOS.TURNO turn JOIN inserted ins ON ins.TURN_ID <> turn.TURN_ID
		WHERE
			ins.TURN_INICIO = ins.TURN_FIN OR
			ins.TURN_INICIO > ins.TURN_FIN OR
			(ins.TURN_INICIO BETWEEN turn.TURN_INICIO AND turn.TURN_FIN - 1 OR ins.TURN_FIN BETWEEN turn.TURN_INICIO + 1 AND turn.TURN_FIN)
		)
	BEGIN
		RAISERROR('El turno ingresado es invalido', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END

	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
	BEGIN
		UPDATE GESTION_DE_GATOS.TURNO
		SET
			TURN_DESCRIPCION = ins.TURN_DESCRIPCION,
			TURN_FIN = ins.TURN_FIN,
			TURN_HABILITADO = ins.TURN_HABILITADO,
			TURN_INICIO = ins.TURN_INICIO,
			TURN_PRECIO_BASE = ins.TURN_PRECIO_BASE,
			TURN_VALOR_KILOMETRO = ins.TURN_VALOR_KILOMETRO
		FROM inserted ins
		WHERE ins.TURN_ID = GESTION_DE_GATOS.TURNO.TURN_ID
	END
	ELSE
	BEGIN
		INSERT INTO GESTION_DE_GATOS.TURNO (TURN_DESCRIPCION, TURN_FIN, TURN_HABILITADO, TURN_INICIO, TURN_PRECIO_BASE, TURN_VALOR_KILOMETRO)
		SELECT TURN_DESCRIPCION, TURN_FIN, TURN_HABILITADO, TURN_INICIO, TURN_PRECIO_BASE, TURN_VALOR_KILOMETRO
		FROM inserted ins
	END
END
GO

PRINT 'Trigger validar viaje'
GO
CREATE TRIGGER GESTION_DE_GATOS.t_validar_viaje ON GESTION_DE_GATOS.VIAJE
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS
		(SELECT 1
		FROM inserted
		WHERE VIAJ_FECHA_INICIO > VIAJ_FECHA_FIN
		)
	BEGIN
		RAISERROR('La fecha de inicio no puede ser mayor a la de fin', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END

	IF EXISTS
		(SELECT 1
		FROM inserted
		WHERE VIAJ_DISTANCIA < 0
		)
	BEGIN
		RAISERROR('La distancia recorrida no puede ser un numero negativo', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END

	IF EXISTS
		(SELECT 1
		FROM CHOFER JOIN inserted ON CHOF_ID = VIAJ_CHOFER
		WHERE CHOF_HABILITADO = 0
		)
	BEGIN
		RAISERROR('No puede ingresarse un viaje con un chofer deshabilitado', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END

	IF EXISTS
		(SELECT 1
		FROM CLIENTE JOIN inserted ON CLIE_ID = VIAJ_CLIENTE
		WHERE CLIE_HABILITADO = 0
		)
	BEGIN
		RAISERROR('No puede ingresarse un viaje con un cliente deshabilitado', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END 

	IF EXISTS
		(SELECT 1
		FROM GESTION_DE_GATOS.VIAJE viaj JOIN inserted ins
		ON
			ins.VIAJ_CHOFER = viaj.VIAJ_CHOFER AND
			ins.VIAJ_CLIENTE = viaj.VIAJ_CLIENTE AND
			ins.VIAJ_TURN_DESCRIPCION = viaj.VIAJ_TURN_DESCRIPCION AND
			ins.VIAJ_TURN_FIN = viaj.VIAJ_TURN_FIN AND
			ins.VIAJ_TURN_INICIO = viaj.VIAJ_TURN_INICIO AND
			ins.VIAJ_TURN_PRECIO_BASE = viaj.VIAJ_TURN_PRECIO_BASE AND
			ins.VIAJ_TURN_VALOR_KILOMETRO = viaj.VIAJ_TURN_VALOR_KILOMETRO AND
			CAST(ins.VIAJ_FECHA_INICIO AS DATE) = CAST(viaj.VIAJ_FECHA_INICIO AS DATE)
		WHERE
			CAST(ins.VIAJ_FECHA_INICIO AS TIME) > CAST(viaj.VIAJ_FECHA_INICIO AS TIME) AND CAST(ins.VIAJ_FECHA_INICIO AS TIME) < CAST(viaj.VIAJ_FECHA_FIN AS TIME) OR
			CAST(ins.VIAJ_FECHA_FIN AS TIME) > CAST(viaj.VIAJ_FECHA_INICIO AS TIME) AND CAST(ins.VIAJ_FECHA_FIN AS TIME) < CAST(viaj.VIAJ_FECHA_FIN AS TIME) OR
			CAST(viaj.VIAJ_FECHA_INICIO AS TIME) > CAST(ins.VIAJ_FECHA_INICIO AS TIME) AND CAST(viaj.VIAJ_FECHA_INICIO AS TIME) < CAST(ins.VIAJ_FECHA_FIN AS TIME) OR
			CAST(viaj.VIAJ_FECHA_FIN AS TIME) > CAST(ins.VIAJ_FECHA_INICIO AS TIME) AND CAST(viaj.VIAJ_FECHA_FIN AS TIME) < CAST(ins.VIAJ_FECHA_FIN AS TIME)
		)
	BEGIN
		RAISERROR('Ya existe un viaje en ese horario', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END


	INSERT INTO GESTION_DE_GATOS.VIAJE (VIAJ_CHOFER, VIAJ_CLIENTE, VIAJ_DISTANCIA, VIAJ_FECHA_FIN, VIAJ_FECHA_INICIO, VIAJ_VEHICULO, VIAJ_TURN_INICIO, VIAJ_TURN_FIN, VIAJ_TURN_DESCRIPCION, VIAJ_TURN_VALOR_KILOMETRO, VIAJ_TURN_PRECIO_BASE)
	SELECT VIAJ_CHOFER, VIAJ_CLIENTE, VIAJ_DISTANCIA, VIAJ_FECHA_FIN, VIAJ_FECHA_INICIO, VIAJ_VEHICULO, VIAJ_TURN_INICIO, VIAJ_TURN_FIN, VIAJ_TURN_DESCRIPCION, VIAJ_TURN_VALOR_KILOMETRO, VIAJ_TURN_PRECIO_BASE
	FROM inserted ins
END
GO

PRINT 'Trigger validar fecha rendicion'
GO
CREATE TRIGGER GESTION_DE_GATOS.t_validar_fecha_rendicion ON GESTION_DE_GATOS.RENDICION
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRY
		IF EXISTS (
			SELECT 1
			FROM inserted I,
				GESTION_DE_GATOS.RENDICION R
			WHERE I.REND_CHOFER = R.REND_CHOFER
				AND (
					I.REND_FECHA = R.REND_FECHA
					OR I.REND_FECHA > CURRENT_TIMESTAMP
				)
		)
			RAISERROR('La fecha de la rendicion ingresada no es valida para el chofer ingresado',16,1)

		INSERT GESTION_DE_GATOS.RENDICION (REND_CHOFER, REND_FECHA, REND_IMPORTE, REND_NUMERO)
		(
			SELECT REND_CHOFER, REND_FECHA, REND_IMPORTE, REND_NUMERO
			FROM inserted
		)
	END TRY
	BEGIN CATCH
		DECLARE
			@MESSAGE NVARCHAR(4000),
			@SEVERITY INT,
			@STATE INT

		SELECT   
			@MESSAGE = ERROR_MESSAGE(),  
			@SEVERITY = ERROR_SEVERITY(),  
			@STATE = ERROR_STATE()

		RAISERROR(@MESSAGE, @SEVERITY, @STATE)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

PRINT 'Trigger validar fecha facturacion'
GO
CREATE TRIGGER GESTION_DE_GATOS.t_validar_fecha_facturacion ON GESTION_DE_GATOS.FACTURACION
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRY

	IF EXISTS (
		SELECT 1
		FROM inserted I,
			GESTION_DE_GATOS.FACTURACION F
		WHERE I.FACT_CLIENTE = F.FACT_CLIENTE
			AND (
				(I.FACT_FECHA_INICIO >= F.FACT_FECHA_INICIO AND I.FACT_FECHA_INICIO <= F.FACT_FECHA_FIN)
				OR (I.FACT_FECHA_FIN >= F.FACT_FECHA_INICIO AND I.FACT_FECHA_FIN <= F.FACT_FECHA_FIN)
				OR (I.FACT_FECHA_INICIO <= F.FACT_FECHA_INICIO AND I.FACT_FECHA_FIN >= F.FACT_FECHA_FIN)
				OR I.FACT_FECHA_INICIO >= I.FACT_FECHA_FIN
				OR I.FACT_FECHA_FIN > CURRENT_TIMESTAMP
			)
	)
		RAISERROR('Las fechas de inicio y fin de la facturacion ingresada no forman un intervalo valido',16,1)

	INSERT GESTION_DE_GATOS.FACTURACION (FACT_CLIENTE, FACT_FECHA, FACT_FECHA_FIN, FACT_FECHA_INICIO, FACT_IMPORTE, FACT_NUMERO)
	(
		SELECT FACT_CLIENTE, FACT_FECHA, FACT_FECHA_FIN, FACT_FECHA_INICIO, FACT_IMPORTE, FACT_NUMERO
		FROM inserted
	)
	END TRY
	BEGIN CATCH
		DECLARE
			@MESSAGE NVARCHAR(4000),
			@SEVERITY INT,
			@STATE INT

		SELECT   
			@MESSAGE = ERROR_MESSAGE(),  
			@SEVERITY = ERROR_SEVERITY(),  
			@STATE = ERROR_STATE()

		RAISERROR(@MESSAGE, @SEVERITY, @STATE)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

PRINT '***************************************************************'
PRINT ''
PRINT 'Fin script_creacion_inicial.sql'
GO