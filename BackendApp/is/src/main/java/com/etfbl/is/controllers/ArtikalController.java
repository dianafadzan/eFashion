package com.etfbl.is.controllers;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.repositories.ArtikalRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/artikli")
public class ArtikalController {

    private final ArtikalRepository repository;


    public ArtikalController(ArtikalRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<ArtikalEntity> findAll() {
        return repository.findAll();
    }

    @GetMapping("/svi")
    public List<ArtikalEntity> findAllRazliciti(){
        return repository.findAllRazliciti();
    }

    @GetMapping("/{id}")
    public List<ArtikalEntity> getById(@PathVariable Integer id) {
        return repository.getByIdartikla(id);
    }

    @GetMapping("/naziv/{naziv}")
    public List<ArtikalEntity> getByNaziv(@PathVariable String naziv) {
        return repository.getByNaziv(naziv);
    }

    @GetMapping("/{id}/{velicina}")
    public ArtikalEntity getByIdAndVelicina(@PathVariable Integer id, @PathVariable String velicina) {
        return repository.getByIdartiklaAndVelicina(id, velicina);
    }

    @GetMapping("/naziv/{naziv}/{velicina}")
    public List<ArtikalEntity> getByNazivAndVelicina(@PathVariable String naziv, @PathVariable String velicina) {
        return repository.getByNazivAndVelicina(naziv, velicina);
    }

    @PostMapping
    public HttpStatus dodajArtikal(@RequestBody ArtikalEntity artikal) {
        try {
            repository.saveAndFlush(artikal);
            return HttpStatus.valueOf(200);
        } catch (Exception e) {
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{id}/{velicina}")
    public ArtikalEntity updateArtikal(@PathVariable Integer id, @PathVariable String velicina, @RequestBody ArtikalEntity artikal) {
        ArtikalEntity a = repository.getByIdartiklaAndVelicina(id, velicina);
        if (a != null) {
            artikal.setIdartikla(id);
            artikal.setVelicina(velicina);
            repository.saveAndFlush(artikal);
            return artikal;
        }
        return null;
    }


}
