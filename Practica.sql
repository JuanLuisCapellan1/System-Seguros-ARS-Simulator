create database PracticeSystem
go
use PracticeSystem


drop table if exists Users;
Create Table Users(
ID int IDENTITY (1, 1) PRIMARY KEY,
Nombre varchar(100),
Email varchar(200),
Password varchar(100),
Phone varchar(12),
created_at datetime DEFAULT GETDATE()
);


drop proc if exists InsertUsers;
----------INSERTAR USUARIOS-------
create proc InsertUsers
@nombre varchar (100),
@email varchar (200), 
@password varchar (100),
@phone varchar(12),
@created_at datetime
as
insert into Users values (@nombre,@email,@password,@phone, @created_at) ;
go


---PROCEDIMIENTOS ALMACENADOS---MOSTRAR USUARIOS---
exec ShowUsers;

create proc ShowUsers
as
select * from Users;
go


drop table if exists Clients;
Create Table Clients(
ID int IDENTITY (1, 1) PRIMARY KEY,
Nombre varchar(100),
Email varchar(200),
No_Cedula varchar(13),
Phone varchar(12),
Direction varchar(250),
Created_At datetime DEFAULT GETDATE()
);

----------INSERTAR-------
exec CreateNewClient;

create proc CreateNewClient
@nombre varchar (100),
@email varchar (200), 
@no_cedula varchar (13),
@phone varchar(12),
@direction varchar(250),
@created_at datetime
as
insert into Clients values (@nombre,@email,@no_cedula,@phone,@direction, @created_at);
go

insert into Clients values ('pedro', 'pedro@gmail.com', '123-2345678-2', '902-212-3344', 'gazcue', default);

exec ShowAllClients;

create proc ShowAllClients
as
select * from Clients;
go


exec FindClient;

create proc FindClient
@nombre varchar (100)
as
select ID from Clients where Nombre = @nombre; 
go


---------EDITAR-----------
exec UpdateClients;

create proc UpdateClients
@nombre varchar (100),
@email varchar (200), 
@no_cedula varchar (13),
@phone varchar(12),
@direction varchar(250),
@id int
as
update Clients set Nombre = @nombre, Email = @email, No_Cedula = @no_cedula, Phone = @phone, Direction = @direction where Id = @id;
go



----------ELIMINAR------------
exec DeleteClients;

create proc DeleteCLients
@idClient int
as
delete from Clients where Id=@idClient
go


drop table if exists Encuesta;
create table Encuesta(
ID int IDENTITY (1, 1) PRIMARY KEY,
Question text,
Answer text,
idClient int
)

insert into Encuesta values ('cual es tu nombre?', 'juan luis capellan', 1);
insert into Encuesta values ('cuantos dias trabajas a la semana', '5', 1);

select * from Encuesta;
delete from Encuesta;
select c.Nombre, e.Question, e.Answer from Encuesta as e join Clients as c on e.idClient = c.ID;

exec CreateNewEncuesta;
drop proc CreateNewEncuesta;
create proc CreateNewEncuesta
@Question text,
@Answer text,
@idClient int
as
insert into Encuesta values (@Question,@Answer,@idClient);
go


exec ShowClientsEncuesta;

create proc ShowClientsEncuesta
as
select e.ID, c.Nombre, e.Question, e.Answer from Encuesta as e join Clients as c on e.idClient = c.ID;
go

