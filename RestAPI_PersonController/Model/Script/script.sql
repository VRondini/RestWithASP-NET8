create table person (
	id int IDENTITY(1,1) PRIMARY KEY,
	address varchar(100) not null,
	first_name varchar(80) not null,
	last_name varchar(80) not null,
	gender varchar(6) not null
)