# TapNews README

Welcome to the TapNews repository! TapNews is a [brief description of your project] built using the .NET framework.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Postman](https://www.postman.com/) installed (optional for testing)

### Installation

1. Clone the repository to your local machine.
   ```bash
   git clone https://github.com/MandealValeriuCristian/TapNews.git
2. Navigate to the project directory.
   ```bash
   cd TapNews
3. Modify the database connection string in the appsettings.json file.
   ```bash
   "ConnectionStrings": {
    "DefaultConnection": "Data Source=Your=PC-username\\SQLEXPRESS; Initial Catalog=tapnews; Integrated Security=true; TrustServerCertificate=True"
   }
4. Running the API and seed data from `API/Data/CategoriesSeedData.json`
   ```bash
   dotnet watch --no-hot-reload
5. Testing with Postman

If you have Postman installed, you can import the provided Postman collection for testing. The collection is located in the postman directory.

  1. Open Postman.
  2. Click on "Import" in the top-left corner.
  3. Choose the provided Postman collection file: TapNews/postman/TapNews.postman_collection.json.

Now, you can use the imported collection to test the API endpoints.
