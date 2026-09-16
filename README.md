# Buchverwaltung

Kleine Web-App mit ASP.NET Core MVC und Entity Framework Core (SQLite).
Buecher anlegen, bearbeiten, loeschen, suchen.

## Starten

Braucht .NET 8 SDK.

```
cd Buchverwaltung
dotnet restore
dotnet run
```

Die Datenbank wird beim ersten Start automatisch angelegt.

## Struktur

- Controllers/BuecherController.cs - die ganze Logik
- Models/Buch.cs - Datenmodell
- Data/AppDbContext.cs - EF Core Verbindung zur Datenbank
- Views/Buecher/ - die Seiten
