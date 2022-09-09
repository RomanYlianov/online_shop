package com.soulworker.shop.model;

import lombok.Data;
import org.springframework.security.core.GrantedAuthority;

import javax.persistence.*;
import java.util.List;
@Data
@Entity
@Table(name = "positions")
public class Position implements GrantedAuthority {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(name = "name", nullable = false, length = 50)
    private String name;
    @Column(name = "description", length = 100)
    private String description;

    @ManyToMany(mappedBy = "positions", fetch = FetchType.EAGER)
    private List<User> users;


    @Override
    public String getAuthority() {
        return name;
    }
}
