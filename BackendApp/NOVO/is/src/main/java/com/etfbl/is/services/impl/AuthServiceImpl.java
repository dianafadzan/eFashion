package com.etfbl.is.services.impl;

import com.etfbl.is.models.dto.JwtRadnik;
import com.etfbl.is.models.dto.LoginResponse;
import com.etfbl.is.models.entities.AdministratorEntity;
import com.etfbl.is.models.entities.RadnikEntity;
import com.etfbl.is.models.enums.Role;
import com.etfbl.is.models.requests.LoginRequest;
import com.etfbl.is.repositories.AdministratorRepository;
import com.etfbl.is.repositories.RadnikRepository;
import com.etfbl.is.services.AuthService;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Service;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.Date;
import java.util.List;
import java.util.Optional;


@Service
public class AuthServiceImpl implements AuthService {

    private final AuthenticationManager authenticationManager;
    private final AdministratorRepository administratorRepository;
    private final RadnikRepository radnikRepository;
    @Value("${authorization.token.expiration-time}")
    private String tokenExpirationTime;
    @Value("${authorization.token.secret}")
    private String tokenSecret;
    @Autowired
    private PasswordEncoder passwordEncoder;

    public AuthServiceImpl(AdministratorRepository administratorRepository ,RadnikRepository radnikRepository, AuthenticationManager authenticationManager) {
        this.administratorRepository = administratorRepository;
        this.radnikRepository=radnikRepository;
        this.authenticationManager=authenticationManager;
    }


    @Override
    public LoginResponse login(LoginRequest request) {
        System.out.println(request);
        LoginResponse response = null;
        try {
            System.out.println("2");
            System.out.println("username:" + request.getUsername());
            System.out.println("pass:" + request.getPassword());
            System.out.println(authenticationManager);


            UsernamePasswordAuthenticationToken us = new UsernamePasswordAuthenticationToken(
                    request.getUsername(), request.getPassword()
            );
            /*String usernm = (String) us.getPrincipal();
            String passw = (String) us.getCredentials();
            System.out.println("usernm:" + usernm);
            if (radnikRepository != null) {
                System.out.println("uslo");
                List<RadnikEntity> r = radnikRepository.getAllByUsername(usernm);
                if (r != null) {
                    //System.out.println("radnik:"+r.get(0));

                    if (passwordEncoder.matches(passw, r.get(0).getLozinka())) {
                        System.out.println("matches");
                        UsernamePasswordAuthenticationToken result = new UsernamePasswordAuthenticationToken(r.get(0), passw);
                        result.setDetails(us.getDetails());
                        //System.out.println("result:"+result);
                        JwtRadnik jwtRadnik = new JwtRadnik( usernm, passw, Role.USER);
                        response = new LoginResponse(radnikRepository.getByUsername(usernm));
                        response.setToken(generateJwt(jwtRadnik));

                    } else {
                        System.out.println("not matches");
                    }
                } else {
                    System.out.println("r null");
                }
            }

             */

            System.out.println("us:" + us);


            Authentication authenticate = authenticationManager
                    .authenticate(us);
            System.out.println("3");
            JwtRadnik user = (JwtRadnik) authenticate.getPrincipal();
            System.out.println(user);
            if(radnikRepository.getByUsername(user.getUsername())!=null) {
                System.out.println("radnik");
                if (administratorRepository.getByRadnikUsername(user.getUsername()) != null) {
                    response = new LoginResponse(administratorRepository.getByRadnikUsername(user.getUsername()));
                }
                else
                    response = new LoginResponse(radnikRepository.getByUsername(user.getUsername()));

            }
            response.setToken(generateJwt(user));
        } catch (Exception ex) {
            ex.printStackTrace();

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
