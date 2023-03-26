# inventoryApp

##User specification for inventory application

The inventory application is a web-based system that allows users to manage their products and bins. The application provides the following functionality:

- Registration: Users can register for an account by providing a valid email address and a password. The password must contain at least one letter and one digit, and have a minimum length of six characters. The email address must be unique and not already registered in the system.
- Product creation: Users can create products by entering a code, a description, a quantity, a price, a nominal weight and a unit of measurement. The code must be unique and not already used by another product in the system.
- Bin creation: Users can create bins by entering a name and a maximum capacity. The name must be unique and not already used by another bin in the system.
- Allocation creation: Users can allocate products to bins by selecting a product, a bin, and a quantity. The quantity must be positive and not exceed the capacity of the bin.
- Product view: Users can view the details of their products. Users can also edit or delete their products, as long as they are not allocated to any bin.
- Bin view: Users can view the details of their bins. Users can also edit or delete their bins, as long as they are not allocated to any product.
- Allocation view: Users can view the details of their allocations, such as product code, bin name, quantity, and date. Users can also edit or delete their allocations, as long as they do not violate the constraints of product quantity or bin capacity.

The inventory application is designed to be user-friendly, secure, and reliable. It uses encryption and authentication to protect user data and prevent unauthorized access. It also uses validation and error handling to ensure data integrity and prevent system failures.


