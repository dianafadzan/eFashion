package com.etfbl.is.repositories;

import com.etfbl.is.entities.AdministratorEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AdministratorRepository extends JpaRepository<AdministratorEntity,String> {
}
