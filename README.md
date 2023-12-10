# Currency Exchange Service

This project facilitates currency conversion and provides statistical summaries for currency exchange endpoints.

## Overview

The Currency Exchange Service within this project allows users to convert currencies and gather statistical insights regarding endpoint usage.

## Endpoints

### Convert Currency

Converts USD currency based on the provided request.

- **Method:** POST
- **Route:** `/api/convert`
- **Request Body:**
    ```json
    {
        "To": "EUR",
        "amount": 100
    }
    ```
- **Response:** 
    - `200 OK` with converted currency details.
    - `400 Bad Request` if the request is invalid.
    - `500 Internal Server Error` if an unexpected error occurs.

### Statistics

Retrieves statistics summary for endpoints.

- **Method:** GET
- **Route:** `/statistics`
- **Response:** 
    - `200 OK` with endpoint statistics summary.
    - `500 Internal Server Error` if an unexpected error occurs.

**Statistics Example:**
Make a GET request to `/statistics` to retrieve endpoint statistics summary.

## Notes

- Modify the connection string in the app settings file (`appsettings.json`) to match your environment configurations.
- This project includes a Postman collection at `Secureship HTTP Client\Secureship Collection.postman_collection.json`. Import this collection into Postman for easy API testing and interaction.
- Ensure proper error handling for each endpoint's response codes to effectively manage potential errors.

## Dependencies

- AutoMapper
- Microsoft.AspNetCore.Mvc
- Refit

## Usage

To utilize these endpoints, ensure that the required dependencies are installed and make appropriate POST and GET requests to the specified routes.

### Convert Currency Example

Make a POST request to `/api/convert` with the JSON payload:
```json
{
    "To": "EUR",
    "amount": 100
}
