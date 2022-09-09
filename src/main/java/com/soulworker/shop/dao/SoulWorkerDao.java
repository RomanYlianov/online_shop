package com.soulworker.shop.dao;

import com.soulworker.shop.model.SoulWorker;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SoulWorkerDao extends JpaRepository<SoulWorker,Long> {
}
