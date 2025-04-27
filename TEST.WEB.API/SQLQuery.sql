--DROP TABLE Products

CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
INSERT INTO Products (Id, Name, Price) VALUES
(1, 'Wireless Mouse', 49.99),
(2, 'Mechanical Keyboard', 129.50),
(3, '27-inch Monitor', 899.00),
(4, 'USB-C Hub', 35.75),
(5, 'Laptop Stand', 60.00),
(6, 'External SSD 1TB', 350.00),
(7, 'Webcam HD', 120.00),
(8, 'Noise Cancelling Headphones', 499.99),
(9, 'Gaming Chair', 850.00),
(10, 'Smartphone Charger', 39.90);
