/*
 @author MrCalling
 @date 31/07/2022 02:38
 @description declare and init entity products
 */

 create table products (id serial primary key, name varchar(100) not null, category_id bigint not null, price real not null, count_possible int not null, is_favourite bool default false, description varchar(100), constraint fk_categories foreign key (category_id) references categories (id));

/*
 init
*/

