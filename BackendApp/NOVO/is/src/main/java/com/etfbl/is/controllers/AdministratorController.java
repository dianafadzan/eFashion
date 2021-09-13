package com.etfbl.is.controllers;

import com.etfbl.is.models.entities.AdministratorEntity;
import com.etfbl.is.repositories.AdministratorRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/administratori")
public class AdministratorController {

    private final AdministratorRepository repository;

    public AdministratorController(AdministratorRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<AdministratorEntity> findAll(){
        return repository.findAll();
    }

    @PostMapping
    public HttpStatus dodajAdministratora(@RequestBody AdministratorEntity administrator){
        try{
            repository.saveAndFlush(administrator);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

}
