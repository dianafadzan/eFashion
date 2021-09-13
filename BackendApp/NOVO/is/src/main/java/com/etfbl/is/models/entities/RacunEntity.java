package com.etfbl.is.models.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Date;
import java.util.List;

@Data
@Entity
@Table(name = "racun")
public class RacunEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idracuna", nullable = false)
    private Integer idracuna;
    @Basic
    @Column(name = "datum", nullable = false)
    private Date datum;
    @Basic
    @Column(name = "ukupno", nullable = false, precision = 2)
    private BigDecimal ukupno;
    @ManyToOne
    @JoinColumn(name = "radnik_jmb", referencedColumnName = "jmb", nullable = false)
    private RadnikEntity radnik;
    @OneToMany(mappedBy = "racun")
    @JsonIgnore
    private List<StavkaEntity> stavkas;

}
