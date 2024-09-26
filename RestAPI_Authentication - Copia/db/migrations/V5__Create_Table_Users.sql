create table users (
	id int IDENTITY(1,1) PRIMARY KEY,
	user_name varchar(50) UNIQUE not null,
	password varchar(130) not null,
	full_name varchar(130) not null,
	refresh_token varchar(500) null,
	refresh_token_expiry_time DateTime null
);