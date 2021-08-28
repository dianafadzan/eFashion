package com.etfbl.is.repositories;

import com.etfbl.is.entities.NarudzbaEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface NarudzbaRepository extends JpaRepository<NarudzbaEntity,Integer> {
    NarudzbaEntity getByIdnarudzbe(Integer idNarudzbe);
}
