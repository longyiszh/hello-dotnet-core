CREATE TABLE [dbo].[Ceremonies]
(
	[Id] INT NOT NULL , 
    [AcolyteID] INT NOT NULL, 
    [SceneID] INT NOT NULL, 
    [Performance] FLOAT NULL DEFAULT 0.0, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Ceremonies_ToAcolytes] FOREIGN KEY ([AcolyteID]) REFERENCES [Acolytes]([Id]),
    CONSTRAINT [FK_Ceremonies_ToScenes] FOREIGN KEY ([SceneID]) REFERENCES [Scenes]([Id])
)
