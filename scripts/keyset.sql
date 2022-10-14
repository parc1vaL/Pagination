SELECT b."Id", b."LastUpdated"
FROM "Blogs" AS b
WHERE b."Id" > 20
ORDER BY b."Id"
LIMIT 10;