package com.etfbl.is.controllers;

import com.etfbl.is.entities.KupacEntity;
import com.etfbl.is.entities.MjestoEntity;
import com.etfbl.is.repositories.MjestoRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/mjesta")
public class MjestoController {

    private final MjestoRepository repository;

    public MjestoController(MjestoRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<MjestoEntity> findAll(){
        return  repository.findAll();
    }

    @GetMapping("/{postanskibroj}")
    public MjestoEntity findByPostBroj(@PathVariable Integer postanskibroj){
        System.out.println(postanskibroj);
        return repository.getByPostanskibroj(postanskibroj);
    }

    @GetMapping("/naziv/{naziv}")
    public MjestoEntity findByNaziv(@PathVariable String naziv){
        return repository.getByNaziv(naziv);
    }

    @PostMapping
    public HttpStatus dodaj(@RequestBody MjestoEntity narudzba){
        try{
            repository.saveAndFlush(narudzba);
            return HttpStatus.valueOf(200);
        }
        catch (Exception ex){
            return HttpStatus.valueOf(500);
        }
    }

    @GetMapping("/kupci/{postBroj}")
    public List<KupacEntity> kupci(@PathVariable Integer postBroj){
        MjestoEntity mjesto=repository.getByPostanskibroj(postBroj);
        if(mjesto!=null)
            return mjesto.getKupacs();
        return null;
    }
}
