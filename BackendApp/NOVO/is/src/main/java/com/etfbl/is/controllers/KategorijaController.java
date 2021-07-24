package com.etfbl.is.controllers;

import com.etfbl.is.entities.KategorijaEntity;
import com.etfbl.is.repositories.KategorijaRepository;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/kategorije")
public class KategorijaController {

    private final KategorijaRepository repository;

    public KategorijaController(KategorijaRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<KategorijaEntity> getAll(){
        return repository.findAll();
    }
}
