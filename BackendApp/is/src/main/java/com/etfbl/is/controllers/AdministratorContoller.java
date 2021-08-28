package com.etfbl.is.controllers;

import com.etfbl.is.entities.AdministratorEntity;
import com.etfbl.is.repositories.AdministratorRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/administratori")
public class AdministratorContoller  {

    private final AdministratorRepository repository;


    public AdministratorContoller(AdministratorRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<AdministratorEntity> findAll(){
        return repository.findAll();
    }

    @GetMapping("/{username}")
    public AdministratorEntity findByUsername(@PathVariable String username){
        return repository.getByUsername(username);
    }

    @PostMapping("/{username}/{password}")
    public AdministratorEntity provjeri(@PathVariable String username,@PathVariable String password){
        AdministratorEntity administrator=repository.getByUsername(username);
        if(administrator!=null)
            if(administrator.getPassword().equals(password))
                return administrator;
        return null;
    }

    @PostMapping
    public HttpStatus registruj(@RequestBody  AdministratorEntity administrator){
        try{
            repository.saveAndFlush(administrator);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{username}")
    public AdministratorEntity update(@PathVariable String username,@RequestBody AdministratorEntity administrator){
        AdministratorEntity a=repository.getByUsername(username);
        if(a!=null){
            administrator.setIdadministratora(a.getIdadministratora());
            repository.saveAndFlush(administrator);
            return administrator;
        }
        return null;
    }


}
