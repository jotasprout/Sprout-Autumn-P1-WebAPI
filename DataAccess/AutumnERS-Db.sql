
-- Tickets by User
select * from AutumnERS.tickets where author_fk = 4;

UPDATE AutumnERS.tickets SET status = 'Approved' WHERE ticketID = 16;
UPDATE AutumnERS.users SET userRole = 'employee' WHERE userID = 16;

-- OLD -- 

create schema AutumnERS;

--The constraint is found by running the second command and copy-pasting the specified constraint in the error msg

alter table AutumnERS.users drop constraint PK__users__CBA1B257E40D9164;
alter table AutumnERS.users drop column userid;

alter table AutumnERS.tickets drop column author_fk;
alter table AutumnERS.tickets drop constraint FK__tickets__author___7A3223E8;

alter table AutumnERS.tickets drop column resolver_fk;
alter table AutumnERS.tickets drop constraint FK__tickets__resolve__7B264821;

drop table AutumnERS.users;

create table AutumnERS.users(
	userID int identity (1,1) unique not null,
	userName varchar (50) unique not null,
	password varchar (50) not null,
	userRole varchar (50) default 'employee',
	primary key (userID)
);

drop table AutumnERS.tickets;
truncate table AutumnERS.tickets;

create table AutumnERS.tickets(
	ticketID int identity (1,1) not null,
	author_fk int foreign key references AutumnERS.users(userID) not null,
	resolver_fk int foreign key references AutumnERS.users(userID) default 2,
	description varchar (255) not null,
	status varchar (50) default 'pending',
	amount money not null,
	primary key(ticketID)
);

UPDATE AutumnERS.users SET userRole = 'employee' WHERE userID = 16;
UPDATE AutumnERS.users SET userRole = 'employee' WHERE userID = 3;
UPDATE AutumnERS.users SET userRole = 'employee' WHERE userID = 4;

insert into AutumnERS.users (userName, password, userRole) values ('paulstanley', 'kiss', 'manager');	 -- ID = 1
insert into AutumnERS.users (userName, password, userRole) values ('genesimmons', 'kiss', 'manager');	 -- ID = 2
insert into AutumnERS.users (userName, password) values ('petercriss', 'kiss');							 -- ID = 3
insert into AutumnERS.users (userName, password) values ('acefrehley', 'kiss');							 -- ID = 4
insert into AutumnERS.users (userName, password, userRole) values ('ericcarr', 'kiss', 'employee');		 -- ID = 5
insert into AutumnERS.users (userName, password, userRole) values ('ericsinger', 'kiss', 'employee');	 -- ID = 6
insert into AutumnERS.users (userName, password) values ('brucekulick', 'kiss');						 -- ID = 7
insert into AutumnERS.users (userName, password) values ('markstjohn', 'kiss');							 -- ID = 8
insert into AutumnERS.users (userName, password) values ('vinnievincent', 'kiss');						 -- ID = 9
insert into AutumnERS.users (userName, password) values ('tommythayer', 'kiss');						 -- ID = 10

select * from AutumnERS.tickets where author_fk = 4;
UPDATE AutumnERS.tickets SET status = 'Approved' WHERE ticketID = 16;

insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (3, 2, 'kitty litter', 'pending', 34.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'cocaine', 'pending', 678.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'guitar strings', 'pending', 22.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'alcohol', 'pending', 965.32);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (3, 2, 'drumsticks', 'pending', 9.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'edibles', 'pending', 278.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'heroin', 'pending', 122.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (5, 2, 'paper', 'pending', 9.32);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (10, 2, 'spoonguard', 'pending', 34.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (7, 2, 'sharpies', 'pending', 4.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (7, 2, 'razor', 'pending', 8.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'doggie bags', 'pending', 49.32);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'web hosting', 'pending', 5034.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'selfie stick', 'pending', 5.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'bail money', 'pending', 1000.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'scarves', 'pending', 65.32);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (1, 2, 'sunglasses', 'pending', 5034.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (1, 2, 'glitter', 'pending', 25.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (2, 1, 'pocket mirrors', 'pending', 100.99);
insert into AutumnERS.tickets (author_fk, resolver_fk, description, status, amount) values (2, 1, 'condoms', 'pending', 65.32);
