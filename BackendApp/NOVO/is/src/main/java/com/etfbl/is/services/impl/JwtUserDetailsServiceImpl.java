package com.etfbl.is.services.impl;

import com.etfbl.is.models.dto.JwtRadnik;
import com.etfbl.is.models.entities.AdministratorEntity;
import com.etfbl.is.models.entities.RadnikEntity;
import com.etfbl.is.models.enums.Role;
import com.etfbl.is.repositories.AdministratorRepository;
import com.etfbl.is.repositories.RadnikRepository;
import com.etfbl.is.services.JwtUserDetailsService;
import org.modelmapper.ModelMapper;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;


import java.util.Optional;


@Service
public class JwtUserDetailsServiceImpl implements JwtUserDetailsService {

    private final AdministratorRepository administratorRepository;
    private final RadnikRepository radnikRepository;


    public JwtUserDetailsServiceImpl(AdministratorRepository administratorRepository, RadnikRepository radnikRepository) {
        this.administratorRepository = administratorRepository;
        this.radnikRepository = radnikRepository;
    }


    @Override
    public JwtRadnik loadUserByUsername(String username) throws UsernameNotFoundException {
        Optional<RadnikEntity> radnik = radnikRepository.findByUsernameAndAktivan(username, (byte) 1);
        if (radnik != null) {
            Optional<AdministratorEntity> administrator = administratorRepository.findByRadnikUsernameAndRadnikAktivan(username, (byte) 1);
            if (administrator != null) {
                JwtRadnik jwtRadnik = new JwtRadnik(administrator.get().getRadnik().getUsername(), administrator.get().getRadnik().getLozinka(), Role.ADMIN);
                return jwtRadnik;
            } else {
                JwtRadnik jwtRadnik = new JwtRadnik(administrator.get().getRadnik().getUsername(), administrator.get().getRadnik().getLozinka(), Role.USER);
                return jwtRadnik;
            }
        } else
            return null;
    }
}
