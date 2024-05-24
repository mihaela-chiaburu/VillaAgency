# General presentation of the site
The visual part of the site comes from a free template. For this, we integrated it into the project through boundles and other methods.
![image](https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/7050b1f7-9b31-4e97-9702-4e2f8560a300)
Figure 1 - General presentation of the site
  Figure 1 shows the general layout of the site, which has at least 10 pages: registration, login, main page, villa page, villa details, contact, profile, search, comments, visit planning and management accessible only to the administrator. The main page has several layouts, integrating within itself a closer combination of the other pages.

# User registration and login
  Below, the functionality and structure of the login and registration pages, as well as the operation with the database, in this context, are presented.

Figure 2 - The session table in the database
  The figure shown shows an SQL query that queries the sessions table of a database named [eUseControlVillaAgency2]. The query selects the first 1000 rows from the [Sessions] table and displays the following columns: SessionId, Username, CookieString, and ExpireTime.



Figure 3 - Registration page
  As shown in Figure 3 above, the registration page is a form with 4 fields. And after pressing REGISTER we can notice how a new user is added to the database.

Figure 4 – Login
  Figure 4 shows the login process for a new user. If the login data is invalid, an error message will be displayed.

Figure 5 – Logged user
  Once the user logs in, the section below the header will display their username and the functional logout option.





# Profile page
  Logged in users have access to the profile page.

Figure 6 - General presentation of the site
Figure 6 shows the default fields and image of a profile that the user fills out. Once the user presses UPDATE, the profile data is updated and saved in the database.

Figure 7 - User profile table
  Figure 7 shows the user profile data.


# Property pages and their details

Figure 8 - Property pages
  Figure 8 shows the villas page, each with visual and textual details.

Figure 9 - Properties details page
  Figure 9 shows how when you click on a property, you are redirected to the page with details about the given property.




# Contact and sorting pages

Figure 10 – Contact page
Figure 10 shows the contact page, where users have the option to send messages to moderators.

Figure 11 – Sorting page
  The sorting page offers only one sorting option: by category.





# Search pages

Figure 12 - General presentation of the site
  The search page offers 3 search options: by name, by maximum and minimum price.

Figure 13 - General presentation of the site
  Figure 13 shows the result of searching for villas with the maximum price of 584500.

# Review pages

Figure 14 – Review page
  Logged in users have the opportunity to leave a review, as well as exclusively delete their own review.

Figure 15 – The review table

# Visit schedule page
Figure 16 – Visit schedule page
  Figure 16 shows the process of recording a visit.


Figure 17 – The planned visit
  Figure 17 shows the planned visit.

Figure 18 – The visits table




# Access filters

Figure 19 – View administrator
  Figure 19 shows the visited site, with the administrator role. Additionally, we can see that a new page has appeared, which was not available to regular users: the Management page.


Figure 20 – Villa management
  On the management page you can see the implementation of all CRUD actions - creating, reading, updating and deleting villas.

Figure 21 – Table of villas




# Project structure

Figure 22 - Project levels
  As shown in the figure above, the project is divided into 4 levels: BusinessLogic, Domain, Helpers and PresentationLayer.

Figure 23 – Business Logic
  Business Logic is organized as follows: the Core map, the DBModels, where the context of the different entities is located, the Interfaces and classes such as SessionBL, BusinessLogic.

Figure 24 – Domain
  Entities such as User, Villa are present at the Domain level and access roles are also illustrated.

Figure 25 - Helpers
  The Helpers tier has helper classes for certain functions such as hashing
