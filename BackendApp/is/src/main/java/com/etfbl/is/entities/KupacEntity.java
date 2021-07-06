package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.util.List;
import java.util.Objects;

@Data
@Entity
@Table(name = "kupac")
public class KupacEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idkupca", nullable = false)
    private Integer idkupca;
    @Basic
    @Column(name = "username", nullable = false, length = 255)
    private String username;
    @Basic
    @Column(name = "email", nullable = false, length = 255)
    private String email;
    @Basic
    @Column(name = "password", nullable = false, length = 255)
    private String password;
    @Basic
    @Column(name = "ime", nullable = false, length = 255)
    private String ime;
    @Basic
    @Column(name = "prezime", nullable = false, length = 255)
    private String prezime;
    @Basic
    @Column(name = "adresa", nullable = false, length = 255)
    private String adresa;
    @Basic
    @Column(name = "brojtelefona", nullable = false, length = 50)
    private String brojtelefona;
    @ManyToOne
    @JoinColumn(name = "postanskibroj", referencedColumnName = "postanskibroj", nullable = false)
    private MjestoEntity mjesto;
    @OneToMany(mappedBy = "kupac")
    @JsonIgnore
    private List<NarudzbaEntity> narudzbe;

}
