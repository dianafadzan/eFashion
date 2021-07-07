package com.etfbl.is.controllers;

import com.etfbl.is.entities.StavkaEntity;
import com.etfbl.is.repositories.StavkaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;


@RestController
@RequestMapping("/stavke")
public class StavkaController {

    private final StavkaRepository repository;

    public StavkaController(StavkaRepository repository) {
        this.repository = repository;
    }

    @GetMapping("/{idNarudzbe}/{idArtikla}/{velicina}")
    public StavkaEntity findbyId(@PathVariable Integer idNarudzbe,@PathVariable Integer idArtikla,@PathVariable String velicina){
        return repository.getByIdnarudzbeAndIdartiklaAndVelicina(idNarudzbe,idArtikla,velicina);
    }

    @PostMapping
    public HttpStatus dodaj(@RequestBody StavkaEntity stavka){
        try{
            repository.saveAndFlush(stavka);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{idNarudzbe}/{idArtikla}/{velicina}")
    public StavkaEntity update(@PathVariable Integer idNarudzbe,@PathVariable Integer idArtikla,@PathVariable String velicina, @RequestBody StavkaEntity stavka){
        StavkaEntity s=repository.getByIdnarudzbeAndIdartiklaAndVelicina(idNarudzbe,idArtikla,velicina);
        if(s!=null){
            stavka.setIdnarudzbe(s.getIdnarudzbe());
            stavka.setIdartikla(s.getIdartikla());
            stavka.setVelicina(s.getVelicina());
            repository.saveAndFlush(stavka);
            return stavka;
        }
        return null;
    }
}
