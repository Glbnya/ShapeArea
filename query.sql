SELECT products.ID, products.title as product, categories.title as category
FROM products
LEFT OUTER JOIN prodkateg
on products.ID = prodkateg.product_id
LEFT OUTER JOIN categories
on prodkateg.category_id = categories.ID
ORDER BY products.ID