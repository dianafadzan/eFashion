package com.etfbl.is.repositories;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.entities.ArtikalEntityPK;
import com.etfbl.is.entities.KupacEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ArtikalRepository extends JpaRepository<ArtikalEntity, ArtikalEntityPK> {
    List<ArtikalEntity> getByIdartikla(Integer id);
    ArtikalEntity getByIdartiklaAndVelicina(Integer id,String velicina);
    List<ArtikalEntity> getByNaziv(String naziv);

    List<ArtikalEntity> getByNazivAndVelicina(String naziv,String velicina);
}
