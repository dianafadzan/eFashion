package com.etfbl.is.repositories;

import com.etfbl.is.entities.StavkaEntity;
import com.etfbl.is.entities.StavkaEntityPK;
import org.springframework.data.jpa.repository.JpaRepository;

public interface StavkaRepository extends JpaRepository<StavkaEntity, StavkaEntityPK> {
    StavkaEntity getByIdnarudzbeAndIdartiklaAndVelicina(Integer idNarudzbe,Integer idArtikla,String velicina);
}
