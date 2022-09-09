package com.soulworker.shop.configuration;

import com.soulworker.shop.model.Position;
import com.soulworker.shop.service.PositionService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.convert.converter.Converter;

import java.util.Optional;

public class PositionConverter implements Converter<String, Position> {

    private Logger logger = LoggerFactory.getLogger(PositionConverter.class);

    @Autowired
    private PositionService service;

    @Override
    public Position convert(String source) {
        Optional<Position> item = null;
        try{
            Long id = Long.parseLong(source);
            Optional<Position> result = service.getPositionDetails(id);
        }
        catch (Exception e){
            logger.error(e.getStackTrace().toString());
        }
        return item.isPresent()? item.get(): null;
    }
}
