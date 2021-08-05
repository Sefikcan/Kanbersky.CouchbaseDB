# Kanbersky.CouchbaseDB
 
#TR

Y�klenilen projenin Startup.cs s�n�f�n�n ConfigureServices metoduna services.RegisterKanberskyCouchbaseDB(configuration) eklenir.

Configure metoduna da app.UseKanberskyCouchbaseDB(host); eklenir.

AppSettings.json dosyas�na a�a��daki formatta ekleme yap�lmal�d�r. "CouchbaseDBSettings": { "Servers": [ "http://xxx:8091" ], "Username": "xx", "Password": "aaa" }

#ENG

To the ConfigureServices method of the Startup.cs class of the loaded project services.RegisterKanberskyCouchbaseDB(configuration) is added.

AppSettings.json file should be added in the following format. "CouchbaseDBSettings": { "Servers": [ "http://xxx:8091" ], "Username": "xx", "Password": "aaa" }

Also to the configure method app.UseKanberskyCouchbaseDB(host); is added.