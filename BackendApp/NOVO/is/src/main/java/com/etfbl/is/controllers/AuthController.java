package com.etfbl.is.controllers;

import com.etfbl.is.models.dto.JwtRadnik;
import com.etfbl.is.models.dto.LoginResponse;
import com.etfbl.is.models.requests.LoginRequest;
import com.etfbl.is.services.AuthService;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;

@RestController
public class AuthController {

    private final AuthService service;
   // private final UserService userService;

    public AuthController(AuthService service) {
        this.service = service;
    }

    @PostMapping("login")
    public LoginResponse login(@RequestBody @Valid LoginRequest request) {
        return service.login(request);
    }

}
