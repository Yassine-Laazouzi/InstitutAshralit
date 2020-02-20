USE [master]
GO
/****** Object:  Database [Institut_Ashralite_ADM]    Script Date: 20/02/2020 00:42:15 ******/
CREATE DATABASE [Institut_Ashralite_ADM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Institut_Ashralite_ADM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SERVER_TEST\MSSQL\DATA\Institut_Ashralite_ADM.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Institut_Ashralite_ADM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SERVER_TEST\MSSQL\DATA\Institut_Ashralite_ADM_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Institut_Ashralite_ADM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ARITHABORT OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET  MULTI_USER 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET QUERY_STORE = OFF
GO
USE [Institut_Ashralite_ADM]
GO
/****** Object:  Table [dbo].[COURS]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COURS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_MATIERE] [int] NOT NULL,
	[ID_ENCADREUR] [int] NOT NULL,
	[LIBELLE] [varchar](256) NULL,
	[DATE_COURS] [datetime] NOT NULL,
	[HEURE_DEBUT] [int] NULL,
	[HEURE_FIN] [int] NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
 CONSTRAINT [PK_COURS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INDIVIDU]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INDIVIDU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_CIVILITE] [int] NOT NULL,
	[ID_METIER] [int] NOT NULL,
	[NOM] [varchar](50) NOT NULL,
	[PRENOM] [varchar](50) NOT NULL,
	[EMAIL] [varchar](50) NULL,
	[PORTABLE] [varchar](10) NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
	[SEMAINE] [nvarchar](50) NULL,
 CONSTRAINT [PK_INDIVIDU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INSCRIPTION]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INSCRIPTION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_MATIERE] [int] NOT NULL,
	[ID_ELEVE] [int] NOT NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
 CONSTRAINT [PK_INSCRIPTION] PRIMARY KEY CLUSTERED 
(
	[ID_MATIERE] ASC,
	[ID_ELEVE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NULL,
	[Password] [nchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_and_Registration]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_and_Registration](
	[UserID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailID] [varchar](250) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Password] [varchar](max) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Login and Registration] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATIERE]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATIERE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ABBREVIATION] [varchar](20) NULL,
	[LIBELLE] [varchar](256) NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
 CONSTRAINT [PK_MATIERE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESENCE]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESENCE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_COURS] [int] NOT NULL,
	[ID_ELEVE] [int] NOT NULL,
	[PRESENT] [bit] NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
	[SEMAINE] [int] NULL,
 CONSTRAINT [PK_PRESENCE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REF_CIVILITE]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REF_CIVILITE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ABBREVIATION] [varchar](10) NULL,
	[LIBELLE] [varchar](100) NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
 CONSTRAINT [PK_REF_CIVILITE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REF_METIER]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REF_METIER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ABBREVIATION] [varchar](10) NULL,
	[LIBELLE] [varchar](100) NULL,
	[COMMENTAIRE] [varchar](2000) NULL,
	[ACTIF] [bit] NOT NULL,
	[DATE_ACTIF] [datetime] NOT NULL,
	[UTILISATEUR_CREATION] [varchar](50) NOT NULL,
	[UTILISATEUR_MODIFICATION] [varchar](50) NOT NULL,
	[DATE_CREATION] [datetime] NOT NULL,
	[DATE_MODIFICATION] [datetime] NOT NULL,
 CONSTRAINT [PK_REF_METIER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[COURS]  WITH CHECK ADD  CONSTRAINT [FK_COURS_INDIVIDU] FOREIGN KEY([ID_ENCADREUR])
REFERENCES [dbo].[INDIVIDU] ([ID])
GO
ALTER TABLE [dbo].[COURS] CHECK CONSTRAINT [FK_COURS_INDIVIDU]
GO
ALTER TABLE [dbo].[COURS]  WITH CHECK ADD  CONSTRAINT [FK_COURS_MATIERE] FOREIGN KEY([ID_MATIERE])
REFERENCES [dbo].[MATIERE] ([ID])
GO
ALTER TABLE [dbo].[COURS] CHECK CONSTRAINT [FK_COURS_MATIERE]
GO
ALTER TABLE [dbo].[INDIVIDU]  WITH CHECK ADD  CONSTRAINT [FK_INDIVIDU_REF_CIVILITE] FOREIGN KEY([ID_CIVILITE])
REFERENCES [dbo].[REF_CIVILITE] ([ID])
GO
ALTER TABLE [dbo].[INDIVIDU] CHECK CONSTRAINT [FK_INDIVIDU_REF_CIVILITE]
GO
ALTER TABLE [dbo].[INDIVIDU]  WITH CHECK ADD  CONSTRAINT [FK_INDIVIDU_REF_METIER] FOREIGN KEY([ID_METIER])
REFERENCES [dbo].[REF_METIER] ([ID])
GO
ALTER TABLE [dbo].[INDIVIDU] CHECK CONSTRAINT [FK_INDIVIDU_REF_METIER]
GO
ALTER TABLE [dbo].[INSCRIPTION]  WITH CHECK ADD  CONSTRAINT [FK_INSCRIPTION_INDIVIDU] FOREIGN KEY([ID_ELEVE])
REFERENCES [dbo].[INDIVIDU] ([ID])
GO
ALTER TABLE [dbo].[INSCRIPTION] CHECK CONSTRAINT [FK_INSCRIPTION_INDIVIDU]
GO
ALTER TABLE [dbo].[INSCRIPTION]  WITH CHECK ADD  CONSTRAINT [FK_INSCRIPTION_MATIERE] FOREIGN KEY([ID_MATIERE])
REFERENCES [dbo].[MATIERE] ([ID])
GO
ALTER TABLE [dbo].[INSCRIPTION] CHECK CONSTRAINT [FK_INSCRIPTION_MATIERE]
GO
ALTER TABLE [dbo].[PRESENCE]  WITH CHECK ADD  CONSTRAINT [FK_PRESENCE_INDIVIDU] FOREIGN KEY([ID_ELEVE])
REFERENCES [dbo].[INDIVIDU] ([ID])
GO
ALTER TABLE [dbo].[PRESENCE] CHECK CONSTRAINT [FK_PRESENCE_INDIVIDU]
GO
ALTER TABLE [dbo].[PRESENCE]  WITH CHECK ADD  CONSTRAINT [FK_PRESENCE_MATIERE] FOREIGN KEY([ID_COURS])
REFERENCES [dbo].[COURS] ([ID])
GO
ALTER TABLE [dbo].[PRESENCE] CHECK CONSTRAINT [FK_PRESENCE_MATIERE]
GO
/****** Object:  StoredProcedure [dbo].[D_supprimer_eleve_dun_cours]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE         PROCEDURE [dbo].[D_supprimer_eleve_dun_cours]
		@id_Matiere     int,
		@id_Eleve		int
as
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	
DELETE FROM PRESENCE
WHERE  ID_ELEVE = @id_Eleve AND ID_COURS = @id_Matiere
/*(
SELECT DISTINCT p.ID_COURS
FROM PRESENCE as P
INNER JOIN COURS as c
ON p.ID_COURS = c.ID
where c.ID_MATIERE =  @id_Matiere
)*/

DELETE  FROM INSCRIPTION
where  ID_ELEVE = @id_Eleve AND ID_MATIERE = (
SELECT ID_MATIERE FROM COURS
WHERE ID =@id_Matiere
)

END

GO
/****** Object:  StoredProcedure [dbo].[D_supprimer_Matiere_avec_eleve]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create           PROCEDURE [dbo].[D_supprimer_Matiere_avec_eleve]
		@id_Matiere     int
		as
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	

DECLARE @id int;
SET @id = (select ID_MATIERE from COURS where ID = @id_Matiere)

Delete from  presence WHERE ID_COURS = @id_Matiere
Delete from  COURS WHERE ID = @id_Matiere
Delete from  INSCRIPTION WHERE ID_MATIERE = @id
Delete from  MATIERE WHERE ID = @id

END

GO
/****** Object:  StoredProcedure [dbo].[I_Ajout_Matiere]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     PROCEDURE [dbo].[I_Ajout_Matiere]
		@I_id_prof		int	
as
	 /*@I_commentaire		varchar(2000), 	/* Numéro de version du dossier */
	@I_actif    		bit,    /*bit = 0 Types de couts par individu */
	@I_utilisateur_creation  varchar(50),
	@I_utilisateur_modification  varchar(50)*/
	
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================




INSERT INTO [dbo].[COURS]
           ([ID_MATIERE]
           ,[ID_ENCADREUR]
           ,[LIBELLE]
           ,[DATE_COURS]
           ,[HEURE_DEBUT]
           ,[HEURE_FIN]
           ,[COMMENTAIRE]
           ,[ACTIF]
           ,[DATE_ACTIF]
           ,[UTILISATEUR_CREATION]
           ,[UTILISATEUR_MODIFICATION]
           ,[DATE_CREATION]
           ,[DATE_MODIFICATION])
     VALUES
           ((SELECT MAX(ID) FROM MATIERE)
           ,@I_id_prof
           ,(select LIBELLE from MATIERE where id = (SELECT MAX(ID) FROM MATIERE))
           ,GETDATE()
		   ,null
		   ,null
		   ,null
           ,1
           ,GETDATE()
           ,'yassine'
           ,'yassine'
           ,GETDATE()
           ,GETDATE()
           )
GO
/****** Object:  StoredProcedure [dbo].[I_Ligne_Table_Presence]    Script Date: 20/02/2020 00:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[I_Ligne_Table_Presence]
    @I_id_cours			int,	/* Id de l'enregistrement */
	@I_id_eleve		int	/* Id du dossier */
	 /*@I_commentaire		varchar(2000), 	/* Numéro de version du dossier */
	@I_actif    		bit,    /*bit = 0 Types de couts par individu */
	@I_utilisateur_creation  varchar(50),
	@I_utilisateur_modification  varchar(50)*/
	
as
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================

--@I_id_cours = select ID_MATIERE  from COURS where id = @I_id_cours 

   -- Declare the variable to be used.
DECLARE @id_matiere int;

-- Initialize the variable.
--SET @MyCounter = select ID_MATIERE  from COURS where id = @I_id_cours ; 
--SELECT @I_id_cours = ID  from COURS where ID_MATIERE = @I_id_cours ; 

set @id_matiere =(select ID from COURS where ID_MATIERE = @I_id_cours) ;

 IF(NOT EXISTS (SELECT distinct 1 FROM PRESENCE WHERE [ID_COURS] = @id_matiere and [ID_ELEVE] =@I_id_eleve))
	

DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter < 53)  -- Il y a 52 semaine dans l'année nous inserons donc 52 ligne dans la table 
	BEGIN
 

INSERT INTO PRESENCE
           ([ID_COURS]
           ,[ID_ELEVE]
           ,[PRESENT]
           ,[COMMENTAIRE]
           ,[ACTIF]
           ,[DATE_ACTIF]
           ,[UTILISATEUR_CREATION]
           ,[UTILISATEUR_MODIFICATION]
           ,[DATE_CREATION]
           ,[DATE_MODIFICATION]
           ,[SEMAINE])
     VALUES
           (@id_matiere
           ,@I_id_eleve
           ,1
           ,null
           ,1
           ,GETDATE()
           ,'yassine'
           ,'yassine'
           ,GETDATE()
           ,GETDATE()
           ,@Counter)
    SET @Counter  = @Counter  + 1
END









SET ANSI_NULLS ON
GO
USE [master]
GO
ALTER DATABASE [Institut_Ashralite_ADM] SET  READ_WRITE 
GO
