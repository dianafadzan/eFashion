package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Collection;
import java.util.List;
import java.util.Objects;

@Data
@Entity
@Table(name = "artikal")
public class ArtikalEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "sifra", nullable = false)
    private Integer sifra;
    @Basic
    @Column(name = "naziv", nullable = false, length = 255)
    private String naziv;
    @Basic
    @Column(name = "velicina", nullable = false, length = 3)
    private String velicina;
    @Basic
    @Column(name = "kolicina", nullable = false)
    private Integer kolicina;
    @Basic
    @Column(name = "cijena", nullable = false, precision = 2)
    private BigDecimal cijena;
    @Basic
    @Column(name = "slika", nullable = true, length = 255)
    private String slika;
    @ManyToOne
    @JoinColumn(name = "kategorija_idkategorije", referencedColumnName = "idkategorije", nullable = false)
    private KategorijaEntity kategorija;
    @OneToMany(mappedBy = "artikal")
    @JsonIgnore
    private List<StavkaEntity> stavkas;

}
