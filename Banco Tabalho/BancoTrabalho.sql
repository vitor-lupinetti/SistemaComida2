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
	TipoUsuario VARCHAR(10) default 'cliente',
	Nome varchar(50) not null,
	Email varchar(max) not null,
	Senha varchar(max) not null,
	Endereco varchar(max) not null,
	ValorGasto decimal(10,2) default 0
)


Create table Entregador 
(
	Id int not null primary key,
	Nome varchar(max) not null,
	IdCidadeEntrega int foreign key references  Cidades(Id)
)

Create table Vendas
(
	Id int not null primary key,
	DataVenda datetime not null,
	IdUsuario int not null foreign key references Usuarios (Id),
    IdEntregador int not null foreign key references Entregador (Id),
	IdCidade int foreign key references  Cidades(Id),
	EnderecoEntrega VARCHAR(100)
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
	Porcentagem int not null,
	DataInicio DATETIME not null,
	DataFim DATETIME not null
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
(1, 'Copo de plastico', 10),(2, 'Enrolado no papel', 10),(3, 'Pote térmico de isopor', 10),(4, 'Embalagem para lanches', 10),(5,'Embalagem de plástico', 10)

insert into Cidades(Id, Descricao,ValorEntrega)
values
(1, 'São Bernardo do Campo',2),(2, 'Santo André', 5),(3,'São Paulo',7)


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
create procedure spListagemCategorias
(

	@idcategoria int
)
as
begin
	select * from Comidas
	 where Idcategoria = @idcategoria 
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
	@TipoUsuario varchar(10),
	@Nome varchar(max),
	@Email varchar(max),
	@Endereco varchar(max),
	@Senha varchar(max),
	@ValorGasto DECIMAL(10,2)
)
as
begin
insert into Usuarios
(Id,tipousuario, nome, Email, Senha,  Endereco, ValorGasto)
values
(@Id, @tipousuario, @Nome, @Email, @Senha, @Endereco, @ValorGasto)
end
GO

------------------------------------------------------------------------------------------------------------------



create procedure spInsert_Entregador(
	@Id int,
	@Nome varchar(max),
	@IdCidadeEntrega int
)
as
begin 
insert into Entregador
(Id,Nome,IdCidadeEntrega)
values
(@Id, @Nome, @IdCidadeEntrega)
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spInsert_Vendas(
	@Id int,
	@DataVenda datetime,
	@IdUsuario int,
    @IdEntregador int,
	@IdCidade int ,
	@EnderecoEntrega varchar(max)
)
as 
begin
insert into Vendas
(Id, DataVenda, IdUsuario, IdEntregador,IdCidade,EnderecoEntrega)
values
(@Id, @DataVenda, @IdUsuario, @IdEntregador, @IdCidade,@EnderecoEntrega)
end 
GO


------------------------------------------------------------------------------------------------------------------
create procedure spInsert_ItensVenda(
	@IdVenda int,
	@IdComida int,
    @Qtd int
)
as 
begin
insert into ItensVenda
(IdVenda, IdComida, Qtd)
values
(@IdVenda, @IdComida, @Qtd)
end 
GO


------------------------------------------------------------------------------------------------------------------



create procedure spInsert_Promocao(
	@Id int,
	@IdCategoria int,
	@Porcentagem int ,
	@DataInicio DATETIME,
	@DataFim DATETIME
)
as
begin
insert into Promocao
(Id, IdCategoria, Porcentagem, DataInicio, DataFim)
values 
(@Id, @IdCategoria, @Porcentagem, @DataInicio, @DataFim)
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
	@TipoUsuario varchar(10),
	@ValorGasto decimal(10,2)
)
as
begin
update Usuarios set
nome = @Nome,
Email = @Email,
Endereco = @Endereco,
Senha = @Senha,
ValorGasto = @ValorGasto,
TipoUsuario = @TipoUsuario
where Id = @Id
end
GO
------------------------------------------------------------------------------------------------------------------

create procedure spUpdate_Entregador
(   @Id int,
	@Nome varchar(max),
	@IdCidadeEntrega int
)
as
begin 
update Entregador set
Nome = @Nome,
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
	@Porcentagem int ,
	@DataInicio DATETIME,
	@DataFim DATETIME
)
as
begin
update Promocao set
IdCategoria = @IdCategoria,
Porcentagem = @Porcentagem,
datainicio = @DataInicio,
datafim = @DataFim
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

insert into Usuarios
VALUES
(2, 'Adm','Vitor','vi.lupinetti@hotmail.com', '123','Rua ingá', 0 )

insert into Entregador (Id, Nome,IdCidadeEntrega)
VALUES
(1,'José',1),(2,'Flavio', 2), (3,'Eduardo',3)

go
------------------------------------------------------------------------------------------------------------------


--select * from Usuarios
--delete from Vendas where Id = 2  

