package com.etfbl.is.controllers;

import com.etfbl.is.entities.StavkaEntity;
import com.etfbl.is.repositories.StavkaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/stavke")
public class StavkaController {

    private final StavkaRepository repository;

    public StavkaController(StavkaRepository repository) {
        this.repository = repository;
    }

    @GetMapping("/{idRacuna}")
    public List<StavkaEntity> getAllRacun(@PathVariable Integer idRacuna){
        return repository.getAllByRacunIdracuna(idRacuna);
    }

    @GetMapping("/{idRacuna}/{artikalSifra}")
    public StavkaEntity getStavka(@PathVariable Integer idRacuna,@PathVariable Integer artikalSifra){
        return repository.getByRacunIdracunaAndArtikalSifra(idRacuna,artikalSifra);
    }

    @PostMapping
    public HttpStatus dodajStavku(@RequestBody StavkaEntity stavka){
        try{
            repository.saveAndFlush(stavka);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{idRacuna}/{artikalSifra}")
    public StavkaEntity updateStavka(@PathVariable Integer idRacuna,@PathVariable Integer artikalSifra,@RequestBody StavkaEntity stavka){
        StavkaEntity s=repository.getByRacunIdracunaAndArtikalSifra(idRacuna, artikalSifra);
        if(s!=null){
            stavka.setRacunIdracuna(s.getRacunIdracuna());
            stavka.setArtikalSifra(s.getArtikalSifra());
            repository.saveAndFlush(stavka);
            return stavka;
        }
        return null;
    }
}
