# InlandMarinaMVC
Work flow of assignment:
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
csharp
Copy code
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
csharp
Copy code
builder.Services.AddDbContext<InlandMarinaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InlandMarinaDatabase")));
•	MVC folder structure was set up automatically:
o	Controllers: For managing application logic.
o	Views: For Razor pages that render the UI.
o	wwwroot: For static assets (CSS, JavaScript, and images).
________________________________________
3. Dependency Injection and Controller Logic
•	Implemented Dependency Injection (DI) for accessing the database:
o	Injected InlandMarinaContext into each controller using constructor injection.
o	Example:
csharp
Copy code
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
•	Used strongly-typed models in Razor views:
o	Passed data like IEnumerable<Slip> from controllers to views.
o	Example in Index.cshtml for slips:
html
Copy code
@model IEnumerable<InlandMarinaData.Slip>

<h1>Available Slips</h1>
<table class="table table-striped table-bordered">
    <thead>
        <tr>
            <th>Slip ID</th>
            <th>Width</th>
            <th>Length</th>
            <th>Dock Name</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var slip in Model)
        {
            <tr>
                <td>@slip.ID</td>
                <td>@slip.Width</td>
                <td>@slip.Length</td>
                <td>@slip.Dock.Name</td>
            </tr>
        }
    </tbody>
</table>
________________________________________
5. Filtering Logic
•	Added a dropdown on the Available Slips page to filter slips by dock.
•	Populated the dropdown using ViewBag in the SlipsController:
csharp
Copy code
ViewBag.Docks = _context.Docks.ToList();
•	Implemented the Filter action:
o	Allows users to select a dock and filter slips.
o	The action reuses the Index view for displaying results:
csharp
Copy code
public IActionResult Filter(int dockId)
{
    var slips = _context.Slips
        .Where(s => s.DockID == dockId && !s.Leases.Any())
        .ToList();

    ViewBag.Docks = _context.Docks.ToList();
    ViewBag.SelectedDockId = dockId;
    return View("Index", slips);
}
________________________________________
6. Styling with CSS and Bootstrap
•	Integrated Bootstrap for responsive design via a CDN.
•	Customized styles using site.css:
o	Styled buttons, tables, navigation, and the footer.
o	Enhanced readability of tables with striped rows and hover effects.
o	Centered homepage content using Flexbox.
o	Example for buttons:
css
Copy code
.btn-primary {
    background-color: #0056b3;
    border-color: #004080;
}
.btn-primary:hover {
    background-color: #004080;
}
________________________________________
7. Navigation and Shared Layout
•	Updated _Layout.cshtml for consistent navigation and footer:
o	Included links to the Home, Contact, and Available Slips pages.
o	Example:
html
Copy code
<nav class="navbar navbar-expand-sm">
    <a class="navbar-brand" asp-controller="Home" asp-action="Index">Inland Marina</a>
    <ul class="navbar-nav">
        <li class="nav-item"><a class="nav-link" asp-controller="Home" asp-action="Index">Home</a></li>
        <li class="nav-item"><a class="nav-link" asp-controller="Home" asp-action="Contact">Contact</a></li>
        <li class="nav-item"><a class="nav-link" asp-controller="Slips" asp-action="Index">Available Slips</a></li>
    </ul>
</nav>
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

