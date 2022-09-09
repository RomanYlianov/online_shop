package com.soulworker.shop.model;

import lombok.Data;

import javax.persistence.*;

@Entity
@Table(name = "set")
@Data
public class Set {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "name", length = 50)
    private String name;

    @Column(name = "description")
    private String description;

}
