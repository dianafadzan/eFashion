package com.etfbl.is.controllers;

import com.etfbl.is.entities.RacunEntity;
import com.etfbl.is.repositories.RacunRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/racuni")
public class RacunController {

    private final RacunRepository repository;

    public RacunController(RacunRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<RacunEntity> findAll(){
        return repository.findAll();
    }

    @GetMapping("/{id}")
    public RacunEntity getById(@PathVariable Integer id){
        return repository.getByIdracuna(id);
    }

    @GetMapping("/datum/{datum}")
    public List<RacunEntity> getAllByDatum(@PathVariable Date datum){
        System.out.println(datum);
        return repository.getAllByDatum(datum);
    }

    @GetMapping("/radnik/{jmb}")
    public List<RacunEntity> getAllByRadnik(@PathVariable String jmb){
        return repository.getAllByRadnikJmb(jmb);
    }

    @GetMapping("/period/{datumOd}/{datumDo}")
    public List<RacunEntity> getAllPerion(@PathVariable Date datumOd,@PathVariable Date datumDo){
        List<RacunEntity> lista=repository.findAll();
        return lista.stream().filter(e->e.getDatum().compareTo(datumOd)>=0 || e.getDatum().compareTo(datumDo)<0).collect(Collectors.toList());
    }

    @PostMapping
    public HttpStatus dodajRacun(@RequestBody RacunEntity racun){
        try{
            repository.saveAndFlush(racun);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }


    @PutMapping("/{id}")
    public RacunEntity updateRacun(@PathVariable Integer id,@RequestBody RacunEntity racun){
        RacunEntity r=repository.getByIdracuna(id);
        if(r!=null){
            racun.setIdracuna(r.getIdracuna());
            repository.saveAndFlush(racun);
            return racun;
        }
        return null;
    }


}
