package com.soulworker.shop.dao;

import com.soulworker.shop.model.Basket;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface BasketDao extends JpaRepository<Basket, Long> {
}
