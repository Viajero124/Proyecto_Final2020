--Creo la Base de Datos
Create DataBase EntidadesPublicas
on(
Name ='EntidadesPublicas',
FileName='c:\ProyectoFinal.mdf'
)
go

--Digo que voy a usar la Base de Datos que cree
Use EntidadesPublicas
go

--Creo las tablas de la Base de Datos
Create table EntidadPublica
(
NombreE varchar(50) NOT NULL Primary Key,
Direccion varchar(50) NOT NULL
)
go

Create table Telefono
(
NombreE varchar(50) NOT NULL Foreign Key References EntidadPublica(NombreE),
NroTel varchar(9) NOT NULL,
Primary Key (NombreE, NroTel)
)
go

Create table TipoTramite
(
NombreE varchar(50) NOT NULL Foreign Key References EntidadPublica(NombreE),
Codigo varchar(6) NOT NULL,
NombreT varchar (25) NOT NULL,
Descripcion varchar(50) NOT NULL,
Primary Key (NombreE, Codigo)
)
go

Create table Empleado
(
CI int NOT NULL Primary Key,
Contraseña varchar(25) NOT NULL,
NomEmpleado varchar(50) NOT NULL
)
go

Create table Solicitud
(
Nro int IDENTITY Primary Key,
FechaHora DateTime NOT NULL,
NomCliente varchar(50) NOT NULL,
estado varchar(15) NOT NULL,
CI int NOT NULL Foreign Key References Empleado(CI),
NombreE varchar(50) NOT NULL,
Codigo varchar(6) NOT NULL,
Foreign Key (NombreE, Codigo) References TipoTramite (NombreE, Codigo),
)
go

--Insersión de datos a las tablas
Insert EntidadPublica(NombreE, Direccion) values ('Entidad1', 'CalleA')
Insert EntidadPublica(NombreE, Direccion) values ('Entidad2', 'CalleB')
Insert EntidadPublica(NombreE, Direccion) values ('Entidad3', 'CalleC')

Insert Telefono(NombreE, NroTel) values ('Entidad1', '111111111')
Insert Telefono(NombreE, NroTel) values ('Entidad1', '111111112')

Insert Telefono(NombreE, NroTel) values ('Entidad2', '222222222')
Insert Telefono(NombreE, NroTel) values ('Entidad3', '333333333')

Insert TipoTramite(NombreE, Codigo, NombreT, Descripcion) values ('Entidad1', '111222', 'Tramite1', 'TextoDescriptivo')
Insert TipoTramite(NombreE, Codigo, NombreT, Descripcion) values ('Entidad2', '333444', 'Tramite2', 'TextoDescriptivo2')
Insert TipoTramite(NombreE, Codigo, NombreT, Descripcion) values ('Entidad3', '555666', 'Tramite3', 'TextoDescriptivo3')
Insert TipoTramite(NombreE, Codigo, NombreT, Descripcion) values ('Entidad3', '555777', 'Nuevo', 'TextoDescriptivo4')
Insert TipoTramite(NombreE, Codigo, NombreT, Descripcion) values ('Entidad3', '555888', 'Ahora', 'TextoDescriptivo4')



Insert Empleado(CI, Contraseña, NomEmpleado) values (11111111, 'Password1', 'Emp1')
Insert Empleado(CI, Contraseña, NomEmpleado) values (22222222, 'Password2', 'Emp2')
Insert Empleado(CI, Contraseña, NomEmpleado) values (33333333, 'Password3', 'Emp3')

Insert Solicitud(FechaHora, NomCliente, estado, CI, NombreE, Codigo) values
('20200120', 'Cliente1', 'Alta', 11111111, 'Entidad1', '111222')
Insert Solicitud(FechaHora, NomCliente, estado, CI, NombreE, Codigo) values
('20200125', 'Cliente2', 'Alta', 22222222, 'Entidad2', '333444')
Insert Solicitud(FechaHora, NomCliente, estado, CI, NombreE, Codigo) values
('20200130', 'Cliente3', 'Alta', 33333333, 'Entidad3', '555666') 
go

--Listar Entidades Publicas
create procedure Listar_Entidades
as
begin
 select EntidadPublica.NombreE,Direccion,NroTel
 from EntidadPublica inner join Telefono on EntidadPublica.NombreE=Telefono.NombreE
 end
 go
 
 --Buscar Tipo de tramite
create PROCEDURE BuscarTipoTramite 

@NombreE varchar(50)
 AS
BEGIN 
	SELECT *
	FROM TipoTramite where NombreE=@NombreE
END
go
 
 --Listar Telefonos
 create procedure Listar_Telefonos @NombreE varchar(50)
 as
 begin
 select Telefono.NroTel
 from EntidadPublica inner join Telefono on EntidadPublica.NombreE=Telefono.NombreE
 where EntidadPublica.NombreE=@NombreE
 end
 go
--Agregar Telrfonos
Create PROCEDURE Agregar_Telefonos @NombreE varchar (50),@Telefonos varchar(9) 
AS
begin

	if (exists (select * From  Telefono Where NombreE = @NombreE and NroTel = @Telefonos))
		return - 1
	
	INSERT  Telefono(NombreE,NroTel) Values (@NombreE, @Telefonos)
	if (@@ERROR = 0)
		return 1
	else
		return - 2
END
go 
 --Eliminar telefonos
 CREATE PROCEDURE EliminarTelefonos @NombreE varchar(50) AS
Begin
	Delete Telefono
	Where NombreE = @NombreE
