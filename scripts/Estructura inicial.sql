use EVENTOS;

create table Usuarios (
	Id int identity(1, 1) not null,
	Usuario varchar(50) not null,
	Contrasenia binary(64) not null,
	Nombre varchar(50) not null,
	Correo varchar(100) not null
	primary key(Id)
);

create table Participante (
	Id int identity(1, 1) not null,
	Nombre varchar(150),
	Empresa varchar(100),
	Cargo varchar(100),
	Telefono int,
	Correo varchar(100),
	Estado varchar(20),
	primary key(Id)
);

create table Empleado (
	Id int identity(1, 1) not null,
	Nombre varchar(150),
	Salario decimal(21, 2),
	Telefono int,
	Correo varchar(100),
	Estado varchar(20),
	primary key(Id)
);

create table Sala (
	Id int identity(1,1) not null,
	Nombre varchar(150),
	Capacidad int,
	primary key(Id)
);

create table Recurso (
	Id int identity(1, 1) not null,
	Nombre varchar(200),
	Tipo varchar(100),
	Cantidad int,
	Precio decimal(21, 2),
	Disponible int,
	Reservado int,
	primary key(Id)
);

create table Factura_Cliente (
	Id int identity(1,1) not null,
	Id_Participante int,
	Id_Recurso int,
	Comentario varchar(200),
	Fecha date,
	Descuentro decimal(21, 2),
	IVA decimal(21, 2),
	Total decimal(21, 2),
	primary key(Id)
);

create table Factura_Proveedor (
	Id int identity(1,1) not null,
	Id_Empleado int,
	Comentario varchar(200),
	Fecha date,
	IVA decimal(21, 2),
	Total decimal(21, 2),
	primary key(Id)
);


create table Asiento (
	Id int identity(1,1) not null,
	Id_Factura_Cliente int,
	Id_Factura_Proveedor int,
	Movimiento int,
	Fecha date,
	Monto decimal(21, 2),
	primary key(Id),
	constraint FK_Factura_Cliente foreign key (Id_Factura_Cliente) references Factura_Cliente(Id),
	constraint FK_Factura_Proveedor foreign key (Id_Factura_Proveedor) references Factura_Proveedor(Id)
);