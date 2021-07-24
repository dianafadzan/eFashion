package com.etfbl.is.entities;

import lombok.*;

import javax.persistence.*;
import java.util.Objects;

@Data
@Entity
@Table(name = "administrator")
public class AdministratorEntity {
    @Id
    @Column(name = "radnik_jmb", nullable = false, length = 13)
    private String radnikJmb;
    @OneToOne
    @JoinColumn(name = "radnik_jmb", referencedColumnName = "jmb", nullable = false)
    private RadnikEntity radnik;

}
