# Secureship-HTTP-Client-Test
# Project Currency Exchange Service

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
- **Route:** `/api/statistics`
- **Response:** 
    - `200 OK` with endpoint statistics summary.
    - `500 Internal Server Error` if an unexpected error occurs.

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
