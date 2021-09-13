package com.etfbl.is.models.dto;

import com.etfbl.is.models.enums.Role;
import lombok.Data;

@Data
public class User {
    private String username;
    private Role role;
    private Byte aktivan;
}
