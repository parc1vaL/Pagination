SELECT b."Id", b."LastUpdated"
FROM "Blogs" AS b
WHERE b."LastUpdated" > '2022-11-12'
--WHERE b."LastUpdated" > '2022-11-12' OR (b."LastUpdated" = '2022-11-12' AND b."Id" > 160)
--WHERE (b."LastUpdated", b."Id") > ('2022-11-12', 160)
ORDER BY b."LastUpdated"
--ORDER BY b."LastUpdated", b."Id"
LIMIT 10;