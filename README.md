# Rest API with .net and Entity Framework
This project implements a Rest API responsible for calculating the price of sale of a given product. 

It applies a certain profit margin on its price.
of cost. The profit margin varies by product category.

# Endpoints
Two entries are available:
- **api01/** = Lists all registered products
- **api01/price?category=\<category\>,cost=\<cost\>** =  The user inform by query string the category and cost price of an item and as a result of the requisition, it gets the new price of
sale already calculated.
    
# Database

The categories with the margin of profit folow this table

| **Categoria**  | **Margem de lucro** |
| ---------------- | --------------------- |
| Brinquedos       | 25%                   |
| Bebidas          | 30%                   |
| Informática      | 10%                   |
| Softplan         | 5%                    |
| Outra categoria  | 15%                   |


# Use cases

1. category **exists** and **value > 0**: returns the calculated value
2. category **exists** and **value <= 0**: returns 0
3. category does **not exist** and **value > 0**: returns value considering 15% profit margin
4. category does **not exist** and **value <= 0**: returns 0

# Makefile

**make run** to run the aplication
**make test** to ran the tests for the aplication

