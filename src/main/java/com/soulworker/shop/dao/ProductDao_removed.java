package com.soulworker.shop.dao;

import com.soulworker.shop.model.Product_removed;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductDao_removed extends JpaRepository<Product_removed, Long> {
}
