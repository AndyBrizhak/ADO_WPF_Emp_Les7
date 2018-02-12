CREATE TABLE [dbo].[Emp] (
    [Id]    INT           NOT NULL,
    [Name]  NVARCHAR (50) NOT NULL,
    [IdDep] NVARCHAR(50)           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Emp_Dep] FOREIGN KEY ([IdDep]) REFERENCES [dbo].[Dep] ([Id])
);

