package com.soulworker.shop.dao;

import com.soulworker.shop.model.Position;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface PositionDao extends JpaRepository<Position, Long> {
}
