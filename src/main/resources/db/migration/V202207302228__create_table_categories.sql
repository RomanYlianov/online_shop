/*
 @author MrCalling
 @date 30/07/2022 22:59
 @description declare and init entity categories
 */

 create table categories (id serial primary key , name varchar(50) not null, description varchar(100) not null)

 /*
  init data
  */

insert into categories (name, description) VALUES ('top up cubic shop', 'include different count of cubic');
insert into categories (name, description) VALUES ('cubic shop', 'include premium items which is located in cubic shop');
insert into categories (name, description) VALUES ('costume shop', 'include different costumes for each character');
insert into categories (name, description) VALUES ('package shop', 'contains various packages with game resources');