package com.soulworker.shop.service;

import com.soulworker.shop.model.Order;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public interface OrderService {

    List<Order> getAllOrders();
    Optional<Order> getOrderDetails();

    Optional<Order> updateOrder();

}
