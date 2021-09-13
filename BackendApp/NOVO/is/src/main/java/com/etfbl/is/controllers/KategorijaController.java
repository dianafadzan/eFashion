package com.etfbl.is.controllers;

import com.etfbl.is.models.entities.KategorijaEntity;
import com.etfbl.is.repositories.KategorijaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

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

    @PostMapping
    public HttpStatus dodajKategpriju(@RequestBody KategorijaEntity kategorija){
        try{
            repository.saveAndFlush(kategorija);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }
}
