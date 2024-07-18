--Inserts
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (1, 'Bogotá');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (2, 'Medellín');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (3, 'Cali');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (4, 'Barranquilla');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (5, 'Cartagena');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (6, 'Santa Marta');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (7, 'Pereira');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (8, 'Manizales');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (9, 'Pasto');
INSERT INTO Ciudades (idCiudad, ciudad) VALUES (10, 'Neiva');

INSERT INTO TipoClientes (id_tipo_cliente, tipo) VALUES (1, 'persona');
INSERT INTO TipoClientes (id_tipo_cliente, tipo) VALUES (2, 'empresa');

INSERT INTO TipoCuentas (id_tipo_cuenta, tipo) VALUES (1, 'ahorros');
INSERT INTO TipoCuentas (id_tipo_cuenta, tipo) VALUES (2, 'corriente');

INSERT INTO TipoTransacciones (id_tipo_transaccion, tipo) VALUES (1, 'consignacion');
INSERT INTO TipoTransacciones (id_tipo_transaccion, tipo) VALUES (2, 'retiro');

-- Datos para personas (id_tipo_cliente = 1)
INSERT INTO Clientes (id_cliente, id_tipo_cliente, direccion, telefono, correo_electronico, fecha_registro, nombre, apellido, fecha_nacimiento, tipo_documento, numero_documento)
VALUES 
(1, 1, 'Calle 1 #123', '1234567890', 'juan.perez@example.com', '2023-01-01', 'Juan', 'Pérez', '1990-01-01', 'CC', '10000001'),
(2, 1, 'Calle 2 #234', '2345678901', 'maria.gonzalez@example.com', '2023-01-02', 'María', 'González', '1991-02-02', 'CC', '10000002'),
(3, 1, 'Calle 3 #345', '3456789012', 'pedro.rodriguez@example.com', '2023-01-03', 'Pedro', 'Rodríguez', '1992-03-03', 'CC', '10000003'),
(4, 1, 'Calle 4 #456', '4567890123', 'ana.martinez@example.com', '2023-01-04', 'Ana', 'Martínez', '1993-04-04', 'CC', '10000004'),
(5, 1, 'Calle 5 #567', '5678901234', 'luis.lopez@example.com', '2023-01-05', 'Luis', 'López', '1994-05-05', 'CC', '10000005'),
(6, 1, 'Calle 6 #678', '6789012345', 'carlos.gomez@example.com', '2023-01-06', 'Carlos', 'Gómez', '1995-06-06', 'CC', '10000006'),
(7, 1, 'Calle 7 #789', '7890123456', 'laura.fernandez@example.com', '2023-01-07', 'Laura', 'Fernández', '1996-07-07', 'CC', '10000007'),
(8, 1, 'Calle 8 #890', '8901234567', 'jose.sanchez@example.com', '2023-01-08', 'José', 'Sánchez', '1997-08-08', 'CC', '10000008'),
(9, 1, 'Calle 9 #901', '9012345678', 'diana.ramirez@example.com', '2023-01-09', 'Diana', 'Ramírez', '1998-09-09', 'CC', '10000009'),
(10, 1, 'Calle 10 #012', '0123456789', 'andres.suarez@example.com', '2023-01-10', 'Andrés', 'Suárez', '1999-10-10', 'CC', '10000010');

