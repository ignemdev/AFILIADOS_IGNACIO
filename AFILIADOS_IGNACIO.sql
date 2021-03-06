--CREATE DATABASE AFILIADOS_IGNACIO
--GO;

--USE AFILIADOS_IGNACIO
--GO

CREATE TABLE ESTATUS(
Id INT IDENTITY(1,1) NOT NULL,
Estatus VARCHAR(100) NOT NULL,

CONSTRAINT PK_ESTATUS_ID PRIMARY KEY(ID)
);

CREATE TABLE PLANES(
Id INT IDENTITY(1,1) NOT NULL,
PlanDescripcion VARCHAR(200) NOT NULL,
MontoCobertura FLOAT NOT NULL,
FechaRegistro DATETIME NOT NULL,
EstatusId INT NOT NULL,

CONSTRAINT PK_PLANES_ID PRIMARY KEY(ID),
CONSTRAINT FK_PLANES_ESTATUS FOREIGN KEY (EstatusId) REFERENCES Estatus(Id) ON DELETE CASCADE
);

CREATE TABLE AFILIADOS(
Id INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(150) NOT NULL,
Apellido Varchar(150) NOT NULL,
Sexo VARCHAR(12) NOT NULL,
Cedula VARCHAR(11) NOT NULL,
NSS Varchar(11) NOT NULL,
FechaRegistro DATETIME NOT NULL,
MontoConsumido FLOAT NOT NULL,
EstatusId INT NOT NULL,
PlanId INT NOT NULL,

CONSTRAINT PK_AFILIADOS_ID PRIMARY KEY(ID),
CONSTRAINT FK_AFILIADOS_ESTATUS FOREIGN KEY(EstatusId) REFERENCES ESTATUS(ID) ON DELETE CASCADE,
CONSTRAINT FK_AFILIADOS_PLANES FOREIGN KEY(PlanId) REFERENCES PLANES(ID)
)

INSERT INTO ESTATUS(Estatus) VALUES ('ACTIVO'),('INACTIVO')

SELECT * FROM ESTATUS