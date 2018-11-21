DROP TABLE dbo.movimientos_stock;

CREATE TABLE dbo.movimientos_stock (  
   audit_log_id uniqueidentifier DEFAULT NEWID() PRIMARY KEY,  
   idArticulo int NOT NULL,  
   descripcion char(1000) NOT NULL,  
   tipo_movimiento char (10) NOT NULL,  
   cantidad int NOT NULL,
   fecha_mov DATETIME not null
   );  
GO  

DROP TRIGGER DBO.TGR_MOVIMIENTOS;
GO
CREATE TRIGGER DBO.TGR_MOVIMIENTOS  
ON dbo.Articuloes
AFTER INSERT, UPDATE   AS
	INSERT INTO dbo.movimientos_stock (cantidad,
								  descripcion,idArticulo,
								  tipo_movimiento,fecha_mov)
	SELECT del.stock,del.descripcion, del.id,'BAJA', SYSDATETIME() FROM deleted  del;


	INSERT INTO dbo.movimientos_stock (cantidad,
								  descripcion,idArticulo,
								  tipo_movimiento,fecha_mov)
	SELECT ins.stock,ins.descripcion, ins.id,'ALTA', SYSDATETIME() FROM inserted  ins;



GO  


SELECT * FROM DBO.movimientos_stock

select convert(varchar, fecha_mov, 108)FROM DBO.movimientos_stock



