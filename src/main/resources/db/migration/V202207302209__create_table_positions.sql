/*
 @author MrCalling
 @date 30/07/2022 22:20
 @description declare and init entity positions
 */

create table positions (id serial primary key, name varchar (50) not null, description varchar(100) not null );
/*
 init data
 */
insert into positions (name, description) VALUES ('user', 'just a user');
insert into positions (name, description) VALUES ('seller', 'handles order processing');
insert into positions (name, description) VALUES ('general_seller', 'create and delete information about products and categories');
insert into positions (name, description) VALUES ('admin', 'moderate information about users');
insert into positions (name, description) VALUES ('owner', 'shop owner, have all access for all information on site');