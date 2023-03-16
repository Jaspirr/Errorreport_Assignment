CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    EmailAdress VARCHAR(100) NOT NULL,
    PasswordHash VARBINARY(64) NOT NULL,
    PasswordSalt VARBINARY(64) NOT NULL,
    Role VARCHAR(20) NOT NULL
);

CREATE TABLE ErrorReport (
    ErrorReportId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME2(0) NOT NULL,
    Status VARCHAR(20) NOT NULL,
    Priority VARCHAR(20) NOT NULL,
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

CREATE TABLE Comments (
    CommentId INT PRIMARY KEY IDENTITY(1,1),
    Text VARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME2(0) NOT NULL,
    CustomerId INT NOT NULL,
    ErrorReportId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
    FOREIGN KEY (ErrorReportId) REFERENCES ErrorReport(ErrorReportId)
);

CREATE TABLE Worker (
    WorkerId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME2(0) NOT NULL,
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

CREATE TABLE WorkerConditions (
    ConditionId INT PRIMARY KEY IDENTITY(1,1),
    WorkerId INT NOT NULL,
    ConditionType VARCHAR(20) NOT NULL,
    Value VARCHAR(MAX) NOT NULL,
    FOREIGN KEY (WorkerId) REFERENCES Worker(WorkerId)
);

