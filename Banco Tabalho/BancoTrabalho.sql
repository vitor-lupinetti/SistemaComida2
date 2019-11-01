USE master
GO

DROP DATABASE IF EXISTS SistemaVendasBD;
GO

CREATE DATABASE SistemaVendasBD
GO

USE SistemaVendasBD
GO

create Table Cidades
(
	Id int primary key,
	Descricao varchar(max),
	ValorEntrega decimal(10,2)
)

Create table Usuarios
(
	Id int primary key,
	Nome varchar(50) not null,
	Email varchar(max) not null,
	Senha varchar(max) not null,
	Imagem varbinary(max) not null,
	Endereco varchar(max) not null,
	ValorGasto decimal(10,2) default 0
)


Create table Entregador 
(
	Id int not null primary key,
	Nome varchar(max) not null,
	Foto varchar(max) not null,
	IdCidadeEntrega int foreign key references  Cidades(Id)
)



Create table Vendas
(
	Id int not null primary key,
	DataVenda datetime not null,
	IdUsuario int not null foreign key references Usuarios (Id),
    IdEntregador int not null foreign key references Entregador (Id),
	IdCidade int foreign key references  Cidades(Id)
)

Create table Categorias
(
	Id int not null primary key,
	Descricao varchar(max) not null
)


Create table Promocao
(
	Id int not null primary key,
	IdCategoria int not null foreign key references Categorias (Id),
	Porcentagem int not null
)

Create table Embalagem
(
	Id int not null primary key,
	Descricao varchar(30) not null,
	QtdEstoque int not null
)


Create table Comidas
(
	Id int primary key,
	Descricao varchar(30) not null,
	Preco decimal (10,2) not null,
	IdCategoria int not null foreign key references Categorias (Id),
	IdEmbalagem int not null foreign key references Embalagem (Id),
	Imagem varbinary(max)
)


Create table ItensVenda
(
	IdVenda int ,
	IdComida int ,
	Qtd int not null,
	primary key (IdVenda, IdComida),
	CONSTRAINT fk_ItensVenda_Venda FOREIGN KEY (IdVenda) REFERENCES Vendas (Id),
	CONSTRAINT fk_ItensVenda_Comida FOREIGN KEY (IdComida) REFERENCES Comidas (Id)
)


Insert into Categorias(Id, Descricao)
values
(1, 'Entrada'), (2, 'Prato Principal'), (3, 'Sobremesa'),(4, 'Bebidas')

insert into Embalagem(Id,Descricao,QtdEstoque)
values
(1, 'Copo de plastico', 10),(2, 'Enrolado no papel', 10),(3, 'Pote térmico de isopor', 10),(4, 'Caixa de papelão', 10),(5,'Emabalagem de plástico', 10)

insert into Cidades(Id, Descricao,ValorEntrega)
values
(1, 'São Bernardo do Campo',2),(2, 'Santo André', 5),(3,'São Paulo',7)

select * from Categorias
----------------------------------------Procedures---------------------------------------------

go

create procedure spDelete(	@id int ,@tabela varchar(max))
as
begin
	declare @sql varchar(max);
	set @sql = ' delete ' + @tabela +
	' where id = ' + cast(@id as varchar(max))
	exec(@sql)
end
GO
------------------------------------------------------------------------------------------------------------------
create procedure spConsulta 
(
	@id int ,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max);
	set @sql = 'select * from ' + @tabela +
	' where id = ' + cast(@id as varchar(max))
	exec(@sql)
end
GO
------------------------------------------------------------------------------------------------------------------
create procedure spConsultaEmail
(
	@email VARCHAR(max)
)
as
begin
select * from Usuarios where email = +  @email

end
GO
--------------------------------------------------------
--
--exec spConsultaEmail 'vi.lupinetti@hotmail.com.br'

--select * from Usuarios where Usuarios.Email = 'vi.lupinetti@hotmail.com.br'
------------------------------------------------------------------------------------------------------------------



