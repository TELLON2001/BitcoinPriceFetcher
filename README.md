# Bitcoin Price Fetcher

Bitcoin Price Fetcher is a web platform that fetches Bitcoin (BTC/USD) prices from multiple sources and provides them through a RESTful API. This README provides an overview of the project, its features, setup instructions, and usage with Postman.

## Features

- **Fetch Bitcoin Price**: Retrieves the current Bitcoin price (BTC/USD) from supported sources.
- **Store Price**: Stores fetched Bitcoin prices in an in-memory database.
- **Retrieve Price History**: Retrieves historical Bitcoin prices from the in-memory database.

## Technologies Used

- **Language**: C# (.NET 8)
- **Framework**: ASP.NET Core
- **Datastore**: In-memory database (SQLite)
- **API Testing**: Postman

## Project Structure

The project is structured as follows:

- **Controllers**: Handle incoming HTTP requests and produce responses.
- **Services**: Implement business logic for fetching and storing Bitcoin prices.
- **Data**: Includes data models and interfaces for interacting with the datastore.

## API Endpoints

### Get Supported Sources

- **GET /api/bitcoinprice/sources**

  Returns a list of all available Bitcoin price sources.

### Fetch Bitcoin Price

- **GET /api/bitcoinprice/{source}**

  Fetches the current Bitcoin price from the specified source.

### Retrieve Price History

- **GET /api/bitcoinprice/history/{source}**

  Retrieves historical Bitcoin prices that were stored in the datastore for the specified source.

## Setup Instructions

To run the project locally and interact with it using Postman, follow these steps:

1. **Clone the repository:**

   ```bash
   git clone https://github.com/TELLON2001/BitcoinPriceFetcher.git
   cd BitcoinPriceFetcher
   ```

2. **Restore dependencies and build the project:**

   ```bash
   dotnet restore
   dotnet build
   ```

3. **Run the application:**

   ```bash
   dotnet run
   ```

4. **Access the API using Postman:**

   - Open Postman and import the provided collection file (`BitcoinPriceFetcher.postman_collection.json`).
   - Use the collection to send requests to the API endpoints (`GET /api/bitcoinprice/sources`, `GET /api/bitcoinprice/{source}`, `GET /api/bitcoinprice/history/{source}`).
   - Replace `{source}` with actual source names from the response of `GET /api/bitcoinprice/sources`.

## Future Improvements

- **Add More Price Sources**: Expand the application to fetch Bitcoin prices from additional sources.
- **Implement Persistent Storage**: Replace the in-memory database with a persistent storage solution like PostgreSQL or MySQL.
- **Enhance Error Handling**: Improve error handling and resilience against network failures or data retrieval issues.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please fork the repository and submit a pull request with your proposed changes.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
