/*
@author MrCalling
@date 30/07/2022 23:33
@description declare and init table soulworkers
 */

create table soulworkers (id serial primary key , full_name varchar(50) not null, age int not null, birthday date not null, control int not null, gun varchar(50) not null, uid bigint default null);

/*
 init data
 */

insert into soulworkers (full_name, age, birthday, control, gun) VALUES ('Haru Estia', 17, '1970-09-17',4,'SoulSoulum' );
insert into soulworkers(full_name, age, birthday, control, gun) VALUES ('Lily Bloommerchen', 15, '1970-02-27', 3, 'Mist Scythe');
insert into soulworkers(full_name, age, birthday, control, gun) VALUES ('Stella Unibell', 14, '1970-06-25', 4, 'Howling Guitar');
insert into soulworkers (full_name, age, birthday, control, gun) VALUES ('Iris Youma', 18, '1970-11-04', 5, 'Hammerstol');
insert into soulworkers (full_name, age, birthday, control, gun) VALUES ('Erwin Erwin Arclight', '1970-05-29', 4, 'Gun Jazz');
insert into soulworkers (full_name, age, birthday, control, gun) VALUES ('Jin Seipatsu', 17, '1970-07-28', 4, 'Spirit Arms');
