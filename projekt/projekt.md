# Projekt

## **Hormonogram pracy dla projektu Dziennik Ocen**

1. **Okno Logowania**
    1. Pole do wprowadzania danych oraz niezbêdne przyciski
    2. Komunikaty ognoœnie b³êdów logowania (z³y login/has³o/ u¿ytkownik nie istnieje)
    3. Tymczasowe dane logowania
2. **Okno Rejestracji**
    1. Pole do wprowadzania danych oraz niezbêdne przyciski
    2. Komunikaty ognoœnie b³êdów logowania (z³y login/has³o, u¿ytkownik ju¿ istnieje)
    3. Dane osoby zak³adaj¹cej konto (email, imie, nazwisko, adres, pesel)
    4. Mo¿liwoœæ zalogowania sie po rejestracji
3. **Okno moje przedmioty**
    1. Tabelka z przedmiotami
        1. Nazwa przedmiotu
        2. Nauczyciel
        3. Sala
        4. Przycisk do ookna oceny z przedmiotu
        5. Przycisk dodaj oceny dla nauczyciela
    2. Wyszukiwarka po nazwie przedmiotu lub nauczycielu lub sali
    3. Tymczasowe dane do weryfikacji
4. **Okno moje oceny z przedmiotu**
    1. Tabelka z ocenami
        1. Nazwa
        2. Opis oceny
        3. Ocena
5. **Okno dodaj ocenê**
    1. Okno dodaj ocene
        1. Uczeñ
        2. Nazwa
        3. Opis
        4. Ocena
        5. Uczen
6. **Okno mój profil**
    1. Podgl¹d profilu u¿ytkownika, dane osobowe
7. **Okno ustawienie u¿ytkownika**
    1. Mo¿liwoœæ edycji danych podanych podczas rejestracji (email, imie, nazwisko, pesel)
    2. Je¿eli nauczyciel to dodatkowe okno klasa i przedmiot

#### Techniczne

1. **Baza danych**
    1. Tabela u¿ytkownicy
    2. Tabela przedmioty
    3. Tabelka oceny
    4. Tabela nauczyciele
2. **ORM - operacje na bazie**
    1. Dodawanie rekordów w bazie
    2. Usuwanie rekorów w bazie
    3. Pobieranie rekordów z bazy
3. **Walidacja danych**
    1. Podczas logowania
    2. Podczas rejestracji
    3. Podczas dodawania ocen
