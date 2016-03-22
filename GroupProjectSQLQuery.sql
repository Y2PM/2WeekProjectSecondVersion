IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
DROP TABLE [dbo].[Game]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Member]') AND type in (N'U'))
DROP TABLE [dbo].[Member]

CREATE TABLE Game
(
game_id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(50),
payout DECIMAL
);

CREATE TABLE Member
(
member_id INT IDENTITY(1,1) PRIMARY KEY,
m_name VARCHAR(50),
m_username VARCHAR(50),
m_password VARCHAR(50),
m_account DECIMAL
);

INSERT INTO Game (name, payout) VALUES ('Odds N Evens', 10);
INSERT INTO Game (name, payout) VALUES ('Lottery', 1000000);
INSERT INTO Game (name, payout) VALUES ('Lucky Number', 1000);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('James', 'ragingbull', 'password123', 0.0);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('Michael', 'rocky', 'password12', 0.0);
INSERT INTO Member (m_name, m_username, m_password, m_account) VALUES ('Rick', 'stuffandthings', 'password1', 0.0);
