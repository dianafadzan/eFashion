package com.etfbl.is.controllers;

import com.etfbl.is.entities.KupacEntity;
import com.etfbl.is.entities.NarudzbaEntity;
import com.etfbl.is.repositories.KupacRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/kupci")
public class KupacController {

    @Autowired
    private final KupacRepository repository;

    public KupacController(KupacRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    List<KupacEntity> findAll() {
        return repository.findAll();
    }

    @GetMapping("/{username}")
    KupacEntity findByUsername(@PathVariable String username){
        return repository.getByUsername(username);
    }

    @PostMapping("/{username}/{password}")
    public KupacEntity provjeri(@PathVariable String username, @PathVariable String password) {
        KupacEntity kupac = repository.getByUsername(username);
        if (kupac != null)
            if (kupac.getPassword().equals(password))
                return kupac;
        return null;
    }

    @PostMapping
    public HttpStatus registruj(@RequestBody KupacEntity kupac){
        try {
            repository.saveAndFlush(kupac);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{username}")
    public KupacEntity update(@PathVariable String username,@RequestBody KupacEntity kupac){
        KupacEntity k=repository.getByUsername(username);
        if(k!=null){
            kupac.setIdkupca(k.getIdkupca());
            repository.saveAndFlush(kupac);
            return kupac;
        }
        return null;
    }

    @GetMapping("/{username}/narudzbe")
    public List<NarudzbaEntity> narudzbe(@PathVariable String username){
        KupacEntity kupac=repository.getByUsername(username);
        return kupac.getNarudzbe();
    }

}
