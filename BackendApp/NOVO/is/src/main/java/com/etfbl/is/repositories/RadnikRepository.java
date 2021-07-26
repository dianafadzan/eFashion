package com.etfbl.is.repositories;

import com.etfbl.is.entities.RadnikEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface RadnikRepository extends JpaRepository<RadnikEntity,String> {

    RadnikEntity getByJmb(String jmb);
    List<RadnikEntity> getAllByUsername(String username);
    List<RadnikEntity> getAllByAktivan(Byte aktivan);
}
