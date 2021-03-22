DROP TABLE Patient;
DROP TABLE RDV;
DROP TABLE Medecin;



CREATE TABLE [dbo].[Patient]
(
    [id] INT IDENTITY (1,1) NOT NULL,
	[CodePatient] VARCHAR(50) NOT NULL, 
    [NomPatient]       VARCHAR(50) NOT NULL, 
    [AdressePatient]    VARCHAR(50) NOT NULL, 
    [DateNaissance] VARCHAR(50) NOT NULL,
    [SexePatient] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)

CREATE TABLE [dbo].[RDV]
(
    [NumeroRDV] INT IDENTITY (1,1) NOT NULL,
    [DateRDV] DATE NOT NULL,
    [HeureRDV] VARCHAR(50) NOT NULL,
    [CodeMedecin] VARCHAR(50) NOT NULL,
    [CodePatient] VARCHAR(50) NOT NULL,
)

CREATE TABLE [dbo].[Medecin]
(
    [id] INT IDENTITY (1,1) NOT NULL,
    [CodeMedecin] VARCHAR(50) NOT NULL,
    [NomMedecin] VARCHAR(50) NOT NULL,
    [TelMedecin] VARCHAR(50) NOT NULL,
    [DateEmbauche] VARCHAR(50) NOT NULL,
    [SpecialiteMedecin] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)