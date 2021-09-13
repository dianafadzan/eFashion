package com.etfbl.is.services.impl;

import com.etfbl.is.models.dto.JwtRadnik;
import com.etfbl.is.models.dto.LoginResponse;
import com.etfbl.is.models.requests.LoginRequest;
import com.etfbl.is.repositories.AdministratorRepository;
import com.etfbl.is.repositories.RadnikRepository;
import com.etfbl.is.services.AuthService;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Service;


import java.util.Date;

@Service
public class AuthServiceImpl implements AuthService {

    private final AuthenticationManager authenticationManager;
    private final AdministratorRepository administratorRepository;
    private final RadnikRepository radnikRepository;
    @Value("${authorization.token.expiration-time}")
    private String tokenExpirationTime;
    @Value("${authorization.token.secret}")
    private String tokenSecret;

    public AuthServiceImpl(AdministratorRepository administratorRepository ,RadnikRepository radnikRepository, AuthenticationManager authenticationManager) {
        System.out.println("prvi");
        this.administratorRepository = administratorRepository;
        this.radnikRepository=radnikRepository;
        this.authenticationManager=authenticationManager;
        System.out.println(radnikRepository);
        System.out.println(administratorRepository);
    }


    @Override
    public LoginResponse login(LoginRequest request) {
        System.out.println(request);
        LoginResponse response = null;
        try {
            System.out.println("2");
            Authentication authenticate = authenticationManager
                    .authenticate(
                            new UsernamePasswordAuthenticationToken(
                                    request.getUsername(), request.getPassword()
                            )
                    );
            System.out.println("3");
            JwtRadnik user = (JwtRadnik) authenticate.getPrincipal();
            System.out.println(user);
            if(radnikRepository==null) {
                System.out.println("radnik");
                response = administratorRepository.findAdministratorEntityByRadnikUsername(user.getUsername(), LoginResponse.class);
            }
            else{
                System.out.println("administrator");
                response = radnikRepository.findByUsername(user.getUsername(), LoginResponse.class);
            }
            response.setToken(generateJwt(user));
        } catch (Exception ex) {
            ex.printStackTrace();
            //LoggingUtil.logException(ex, getClass());
            //throw new UnauthorizedException();
        }
        return response;
    }

    private String generateJwt(JwtRadnik user) {
        return Jwts.builder()
                .setId(user.getUsername())
                .setSubject(user.getUsername())
                .claim("role", user.getRole().name())
                .setExpiration(new Date(System.currentTimeMillis() + Long.parseLong(tokenExpirationTime)))
                .signWith(SignatureAlgorithm.HS512, tokenSecret)
                .compact();
    }
}
