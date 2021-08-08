package com.etfbl.is.entities;

import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Objects;

@Data
@Entity
@Table(name = "stavka")
@IdClass(StavkaEntityPK.class)
public class StavkaEntity {
    @Id
    @Column(name = "racun_idracuna", nullable = false)
    private Integer racunIdracuna;
    @Id
    @Column(name = "artikal_sifra", nullable = false)
    private Integer artikalSifra;
    @Basic
    @Column(name = "kolicina", nullable = false)
    private Integer kolicina;
    @Basic
    @Column(name = "cijena", nullable = false, precision = 2)
    private BigDecimal cijena;
    @ManyToOne
    @JoinColumn(name = "racun_idracuna", referencedColumnName = "idracuna", nullable = false,insertable = false,updatable = false)
    private RacunEntity racun;
    @ManyToOne
    @JoinColumn(name = "artikal_sifra", referencedColumnName = "sifra", nullable = false,insertable = false,updatable = false)
    private ArtikalEntity artikal;

}
