CREATE TABLE GameResults (
    ID INT PRIMARY KEY,
    PlayerName VARCHAR(50) NOT NULL,
    GameDuration INT NOT NULL,
    WinDateTime DATETIME NOT NULL
);