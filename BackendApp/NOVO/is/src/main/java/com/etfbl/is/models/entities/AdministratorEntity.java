package com.etfbl.is.models.entities;

import lombok.*;

import javax.persistence.*;

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
