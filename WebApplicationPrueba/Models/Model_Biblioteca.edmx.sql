
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/03/2018 09:29:04
-- Generated from EDMX file: C:\Users\jhernandez\Source\Repos\CRUD-Jedi\WebApplicationPrueba\Models\Model_Biblioteca.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Biblioteca];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_HologramaJedi_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HologramaJedi] DROP CONSTRAINT [FK_HologramaJedi_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_HologramaJedi_ToTable_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HologramaJedi] DROP CONSTRAINT [FK_HologramaJedi_ToTable_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Jedis_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jedis] DROP CONSTRAINT [FK_Jedis_ToTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grado];
GO
IF OBJECT_ID(N'[dbo].[Holograma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Holograma];
GO
IF OBJECT_ID(N'[dbo].[HologramaJedi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HologramaJedi];
GO
IF OBJECT_ID(N'[dbo].[Jedis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jedis];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Grado'
CREATE TABLE [dbo].[Grado] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL
);
GO

-- Creating table 'Holograma'
CREATE TABLE [dbo].[Holograma] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Duracion] float  NOT NULL
);
GO

-- Creating table 'HologramaJedi'
CREATE TABLE [dbo].[HologramaJedi] (
    [Id] int  NOT NULL,
    [idHolograma] int  NOT NULL,
    [idJedi] int  NOT NULL
);
GO

-- Creating table 'Jedis'
CREATE TABLE [dbo].[Jedis] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [idGrado] int  NOT NULL,
    [Edad] int  NULL,
    [Direccion] nvarchar(50)  NULL,
    [Color] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Grado'
ALTER TABLE [dbo].[Grado]
ADD CONSTRAINT [PK_Grado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Holograma'
ALTER TABLE [dbo].[Holograma]
ADD CONSTRAINT [PK_Holograma]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HologramaJedi'
ALTER TABLE [dbo].[HologramaJedi]
ADD CONSTRAINT [PK_HologramaJedi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jedis'
ALTER TABLE [dbo].[Jedis]
ADD CONSTRAINT [PK_Jedis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idGrado] in table 'Jedis'
ALTER TABLE [dbo].[Jedis]
ADD CONSTRAINT [FK_Jedis_ToTable]
    FOREIGN KEY ([idGrado])
    REFERENCES [dbo].[Grado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Jedis_ToTable'
CREATE INDEX [IX_FK_Jedis_ToTable]
ON [dbo].[Jedis]
    ([idGrado]);
GO

-- Creating foreign key on [idHolograma] in table 'HologramaJedi'
ALTER TABLE [dbo].[HologramaJedi]
ADD CONSTRAINT [FK_HologramaJedi_ToTable]
    FOREIGN KEY ([idHolograma])
    REFERENCES [dbo].[Holograma]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HologramaJedi_ToTable'
CREATE INDEX [IX_FK_HologramaJedi_ToTable]
ON [dbo].[HologramaJedi]
    ([idHolograma]);
GO

-- Creating foreign key on [idJedi] in table 'HologramaJedi'
ALTER TABLE [dbo].[HologramaJedi]
ADD CONSTRAINT [FK_HologramaJedi_ToTable_1]
    FOREIGN KEY ([idJedi])
    REFERENCES [dbo].[Jedis]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HologramaJedi_ToTable_1'
CREATE INDEX [IX_FK_HologramaJedi_ToTable_1]
ON [dbo].[HologramaJedi]
    ([idJedi]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------