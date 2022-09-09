package com.soulworker.shop.service;

import com.soulworker.shop.model.Category;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface CategoryService {
    List<Category> getAllCategories();
    Optional<Category> getCategoryDetails(Long id);
    Optional<Category> addCategory(Category item);
    Optional<Category> updateCategory();
    void removeCategory();
}
