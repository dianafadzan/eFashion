package com.etfbl.is.controllers;

import com.etfbl.is.entities.AdministratorEntity;
import com.etfbl.is.entities.NarudzbaEntity;
import com.etfbl.is.entities.PotvrdaEntity;
import com.etfbl.is.entities.StavkaEntity;
import com.etfbl.is.repositories.NarudzbaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/narudzbe")
public class NarudzbaContoller {

    private final NarudzbaRepository repository;

    public NarudzbaContoller(NarudzbaRepository repository) {
        this.repository = repository;
    }

    @GetMapping("/{id}")
    public NarudzbaEntity findById(@PathVariable Integer id){
        return repository.getByIdnarudzbe(id);
    }

    @GetMapping("/potvrda/{id}")
    public PotvrdaEntity findPotvrda(@PathVariable Integer id){
        NarudzbaEntity narudzba=repository.getByIdnarudzbe(id);
        if(narudzba!=null)
            return narudzba.getPotvrdas();
        return null;
    }

    @GetMapping("/stavke/{id}")
    public List<StavkaEntity> findAllStavke(@PathVariable Integer id){
        NarudzbaEntity narudzba=repository.getByIdnarudzbe(id);
        if(narudzba!=null)
            return narudzba.getStavkas();
        return null;
    }

    @PostMapping
    public HttpStatus dodaj(@RequestBody NarudzbaEntity narudzba){
        try{
            repository.saveAndFlush(narudzba);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{id}")
    public NarudzbaEntity update(@RequestBody NarudzbaEntity narudzba,@PathVariable Integer id){
        NarudzbaEntity n=repository.getByIdnarudzbe(id);
        if(n!=null){
            narudzba.setIdnarudzbe(n.getIdnarudzbe());
            repository.saveAndFlush(narudzba);
            return narudzba;
        }
        return null;
    }

    @PutMapping("/administrator/{id}")
    public NarudzbaEntity updateAdministrator(@PathVariable Integer id, @RequestBody AdministratorEntity administrator){
        NarudzbaEntity narudzba=repository.getByIdnarudzbe(id);
        if(narudzba!=null){
            narudzba.setAdministrator(administrator);
            repository.saveAndFlush(narudzba);
            return narudzba;
        }
        return null;
    }
}
