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
@Table(name = "radnik")
public class RadnikEntity {
    @Id
    @Column(name = "jmb", nullable = false, length = 13)
    private String jmb;
    @Basic
    @Column(name = "ime", nullable = false, length = 255)
    private String ime;
    @Basic
    @Column(name = "prezime", nullable = false, length = 255)
    private String prezime;
    @Basic
    @Column(name = "username", nullable = false, length = 255)
    private String username;
    @Basic
    @Column(name = "lozinka", nullable = false, length = 255)
    private String lozinka;
    @Basic
    @Column(name = "plata", nullable = false, precision = 2)
    private BigDecimal plata;
    @Basic
    @Column(name = "aktivan", nullable = false)
    private Byte aktivan;
    @OneToOne(cascade = CascadeType.ALL,mappedBy = "radnik")
    @JsonIgnore
    private AdministratorEntity administrator;
    @OneToMany(mappedBy = "radnik")
    @JsonIgnore
    private List<RacunEntity> racuns;

}
