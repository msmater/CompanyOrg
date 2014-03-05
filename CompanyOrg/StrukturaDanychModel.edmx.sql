
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2014 15:41:32
-- Generated from EDMX file: C:\__workspace\CompanyOrg\CompanyOrg\StrukturaDanychModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CompanyOrg];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_jednostka_organizacyjnauzytkownik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[uzytkownik] DROP CONSTRAINT [FK_jednostka_organizacyjnauzytkownik];
GO
IF OBJECT_ID(N'[dbo].[FK_lokalizacjauzytkownik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[uzytkownik] DROP CONSTRAINT [FK_lokalizacjauzytkownik];
GO
IF OBJECT_ID(N'[dbo].[FK_komputerlokalizacja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[komputer] DROP CONSTRAINT [FK_komputerlokalizacja];
GO
IF OBJECT_ID(N'[dbo].[FK_komputeruzytkownik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[komputer] DROP CONSTRAINT [FK_komputeruzytkownik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[jednostka_organizacyjna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[jednostka_organizacyjna];
GO
IF OBJECT_ID(N'[dbo].[komputer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[komputer];
GO
IF OBJECT_ID(N'[dbo].[lokalizacja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lokalizacja];
GO
IF OBJECT_ID(N'[dbo].[uzytkownik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[uzytkownik];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'jednostka_organizacyjna'
CREATE TABLE [dbo].[jednostka_organizacyjna] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(100)  NOT NULL,
    [kod] nvarchar(20)  NOT NULL,
    [status] bit  NOT NULL,
    [id_manager] int  NOT NULL,
    [MPK] nvarchar(50)  NULL,
    [id_nadrzedna] int  NOT NULL
);
GO

-- Creating table 'komputer'
CREATE TABLE [dbo].[komputer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(50)  NOT NULL,
    [nazwa_dns] nvarchar(50)  NOT NULL,
    [numer_seryjny] nvarchar(50)  NOT NULL,
    [host_name] nvarchar(50)  NOT NULL,
    [MPK] nvarchar(50)  NULL,
    [szczegoly_lokalizacji] nvarchar(50)  NULL,
    [nr_inwentarzowy] nvarchar(50)  NOT NULL,
    [wartosc_poczatkowa] nvarchar(50)  NULL,
    [wartosc_netto] nvarchar(50)  NULL,
    [numer_ot] nvarchar(50)  NULL,
    [typ_komputera] int  NOT NULL,
    [nr_id_system_zew] nvarchar(50)  NULL,
    [cd_dvd] bit  NULL,
    [karta_sieciowa] bit  NULL,
    [adres_ip] nvarchar(50)  NOT NULL,
    [zegar_cpu] nvarchar(50)  NULL,
    [ilosc_proc] int  NULL,
    [ilosc_ram] int  NULL,
    [rozmiar_hdd] nvarchar(50)  NOT NULL,
    [rozmiar_monitora] nvarchar(50)  NULL,
    [nazwa_monitora] nvarchar(50)  NOT NULL,
    [model_procesora] int  NOT NULL,
    [model_komputera] nvarchar(50)  NULL,
    [lokalizacjaId] int  NOT NULL,
    [wlascicielID] int  NOT NULL
);
GO

-- Creating table 'lokalizacja'
CREATE TABLE [dbo].[lokalizacja] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ulica] nvarchar(50)  NULL,
    [miasto] nvarchar(50)  NOT NULL,
    [kod_pocztowy] nvarchar(50)  NULL,
    [pokoj] nvarchar(100)  NULL
);
GO

-- Creating table 'uzytkownik'
CREATE TABLE [dbo].[uzytkownik] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nazwisko] nvarchar(50)  NOT NULL,
    [imie] nvarchar(50)  NOT NULL,
    [NRE] nvarchar(25)  NOT NULL,
    [drugie_imie] nvarchar(50)  NULL,
    [status] bit  NOT NULL,
    [login_AD] nvarchar(50)  NOT NULL,
    [typ_kontaktu] int  NOT NULL,
    [typ_dostepu] int  NOT NULL,
    [stanowisko] int  NULL,
    [AWiZ] bit  NULL,
    [delegacja_akceptacji] int  NULL,
    [tel_kom] nvarchar(50)  NULL,
    [tel_stac] nvarchar(50)  NULL,
    [email] nvarchar(60)  NULL,
    [MPK] nvarchar(50)  NULL,
    [jednostka_organizacyjnaID_JO] int  NOT NULL,
    [lokalizacjaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'jednostka_organizacyjna'
ALTER TABLE [dbo].[jednostka_organizacyjna]
ADD CONSTRAINT [PK_jednostka_organizacyjna]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'komputer'
ALTER TABLE [dbo].[komputer]
ADD CONSTRAINT [PK_komputer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lokalizacja'
ALTER TABLE [dbo].[lokalizacja]
ADD CONSTRAINT [PK_lokalizacja]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'uzytkownik'
ALTER TABLE [dbo].[uzytkownik]
ADD CONSTRAINT [PK_uzytkownik]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [jednostka_organizacyjnaID_JO] in table 'uzytkownik'
ALTER TABLE [dbo].[uzytkownik]
ADD CONSTRAINT [FK_jednostka_organizacyjnauzytkownik]
    FOREIGN KEY ([jednostka_organizacyjnaID_JO])
    REFERENCES [dbo].[jednostka_organizacyjna]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_jednostka_organizacyjnauzytkownik'
CREATE INDEX [IX_FK_jednostka_organizacyjnauzytkownik]
ON [dbo].[uzytkownik]
    ([jednostka_organizacyjnaID_JO]);
GO

-- Creating foreign key on [lokalizacjaId] in table 'uzytkownik'
ALTER TABLE [dbo].[uzytkownik]
ADD CONSTRAINT [FK_lokalizacjauzytkownik]
    FOREIGN KEY ([lokalizacjaId])
    REFERENCES [dbo].[lokalizacja]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_lokalizacjauzytkownik'
CREATE INDEX [IX_FK_lokalizacjauzytkownik]
ON [dbo].[uzytkownik]
    ([lokalizacjaId]);
GO

-- Creating foreign key on [lokalizacjaId] in table 'komputer'
ALTER TABLE [dbo].[komputer]
ADD CONSTRAINT [FK_komputerlokalizacja]
    FOREIGN KEY ([lokalizacjaId])
    REFERENCES [dbo].[lokalizacja]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_komputerlokalizacja'
CREATE INDEX [IX_FK_komputerlokalizacja]
ON [dbo].[komputer]
    ([lokalizacjaId]);
GO

-- Creating foreign key on [wlascicielID] in table 'komputer'
ALTER TABLE [dbo].[komputer]
ADD CONSTRAINT [FK_komputeruzytkownik]
    FOREIGN KEY ([wlascicielID])
    REFERENCES [dbo].[uzytkownik]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_komputeruzytkownik'
CREATE INDEX [IX_FK_komputeruzytkownik]
ON [dbo].[komputer]
    ([wlascicielID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------