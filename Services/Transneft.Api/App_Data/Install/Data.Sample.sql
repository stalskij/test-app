SET IDENTITY_INSERT dbo.Company ON; 
INSERT INTO dbo.Company ([Id], [Name], [Address]) 
	VALUES	(1, N'ПАО Роснефть', N'г.Москва, ул. Ленина 1');
SET IDENTITY_INSERT dbo.Company OFF; 

SET IDENTITY_INSERT dbo.AffiliatedCompany ON; 
INSERT INTO dbo.AffiliatedCompany ([Id], [Name], [Address], [CompanyId]) 
	VALUES	(1, N'ООО ЮНГ', N'г.Нефтеюганск, ул. Ленина 1', 1),
			(2, N'ООО Няганьнефтегаз', N'г.Нягань, ул. Ленина 2', 1),
			(3, N'ООО Томскнефть',	N'г.Томск, ул. Ленина 3', 1),
			(4, N'ООО Самотлорнефтегаз', N'г.Самотлор, ул. Ленина 4', 1),
			(5, N'ООО Дагнефть', N'г.Махачкала, ул. Ленина 5', 1);
SET IDENTITY_INSERT dbo.AffiliatedCompany OFF;

SET IDENTITY_INSERT dbo.ConsumptionObject ON; 
INSERT INTO dbo.ConsumptionObject ([Id], [Name], [Address], [AffiliatedCompanyId]) 
	VALUES	(1, N'ВС 120/10 Весна', N'г.Москва, ул. Ленина 1', 1),
			(2, N'ПС 110/00 Альфа', N'г.Томск, ул. Ленина 1', 2),
			(3, N'НН 150/60 Поло', N'г.Новгород Великий, ул. Ленина 1', 3),
			(4, N'КС 140/30 Кента', N'г.Уфа, ул. Ленина 1', 3),
			(5, N'ВС 100/70 Липа', N'г.Саранск, ул. Ленина 1', 3);
SET IDENTITY_INSERT dbo.ConsumptionObject OFF; 

