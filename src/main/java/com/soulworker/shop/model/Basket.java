package com.soulworker.shop.model;

import lombok.Data;

import javax.persistence.*;
import java.util.List;


@Entity
@Table(name = "basket")
@Data
public class Basket {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne
    @JoinColumn(name = "product_id")
    private Product_removed product;

    @Column(name = "count")
    private Integer count;

    @Column(name = "price")
    private Double price;

    @OneToMany(mappedBy = "firstPosition")
    private List<Order> firstPosition;

    @OneToMany(mappedBy = "lastPosition")
    private List<Order> lastProduct;

}
