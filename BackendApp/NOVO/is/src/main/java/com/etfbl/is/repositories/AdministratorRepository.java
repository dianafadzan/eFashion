package com.etfbl.is.repositories;

import com.etfbl.is.models.entities.AdministratorEntity;
import com.etfbl.is.models.entities.RadnikEntity;
import com.etfbl.is.models.requests.SignUpRequest;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface AdministratorRepository extends JpaRepository<AdministratorEntity,String> {
    Optional<AdministratorEntity> findByRadnikUsernameAndRadnikAktivan(String username, Byte status);
    <T> T findAdministratorEntityByRadnikUsername(String username,Class<T> response);
}
