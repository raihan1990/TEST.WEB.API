-- Create Category table first (because Product depends on it)
CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

-- Create Product table
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
);


-- Insert Categories with manual Id values
INSERT INTO Categories (Id, Name) VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Home Appliances'),
(4, 'Books'),
(5, 'Furniture');

-- Insert Products with manual Id values and corresponding CategoryId
INSERT INTO Products (Id, Name, Price, CategoryId) VALUES
(1, 'Smartphone', 799.99, 1),    -- Electronics
(2, 'Laptop', 1299.99, 1),       -- Electronics
(3, 'T-Shirt', 19.99, 2),        -- Clothing
(4, 'Jeans', 39.99, 2),          -- Clothing
(5, 'Microwave', 149.99, 3),     -- Home Appliances
(6, 'Washing Machine', 499.99, 3), -- Home Appliances
(7, 'Novel', 9.99, 4),           -- Books
(8, 'Sofa', 899.99, 5);          -- Furniture
