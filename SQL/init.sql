CREATE TABLE Products (
	Id int PRIMARY KEY,
	Name varchar(100)
);

CREATE TABLE Categories (
	Id int PRIMARY KEY,
	Name varchar(100)
);

CREATE TABLE ProductCategories (
	ProductId int,
	CategoryId int,
	PRIMARY KEY (ProductId, CategoryId),
	CONSTRAINT FK_Product FOREIGN KEY (ProductId) REFERENCES Products(Id),
	CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id) 
);

INSERT INTO Products (
	Id, Name
)
VALUES 
	(1, 'Apple'),
	(2, 'Orange'),
	(3, 'Tomato'),
	(4, 'Plum'),
	(5, 'Potato'),
	(6, 'Blueberry');

INSERT INTO Categories (
	Id, Name
)
VALUES
	(1, "Fruits"),
	(2, "Vegetables"),
	(3, "Promo");

INSERT INTO ProductCategories (
	ProductId, CategoryId
)
VALUES
	(1, 1),
	(2, 1),
	(4, 1),
	(3, 2),
	(5, 2),
	(2, 3),
	(3, 3);