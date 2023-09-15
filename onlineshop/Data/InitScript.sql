IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'onlineshop')
BEGIN
  CREATE DATABASE onlineshop;
END;
GO

use onlineshop;
go


/*
* adding roles
*/
insert into AspNetRoles (Name, NormalizedName, Description, ConcurrencyStamp) values ('BUYER', 'BUYER', 'role which declare a buyer', NEWID());
go
insert into AspNetRoles (Name, NormalizedName, Description, ConcurrencyStamp) values ('SELLER', 'SELLER', 'role which declare e seller', NEWID());
go
insert into AspNetRoles (Name, NormalizedName, Description, ConcurrencyStamp) values ('ADMIN', 'ADMIN', 'role which declare a admin',  NEWID());
go
insert into AspNetRoles (Name, NormalizedName, Description, ConcurrencyStamp) values ('OWNER', 'OWNER', 'role which declare a owner', NEWID());
go

/*
adding users
pass is Root#0000
*/

INSERT INTO AspNetUsers
           (
            UserName,
            NormalizedUserName,
            Email,
			NormalizedEmail,
			EmailConfirmed,            
            PasswordHash,
            KeyWord,
            FullName,
            Birthday,
            Address,
            Country,
            Is_Vip,
            creation_time,
			AccessFailedCount,
            SecurityStamp,
			ConcurrencyStamp,
            PhoneNumber,
			PhoneNumberConfirmed,
			TwoFactorEnabled,
			LockoutEnabled
           )
     VALUES
           (
				 'username1',
				 'USERNAME1',
				 'root@mail.ru',
				 'ROOT@MAIL.RU',
				  0,
				 'odjKsACMavk/78YMFkQJNlmbbKf0N9oak0OuhuElhB0=',
				 '1234',
				 'Ivanov Ivan Ivanovich',
				  CONVERT(datetime2, '2002-02-14'),
				  'Cair, Egypt',
				  'Arabic (Bahrain)',
				  0,
				  GETDATE(),
				  0,
				  NEWID(),
				  NEWID(),
				  '+79045950200',
				  0,
				  0,
				  0
		   );

/*
* adding uerroles;
*/

insert into AspNetUserRoles (UserId, RoleId ) values ((select Id from AspNetUsers where NormalizedUserName = 'username1'), (select Id from AspNetRoles where NormalizedName = 'BUYER'));
go
insert into AspNetUserRoles (UserId, RoleId ) values ((select Id from AspNetUsers where NormalizedUserName = 'username1'), (select Id from AspNetRoles where NormalizedName = 'ADMIN'));
go

insert into AspNetUserRoles (UserId, RoleId ) values ((select Id from AspNetUsers where NormalizedUserName = 'username1'), (select Id from AspNetRoles where NormalizedName = 'SELLER'));
go

insert into AspNetUserRoles (UserId, RoleId ) values ((select Id from AspNetUsers where NormalizedUserName = 'username1'), (select Id from AspNetRoles where NormalizedName = 'OWNER'));
go

/*
* deliverymethods table
*/

insert into deliverymethod (name, description) values ('method 1', 'description 1');
go
insert into deliverymethod (name, description) values ('method 2', 'description 2');
go


/*
* categories table
*/

insert into category (name, description) values ('root category', 'category description');
go
insert into category (name, description) values ('name 2', 'description 2');
go

/*
* supplerfirm
*/

insert into supplerfirm (name, address, country, register_date, rating, description) values ('root supplerfirm', 'root address', 'root country', GETDATE(), 10.0, 'root description');
go
insert into supplerfirm (name, address, country, register_date, rating, description) values ('firm 2', 'address 2', 'country 2', GETDATE(), 8.4, 'description 2');
go

/*
* payment methods
*/

insert into paymentmethod (name, user_id, payment_type, provider, number, CVV ) values ('method 1', (select Id from AspNetUsers where NormalizedEmail='ROOT@MAIL.RU'), 'QIWI', 'provider 1', '123456', 123);
go
insert into paymentmethod (name, user_id, payment_type, provider, number) values ('method 2', (select Id from AspNetUsers where NormalizedEmail='ROOT@MAIL.RU'), 'QIWI', 'provider 2', '123456');
go

/*
* products
*/

insert into product (cipher, name, category_id, supplerfirm_id, count_all, count_this, price, rating, is_hot, description) values ('P#0000-00-00#AAAAAaaaaaaaaaaaaaaa', 'removed product', (select id from category where name='root category'), (select id from supplerfirm where name='root supplerfirm'), 0, 0,0.0, 10.0, 0, 'root description root description'); 
go
insert into product (cipher, name, category_id, supplerfirm_id, count_all, count_this, price, rating, is_hot, description) values ('P#2023-08-12#LPLHYRQK0ba1Bvn7nXVi', 'product 1', (select id from category where name='name 2'), (select id from supplerfirm where name='firm 2'), 1000, 800, 125.40, 8.3, 1, 'description description 1') 
go

/*
* events
*/

insert into event (title, product_id, text, creation_time) values ('title 12345', (select id from product where name = 'product 1'), 'text 123234235235235235 text', GETDATE());
go

/*
* basket
*/

insert into basket (product_id, buyer_id, count, intermediate_cost) values ((select id from product where name='product 1'), (select Id from AspNetUsers where NormalizedEmail='ROOT@MAIL.RU'), 1, (select price from product where name='product 1'));
go


/*
* orders
*/


INSERT INTO [order]
           (
            [cipher]
           ,[count]
           ,[final_price]
           ,[buyer_id]
           ,[deliverymethod_id]
           ,[paymentmethod_id]
           ,[mark]
           ,[receipt_code]
           ,[track_number]
           ,[order_status]
           ,[creation_time])
     VALUES
           (
           'O#2023-08-12#HAPYCLS00DcU5hoNL4F68KRE4wO3s0'
           ,1
           ,125.12
           ,(select id from AspNetUsers where NormalizedEmail = 'ROOT@MAIL.RU')
           ,(select id from deliverymethod where name='method 1')
           ,(select id from paymentmethod where name='method 1')
           ,5
           ,1234
           ,'track1234'
           ,'IN_QUEUE'
           ,GETDATE())

go

/*
*orderproduct
*/

insert into orderproduct (order_id, product_id) values ((select id from [order] where cipher='O#2023-08-12#HAPYCLS00DcU5hoNL4F68KRE4wO3s0'), (select id from product where cipher='P#2023-08-12#LPLHYRQK0ba1Bvn7nXVi'));
go

/*
* comments
*/

insert into comment (tittle, user_id, product_id, text, creation_time) values ('title 1', (select Id from AspNetUsers where NormalizedEmail='ROOT@MAIL.RU'), (select id from product where name='product 1'), 'text of comment 1', GETDATE());
go