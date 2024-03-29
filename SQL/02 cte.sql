WITH ProductAndCategoryIds AS (
	SELECT 
		Products.Name,
		ProductCategories.CategoryId
	FROM
		Products
	LEFT JOIN ProductCategories
		ON Products.Id = ProductCategories.ProductId
)
SELECT
	ProductAndCategoryIds.Name,
	Categories.Name
FROM
	ProductAndCategoryIds
LEFT JOIN Categories
	ON ProductAndCategoryIds.CategoryId == Categories.Id