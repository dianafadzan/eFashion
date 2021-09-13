package com.etfbl.is.models.dto;

import com.etfbl.is.models.entities.AdministratorEntity;
import com.etfbl.is.models.entities.RadnikEntity;
import lombok.Data;
import lombok.EqualsAndHashCode;

@EqualsAndHashCode(callSuper = true)
@Data
public class LoginResponse extends User {
    private String token;

    public LoginResponse(RadnikEntity radnik){
        super(radnik.getJmb(),radnik.getUsername(),radnik.getAktivan());
        this.token=null;
    }

    public LoginResponse(AdministratorEntity administrator){
        super(administrator.getRadnikJmb(),administrator.getRadnik().getUsername(),administrator.getRadnik().getAktivan());
        this.token=null;
    }
}
