Use [master];

Drop DataBase DataBaseNFe;
Create DataBase DataBaseNFe;

Use DataBaseNFe;

BEGIN TRANSACTION;
GO

CREATE TABLE [Destinatario] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [IdEndereco] int NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [indIEDest] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Destinatario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Emissor] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [IdEndereco] int NOT NULL,
    [CNPJ] nvarchar(max) NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Fantasia] nvarchar(max) NOT NULL,
    [IE] nvarchar(max) NOT NULL,
    [CRT] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Emissor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [Logradouro] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [CodigoMunicipio] nvarchar(max) NULL,
    [Municipio] nvarchar(max) NULL,
    [UF] nvarchar(max) NULL,
    [CEP] nvarchar(max) NULL,
    [CodigoPais] nvarchar(max) NULL,
    [Pais] nvarchar(max) NULL,
    [Complemento] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Ide] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [cUF] nvarchar(max) NOT NULL,
    [cNF] nvarchar(max) NOT NULL,
    [natOp] nvarchar(max) NOT NULL,
    [mod] nvarchar(max) NOT NULL,
    [serie] nvarchar(max) NOT NULL,
    [nNF] nvarchar(max) NOT NULL,
    [dhEmi] datetime2 NOT NULL,
    [tpNF] nvarchar(max) NOT NULL,
    [idDest] nvarchar(max) NOT NULL,
    [cMunFG] nvarchar(max) NOT NULL,
    [tpImp] nvarchar(max) NOT NULL,
    [tpEmis] nvarchar(max) NOT NULL,
    [cDV] nvarchar(max) NOT NULL,
    [tpAmb] nvarchar(max) NOT NULL,
    [finNFe] nvarchar(max) NOT NULL,
    [indFinal] nvarchar(max) NOT NULL,
    [indPres] nvarchar(max) NOT NULL,
    [procEmi] nvarchar(max) NOT NULL,
    [verProc] nvarchar(max) NOT NULL,
    [dhSaiEnt] datetime2 NOT NULL,
    CONSTRAINT [PK_Ide] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [InformacaoNFe] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [Versao] nvarchar(max) NOT NULL,
    [IdOriginal] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_IformacoesNFe] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [LogAlteracaoNFeProcessada] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [IdLogNFeProcessada] int NOT NULL,    
    [Campo] nvarchar(max) NULL,
    [ValorAntigo] nvarchar(max) NULL,	
    [ValorNovo] nvarchar(max) NULL,
    CONSTRAINT [PK_LogAlteracaoNfeProcessada] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [LogNFeProcessada] (
    [Id] int NOT NULL IDENTITY,
    [DataHoraInicio] datetime2 NOT NULL,
    [DataHoraFim] datetime2 NULL,
    [IdNotaInicial] int NOT NULL,
    [IdNotaFinal] int Not NULL,
    CONSTRAINT [PK_LogNFeProcessada] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [NFeProcessada] (
    [Id] int NOT NULL IDENTITY,
	[IdLogNFeProcessada] int NOT NULL,
    [IdOriginal] int NOT NULL,
    [Versao] nvarchar(max) NULL,
    [Xmlns] nvarchar(max) NULL,
    CONSTRAINT [PK_NFeProcessada] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProdutoNFe] (
    [Id] int NOT NULL IDENTITY,
    [IdNFeProcessada] int NOT NULL,
    [NumeroItem] int NOT NULL,
    [Codigo] nvarchar(max) NOT NULL,
    [cEAN] nvarchar(max) NOT NULL,
    [Desricao] nvarchar(max) NOT NULL,
    [NCM] int NOT NULL,
    [CFOP] int NOT NULL,
    [uCom] nvarchar(max) NOT NULL,
    [qCom] int NOT NULL,
    [vUnCom] decimal(18,2) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [cEANTrib] int NOT NULL,
    [uTrib] nvarchar(max) NOT NULL,
    [qTrib] decimal(18,2) NOT NULL,
    [vUnTrib] decimal(18,2) NOT NULL,
    [indTot] nvarchar(max) NOT NULL,
    [Preco] decimal(18,2) NOT NULL,
    [Imposto] decimal(18,2) NOT NULL,
    [Marca] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProdutoNFe] PRIMARY KEY ([Id])
);
GO

ALTER TABLE [Destinatario] ADD CONSTRAINT FK_Destinatario_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);
ALTER TABLE [Destinatario] ADD CONSTRAINT FK_Destinatario_Endereco FOREIGN KEY ([IdEndereco]) REFERENCES [Endereco] (id);

ALTER TABLE [Emissor] ADD CONSTRAINT FK_Emissor_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);
ALTER TABLE [Emissor] ADD CONSTRAINT FK_Emissor_Endereco FOREIGN KEY ([IdEndereco]) REFERENCES [Endereco] (id);

ALTER TABLE [Ide] ADD CONSTRAINT FK_Ide_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);

ALTER TABLE [InformacaoNFe] ADD CONSTRAINT FK_InformacaoNFe_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);

ALTER TABLE [LogAlteracaoNfeProcessada] ADD CONSTRAINT FK_LogAlteracaoNfeProcessada_LogNFeProcessada FOREIGN KEY ([IdLogNFeProcessada]) REFERENCES [LogNFeProcessada] (id);
ALTER TABLE [LogAlteracaoNfeProcessada] ADD CONSTRAINT FK_LogAlteracaoNfeProcessada_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);

ALTER TABLE [NFeProcessada] ADD CONSTRAINT FK_NFeProcessada_LogNFeProcessada FOREIGN KEY ([IdLogNFeProcessada]) REFERENCES [LogNFeProcessada] (id);

ALTER TABLE [ProdutoNFe] ADD CONSTRAINT FK_ProdutoNFe_NFeProcessada FOREIGN KEY ([IdNFeProcessada]) REFERENCES [NFeProcessada] (id);

COMMIT;
GO


