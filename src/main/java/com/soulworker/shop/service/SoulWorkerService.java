package com.soulworker.shop.service;

import com.soulworker.shop.model.SoulWorker;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface SoulWorkerService {
    List<SoulWorker> getAllCharacters();
    Optional<SoulWorker> getCharacterDetails();
    Optional<SoulWorker> addNewCharacter(SoulWorker item);
    Optional<SoulWorker> updateCharacter(SoulWorker item);
    void removeCharacter(Long id);
}
