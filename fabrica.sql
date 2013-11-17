/************************** WAMPSERVER *********************/

create database fabrica;

	use fabrica;

	create table empresa (
		id int (20) not null auto_increment,
		nombre varchar (20) not null,
		direccion varchar (20) not null,
		telefono varchar (20) not null,
		email varchar (50) not null,
		primary key (id)
	);