End
Go
 
 --Buscar Entidad Publica 
 create procedure BuscarEntidad   @NombreE varchar(50)
as
begin
 select EntidadPublica.NombreE,Direccion,NroTel
 from EntidadPublica inner join Telefono on EntidadPublica.NombreE=Telefono.NombreE
 where EntidadPublica.NombreE=@NombreE
 end
 go

--Buscar Usuario
create procedure BuscarUsuario @CI int
as
begin
select *
from Empleado
where CI=@CI
end
go

--Buscar Estado de tramite
create procedure BuscarEstadoTramite @Numero int
as
begin
select *
from Solicitud
where Nro=@Numero
end
go
--Modificar EntidadPublica
Create PROCEDURE ModificarEntidadP @Nombre varchar(50), @Direccion varchar(50)  
AS
BEGIN 
	if (NOT EXISTS (SELECT NombreE FROM EntidadPublica WHERE NombreE=@Nombre))
		RETURN -1;
		

	--si llego aca puedo modificar
	DECLARE @Error int
	

	UPDATE EntidadPublica SET NombreE =@Nombre, Direccion=@Direccion
	WHERE NombreE =@Nombre;
	SET @Error=@@ERROR;
	
	
    
    if @Error<>0
    return -2
    else
    return 0
	
END	
go

--Eliminar Entidad Publica
Create PROCEDURE EliminarEntidadP @Nombre varchar(50) 
AS
BEGIN 
	
	IF (NOT EXISTS (SELECT NombreE FROM EntidadPublica WHERE NombreE =@Nombre ))
		RETURN -1;
	IF ( EXISTS (SELECT NombreE FROM Solicitud WHERE NombreE =@Nombre ))
		RETURN -2;

	--si llego aca puedo eliminar
	DECLARE @Error int

	BEGIN TRAN
	DELETE TipoTramite WHERE  NombreE =@Nombre 
	SET @Error=@@ERROR;
	
	DELETE TELEFONO WHERE  NombreE =@Nombre 
	SET @Error=@@ERROR+@Error;
			
	DELETE EntidadPublica WHERE  NombreE =@Nombre;
	SET @Error=@@ERROR+@Error;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN;
		RETURN 1;
	END
	ELSE
	BEGIN
		ROLLBACK TRAN;
		RETURN -3;
	END	
END
go

--Agregar Entidad
Create PROCEDURE AgregarEntidadP @Nombre varchar(50), @Direccion varchar(50) 
AS
BEGIN 

if (exists ( Select NombreE from EntidadPublica where NombreE = @Nombre))
return -1 

else 
begin 

insert into EntidadPublica(NombreE, Direccion)values (@nombre, @Direccion)



	IF(@@ERROR<>0)
	BEGIN 
	
	return -2
	end
	else
	return 0
	
	END	
	end	
go


--Control de Logueo
Create Procedure LogueoUsuario @Usu varchar(10), @Pass varchar(10) AS
Begin
	Select *
	From Empleado
	Where NomEmpleado = @Usu AND Contraseña = @Pass
End
go

--Listar Tipos de tramites
create procedure Listar_TipoTramite
as
begin
 select *
 from TipoTramite
 order by NombreT
 end
 go
 
 ---Empleado
 CREATE PROCEDURE BuscarEmpleado @CI int AS
BEGIN
	select *
	from Empleado
	where @CI = CI
END
go

CREATE PROCEDURE EliminarEmpleado @CI int AS
BEGIN
	IF (NOT EXISTS (SELECT * FROM Empleado WHERE CI = @CI))
		RETURN 0;

	IF (EXISTS (SELECT * FROM Solicitud WHERE CI = @CI))
		RETURN -1;

	--aca ya puedo eliminar
	
	DELETE Empleado WHERE CI = @CI;

	IF(@@Error=0)
		RETURN 1;
	ELSE
		RETURN -2;
end
go

CREATE PROCEDURE AltaEmpleado @CI int, @Contraseña Varchar(25), @NomEmpleado Varchar(50) AS
BEGIN
	IF (EXISTS (SELECT CI FROM Empleado WHERE CI=@CI))
		RETURN -1;
	
		
		--aca ya puedo agregar
	
		INSERT INTO Empleado (CI, Contraseña, NomEmpleado) VALUES (@CI, @Contraseña, @NomEmpleado);
		
		IF(@@Error=0)
		RETURN 1;
		ELSE
		RETURN -2;	
		
	
END
go

CREATE PROCEDURE ModificarEmpleado @CI int, @Contraseña Varchar(25), @NomEmpleado Varchar(50) AS
BEGIN
	IF NOT (EXISTS (SELECT * FROM Empleado WHERE CI = @CI))
	Return -1;
	
	--aca ya puedo modificar
	UPDATE Empleado
	SET NomEmpleado = @NomEmpleado
	WHERE CI = @CI

	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -2
End
go

--Solicitud de tramites

--Agregar Solicitud
Create PROCEDURE AgregarSolicitud @FechaHora DateTime, @NomCliente varchar(50),@Estado varchar(15),@CI int,@NombreE varchar(50),@Codigo varchar(6) 
AS
BEGIN 

if (exists ( Select FechaHora from Solicitud where FechaHora = @FechaHora))
return -1 

else 
begin 

insert into Solicitud(FechaHora,NomCliente,estado,CI,NombreE,Codigo)values (@FechaHora,@NomCliente,@Estado,@CI,@NombreE,@Codigo)



	IF(@@ERROR<>0)
	BEGIN 
	
	return -2
	end
	else
	return 0
	
	END	
	end	
go