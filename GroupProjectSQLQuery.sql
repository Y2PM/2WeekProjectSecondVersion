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

INSERT INTO Game (name) VALUES ('Odds N Evens');
INSERT INTO Game (payout) VALUES (10);
INSERT INTO Game (name) VALUES ('Lottery');
INSERT INTO Game (payout) VALUES (1000000);
INSERT INTO Game (name) VALUES ('Lucky Number');
INSERT INTO Game (payout) VALUES (1000);
INSERT INTO Member (m_name) VALUES ('James');
INSERT INTO Member (m_username) VALUES ('ragingbull');
INSERT INTO Member (m_password) VALUES ('password123');
INSERT INTO Member (m_account) VALUES (0.0);
INSERT INTO Member (m_name) VALUES ('Michael');
INSERT INTO Member (m_username) VALUES ('rocky');
INSERT INTO Member (m_password) VALUES ('password12');
INSERT INTO Member (m_account) VALUES (0.0);
INSERT INTO Member (m_name) VALUES ('Rick');
INSERT INTO Member (m_username) VALUES ('stuffandthings');
INSERT INTO Member (m_password) VALUES ('password1');
INSERT INTO Member (m_account) VALUES (0.0);