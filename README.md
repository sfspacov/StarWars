Clean Architecture using TDD, DDD, SOLID Principles, Exception Handler, Notifier, Repository Pattern and many other good practicies,...

As long this is just a POC, I used a memory database.

**How it works**

Use a json like this one:

```json
{
    "sku": 43264,
    "name": "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
    "inventory": {
        "quantity": 15,
        "warehouses": [
            {
                "locality": "SP",
                "quantity": 12,
                "type": "ECOMMERCE"
            },
            {
                "locality": "MOEMA",
                "quantity": 3,
                "type": "PHYSICAL_STORE"
            }
        ]
    },
    "isMarketable": true
}
```

There is endpoints for:

- Product creation where the payload will be the json considered above (except for **isMarketable** and **inventory.quantity** properties)
- Product edition by **sku**
- Get product by **sku**
- Delete product by **sku**

### Rules

- Every time a product is retrieved by **sku** the property must be calculated: **inventory.quantity**

        The inventory.quantity property is the sum of the quantity of the warehouses

- Every time a product is retrieved by **sku** the property must be calculated: **isMarketable**

        A product is marketable whenever its inventory.quantity is greater than 0

- If a product already in memory tries to be created with the same **sku** an exception must be thrown

        Two products are considered equal if their skus are the same

- When updating a product, the old one must be overwritten with the one being sent in the requisition
        
        The request must receive the sku and update with the product that is also coming in the request
