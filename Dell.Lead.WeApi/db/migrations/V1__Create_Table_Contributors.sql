CREATE TABLE contributors(
	id BIGINT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(155) NOT NULL,
	cpf BIGINT UNIQUE NOT NULL,
	date_of_birth DATE NOT NULL,
	cellfone BIGINT NOT NULL,
	gender VARCHAR(30) NOT NULL,
	address_id BIGINT NOT NULL
);
