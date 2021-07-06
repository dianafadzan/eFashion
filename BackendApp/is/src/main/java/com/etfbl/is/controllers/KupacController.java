package com.etfbl.is.controllers;

import com.etfbl.is.entities.KupacEntity;
import com.etfbl.is.repositories.KupacRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/kupci")
public class KupacController {

    @Autowired
    private final KupacRepository repository;

    public KupacController(KupacRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    List<KupacEntity> findAll(){
        return  repository.findAll();
    }
}
