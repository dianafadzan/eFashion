package com.etfbl.is.repositories;

import com.etfbl.is.models.entities.RadnikEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface RadnikRepository extends JpaRepository<RadnikEntity,String> {

    RadnikEntity getByJmb(String jmb);
    List<RadnikEntity> getAllByUsername(String username);
    List<RadnikEntity> getAllByAktivan(Byte aktivan);
    Optional<RadnikEntity> findByUsernameAndAktivan(String username, Byte status);
    Optional<RadnikEntity> findByUsername(String username);
    <T> T findByUsername(String username,Class<T> response);

}
