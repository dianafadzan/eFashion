package com.etfbl.is.models.entities;

import lombok.*;

import javax.persistence.Column;
import javax.persistence.Id;
import java.io.Serializable;

@Data
public class StavkaEntityPK implements Serializable {
    @Column(name = "racun_idracuna", nullable = false)@Id
    private Integer racunIdracuna;
    @Column(name = "artikal_sifra", nullable = false)@Id
    private Integer artikalSifra;

}
