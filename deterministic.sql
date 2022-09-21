SELECT b."Id", b."LastUpdated"
FROM "Blogs" AS b
--WHERE b."LastUpdated" > '2022-09-23'
--WHERE b."LastUpdated" > '2022-10-23' OR (b."LastUpdated" = '2022-10-23' AND b."Id" > 160)
WHERE (b."LastUpdated", b."Id") > ('2022-10-23', 160)
ORDER BY b."LastUpdated", b."Id"
LIMIT 10;