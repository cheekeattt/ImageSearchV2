# ImageSearchV2

## Overview
ImageSearchV2 is a .NET 6-based API service that provides a unified image search experience by integrating multiple image search providers such as Unsplash, PixaBay, and StoryBlocks. The API allows users to search for images based on keywords and returns consolidated results from all configured providers.

## Features
- Unified image search across multiple providers.
- Modular provider-based architecture.
- Easy-to-extend support for new image sources.
- AutoMapper integration for seamless data mapping.

## Prerequisites
- .NET 6 SDK
- Docker (optional, for containerized deployment)
- Valid API keys for the following providers:
  - Unsplash
  - PixaBay
  - StoryBlocks

## Installation

### Clone the Repository
```bash
git clone <repository-url>
cd ImageSearchV2
```

### Configure API Keys
Update the `appsettings.json` file with your API keys and other configurations:
```json
"Unsplash": {
  "AccessKey": "<your-unsplash-access-key>"
},
"PixaBay": {
  "ApiKey": "<your-pixabay-api-key>"
},
"StoryBlocks": {
  "PublicKey": "<your-storyblocks-public-key>",
  "PrivateKey": "<your-storyblocks-private-key>",
  "UrlPrefix": "https://api.graphicstock.com/api/v2/images/search"
}
```

### Build and Run the Project

#### Using .NET CLI
1. Restore dependencies:
   ```bash
   dotnet restore
   ```
2. Build the project:
   ```bash
   dotnet build
   ```
3. Run the application:
   ```bash
   dotnet run --project ImageSearchV2
   ```

#### Using Docker
1. Build the Docker image:
   ```bash
   docker build -t imagesearchv2:latest .
   ```
2. Tag the image for your Docker registry (if applicable):
   ```bash
   docker tag imagesearchv2:latest <your-registry>/imagesearchv2:latest
   ```
3. Push the image to your Docker registry (if applicable):
   ```bash
   docker push <your-registry>/imagesearchv2:latest
   ```
4. Run the container:
   ```bash
   docker run -p 8080:80 imagesearchv2:latest
   ```

## API Endpoints

### Search Images
**POST** `/api/imagesearch`

#### Request Body
```json
{
  "Keyword": "<search-keyword>"
}
```

#### Response
```json
[
  {
    "ImageID": "<image-id>",
    "Thumbnails": "<thumbnail-url>",
    "Preview": "<preview-url>",
    "Title": "<image-title>",
    "Source": "<source-provider>",
    "Tags": ["<tag1>", "<tag2>"]
  }
]
```

### GraphQL Endpoint
**POST** `/graphql`

GraphQL allows for flexible queries. You can define your own search parameters and structure for the response.

#### Example Query
```graphql
query {
  searchImages(keyword: "nature") {
    imageID
    title
    source
    thumbnails
  }
}
Response
json
Copy
Edit
{
  "data": {
    "searchImages": [
      {
        "imageID": "<image-id>",
        "title": "<image-title>",
        "source": "<source-provider>",
        "thumbnails": "<thumbnail-url>"
      }
    ]
  }
}
```

### Swagger UI
Swagger UI is integrated into the project to explore and test the API endpoints.

1. Navigate to `http://localhost:5018/swagger` (or the appropriate URL for your environment).
2. Explore the available API endpoints.
3. Test the API directly from the Swagger interface.

## Project Structure
```
ImageSearchV2/
├── Controllers/         # API Controllers
├── Interfaces/          # Abstractions for services and providers
├── Models/              # Request and Response models
├── Providers/           # Implementation of image source providers
├── Services/            # Core services and business logic
├── Helper/              # Utility classes
└── appsettings.json     # Configuration file
```

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes and push them to your fork.
4. Open a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

