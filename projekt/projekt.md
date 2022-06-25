# Projekt

## **Hormonogram pracy dla projektu Dziennik Ocen**

1. **Okno Logowania**
    1. Pole do wprowadzania danych oraz niezbędne przyciski
    2. Komunikaty ognośnie błędów logowania (zły login/hasło/ użytkownik nie istnieje)
    3. Tymczasowe dane logowania (admin/admin)
2. **Okno Rejestracji**
    1. Pole do wprowadzania danych oraz niezbędne przyciski
        1. Login
        2. Password
        3. Repat password
        4. Name
        5. Email
    2. Komunikaty ognośnie błędów logowania (zły login/hasło, użytkownik już istnieje, błędny emial)
    3. Dane osoby zakładającej konto (login, hasło, email, imie)
    4. Możliwość zalogowania sie po rejestracji
3. **ToDo view**
    1. Tabelka z zadaniami
        1. ID
        2. Name
        3. StatusName
        4. Tags
        5. Date
    2. Pola do tworzenia/edytowania zadań
        1. Name
        2. Status (Lista)
        3. Date (Date picker)
        4. Tagi (Lista)
    3. Przyciski
        1. Create
        2. Update
        3. Delete
        4. Manage tags
        5. Sign out
4. **Tags view**
    1. Lista z tagami
    2. Pole do wprowadzania nazwy
        1. Create
        2. Update
        3. Delete
        4. Cancel

#### Techniczne

1. **Baza danych**
    1. Tabela użytkownicy
    2. Tabela zadania
    3. Tabelka tagi
    4. Tabela otagowane zadania
2. **ORM - operacje na bazie**
    1. Dodawanie rekordów w bazie
    2. Usuwanie rekordów w bazie
    3. Pobieranie rekordów z bazy
3. **Walidacja danych**
    1. Podczas logowania
    2. Podczas rejestracji
    3. Podczas dodawania zadań
    4. Podczas dodawania tagów
