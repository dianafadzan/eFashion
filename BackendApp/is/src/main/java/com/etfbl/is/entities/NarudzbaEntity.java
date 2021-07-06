package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Date;
import java.util.List;
import java.util.Objects;

@Data
@Entity
@Table(name = "narudzba")
public class NarudzbaEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idnarudzbe", nullable = false)
    private Integer idnarudzbe;
    @Basic
    @Column(name = "ukupnacijena", nullable = false, precision = 2)
    private BigDecimal ukupnacijena;
    @Basic
    @Column(name = "datum", nullable = false)
    private Date datum;
    @Basic
    @Column(name = "adresa", nullable = false, length = 255)
    private String adresa;
    @Basic
    @Column(name = "ime", nullable = false, length = 255)
    private String ime;
    @Basic
    @Column(name = "prezime", nullable = false, length = 255)
    private String prezime;
    @Basic
    @Column(name = "brojtelefona", nullable = false, length = 50)
    private String brojtelefona;
    @Basic
    @Column(name = "isporuceno", nullable = false)
    private Byte isporuceno;
    @ManyToOne
    @JoinColumn(name = "idadministratora", referencedColumnName = "idadministratora")
    private AdministratorEntity administrator;
    @ManyToOne
    @JoinColumn(name = "postanskibroj", referencedColumnName = "postanskibroj", nullable = false)
    private MjestoEntity mjesto;
    @ManyToOne
    @JoinColumn(name = "idkupca", referencedColumnName = "idkupca", nullable = false)
    private KupacEntity kupac;
    @OneToOne(mappedBy = "narudzba")
    @JsonIgnore
    private PotvrdaEntity potvrdas;
    @OneToMany(mappedBy = "narudzba")
    @JsonIgnore
    private List<StavkaEntity> stavkas;

}
