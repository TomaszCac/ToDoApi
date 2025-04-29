CREATE TABLE ToDos (
    Id INT NOT NULL AUTO_INCREMENT,
    Title LONGTEXT NOT NULL,
    Description LONGTEXT,
    CompletePercent INT NOT NULL,
    Expiration DATETIME(6) NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

INSERT INTO ToDos (Title, Description, CompletePercent, Expiration) VALUES
('Learn geometrics', 'Learning by listening to podcasts', 20, DATE_ADD(CURDATE(), INTERVAL 1 DAY)),
('Finish studies about frogs', 'Frogs from African continent', 75, DATE_ADD(CURDATE(), INTERVAL 6 DAY)),
('Read a Book', NULL, 0, DATE_ADD(CURDATE(), INTERVAL 10 DAY)),
('Clean the dishes', 'Those dishes wont clean themselves', 50, DATE_ADD(CURDATE(), INTERVAL 3 HOUR));