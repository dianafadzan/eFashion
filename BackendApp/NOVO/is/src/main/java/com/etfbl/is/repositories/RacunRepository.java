package com.etfbl.is.repositories;

import com.etfbl.is.entities.RacunEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Date;
import java.util.List;

public interface RacunRepository extends JpaRepository<RacunEntity,Integer> {

    RacunEntity getByIdracuna(Integer id);
    List<RacunEntity> getAllByDatum(Date datum);
    List<RacunEntity> getAllByRadnikJmb(String jmb);
}
