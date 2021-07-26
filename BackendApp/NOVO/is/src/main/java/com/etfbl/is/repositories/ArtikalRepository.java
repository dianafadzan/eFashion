package com.etfbl.is.repositories;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.entities.KategorijaEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface ArtikalRepository extends JpaRepository<ArtikalEntity,Integer> {
    ArtikalEntity getBySifra(Integer id);

    List<ArtikalEntity> getAllByKategorija(KategorijaEntity kategorija);

    List<ArtikalEntity> getAllByKategorijaNaziv(String naziv);
    List<ArtikalEntity> getAllByKategorijaNazivAndVelicina(String naziv,String velicina);

    //@Query("select new com.etfbl.is.dto.ArtikalKategorija(a.sifra,a.naziv,a.velicina,a.kolicina,a.cijena,k.idkategorije,k.naziv) from ArtikalEntity a inner join KategorijaEntity k on a.kategorija.idkategorije=k.idkategorije")
    //List<ArtikalKategorija> getArtikaliKategorija();

    /*
    @Query("select a from ArtikalEntity a group by a.sifra")
    List<ArtikalEntity> findAllRazlicitiId();

    @Query("select a from ArtikalEntity a group by a.naziv")
    List<ArtikalEntity> findAllRazlicinitNaziv();

     */

}
