IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
DROP TABLE [dbo].[Game]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Member]') AND type in (N'U'))
DROP TABLE [dbo].[Member]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GroupProject].[dbo].[Log]') AND type in (N'U'))
drop table [GroupProject].[dbo].[Log]

CREATE TABLE [GroupProject].[dbo].[Log] (
    [Id] [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Date] [datetime] NOT NULL,
    [Thread] [varchar] (255) NOT NULL,
    [Level] [varchar] (50) NOT NULL,
    [Logger] [varchar] (255) NOT NULL,
    [Message] [varchar] (4000) NOT NULL,
    [Exception] [varchar] (2000) NULL
)

CREATE TABLE Game
(
game_id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(50),
payout DECIMAL,
price DECIMAL,
profit DECIMAL
);

CREATE TABLE Member
(
member_id INT IDENTITY(1,1) PRIMARY KEY,
m_name VARCHAR(50),
m_username VARCHAR(50),
m_password VARCHAR(50),
m_account DECIMAL
);

INSERT INTO Game (name, payout, price, profit) VALUES ('Odds N Evens', 10, 1.00, 0);
INSERT INTO Game (name, payout, price, profit) VALUES ('Lottery', 1000000, 2.00, 0);
INSERT INTO Game (name, payout, price, profit) VALUES ('Lucky Number', 1000, 1.50, 0);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('James', 'ragingbull', 'password123', 0.0);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('Michael', 'rocky', 'password12', 0.0);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('Rick', 'stuffandthings', 'password1', 0.0);
