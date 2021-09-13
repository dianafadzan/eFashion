package com.etfbl.is.models.dto;

import com.etfbl.is.models.enums.Role;
import lombok.*;

@Data
public class User {
    private String jmb;
    private String username;
    private Byte aktivan;

    public User(String jmb, String username, Byte aktivan) {
        this.jmb = jmb;
        this.username = username;
        this.aktivan = aktivan;
    }
}
