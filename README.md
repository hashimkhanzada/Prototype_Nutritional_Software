# Introduction 
### Nz Food Files - Calorie Tracker

The purpose of this project is to provide users an application they can use to log their daily food intake and track calories.

# Description
1. Users can register and log in, microsoft identity is used to set up this system
2. There's an initial register page where user details are entered, those details are used to calculate the user's TDEE (total daily energy intake)
3. The dashboard contains information about the food the user has logged in, as well as the user's calorie/macro intake for that day.
4. The user can search for food intake data pertaining to a particular day using the calendar input provided below.
5. The user can display food data on the dashboard, the primary source of food data is from the official NzFoodFiles documents, which are automatically inserted when the database project is published. Users can select those food items, and display them.
6. The user can display custom food data on the dashboard. Custom food are items added by the user (all details are based on user input).
7. The user can manually set their caloric goal, which replaces the automatically calculated caloric goal on the dashboard.
8. Any day the user logs in, their caloric goal is set to what it was when the user last logged in. Allowing the user to keep their custom caloric goal as the default.

# Get Started

## Publish SQL Database
To run the project, the sql database needs to be published using a specific name.

1. Right-Click the sql project (DBFoodFiles)
2. Select Publish..
3. To the right of "Target database connection", click Edit --> Browse --> Local --> MSSQLLocalDB --> Click Ok
4. Under Database name, enter "LocalDBFoodFiles", click Publish

The SQL Database should be published now

## Migration

1. Tools --> NuGet Package Manager --> NuGet Package Manager Console
2. Type, EntityFrameworkCore\Update-Database
3. Press enter

You should now be able to use the application