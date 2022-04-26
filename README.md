# WSEI | 2021/2022 lato | labN/1/ISN | Programowanie obiektowe

https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-labs-pa3ek1

## Lab 1

[lab_1](lab_1)

## Projekt

### **Hormonogram pracy dla projektu Dziennik Ocen**

1. **Okno Logowania**
    1. Pole do wprowadzania danych oraz niezbędne przyciski
    2. Komunikaty ognośnie błędów logowania (zły login/hasło/ użytkownik nie istnieje)
    3. Tymczasowe dane logowania
2. **Okno Rejestracji**
    1. Pole do wprowadzania danych oraz niezbędne przyciski
    2. Komunikaty ognośnie błędów logowania (zły login/hasło, użytkownik już istnieje)
    3. Dane osoby zakładającej konto (email, imie, nazwisko, adres, pesel)
    4. Możliwość zalogowania sie po rejestracji
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
5. **Okno dodaj ocenę**
    1. Okno dodaj ocene
        1. Uczeń
        2. Nazwa
        3. Opis
        4. Ocena
        5. Uczen
6. **Okno mój profil**
    1. Podgląd profilu użytkownika, dane osobowe
7. **Okno ustawienie użytkownika**
    1. Możliwość edycji danych podanych podczas rejestracji (email, imie, nazwisko, pesel)
    2. Jeżeli nauczyciel to dodatkowe okno klasa i przedmiot

#### Techniczne

1. **Baza danych**
    1. Tabela użytkownicy
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
