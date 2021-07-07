package com.etfbl.is.controllers;

import com.etfbl.is.entities.PotvrdaEntity;
import com.etfbl.is.repositories.PotvrdaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/potvrde")
public class PotvrdaController {

    private final PotvrdaRepository repository;

    public PotvrdaController(PotvrdaRepository repository) {
        this.repository = repository;
    }

    @PostMapping //nakon ove metode mora da se pozove metoda u NarudzbaController koja ce azurirati idadministratora
    public HttpStatus dodaj(@RequestBody PotvrdaEntity potvrda){
        try{
            repository.saveAndFlush(potvrda);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }


}
