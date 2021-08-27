-- -------------------------------------------------------
-- trigeri za mijenjanje kolicine artikala pri kupovini
-- -------------------------------------------------------

delimiter $$
create trigger artikal_update after insert 
on stavka
for each row
begin
	update artikal
    set kolicina = kolicina-new.kolicina
    where sifra=new.artikal_sifra;
end $$
delimiter ;


delimiter $$
create trigger artikal_del after delete 
on stavka
for each row
begin
	update artikal
    set kolicina = kolicina+old.kolicina
    where sifra=old.artikal_sifra;
end $$
delimiter ;


