package com.etfbl.is.controllers;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.repositories.ArtikalRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/artikli")
public class ArtikalController {

    @Autowired
    private final ArtikalRepository repository;


    public ArtikalController(ArtikalRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<ArtikalEntity> findAll(){
        return repository.findAll();
    }

    @GetMapping("/{id}")
    public ArtikalEntity getById(@PathVariable Integer id){
        return repository.getById(id);
    }
    @GetMapping("/naziv/{naziv}")
    public List<ArtikalEntity> getByNaziv(@PathVariable String naziv){
        return repository.getByNaziv(naziv);
    }
}
