package com.etfbl.is.entities;

import lombok.*;

import javax.persistence.*;
import java.sql.Date;
import java.util.Objects;

@Data
@Entity
@Table(name = "potvrda")
public class PotvrdaEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idpotvrde", nullable = false)
    private Integer idpotvrde;
    @Basic
    @Column(name = "proslanarudzba", nullable = false)
    private Byte proslanarudzba;
    @Basic
    @Column(name = "datumobrade", nullable = false)
    private Date datumobrade;
    @OneToOne
    @JoinColumn(name = "idnarudzbe", referencedColumnName = "idnarudzbe", nullable = false)
    private NarudzbaEntity narudzba;

}
