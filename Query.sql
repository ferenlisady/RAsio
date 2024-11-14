CREATE TABLE MsUser (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    UserGender VARCHAR(6) NOT NULL,
    UserDOB DATE NOT NULL,
    UserPhone VARCHAR(15) NOT NULL,
    UserAddress VARCHAR(100) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    UserRole VARCHAR(10) NOT NULL
);

CREATE TABLE MsStationery (
    StationeryID INT IDENTITY(1,1) PRIMARY KEY,
    StationeryName VARCHAR(50) NOT NULL,
    StationeryPrice INT NOT NULL
);

CREATE TABLE Cart (
    UserID INT,
    StationeryID INT,
    Quantity INT NOT NULL,
    PRIMARY KEY (UserID, StationeryID),
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID),
    FOREIGN KEY (StationeryID) REFERENCES MsStationery(StationeryID)
);

CREATE TABLE TransactionHeader (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    TransactionDate DATE NOT NULL,
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID)
);

CREATE TABLE TransactionDetail (
    TransactionID INT,
    StationeryID INT,
    Quantity INT NOT NULL,
    PRIMARY KEY (TransactionID, StationeryID),
    FOREIGN KEY (TransactionID) REFERENCES TransactionHeader(TransactionID),
    FOREIGN KEY (StationeryID) REFERENCES MsStationery(StationeryID)
);
