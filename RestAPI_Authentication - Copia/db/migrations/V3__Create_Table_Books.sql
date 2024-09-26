create table books (
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(100) not null,
	author varchar(80) not null,
	publisher varchar(80) not null,
	genre varchar(20) not null
);