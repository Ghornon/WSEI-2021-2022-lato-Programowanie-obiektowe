# Projekt

## **Hormonogram pracy dla projektu Dziennik Ocen**

1. **Okno Logowania**
    1. Pole do wprowadzania danych oraz niezb�dne przyciski
    2. Komunikaty ogno�nie b��d�w logowania (z�y login/has�o/ u�ytkownik nie istnieje)
    3. Tymczasowe dane logowania
2. **Okno Rejestracji**
    1. Pole do wprowadzania danych oraz niezb�dne przyciski
    2. Komunikaty ogno�nie b��d�w logowania (z�y login/has�o, u�ytkownik ju� istnieje)
    3. Dane osoby zak�adaj�cej konto (email, imie, nazwisko, adres, pesel)
    4. Mo�liwo�� zalogowania sie po rejestracji
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
5. **Okno dodaj ocen�**
    1. Okno dodaj ocene
        1. Ucze�
        2. Nazwa
        3. Opis
        4. Ocena
        5. Uczen
6. **Okno m�j profil**
    1. Podgl�d profilu u�ytkownika, dane osobowe
7. **Okno ustawienie u�ytkownika**
    1. Mo�liwo�� edycji danych podanych podczas rejestracji (email, imie, nazwisko, pesel)
    2. Je�eli nauczyciel to dodatkowe okno klasa i przedmiot

#### Techniczne

1. **Baza danych**
    1. Tabela u�ytkownicy
    2. Tabela przedmioty
    3. Tabelka oceny
    4. Tabela nauczyciele
2. **ORM - operacje na bazie**
    1. Dodawanie rekord�w w bazie
    2. Usuwanie rekor�w w bazie
    3. Pobieranie rekord�w z bazy
3. **Walidacja danych**
    1. Podczas logowania
    2. Podczas rejestracji
    3. Podczas dodawania ocen
