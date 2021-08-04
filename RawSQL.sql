SELECT *
FROM [Users] AS [u]
INNER JOIN [Posts] AS [p] ON [u].[Id] = [p].[UserId]
INNER JOIN [Likes] AS [l] ON [p].[Id] = [l].[PostId]
WHERE MONTH([l].[Created]) = MONTH({0}) AND YEAR([l].[Created]) = YEAR({0})
GROUP BY [u].[Id]
ORDER BY COUNT ([u].[Id]) DESC

SELECT *
FROM [Users]
WHERE (
	SELECT AVG (COUNT ([l].[Id]))
	FROM [Likes] AS [l]
	INNER JOIN [Posts] AS [p] ON [p].[Id] = [l].[PostId]
	INNER JOIN [Users] AS [u] ON [u].[Id] = [p].[UserId]
	WHERE [u].[Id] = [Users].[Id]
	GROUP BY [u].[Id]
	) >= (
	SELECT AVG (COUNT ([likes].[Id]))
	FROM [Likes] AS [likes]
	INNER JOIN [Posts] AS [posts] ON [posts].[Id] = [likes].[PostId]
	GROUP BY [posts].[Id]
	)