# The Chosen Blogger

Welcome to The Chosen Blogger, a simple blogging web app designed for practicing Onion Architecture. This application utilizes Razor Pages as the Application Framework in the Presentation Layer and EF Core as the ORM.

## Features

- Create articles in specific categories
- Read articles and share comments
- Admin panel for comment moderation, article, and category management

## Installation

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine
- [Entity Framework Core tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) for managing database migrations

### Getting Started

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/your-repository.git
   ```

2. Navigate to the project directory:

   ```bash
   cd TheChosenBlogger
   ```

3. Update EF Core database:

   ```bash
   dotnet ef database update
   ```

   This command will apply any pending migrations and update the database schema according to your model changes.

4. Run the application:

   ```bash
   dotnet run
   ```

   Visit `https://localhost:5001` in your browser to access the application.

## Contributing

Contributions are welcome! Feel free to submit pull requests or open issues for any suggestions or improvements.

## License

This project is licensed under the [MIT License](LICENSE).
