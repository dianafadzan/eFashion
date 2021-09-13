package com.etfbl.is.services;


import com.etfbl.is.models.dto.LoginResponse;
import com.etfbl.is.models.requests.LoginRequest;

public interface AuthService {
    LoginResponse login(LoginRequest request);
}
