package com.etfbl.is.entities;

import lombok.*;

import javax.persistence.Column;
import javax.persistence.Id;
import java.io.Serializable;
import java.util.Objects;

@Data
public class StavkaEntityPK implements Serializable {
    @Column(name = "idartikla", nullable = false)
    @Id
    private Integer idartikla;
    @Column(name = "velicina", nullable = false, length = 45)
    @Id
    private String velicina;
    @Column(name = "idnarudzbe", nullable = false)
    @Id
    private Integer idnarudzbe;

}
