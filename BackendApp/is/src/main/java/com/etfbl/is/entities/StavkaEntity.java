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
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idartikla", nullable = false)
    private Integer idartikla;
    @Id
    @Column(name = "velicina", nullable = false, length = 45)
    private String velicina;
    @Id
    @Column(name = "idnarudzbe", nullable = false)
    private Integer idnarudzbe;
    @Basic
    @Column(name = "kolicina", nullable = false)
    private Integer kolicina;
    @Basic
    @Column(name = "cijena", nullable = false, precision = 2)
    private BigDecimal cijena;
    @ManyToOne
    @JoinColumns({@JoinColumn(name = "idartikla", referencedColumnName = "idartikla", nullable = false,insertable = false,updatable = false), @JoinColumn(name = "velicina", referencedColumnName = "velicina", nullable = false,insertable = false,updatable = false)})
    private ArtikalEntity artikal;
    @ManyToOne
    @JoinColumn(name = "idnarudzbe", referencedColumnName = "idnarudzbe", nullable = false,insertable = false,updatable = false)
    private NarudzbaEntity narudzba;

}