create trigger trg_excVendas on Vendas instead of delete as -- se colocar for/after a trigger não será disparada, por causa das referencias de itensVenda
begin													  -- a funcão do instead of é disparar qnd houver o evento delete, mas ela não ira deletar as Vendas, apenas vai executar as instruções de dentro 
	declare @vendaId int = (select id from deleted)
	delete from ItensVenda where  IdVenda = @vendaId
	delete from Vendas where id = @vendaId
end


------------------------------------------------------------------------------------------------------------------------
go
alter PROCEDURE spConsulta1
(
	@Filtro1 VARCHAR(10),
	@Filtro2 VARCHAR(10),
	@Filtro3 VARCHAR(10)
)
as
begin


	declare @sql1 VARCHAR(max)
	declare @sql2 VARCHAR(max)
	DECLARE @sql3 VARCHAR(max)

	if @Filtro1 = 'mv' BEGIN
		set @sql1 = 'select co.Descricao,ci.Descricao as Cidade, co.Preco, null as DataVenda, count(i.Qtd) as qtd'
		set @sql3 = ' group by co.Descricao,ci.Descricao, co.Preco
					order by qtd desc'
	end
	else if @Filtro1 = 'p' begin
		set @sql1 = 'select co.Descricao,ci.Descricao as Cidade, co.Preco, v.DataVenda'
		set @sql3 = ' order by co.preco'
	end
	else if @Filtro1 = 'dv' BEGIN
		set @sql1 = 'select co.Descricao,ci.Descricao as cidade, co.Preco, v.DataVenda'
		set @sql3 = ' order by v.datavenda'
	end

		set @sql2 = ' from Vendas v inner join ItensVenda i ON
	v.Id = i.IdVenda inner join Cidades ci ON
	v.IdCidade = ci.Id inner join Comidas co ON
	i.IdComida = co.Id inner join Categorias ca on 
	co.IdCategoria = ca.Id'

		set @sql1 += @sql2

	if @Filtro2 = 'entrada' BEGIN
		set @sql1 += ' where ca.Descricao = ''Entrada'' ' 
	end
	else if @Filtro2 = 'pratoprincipal' begin
		set @sql1 += ' where ca.Descricao = ''Prato Principal''' 
	end
	else if @Filtro2 = 'sobremesa' BEGIN
		set @sql1 += ' where ca.Descricao = ''Sobremesa''' 
	end
	else if @Filtro2 = 'bebida' BEGIN
		set @sql1 += ' where ca.Descricao = ''Bebidas''' 
	end
	else if @Filtro2 = 'todos' BEGIN
		set @sql2 = 'todos'
	end

	if @Filtro3 = 'SA' BEGIN
		if @sql2 = 'todos' BEGIN
			set @sql1 += ' where ci.Descricao = ''Santo André'' ' 
		END
		set @sql1 += ' and ci.Descricao = ''Santo André'' '
	end
	else if @Filtro3 = 'SB' BEGIN
		if @sql2 = 'todos' BEGIN
			set @sql1 += ' where ci.Descricao = ''São Bernardo do Campo''' 
		END
		set @sql1 += ' and ci.Descricao = ''São Bernardo do Campo'''
	end

	else if @Filtro3 = 'SP' BEGIN
		if @sql2 = 'todos' BEGIN
			set @sql1 += ' where ci.Descricao = ''São Paulo''' 
		END
		set @sql1 += ' and ci.Descricao = ''São Paulo'''
	end
	


	set @sql1 += @sql3

	exec(@sql1)

end
go
-------------------------------------------------------------------------------------------------------------------------
exec spConsulta1 'mv', 'todos', 'TD'

select * from Vendas
select * from Usuarios
select * from Entregador
select * from ItensVenda
SELECT * from Cidades
select * from Comidas
select * from Categorias
go
create trigger trg_estoque on ItensVenda for insert as
begin
	
	declare @ComidaId int = (select IdComida from inserted)
	declare @qtdV int = (select Qtd from inserted) 
	declare @EmbalagemId int = (select IdEmbalagem from Comidas where Id = @ComidaId )
	update Embalagem set
	QtdEstoque = QtdEstoque -@qtdV
	where Id = @EmbalagemId
	declare @qtdE int = (select QtdEstoque from Embalagem where Id = @EmbalagemId)
	if @qtdE < 0 begin
		declare @Descricao varchar(max) = (select Descricao from Comidas where Id = @ComidaId)
		print 'O prato '+ cast(@Descricao as varchar(max)) + ' não pode ser vendido por falta na quantidade de estoque'
		rollback tran
    end
end

--select * from ItensVenda
--select * from Embalagem

select co.Descricao,ci.Descricao as Cidade, co.Preco, count(i.Qtd) as qtd, null as DataVenda from Vendas v inner join ItensVenda i ON
	v.Id = i.IdVenda inner join Cidades ci ON
	v.IdCidade = ci.Id inner join Comidas co ON
	i.IdComida = co.Id inner join Categorias ca on 
	co.IdCategoria = ca.Id where ci.Descricao = 'Santo André'  and ci.Descricao = 'Santo André'  group by co.Descricao,ci.Descricao, co.Preco
					order by qtd desc