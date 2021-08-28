package com.etfbl.is.controllers;

import com.etfbl.is.entities.ArtikalEntity;
import com.etfbl.is.entities.KategorijaEntity;
import com.etfbl.is.repositories.ArtikalRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/artikli")
public class ArtikalController {

    private final ArtikalRepository repository;


    public ArtikalController(ArtikalRepository repository) {
        this.repository = repository;
    }

    @GetMapping
    public List<ArtikalEntity> findAll() {
        return repository.findAll();
    }

    /*
    @GetMapping("/svi/id")
    public List<ArtikalEntity> findAllRazlicitiId(){
        return repository.findAllRazlicitiId();
    }

    @GetMapping("/svi/naziv")
    public List<ArtikalEntity> findAllRazlicitiNaziv(){
        return repository.findAllRazlicinitNaziv();
    }

    */

    @GetMapping("/{sifra}")
    public ArtikalEntity getBySifra(@PathVariable Integer sifra) {
        return repository.getBySifra(sifra);
    }



    @GetMapping("/kategorija")
    public List<ArtikalEntity> getByKategorija(@RequestBody KategorijaEntity kategorija) {
        return repository.getAllByKategorija(kategorija);
    }

    /*

    @GetMapping("/kategorija/string")
    public String getByKategorija() {
        return "Kategorijaaaaa";
    }

    */


    @GetMapping("/kategorija/{naziv}/{velicina}")
    public List<ArtikalEntity> getByKategorijaVelicina(@PathVariable String naziv, @PathVariable String velicina) {
        return repository.getAllByKategorijaNazivAndVelicina(naziv,velicina);
    }

    @GetMapping("kategorija/{naziv}")
    public List<ArtikalEntity> getByNazivKategorije(@PathVariable String naziv){
        return repository.getAllByKategorijaNaziv(naziv);
    }

    @PostMapping
    public HttpStatus dodajArtikal(@RequestBody ArtikalEntity artikal) {
        try {
            repository.saveAndFlush(artikal);
            return HttpStatus.valueOf(200);
        } catch (Exception e) {
            return HttpStatus.valueOf(500);
        }
    }

    @PutMapping("/{id}")
    public ArtikalEntity updateArtikal(@PathVariable Integer id, @RequestBody ArtikalEntity artikal) {
        ArtikalEntity a = repository.getBySifra(id);
        if (a != null) {
            artikal.setSifra(id);
            repository.saveAndFlush(artikal);
            return artikal;
        }
        return null;
    }


}
