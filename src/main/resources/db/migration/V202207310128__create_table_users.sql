/*
 @author MrCalling
 @date 31/07/2022 01:28
 @description declare and init entity users
 */

create table users (id serial not null, user_name varchar(50) not null, email varchar(50) not null, first_name varchar(50) not null, second_name varchar(50) not null, password varchar(100) not null);
/*
 init data
 */
insert into users(user_name, email, first_name, second_name, password) VALUES ('user', 'buyer_noreply@gmail.com', 'Ivanov', 'Ivan', '' );
insert into users(user_name, email, first_name, second_name, password) VALUES ('seller', 'seller_noreply@gmail.com', 'Petrov', 'Petr', '');
insert into users(user_name, email, first_name, second_name, password) VALUES ('general_seller', 'general_seller_noreply@gmail.com', 'Sidorov', 'Vitaly', '');
insert into users(user_name, email, first_name, second_name, password) VALUES ('admin', 'admin_noreply@gmail.com', 'Gorohov','Ivan', '');
insert into users(user_name, email, first_name, second_name, password) VALUES ('owner', 'owner_noreply@gmail.com', 'Rakov', 'Artem','');