-- Datos para empresas (id_tipo_cliente = 2)
INSERT INTO Clientes (id_cliente, id_tipo_cliente, direccion, telefono, correo_electronico, fecha_registro, razon_social, nombre_comercial, ruc, contacto_principal, telefono_contacto)
VALUES 
(11, 2, 'Avenida 1 #123', '2234567890', 'empresa1@example.com', '2023-02-01', 'Empresa Uno S.A.', 'Empresa Uno', '80000001', 'Carlos Pérez', '3234567890'),
(12, 2, 'Avenida 2 #234', '3345678901', 'empresa2@example.com', '2023-02-02', 'Empresa Dos S.A.', 'Empresa Dos', '80000002', 'María Gómez', '4345678901'),
(13, 2, 'Avenida 3 #345', '4456789012', 'empresa3@example.com', '2023-02-03', 'Empresa Tres S.A.', 'Empresa Tres', '80000003', 'Pedro Sánchez', '5456789012'),
(14, 2, 'Avenida 4 #456', '5567890123', 'empresa4@example.com', '2023-02-04', 'Empresa Cuatro S.A.', 'Empresa Cuatro', '80000004', 'Ana Rodríguez', '6567890123'),
(15, 2, 'Avenida 5 #567', '6678901234', 'empresa5@example.com', '2023-02-05', 'Empresa Cinco S.A.', 'Empresa Cinco', '80000005', 'Luis Martínez', '7678901234'),
(16, 2, 'Avenida 6 #678', '7789012345', 'empresa6@example.com', '2023-02-06', 'Empresa Seis S.A.', 'Empresa Seis', '80000006', 'Carlos Fernández', '8789012345'),
(17, 2, 'Avenida 7 #789', '8890123456', 'empresa7@example.com', '2023-02-07', 'Empresa Siete S.A.', 'Empresa Siete', '80000007', 'Laura Ramírez', '9890123456'),
(18, 2, 'Avenida 8 #890', '9901234567', 'empresa8@example.com', '2023-02-08', 'Empresa Ocho S.A.', 'Empresa Ocho', '80000008', 'José Suárez', '1901234567'),
(19, 2, 'Avenida 9 #901', '1012345678', 'empresa9@example.com', '2023-02-09', 'Empresa Nueve S.A.', 'Empresa Nueve', '80000009', 'Diana López', '2102345678'),
(20, 2, 'Avenida 10 #012', '1123456789', 'empresa10@example.com', '2023-02-10', 'Empresa Diez S.A.', 'Empresa Diez', '80000010', 'Andrés Gómez', '3123456789');

INSERT INTO Cuentas (id_cliente, id_tipo_cuenta, saldo, id_ciudad_origen, fecha_apertura)
VALUES 
(1, 1, 5000.00, 1, '2023-03-01'),
(2, 1, 3000.00, 2, '2023-03-02'),
(3, 1, 4500.00, 3, '2023-03-03'),
(4, 1, 6000.00, 4, '2023-03-04'),
(5, 1, 2500.00, 5, '2023-03-05'),
(6, 1, 7000.00, 6, '2023-03-06'),
(7, 1, 3500.00, 7, '2023-03-07'),
(8, 1, 5500.00, 8, '2023-03-08'),
(9, 1, 8000.00, 9, '2023-03-09'),
(10, 1, 4000.00, 10, '2023-03-10');

-- Cuentas corrientes (id_tipo_cuenta = 2)
INSERT INTO Cuentas (id_cliente, id_tipo_cuenta, saldo, id_ciudad_origen, fecha_apertura)
VALUES 
(11, 2, 10000.00, 1, '2023-04-01'),
(12, 2, 15000.00, 2, '2023-04-02'),
(13, 2, 20000.00, 3, '2023-04-03'),
(14, 2, 25000.00, 4, '2023-04-04'),
(15, 2, 30000.00, 5, '2023-04-05'),
(16, 2, 35000.00, 6, '2023-04-06'),
(17, 2, 40000.00, 7, '2023-04-07'),
(18, 2, 45000.00, 8, '2023-04-08'),
(19, 2, 50000.00, 9, '2023-04-09'),
(20, 2, 55000.00, 10, '2023-04-10');


INSERT INTO Transacciones (id_cuenta, id_tipo_transaccion, monto, fecha_transaccion, id_ciudad_transaccion)
values
(1,1,10000,GETDATE(),1),
(1,1,5000000,GETDATE(),1),
(4,1,5000000,GETDATE(),1),
(2,2,100,GETDATE(),2),
(3,2,100,GETDATE(),1),
(4,2,100,GETDATE(),1),
(5,2,100,GETDATE(),5),
(1,2,100,'2023-07-17 20:39:08.850',1),
(1,2,200,'2022-06-17 20:39:08.850',7),
(1,2,100,GETDATE(),8),
(5,2,100,GETDATE(),1);

GO

INSERT INTO Transacciones (id_cuenta, id_tipo_transaccion, monto, fecha_transaccion, id_ciudad_transaccion)
values(1,2,1000000,GETDATE(),2),
(4,2,1000000,GETDATE(),1),
(1,1,1000000,GETDATE(),2);

GO




select * from Transacciones
where id_cuenta=1
and id_ciudad_transaccion!=1

