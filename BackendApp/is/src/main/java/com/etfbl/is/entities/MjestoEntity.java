package com.etfbl.is.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.*;

import javax.persistence.*;
import java.util.List;
import java.util.Objects;

@Data
@Entity
@Table(name = "mjesto")
public class MjestoEntity {
    @Id@Column(name = "postanskibroj", nullable = false)
    private Integer postanskibroj;
    @Basic@Column(name = "naziv", nullable = true, length = 45)
    private String naziv;
    @OneToMany(mappedBy = "mjesto")
    @JsonIgnore
    private List<KupacEntity> kupacs;
    @OneToMany(mappedBy = "mjesto")
    @JsonIgnore
    private List<NarudzbaEntity> narudzbas;

}
