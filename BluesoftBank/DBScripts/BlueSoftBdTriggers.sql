--Triggers 
CREATE OR ALTER TRIGGER before_insert_transaccion
	ON Transacciones
	INSTEAD OF INSERT, UPDATE
	AS
	BEGIN
		DECLARE @saldo_actual DECIMAL(15, 2);
		DECLARE @cuenta_id INT;
		DECLARE @tipo_transaccion VARCHAR(50);
		DECLARE @monto DECIMAL(15, 2);

		-- Obtener los valores de la nueva fila
		SELECT @cuenta_id = INSERTED.id_cuenta, @tipo_transaccion = INSERTED.id_tipo_transaccion, @monto = INSERTED.monto
		FROM INSERTED;

		-- Obtener el saldo actual de la cuenta
		SELECT @saldo_actual = saldo
		FROM Cuentas
		WHERE id_cuenta = @cuenta_id;

		-- Verificar el tipo de transacción y el saldo
		IF @tipo_transaccion = 2
		BEGIN
			IF @saldo_actual < @monto
			BEGIN
				-- Lanzar un error si el saldo es insuficiente
				RAISERROR('Saldo insuficiente para realizar el retiro', 16, 1);
				ROLLBACK TRANSACTION;
				RETURN;
			END
		END

		-- Insertar la nueva transacción
		INSERT INTO Transacciones (id_cuenta, id_tipo_transaccion, monto, fecha_transaccion,id_ciudad_transaccion)
		SELECT id_cuenta, id_tipo_transaccion, monto, fecha_transaccion,id_ciudad_transaccion
		FROM INSERTED;
END
GO



--
CREATE OR ALTER TRIGGER after_insert_transaccion
ON Transacciones
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar cada fila insertada
    DECLARE @cuenta_id INT;
    DECLARE @tipo_transaccion VARCHAR(50);
    DECLARE @monto DECIMAL(15, 2);

    DECLARE inserted_cursor CURSOR FOR
    SELECT id_cuenta, id_tipo_transaccion, monto
    FROM INSERTED;

    OPEN inserted_cursor;
    FETCH NEXT FROM inserted_cursor INTO @cuenta_id, @tipo_transaccion, @monto;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @tipo_transaccion = 1
        BEGIN
            UPDATE Cuentas
            SET saldo = saldo + @monto
            WHERE id_cuenta = @cuenta_id;
        END
        ELSE IF @tipo_transaccion = 2
        BEGIN
            UPDATE Cuentas
            SET saldo = saldo - @monto
            WHERE id_cuenta = @cuenta_id;
        END

        FETCH NEXT FROM inserted_cursor INTO @cuenta_id, @tipo_transaccion, @monto;
    END

    CLOSE inserted_cursor;
    DEALLOCATE inserted_cursor;
END
GO


