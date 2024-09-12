create database DiamondShopDB
CREATE TABLE Account (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(200) DEFAULT NULL,
    password VARCHAR(200) DEFAULT NULL,
    phone VARCHAR(200) DEFAULT NULL,
    dob DATE DEFAULT NULL,
    email VARCHAR(200) NOT NULL,
    fullname NVARCHAR(MAX) NOT NULL,
    role INT NOT NULL,
    created DATETIME NOT NULL,
    status TINYINT NOT NULL
);

CREATE TABLE Quote_Status (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);
CREATE TABLE Product_Type (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Product (
    id INT PRIMARY KEY IDENTITY(1,1),
    imageUrl NVARCHAR(MAX) NOT NULL,
    product_type_id INT NOT NULL,
    mounting_size FLOAT DEFAULT NULL,
    FOREIGN KEY (product_type_id) REFERENCES Product_Type(id)
);
CREATE TABLE Quote (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT NOT NULL,
    account_id INT NOT NULL,
    quote_status_id INT NOT NULL,
    product_price FLOAT NOT NULL,
    production_price FLOAT NOT NULL,
    profit_rate FLOAT NOT NULL,
    total_price AS (product_price * (100 + profit_rate) / 100 + production_price) PERSISTED,
    note NVARCHAR(MAX) DEFAULT NULL,
    design_staff_id INT DEFAULT NULL,
    production_staff_id INT DEFAULT NULL,
    created DATETIME NOT NULL,
    FOREIGN KEY (product_id) REFERENCES Product(id),
    FOREIGN KEY (account_id) REFERENCES Account(id),
    FOREIGN KEY (quote_status_id) REFERENCES Quote_Status(id),
    FOREIGN KEY (design_staff_id) REFERENCES Account(id),
    FOREIGN KEY (production_staff_id) REFERENCES Account(id)
);

CREATE TABLE Order_Status (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Orders (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT NOT NULL,
    account_id INT NOT NULL,
    product_price FLOAT NOT NULL,
    profit_rate FLOAT NOT NULL,
    production_price FLOAT NOT NULL,
    total_price FLOAT NOT NULL,
    order_status_id INT NOT NULL,
    note NVARCHAR(MAX) DEFAULT NULL,
    design_staff_id INT DEFAULT NULL,
    production_staff_id INT DEFAULT NULL,
    created DATETIME NOT NULL,
    FOREIGN KEY (product_id) REFERENCES Product(id),
    FOREIGN KEY (account_id) REFERENCES Account(id),
    FOREIGN KEY (order_status_id) REFERENCES Order_Status(id),
    FOREIGN KEY (design_staff_id) REFERENCES Account(id),
    FOREIGN KEY (production_staff_id) REFERENCES Account(id)
);

CREATE TABLE Production_Status (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Production_Process (
    id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT NOT NULL,
    production_status_id INT NOT NULL,
    imageUrl NVARCHAR(MAX) DEFAULT NULL,
    created DATETIME NOT NULL,
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    FOREIGN KEY (production_status_id) REFERENCES Production_Status(id)
);
CREATE TABLE Diamond_Clarity (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Diamond_Color (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Diamond_Origin (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL
);
CREATE TABLE Diamond (
    id INT PRIMARY KEY IDENTITY(1,1),
    size FLOAT NOT NULL,
    imageUrl NVARCHAR(MAX) NOT NULL,
    diamond_color_id INT NOT NULL,
    diamond_origin_id INT NOT NULL,
    diamond_clarity_id INT NOT NULL,
    price FLOAT NOT NULL,
    status TINYINT NOT NULL,
    created DATETIME NOT NULL,
    FOREIGN KEY (diamond_color_id) REFERENCES Diamond_Color(id),
    FOREIGN KEY (diamond_origin_id) REFERENCES Diamond_Origin(id),
    FOREIGN KEY (diamond_clarity_id) REFERENCES Diamond_Clarity(id)
);




CREATE TABLE Metal (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(MAX) NOT NULL,
    buy_price_per_gram FLOAT NOT NULL,
    sale_price_per_gram FLOAT NOT NULL,
    imageUrl NVARCHAR(MAX) NOT NULL,
    specific_weight FLOAT NOT NULL,
    deactivated TINYINT NOT NULL,
    created DATETIME NOT NULL
);



CREATE TABLE Product_Diamond (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT NOT NULL,
    diamond_id INT NOT NULL,

    count INT NOT NULL,
    price FLOAT NOT NULL,
    status TINYINT NOT NULL,
    FOREIGN KEY (product_id) REFERENCES Product(id),
    FOREIGN KEY (diamond_id) REFERENCES Diamond(id),

);

CREATE TABLE Product_Metal (
    id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT NOT NULL,
    metal_id INT NOT NULL,
    weight FLOAT NOT NULL,
    status TINYINT NOT NULL,
    price FLOAT NOT NULL,
    FOREIGN KEY (product_id) REFERENCES Product(id),
    FOREIGN KEY (metal_id) REFERENCES Metal(id)
);

INSERT INTO Account(username, password, phone, dob, email, fullname, role, created, status)
VALUES 
('customer', '123', '123123123', '2024-07-12', '123@gmail.com', 'Nguyen Van A', 1, '2024-07-12 15:30:00','0'),
('manager', '123', '123123123', '2024-07-13', '123@gmail.com', 'Nguyen Van B', 2, '2024-07-13 15:30:00','0'),
('salestaff', '123', '123123123', '2024-07-14', '123@gmail.com', 'Nguyen Van C', 3, '2024-07-14 15:30:00','0'),
('designstaff', '123', '123123123', '2024-07-15', '123@gmail.com', 'Nguyen Van D', 4, '2024-07-15 15:30:00','0'),
('productionstaff', '123', '123123123', '2024-07-16', '123@gmail.com', 'Nguyen Van E', 5, '2024-07-16 15:30:00','0');

INSERT INTO Diamond_Clarity(name)
values
('IF'),
('VVS1'),
('VVS2'),
('VS1'),
('VS2')

INSERT INTO Diamond_Color(name)
values
('D'),
('E'),
('J'),
('F')

INSERT INTO Diamond_Origin(name)
values
('Natural'),
('Lab')

INSERT INTO Diamond (size, imageUrl, diamond_color_id, diamond_origin_id, diamond_clarity_id, price, status, created)
VALUES
(5.2, 'image.jpg', 1, 1, 1, 54500000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 1, 1, 2, 52800000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 1, 1, 3, 49800000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 1, 1, 4, 46600000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 1, 1, 5, 42100000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 2, 1, 1, 52000000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 2, 1, 2, 50200000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 2, 1, 3, 47200000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 2, 1, 4, 45100000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 2, 1, 5, 40800000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 3, 1, 1, 35000000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 3, 1, 2, 33300000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 3, 1, 3, 45500000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 3, 1, 4, 43200000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 3, 1, 5, 38600000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 4, 1, 1, 32000000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 4, 1, 2, 31100000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 4, 1, 3, 43000000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 4, 1, 4, 40800000, 0, '2024-08-06 00:00:00'),
(5.2, 'image.jpg', 4, 1, 5, 36500000, 0, '2024-08-06 00:00:00');

INSERT INTO Metal (
    name,
    buy_price_per_gram,
    sale_price_per_gram,
    imageUrl,
    specific_weight,
    deactivated,
    created
)
VALUES
('10K Gold', 5000000, 5500000, 'main.jpg', 0.0136, 0, '2024-05-22 00:00:00'),
('14K Gold', 6000000, 6600000, 'main.jpg', 0.0147, 0, '2024-05-23 00:00:00'),
('18K Gold', 7000000, 7700000, 'main.jpg', 0.0156, 0, '2024-05-24 00:00:00'),
('10K Rose Gold', 5200000, 5720000, 'main.jpg', 0.0132, 0, '2024-03-25 00:00:00'),
('14K Rose Gold', 6200000, 6820000, 'main.jpg', 0.0143, 0, '2024-03-26 00:00:00'),
('18K Rose Gold', 7200000, 7920000, 'main.jpg', 0.0152, 0, '2024-03-27 00:00:00'),
('Silver', 700000, 770000, 'main.jpg', 0.0105, 0, '2024-04-18 00:00:00'),
('Platinum', 900000, 990000, 'main.jpg', 0.0214, 0, '2024-05-12 00:00:00');


INSERT INTO Order_Status(name)
values
('Deposit'),
('Designing'),
('Manufacturing'),
('Payment'),
('Comeplete'),
('Cancel')

INSERT INTO Product_Type(name)
values
('Ring'),
('Band'),
('Pendant')

INSERT INTO Production_Status(name)
values
('Unrealized'),
('Casting'),
('Assembly'),
('Polishing'),
('Finished')

INSERT INTO Quote_Status(name)
values
('Received'),
('Assigned'),
('Priced'),
('Completed'),
('Cancelled')
