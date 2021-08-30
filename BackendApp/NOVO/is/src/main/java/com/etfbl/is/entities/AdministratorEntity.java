package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
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
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "radnik_jmb", referencedColumnName = "jmb", nullable = false)
    @PrimaryKeyJoinColumn
    private RadnikEntity radnik;

}
