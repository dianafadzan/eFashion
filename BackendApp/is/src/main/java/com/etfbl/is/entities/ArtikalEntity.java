package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.List;
import java.util.Objects;

@Data
@Entity
@Table(name = "artikal")
@IdClass(ArtikalEntityPK.class)
public class ArtikalEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idartikla", nullable = false)
    private Integer idartikla;
    @Id
    @Column(name = "velicina", nullable = false, length = 45)
    private String velicina;
    @Basic
    @Column(name = "naziv", nullable = false, length = 255)
    private String naziv;
    @Basic
    @Column(name = "kolicina", nullable = false)
    private Integer kolicina;
    @Basic
    @Column(name = "slika", nullable = true, length = 255)
    private String slika;
    @Basic
    @Column(name = "jedcijena", nullable = false, precision = 2)
    private BigDecimal jedcijena;
    @ManyToOne
    @JoinColumn(name = "idadministratora", referencedColumnName = "idadministratora", nullable = false)
    private AdministratorEntity administrator;
    @OneToMany(mappedBy = "artikal")
    @JsonIgnore
    private List<StavkaEntity> stavkas;

}
