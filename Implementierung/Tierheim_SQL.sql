if DB_ID('Tierheim') is null
create database Tierheim;


if OBJECT_ID('Tiere') is null
create table Tiere
(
	Tier_ID int primary key identity(1,1),
	Tierart varchar(20),
	Tiername varchar(20),
	Geburtsdatum DateTime,
	Beschreibung varchar(100)
)

if OBJECT_ID('Account') is null
create table Account
(
	Nutzer_ID int primary key identity(1,1),
	Benutzername varchar(20),
	Passwort varchar(20),
	is_ADMIN bit

)

if OBJECT_ID('Anfragen') is null
create table Anfragen
(
	Anfrage_ID int primary key identity(0,1),
	Nutzer_ID int,
	Tier_ID int,
	foreign key (Nutzer_ID) references Account(Nutzer_ID),
	foreign key (Tier_ID) references Tiere(Tier_ID)
)

insert into Account(Benutzername, Passwort, is_ADMIN)
values 
('Peter', '123', 0 ),
('Max', '123', 0 ),
('Klaus', '123', 0 ),
('Amelie', '123', 0 ),
('Lisa', '123', 1 )

insert into Tiere(Tierart,Tiername,Geburtsdatum,Beschreibung)
values 
('Schildkröte', 'Freitag', '2010.1.1', 'Nicht besonderst schnell aber dafür gefrässig'),
('Hund', 'Paula', '2020.1.1','des Menschen bester Freund'),
('Katze', 'Anna','2022.4.3', 'Sie liebt Fisch' ),
('Hund', 'Jule', '2021.2.3','braucht viel Freilauf' ),
('Gekko', 'Prinz', '2024.5.6','liegt nur rum' )


select * from Tiere 
select * from Account

insert into Anfragen(Nutzer_ID, Tier_ID)
values 
(2, 3),
(4, 1),
(4, 5),
(1, 4),
(3, 3)

select a.Anfrage_ID,Benutzername, t.Tiername, t.Tierart from Anfragen as a
join Tiere as t on a.Tier_ID = t.Tier_ID
join Account as n on a.Nutzer_ID = n.Nutzer_ID

