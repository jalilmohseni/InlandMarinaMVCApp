# InlandMarinaMVC
1. Setting Up the Database
•	Created the database using Entity Framework Core and added the following tables:
o	Customers
o	Docks
o	Slips
o	Leases
•	Defined entities as classes in the InlandMarinaData class library:
o	Represented each table with DbSet properties in the InlandMarinaContext class.
o	Seeded initial data for docks, slips, and leases in the OnModelCreating method.
•	Created the SlipsdbManager class:
o	Centralized CRUD operations for the Slips table.
o	Simplified logic for querying unleased slips.

•	Installed required NuGet packages:
o	Microsoft.EntityFrameworkCore.Tools
o	Microsoft.EntityFrameworkCore.SqlServer
•	Configured SQL Server connection in InlandMarinaContext:
optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                              Database=InlandMarina;
                              Trusted_Connection=True;
                              Encrypt=False;");
•	Applied database changes using EF Core migrations:
o	Ran Add-Migration to create migration files.
o	Ran Update-Database to apply the migrations and generate the database.
________________________________________
2. Creating the ASP.NET Core MVC Project
•	Created a new ASP.NET Core MVC project named InlandMarinaMVC.
•	Registered InlandMarinaContext in Program.cs for Dependency Injection (DI):
builder.Services.AddDbContext<InlandMarinaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InlandMarinaDatabase")));
•	MVC folder structure set up (automatically):
o	Controllers: For managing application logic.
o	Views: For Razor pages that render the UI.
o	wwwroot: For static assets (CSS, JavaScript, and images).
________________________________________
3. Dependency Injection and Controller Logic
•	Implemented Dependency Injection (DI) for accessing the database:
o	Injected InlandMarinaContext into each controller using constructor injection.
public SlipsController(InlandMarinaContext context)
{
    _context = context; // Dependency injection for database context
}
•	Created two controllers:
1.	HomeController:
	Manages the Home and Contact pages.
	Actions:
	Index: Displays a welcome message and navigation links.
	Contact: Displays marina contact details.
2.	SlipsController:
	Manages available slips and filtering functionality.
	Actions:
	Index: Fetches and displays unleased slips from the database.
	Filter: Filters slips by dock ID using LINQ.
________________________________________
4. Razor Views for Pages
•	Created Razor views for each action:
1.	Home Views:
	Index.cshtml: Displays a welcome message, a short description, and buttons to navigate to other pages.
	Contact.cshtml: Displays contact details for the marina.
2.	Slips Views:
	Index.cshtml: Displays a table of available slips and a dropdown to filter slips by dock.
________________________________________
5. Filtering Logic
•	Added a dropdown on the Available Slips page to filter slips by dock.
•	Populated the dropdown using ViewBag in the SlipsController:
ViewBag.Docks = _context.Docks.ToList();
•	Implemented the Filter action:
o	Allows users to select a dock and filter slips.The action reuses the Index view for displaying results:
________________________________________
6. Styling with CSS and Bootstrap
•	Integrated Bootstrap for responsive design via a CDN.
•	Customized styles using site.css:
________________________________________
7. Navigation and Shared Layout
•	Updated _Layout.cshtml for consistent navigation and footer:
o	Included links to the Home, Contact, and Available Slips pages.
________________________________________
Key Features of the Application
1.	Dynamic Data Retrieval:
o	Retrieves and displays slips and docks data from the database using EF Core.
2.	Filtering Functionality:
o	Users can filter slips by dock via a dropdown menu.
3.	Responsive Design:
o	Fully responsive design using Bootstrap.
4.	Reusable Layout:
o	Shared _Layout.cshtml ensures consistent design across all pages.
5.	Custom Styling:
o	Tailored CSS improves usability and enhances the user experience.
