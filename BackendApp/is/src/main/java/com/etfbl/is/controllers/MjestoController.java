package com.etfbl.is.controllers;

import com.etfbl.is.entities.MjestoEntity;
import com.etfbl.is.repositories.MjestoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/mjesta")
public class MjestoController {

    @Autowired
    private final MjestoRepository repository;

    public MjestoController(MjestoRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<MjestoEntity> findAll(){
        return  repository.findAll();
    }
}
