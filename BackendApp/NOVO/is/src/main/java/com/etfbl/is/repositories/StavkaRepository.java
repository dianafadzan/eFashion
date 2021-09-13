package com.etfbl.is.repositories;

import com.etfbl.is.models.entities.StavkaEntity;
import com.etfbl.is.models.entities.StavkaEntityPK;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface StavkaRepository extends JpaRepository<StavkaEntity, StavkaEntityPK> {

    List<StavkaEntity> getAllByRacunIdracuna(Integer idRacuna);
    StavkaEntity getByRacunIdracunaAndArtikalSifra(Integer idRacuna,Integer artikalSifra);
}
