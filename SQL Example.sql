DECLARE @__ToLower_0 nvarchar(4000) = N'post';

SELECT [p].[Id], [p].[Created], [p].[Header], [p].[PostAttributeId], [p].[Updated], [p].[UserId], [u].[Id], [u].[Created], [u].[Email], [u].[FirstName], [u].[IsVerified], [u].[LastName], [u].[Password], [u].[Sol], [u].[UserRoleId], [u].[UserStatus], [t].[Id], [t].[Text], [t].[ImageId], [t].[Discriminator]
FROM [Posts] AS [p]
LEFT JOIN (
    SELECT [p0].[Id], [p1].[Text], [p2].[ImageId], CASE
        WHEN [p2].[Id] IS NOT NULL THEN N'PostImageAttribute'
        WHEN [p1].[Id] IS NOT NULL THEN N'PostTextAttribute'
    END AS [Discriminator]
    FROM [PostAttributes] AS [p0]
    LEFT JOIN [PostTextAttributes] AS [p1] ON [p0].[Id] = [p1].[Id]
    LEFT JOIN [PostImageAttributes] AS [p2] ON [p0].[Id] = [p2].[Id]
) AS [t] ON [p].[PostAttributeId] = [t].[Id]
INNER JOIN [Users] AS [u] ON [p].[UserId] = [u].[Id]
WHERE ([t].[Discriminator] IN (N'PostTextAttribute', N'PostImageAttribute') AND ((@__ToLower_0 LIKE N'') 
OR (CHARINDEX(@__ToLower_0, LOWER([t].[Text])) > 0))) OR (([t].[Discriminator] = N'PostImageAttribute') 
AND ((@__ToLower_0 LIKE N'') OR (CHARINDEX(@__ToLower_0, LOWER([t].[Text])) > 0)))

exec sp_executesql N'SELECT [p].[Id], [p].[Created], [p].[Header], [p].[PostAttributeId], [p].[Updated], [p].[UserId], [u].[Id], [u].[Created], [u].[Email], [u].[FirstName], [u].[IsVerified], [u].[LastName], [u].[Password], [u].[Sol], [u].[UserRoleId], [u].[UserStatus], [t].[Id], [t].[Text], [t].[ImageId], [t].[Discriminator]
FROM [Posts] AS [p]
LEFT JOIN (
    SELECT [p0].[Id], [p1].[Text], [p2].[ImageId], CASE
        WHEN [p2].[Id] IS NOT NULL THEN N''PostImageAttribute''
        WHEN [p1].[Id] IS NOT NULL THEN N''PostTextAttribute''
    END AS [Discriminator]
    FROM [PostAttributes] AS [p0]
    LEFT JOIN [PostTextAttributes] AS [p1] ON [p0].[Id] = [p1].[Id]
    LEFT JOIN [PostImageAttributes] AS [p2] ON [p0].[Id] = [p2].[Id]
) AS [t] ON [p].[PostAttributeId] = [t].[Id]
INNER JOIN [Users] AS [u] ON [p].[UserId] = [u].[Id]
WHERE ([t].[Discriminator] IN (N''PostTextAttribute'', N''PostImageAttribute'') AND ((@__ToLower_0 LIKE N'''') 
OR (CHARINDEX(@__ToLower_0, LOWER([t].[Text])) > 0))) OR (([t].[Discriminator] = N''PostImageAttribute'') 
AND ((@__ToLower_0 LIKE N'''') OR (CHARINDEX(@__ToLower_0, LOWER([t].[Text])) > 0)))
',N'@__ToLower_0 nvarchar(4000)',@__ToLower_0=N'post'