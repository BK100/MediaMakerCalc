# MediaMakerCalc

This project was created to satisfy the requirements of the Mediamaker technical test. It contains an auth integrated Web API that allows the user to run calculations based on requests sent to the endpoints. An example of the authentication call, as well as requests for each of the endpoints, can be found in the top-level Postman collection.

# Using the calculator

First, users will need to supply credentials to the authentication endpoint in order to recieve a bearer token. The credentials required are "testUser" and "testPassword". The bearer token can then be used to authenticate the user and access the calculation endpoints in the calculation controller. These endpoints include -

/Add
/Subtract
/Multiply
/Divide
/MixedCalculation

The first four are functionalities outlined by the task specification - the fifth endpoint allows the user to send a request containing values and operators to build a more standard calculation, without being restricted to a single type.
The operators are an enum type, and use the corresponding values -
Add - 1
Subtract - 2
Multiply - 3
Divide - 4

Any further examples can be found within the postman collection.
Additionally, the repo also contains functionality for logging requests, successes and errors to an SQLite database using Entity Framework. Also included is a test project with a selection of NUnit tests for testing the calculator endpoint methods.
