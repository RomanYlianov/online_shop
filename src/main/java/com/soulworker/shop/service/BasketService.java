package com.soulworker.shop.service;

import com.soulworker.shop.model.Basket;
import com.soulworker.shop.model.User;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface BasketService {

    List<Basket> getAllProductsInBasket(User user);
    Optional<Basket> getBasketDetails();
    Optional<Basket> addProductToBasket();
    Optional<Basket> updateProductInBasket(Basket item);
    void removeProductFromBasket(Basket item);
}
