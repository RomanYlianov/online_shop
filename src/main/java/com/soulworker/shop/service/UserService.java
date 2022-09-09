package com.soulworker.shop.service;

import com.soulworker.shop.model.User;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

@Service
public interface UserService {
    List<User> getAllUsers();

    Optional<User> getUserDetails(Long id);

    Optional<User> addNewUser(User item);

    Optional<User> updateNewUser(User item);

    void removeUser(Long id);

    Boolean addUserToRole(User item, String roleName);

    Boolean removeUserFromRole(User item, String roleName);
}
