CREATE TABLE [dbo].[KindaRepository] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Size1]   DECIMAL (18)   NOT NULL,
    [Size2]   DECIMAL (18)   NOT NULL,
    [Size3]   DECIMAL (18)   NOT NULL,
    [Model]   IMAGE          NOT NULL,
    [Path]    NVARCHAR (255) NOT NULL,
    [DimVal1] DECIMAL (18)   DEFAULT ((0)) NOT NULL,
    [DimVal2] DECIMAL (18)   DEFAULT ((0)) NOT NULL,
    [DimVal3] DECIMAL (18)   DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

