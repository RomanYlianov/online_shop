package com.soulworker.shop.service;

import com.soulworker.shop.model.Product_removed;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface ProductService {

    List<Product_removed> getAllProducts();

    Optional<Product_removed> getProductsDetails();

    Optional<Product_removed> addNewProduct(Product_removed item);

    Optional<Product_removed> updateNewProduct(Product_removed item);

    void removeProduct(Long id);

}
