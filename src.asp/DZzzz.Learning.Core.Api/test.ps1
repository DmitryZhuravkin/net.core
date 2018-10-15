# GET all reservations
Invoke-RestMethod http://localhost:7000/api/reservation -Method GET

#GET one reservation
Invoke-RestMethod http://localhost:7000/api/reservation/1 -Method GET

#POST create new
Invoke-RestMethod http://localhost:7000/api/reservation -Method POST -Body (@{clientName="Anne"; location="Meeting Room 4"} | ConvertTo-Json) -ContentType "application/json"

#PUT replace reservation
Invoke-RestMethod http://localhost:7000/api/reservation -Method PUT -Body (@{reservationId="1"; clientName="Bob"; location="Media Room"} | ConvertTo-Json) -ContentType "application/json"

#PATCH update
Invoke-RestMethod http://localhost:7000/api/reservation/2 -Method PATCH -Body (@{ op="replace"; path="clientName"; value="Bob"},@{ op="replace"; path="location"; value="Lecture Hall"} | ConvertTo-Json) -ContentType "application/json"

#DELETE delete
Invoke-RestMethod http://localhost:7000/api/reservation/2 -Method DELETE