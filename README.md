# eShop Web API

## Overview

The eShop Web API project is a .NET-based application that serves as the backend for an online multitenant e-commerce platform. Modeled after platforms like Shopify, it utilizes the Onion Architecture for a modular and scalable design. The application incorporates JWT and refresh tokens for robust authentication and authorization mechanisms. It provides a set of API endpoints for managing products and orders within the eShop.

## Table of Contents

- [Installation](#Installation)
- [Usage](#usage)
- [Sample Endpoints](#endpoints)
- [Examples](#examples)

## Installation

To get started with the eShop Web API, follow these steps:

```bash
# Clone the repository
git clone https://github.com/OkaforGerald/eShopAPI.git

# Navigate to the project directory
cd eShopAPI

# Install dependencies
dotnet restore
```
## Usage

After installing the dependencies, you can build and run the project:

```bash
# Build the project
dotnet build

# Run the project
dotnet run
```
## Endpoints

The application provides the following API endpoints, including but not limited to:

- GET /api/stores

Retrieve a list of all stores in a paginated list.
- POST /api/stores

Add a new store to the database.
- GET /api/stores/{productID}/products

Retrieve a list of all products owned by a store in a paginated list.
- POST /api/category/{categoryID}/products

Retrieves a list of all products in a category in a paginated list.

## Examples

# Get products in a store

```curl
curl -X GET http://localhost:7202/api/stores/{productID}/products?PageSize=2&searchTerm=14 Pro M
```
Response:

```json
[
  {
    "id": "18e6b046-46bf-49bf-1e87-08dbe0ad756e",
    "name": "Apple iPhone 14 Pro Max",
    "description": "Unlock the potential of the iPhone 14 Pro Max with our powerful API. Seamlessly integrate the advanced Pro-Grade camera system, ProMotion display, and lightning-fast A16 Bionic chip into your applications. Access 5G connectivity, Face ID, and MagSafe technology for a truly immersive and secure user experience. Elevate your app's performance with iOS 16 compatibility and tap into the future of mobile innovation. Experience the API that empowers your app to harness the full capabilities of the iPhone 14 Pro Max.",
    "imageUrl": "https://localhost:7202/Images/c29cc033-a241-4674-a040-e51c0cc71873/iPhone 14 Pro Max.jpg",
    "brand": "Apple",
    "price": 980000,
    "quantity": 10
  }
]

```

# Get products by category

```curl
curl -X GET http://localhost:7202/api/category/products?categoryId=d88874a9-1b18-46c9-9636-cbdc33a615cc&PageSize=2&orderBy=price asc
```
```json
[
  {
    "id": "e4d6ada5-da2e-4ca7-1e71-08dbe0ad756e",
    "name": "Zebra wax ribbon 60mm x 450m",
    "description": "Wax ribbons work best with paper materials when fast print speeds are required, and in applications with little to no exposure to chemicals or abrasion. Ideal for general purpose labeling, shelf labels, shipping and receiving, inventory tracking, warehousing, or retail tags and labels Suitable for printing on most uncoated and coated paper labels and tags Good print quality at speeds up to 254mm/sec (10ips) and 152mm/sec (6ips) for rotated barcodes",
    "imageUrl": "https://72gjvchc-7202.uks1.devtunnels.ms/Images/966d779e-c693-4abe-bbc3-325ecc71b48d/Zebra wax ribbon 60mm x 450m.jpg",
    "brand": "Zebra",
    "price": 5069,
    "quantity": 5
  },
  {
    "id": "8a8ef844-56b6-4e4a-1e70-08dbe0ad756e",
    "name": "Zebra wax ribbon 110mm x 450m",
    "description": "Wax ribbons work best with paper materials when fast print speeds are required, and in applications with little to no exposure to chemicals or abrasion. Ideal for general purpose labeling, shelf labels, shipping and receiving, inventory tracking, warehousing, or retail tags and labels Suitable for printing on most uncoated and coated paper labels and tags Good print quality at speeds up to 254mm/sec (10ips) and 152mm/sec (6ips) for rotated barcodes",
    "imageUrl": "https://72gjvchc-7202.uks1.devtunnels.ms/Images/966d779e-c693-4abe-bbc3-325ecc71b48d/Zebra wax ribbon 110mm x 450m.jpg",
    "brand": "Zebra",
    "price": 6358.14,
    "quantity": 6
  }
]
```



