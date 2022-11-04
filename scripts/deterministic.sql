SELECT b."Id", b."LastUpdated"
FROM "Blogs" AS b
WHERE b."LastUpdated" > '2022-11-12'
-- WHERE b."LastUpdated" > '2022-11-12' OR (b."LastUpdated" = '2022-11-12' AND b."Id" > 10)
-- WHERE (b."LastUpdated", b."Id") > ('2022-11-12', 10)
ORDER BY b."LastUpdated"
-- ORDER BY b."LastUpdated", b."Id"
LIMIT 10;