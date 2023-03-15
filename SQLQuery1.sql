CREATE TABLE Customer (
    Id uniqueidentifier PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    EmailAddress NVARCHAR(255) NOT NULL,
    PhoneNumber CHAR(13) NOT NULL
);

CREATE TABLE ErrorReport (
    ErrorReportId int PRIMARY KEY NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    EntryTime DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CustomerId uniqueidentifier NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE Comment (
    CommentId int PRIMARY KEY NOT NULL,
    Comment NVARCHAR(255) NOT NULL,
    EntryTime DATETIME NOT NULL,
    ErrorReportId int NOT NULL,
    FOREIGN KEY (ErrorReportId) REFERENCES ErrorReport(ErrorReportId)
);