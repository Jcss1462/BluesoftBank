--CREATE DATABASE BlueSoftBank;

/*

Drop table  Transacciones;
Drop table  TipoTransacciones;
Drop table Cuentas
Drop table TipoCuentas
Drop table Clientes;
Drop table TipoClientes;
Drop table  Ciudades;

*/


--TABLAS

CREATE TABLE Ciudades (
	idCiudad INT PRIMARY KEY,
	ciudad VARCHAR(20));

CREATE TABLE TipoClientes (
	id_tipo_cliente INT PRIMARY KEY,
	tipo VARCHAR(20));


CREATE TABLE Clientes (
    id_cliente INT PRIMARY KEY,
    id_tipo_cliente INT NOT NULL,  -- 'persona' o 'empresa'
	direccion VARCHAR(255),
    telefono VARCHAR(20),
    correo_electronico VARCHAR(100),
    fecha_registro DATE,
	-- Para personas naturales
    nombre VARCHAR(100),  
    apellido VARCHAR(100),  
    fecha_nacimiento DATE,  
    tipo_documento VARCHAR(50), 
    numero_documento VARCHAR(50), 
	 -- Para empresas
    razon_social VARCHAR(255), 
    nombre_comercial VARCHAR(255),  
    ruc VARCHAR(20),  
    contacto_principal VARCHAR(100), 
    telefono_contacto VARCHAR(20),

	FOREIGN KEY (id_tipo_cliente) REFERENCES TipoClientes(id_tipo_cliente)
);


CREATE TABLE TipoCuentas (
	id_tipo_cuenta INT PRIMARY KEY,
	tipo VARCHAR(20));


CREATE TABLE Cuentas (
    id_cuenta INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT,
    id_tipo_cuenta INT NOT NULL,  -- 'ahorros' o 'corriente'
    saldo DECIMAL(15, 2) NOT NULL DEFAULT 0,
    id_ciudad_origen INT,
    fecha_apertura DATE,
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente),
	FOREIGN KEY (id_tipo_cuenta) REFERENCES TipoCuentas(id_tipo_cuenta),
	FOREIGN KEY (id_ciudad_origen) REFERENCES Ciudades(idCiudad)
);

CREATE TABLE TipoTransacciones(
	id_tipo_transaccion INT PRIMARY KEY,
	tipo VARCHAR(20));

CREATE TABLE Transacciones (
    id INT  PRIMARY KEY IDENTITY(1,1),
    id_cuenta INT NOT NULL,
    id_tipo_transaccion INT NOT NULL,  -- 'consignacion' o 'retiro'
    monto DECIMAL(15, 2) NOT NULL,
    fecha_transaccion  DATETIME DEFAULT GETDATE(),
    id_ciudad_transaccion INT,
    FOREIGN KEY (id_cuenta) REFERENCES Cuentas(id_cuenta),
	FOREIGN KEY (id_tipo_transaccion) REFERENCES TipoTransacciones(id_tipo_transaccion),
	FOREIGN KEY (id_ciudad_transaccion) REFERENCES Ciudades(idCiudad)
);
