# Kanbersky.CouchbaseDB
 
#TR

Yüklenilen projenin Startup.cs sýnýfýnýn ConfigureServices metoduna services.RegisterKanberskyCouchbaseDB(configuration) eklenir.

Configure metoduna da app.UseKanberskyCouchbaseDB(host); eklenir.

AppSettings.json dosyasýna aþaðýdaki formatta ekleme yapýlmalýdýr. "CouchbaseDBSettings": { "Servers": [ "http://xxx:8091" ], "Username": "xx", "Password": "aaa" }

#ENG

To the ConfigureServices method of the Startup.cs class of the loaded project services.RegisterKanberskyCouchbaseDB(configuration) is added.

AppSettings.json file should be added in the following format. "CouchbaseDBSettings": { "Servers": [ "http://xxx:8091" ], "Username": "xx", "Password": "aaa" }

Also to the configure method app.UseKanberskyCouchbaseDB(host); is added.