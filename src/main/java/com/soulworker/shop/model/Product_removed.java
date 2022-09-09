package com.soulworker.shop.model;

import lombok.Data;

import javax.persistence.*;
import java.util.List;

@Data
@Entity
@Table(name = "products")
public class Product_removed {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(name = "name", length = 100, nullable = false)
    private String name;
    @ManyToOne
    @JoinColumn(name = "category_id", nullable = false)
    private Category category;
    @Column(name = "price", nullable = false)
    private Double price;
    @Column(name = "count_possible", nullable = false)
    private int countPossible;
    @Column(name = "is_favourite")
    private boolean isFavourite;
    @Column(name = "description")
    private String description;

    @ManyToMany
    @JoinTable(name = "products_soulworkers",
            joinColumns = @JoinColumn(name = "product_id"),
            inverseJoinColumns = @JoinColumn(name = "soulworker_id"))
    private List<SoulWorker> characters;


    @OneToMany(mappedBy = "product")
    private List<Basket> basket;
}
