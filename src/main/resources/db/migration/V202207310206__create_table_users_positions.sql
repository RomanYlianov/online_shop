/*
 @author MrCalling
 @date 31/07/2022 02:07
 @description declare and init entity users_positions
 */

create table users_positions (id serial primary key, uid bigint not null, pid bigint not null, constraint fk_user foreign key (uid) references users (id) on delete cascade, constraint fk_positions foreign key (pid) references positions (id) on delete cascade);

/*
 init
*/

insert into users_positions (uid, pid) VALUES (1, 1);
insert into users_positions (uid, pid) VALUES (2, 2);
insert into users_positions (uid, pid) VALUES (3, 3);
insert into users_positions (uid, pid) VALUES (4, 4);
insert into users_positions (uid, pid) VALUES (5, 5);