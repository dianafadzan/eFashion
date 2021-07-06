package com.etfbl.is.repositories;

import com.etfbl.is.entities.KupacEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface KupacRepository extends JpaRepository<KupacEntity,Integer> {
    KupacEntity getByUsername(String username);

}
