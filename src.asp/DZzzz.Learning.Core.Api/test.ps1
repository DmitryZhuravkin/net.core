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

#Invoke-WebRequest does not deal with parsing the data all that much. 
#With -UseBasicParsing, it does some Regex-based HTML parsing. 
#Without this switch, it’ll use the Internet Explorer COM API to parse the document.

#Invoke-RestMethod on the other hand has code to support JSON and XML content. 
#It’ll attempt to detect an appropriate decoder. 
#It does not support HTML (except for XML-compliant HTML, of course).

Invoke-WebRequest http://localhost:7000/api/content/string | select @{n='Content-Type';e={ $_.Headers."Content-Type" }}, Content
Invoke-WebRequest http://localhost:7000/api/content/int | select @{n='Content-Type';e={ $_.Headers."Content-Type" }}, Content
Invoke-WebRequest http://localhost:7000/api/content/object | select @{n='Content-Type';e={ $_.Headers."Content-Type" }}, Content

Invoke-WebRequest http://localhost:7000/api/content/object -Headers @{Accept="application/xml"} | select @{n='Content-Type';e={ $_.Headers."Content-Type" }}, Content
Invoke-WebRequest http://localhost:7000/api/content/jsonobject -Headers @{Accept="application/xml"} | select @{n='Content-Type';e={ $_.Headers."Content-Type" }}, Content

(Invoke-WebRequest http://localhost:7000/api/content/withformatobject/xml).Headers."Content-Type"
