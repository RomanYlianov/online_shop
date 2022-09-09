package com.soulworker.shop.model;

import lombok.Data;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

@Data
@Entity
@Table(name = "soulworkers")
public class SoulWorker {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "full_name", nullable = false, length = 100)
    private String fullName;

    @Column(name = "control")
    private int control;

    @Column(name = "gun", length = 50)
    private String gun;

    @Column(name = "birthday")
    @Temporal(TemporalType.DATE)
    private Date birthday;
    @Column(name = "age")
    private int age;
    @Column(name = "description")
    private String description;

    @ManyToMany(mappedBy = "characters", fetch = FetchType.EAGER)
    List<Product_removed> products;

    @ManyToMany(mappedBy = "characters", fetch = FetchType.EAGER)
    private List<User> user;
}
