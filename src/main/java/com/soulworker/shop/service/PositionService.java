package com.soulworker.shop.service;


import org.springframework.stereotype.Service;
import com.soulworker.shop.model.*;
import java.util.List;
import java.util.Optional;


@Service
public interface PositionService {
    List<Position> getAllPositions();

    Optional<Position> getPositionDetails(Long id);

    Optional<Position> addNewPosition(Position item);

    Optional<Position> updateNewPosition(Position item);

    void removePosition(Long id);
}
