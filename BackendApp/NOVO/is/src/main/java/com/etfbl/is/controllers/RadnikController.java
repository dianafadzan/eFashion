package com.etfbl.is.controllers;

import com.etfbl.is.entities.RadnikEntity;
import com.etfbl.is.repositories.RadnikRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/radnici")
public class RadnikController {

    private final RadnikRepository repository;

    public RadnikController(RadnikRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<RadnikEntity> findAll(){
        return repository.findAll();
    }

    @GetMapping("/{jmb}")
    public RadnikEntity getByJmb(@PathVariable String jmb){
        return repository.getByJmb(jmb);
    }

    @GetMapping("/username/{username}")
    public List<RadnikEntity> getByUsername(@PathVariable String username){
        return repository.getAllByUsername(username);
    }

    @GetMapping("/aktivni/{aktivan}")
    public List<RadnikEntity> getAllAktivni(@PathVariable Byte aktivan){
        return repository.getAllByAktivan(aktivan);
    }

    @PutMapping("/{jmb}")
    public RadnikEntity updateRadnik(@PathVariable String jmb,@RequestBody RadnikEntity radnik){
        RadnikEntity r=repository.getByJmb(jmb);
        if(r!=null){
            radnik.setJmb(r.getJmb());
            repository.saveAndFlush(radnik);
            return radnik;
        }
        return null;
    }

    @PostMapping
    public HttpStatus dodajRdnika(@RequestBody RadnikEntity radnik){
        try{
            repository.saveAndFlush(radnik);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }
}
