-- ---------------------------------
-- Testni podaci
-- ---------------------------------

insert into kategorija ( idkategorije, naziv) values (null, 'majica');
insert into kategorija ( idkategorije, naziv) values (null, 'haljina');
insert into kategorija ( idkategorije, naziv) values (null, 'hlace');

insert into artikal (sifra, naziv, velicina, kolicina, cijena, slika, kategorija_idkategorije) values (null, 'haljina1', 's', 2, 40.00, load_file('C:\Users\Korisnik\Desktop\eFashion\Word.lnk\eFashion\BackendApp\NOVO\slikeOdjece\haljina1'), 2);
insert into artikal (sifra, naziv, velicina, kolicina, cijena, slika, kategorija_idkategorije) values (null, 'majica1', 's', 3, 20.00, load_file('C:\Users\Korisnik\Desktop\eFashion\Word.lnk\eFashion\BackendApp\NOVO\slikeOdjece\majica1'), 1);
insert into artikal (sifra, naziv, velicina, kolicina, cijena, slika, kategorija_idkategorije) values (null, 'hlace1', 's', 4, 30.00, load_file('C:\Users\Korisnik\Desktop\eFashion\Word.lnk\eFashion\BackendApp\NOVO\slikeOdjece\hlace1'), 3);

insert into radnik (jmb, ime, prezime, username, lozinka, plata, aktivan) values ('1234567890000', 'Mladjo', 'Medic', 'mladjo123', 'f47baffbe0414d1921e434bb687f63b7067cd08841b4422443200c0826111720', 600.00, true);
insert into radnik (jmb, ime, prezime, username, lozinka, plata, aktivan) values ('1234567890001', 'Milana', 'Maric', 'milana123', '8f5b0d96f685d770f54e24850ebb79a96909a8aeb851a52454a02cba350c7e1b', 800.00, true);

insert into administrator (radnik_jmb) values ('1234567890001');


