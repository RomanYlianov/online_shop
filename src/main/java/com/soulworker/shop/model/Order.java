package com.soulworker.shop.model;

import lombok.Data;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "orders")
@Data
public class Order {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(name = "cipher", nullable = false)
    private String cipher;
    @ManyToOne
    @JoinColumn(name = "first_position")
    private Basket firstPosition;
    @ManyToOne
    @JoinColumn(name = "last_product")
    private Basket lastPosition;
    @Column(name = "count")
    private Integer count;
    @Column(name = "price")
    private Double price;
    @Column(name = "order_date")
    @Temporal(TemporalType.DATE)
    private Date orderDate;
    @Column(name = "description")
    private String description;

}
