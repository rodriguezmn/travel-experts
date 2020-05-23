# Travel Experts Windows Application and Website developed using C# and ASP.NET
######################################################

## Irada Shamilova

### Backend:
#### Initial Set up of .NET Core Web Appication using Enterprise Framework
#### Created initial models using DB First Approach
#### Created MVC backend structure for Home, Packages & Customer Bookings Pages
#### Created new BookingsViewModel for Joint view of Bookings and Booking Details, so that we can filter this data by Customer ID 
#### Created BookingManager with public static method to GetAllBookingDetails
#### Created GetAllByBookingID, GetAllByCustomerID methods in the BookingManager to join Bookings & BookingDetails tables for new joint view.
#### Added GetUserName into BookingManager to convert userName from Login to UserName, so that we can greet users by First Name.
#### Wrote Booking Controller to GET joint View List (pulling information from Bookings and BookingDetails Models into new Joint Model)
#### Wrote PackageManager to GetAllPackages from DB and to GetAllCurrent Packages from DB based on current date
#### Wrote Packages Controller to GET Packages from DB to the Packages View
#### Added PackagesViewModel for Packages View.
#### Customer Profile edit functionality set up

### Frontend:
#### Added Modern look to NavBar using BootStrap styles
#### Added Parallax scrolling effect with Hero Image to shared Layout
#### Added all the text and design to Home Page
#### Added Animation to Home page elements for modern look
#### Added Animation effect with background images to create 3D revolving effect
#### Created Packages View with Animation effect to display only current packages with images in the card format using Bootstrap
#### Created Bookings View to filter Bookings by Customer ID 
#### Created Contact Page

### Azure hosting:
#### Created WebApp on Azure
#### Created SQL DB on Azure
#### Run Query to add DB data to Azure DB
#### Added Connection String to Azure and to TravelExpertsContext.cs file so that WebApp can talk to DB on Azure
#### Pushed the website and updates to Azure


######################################################

##  Karim Khan 

### Set up SQL DB and added user credentials to Agents and Customers table to serve <b>Registration</b> and <b>Login</b> pages

### Created <b>Registration</b> page to sign up new customers, added regular expressions and validation checks

### Created <b>Edit Customer Registration</b> page to allow customers to update their information

### Created CustomersController class to sign up new customers and update their information

### Supported in managing the Project along with Team members



######################################################

##  Lida Goldchteine

### Formatted tables added information to Views and Models

### Researched potential web hosting options

### Checked the requirenments have been met

### Tested modules and gave my feedback

### Built final presentation

######################################################

## Jacobus Badenhorst

### Built WPFApp_Cloud .NET Core App learning XAML and UI Design

### Configured App to be stand alone with no dependancies using API's for database interaction in the cloud

### Incorporated full CRUD functionality in with Packages, Products, and Suppliers requiring extensive debugging due to database and API Controller requirements

### UX : All required Validation functional as per project requirements (startDate < Enddate, Cost > Commission, ) as well as Agents Authentication functionality (API)


######################################################

### Marlon Rodriguez

### Log in & authentication:

### Created AccountController class to authenticate and authorize users

### Created Domain class to build an user domain object and get username and password from data context to authenticate users

### Created login partial view to modify navigation bar based on logged-in user (adding name of user and bookings link)

### Programmed method to get customer ID from database 

### Added javascript scripts to login and create account views to clear password input elements on page load

### Log out:

### Logged out users using AccountController

### Authorization:

##  Added authorization annotation for Bookings view

### Booking view and controller:

### Retreived and calculated booking total from bookings object and created table row to show the bookings total 

### Front-end design:

### Used bootstrap to make table, text headings and forms responsive for different viewport sizes 

### Added google maps links to contact page

### Added bootstap css flexbox classes to contact page to make addresses and maps responsive for diferent viewport dimensions

### Project Management: 

### Created github repository and added team members as collaborators

### Created Jira project and helped add and assing tasks in project backlog

### Created project folder on Microsoft OneDrive and added project files including daily standup meetings template, team mebers contacts, project procedures

### Instruct team memebers on how to work with visual studio & github integration
