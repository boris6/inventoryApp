# inventoryApp

Warehouse management application


Home screen
Contains company logo, user name field, password field, login and registration buttons.

Registration
Contains user name and password fields and Register button.
Password rule: Must contain at least 1 special character.
Username rule: Can’t use existing one.

Login
Contains username and password fields and Login button.
Optional: Remember me checkbox

Main page
After successful login, main page opens. It contains Products, Bins, Allocations tabs.

Products
Product tab contains list of all products in the warehouse in all bins. At the top there is a search box and Add button.
Bellow is a list of all products with its details and Edit and Delete buttons in each row.

Add product
New page with fields:
Code, Name, Unit of Measure, Price, Nominal Weight
Unit of measure is dropdown with options Each, Case and Kg.
Nominal Weight is required for Qty and Case products and represents weight of each piece or case.
Validation: Can’t use same code twice.

Edit product
Same page as Add, prepopulated with data from selected row.

Delete product
Shows confirmation message. At confirm deletes product and all it’s data from the bin locations. 





Bins
Contains list of all bins. Same as product, has options to Add, Delete or Edit Bin.
When bin has any products in it, it can’t be deleted. 

Add bin
Bin name(unique), Maximum Weight capacity

Allocations
Contains list of all allocations. List can be filtered by product or bin. Has option to add, delete or edit allocation.

Add allocation
Contains product selection, Bin selection, Quantity field.
If selected bin exceeds maximum weight capacity, can’t save allocation.

Edit allocation
Same as add with prepopulated data. Weight validation.

Delete
Confirmation message displays. At confirm remove allocation.




