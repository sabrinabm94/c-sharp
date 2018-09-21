#populando usuários
INSERT INTO users (name, username, password, cpf, accountId)
VALUES ('Sabrina', 'sabrina', 'sabrina123', 6541321, 1);

INSERT INTO users (name, username, password, cpf, accountId)
VALUES ('Alexander', 'alexander', 'alexander123', 123456, 2);

SELECT * FROM users;

#populando contas
INSERT INTO accounts (type, balance, userId)
VALUES ('cc', 0, 1);

INSERT INTO accounts (type, balance, userId)
VALUES ('cc', 500, 2);

SELECT * FROM accounts;