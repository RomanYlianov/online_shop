package com.soulworker.shop.configuration;

import com.soulworker.shop.model.User;
import com.soulworker.shop.service.UserService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.convert.converter.Converter;

import java.util.Optional;

public class UserConverter implements Converter<String, User> {

    @Autowired
    private UserService service;

    Logger logger = LoggerFactory.getLogger(UserConverter.class);

    @Override
    public User convert(String source) {
        Optional<User> item = null;
        try{
            Long id = Long.parseLong(source);
            item = service.getUserDetails(id);
        }
        catch (Exception e){
            logger.error(e.getStackTrace().toString());
        }
        return item.isPresent()? item.get(): null;
    }
}