create procedure spListagem
(
	@tabela varchar(max),
	@ordem varchar(max)
)
as
begin
	exec('select * from ' + @tabela +
	' order by ' + @ordem)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spProximoId
(@tabela varchar(max))
as
begin
	exec('select isnull(max(id) +1, 1) as MAIOR from '
	+@tabela)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spInsert_Usuarios
(
	@Id int,
	@Nome varchar(max),
	@Email varchar(max),
	@Endereco varchar(max),
	@Senha varchar(max),
	@Imagem varbinary(max)
)
as
begin
insert into Usuarios
(Id, nome, Email, Senha, Imagem, Endereco)
values
(@Id, @Nome, @Email, @Senha, @Imagem, @Endereco)
end
GO

------------------------------------------------------------------------------------------------------------------



create procedure spInsert_Entregador(
	@Id int,
	@Nome varchar(max),
	@Foto varchar(max) ,
	@IdCidadeEntrega int
)
as
begin 
insert into Entregador
(Id,Nome,Foto,IdCidadeEntrega)
values
(@Id, @Nome, @Foto, @IdCidadeEntrega)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spInsert_Vendas(
	@Id int,
	@DataVenda datetime,
	@IdUsuario int,
    @IdEntregador int,
	@IdCidade int 
)
as 
begin
insert into Vendas
(Id, DataVenda, IdUsuario, IdEntregador,IdCidade)
values
(@Id, @DataVenda, @IdUsuario, @IdEntregador, @IdCidade)
end 
GO


------------------------------------------------------------------------------------------------------------------


create procedure spInsert_Promocao(
	@Id int,
	@IdCategoria int,
	@Porcentagem int 
)
as
begin
insert into Promocao
(Id, IdCategoria, Porcentagem)
values 
(@Id, @IdCategoria, @Porcentagem)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spInsert_Comidas(
	@Id int,
	@Descricao varchar(30),
	@Preco decimal (10,2),
	@IdCategoria int,
	@IdEmbalagem int,
	@Imagem varbinary(max)
)
as
begin
insert into Comidas
(Id, Descricao,Preco,IdCategoria,IdEmbalagem,Imagem)
values
(@Id, @Descricao,@Preco, @IdCategoria, @IdEmbalagem, @Imagem)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Usuarios
(
	@Id int,
	@Nome varchar(max),
	@Email varchar(max),
	@Endereco varchar(max),
	@Senha varchar(max),
	@Imagem varbinary(max)
)
as
begin
update Usuarios set
nome = @Nome,
Email = @Email,
Endereco = @Endereco,
Senha = @Senha,
Imagem = @Imagem
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Entregador
(   @Id int,
	@Nome varchar(max),
	@Foto varchar(max) ,
	@IdCidadeEntrega int
)
as
begin 
update Entregador set
Nome = @Nome,
Foto = @Foto,
IdCidadeEntrega = @IdCidadeEntrega
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Vendas
(
	@Id int,
	@DataVenda datetime,
	@IdUsuario int,
    @IdEntregador int,
	@IdCidade int 
)
as
begin 
update Vendas set
DataVenda = @DataVenda,
IdUsuario = @IdUsuario,
IdEntregador = @IdEntregador,
IdCidade = @IdCidade
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Promocao
(
	@Id int,
	@IdCategoria int,
	@Porcentagem int 
)
as
begin
update Promocao set
IdCategoria = @IdCategoria,
Porcentagem = @Porcentagem
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Comidas
(
	@Id int,
	@Descricao varchar(30),
	@Preco decimal (10,2),
	@IdCategoria int,
	@IdEmbalagem int,
	@Imagem varbinary(max)
)
as
begin
update Comidas set
Descricao = @Descricao,
Preco = @Preco,
IdCategoria = @IdCategoria,
IdEmbalagem = @IdEmbalagem,
Imagem = @Imagem
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

select * from Usuarios
select * from Comidas

