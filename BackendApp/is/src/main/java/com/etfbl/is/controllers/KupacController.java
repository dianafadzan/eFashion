package com.etfbl.is.controllers;

import com.etfbl.is.entities.KupacEntity;
import com.etfbl.is.repositories.KupacRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.ExampleMatcher;
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

    @PostMapping("/{username}/{password}")
    public KupacEntity provjeri(@PathVariable String username, @PathVariable String password) {
        KupacEntity kupac = repository.getByUsername(username);
        if (kupac != null)
            if (kupac.getPassword().equals(password))
                return kupac;
        return null;
    }


}
