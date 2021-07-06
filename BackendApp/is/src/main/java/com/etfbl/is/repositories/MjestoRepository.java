package com.etfbl.is.repositories;

import com.etfbl.is.entities.MjestoEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface MjestoRepository extends JpaRepository<MjestoEntity,Integer> {
    MjestoEntity getByPostanskibroj(Integer postanskiBroj);
    MjestoEntity getByNaziv(String naziv);
}
