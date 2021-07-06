package com.etfbl.is.repositories;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.entities.KupacEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ArtikalRepository extends JpaRepository<ArtikalEntity,Integer> {
    ArtikalEntity getByIdartikla(Integer id);
    List<ArtikalEntity> getByNaziv(String naziv);
}
