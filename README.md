# General presentation of the site

  The visual part of the site comes from a free template. For this, we integrated it into the project through boundles and other methods.
![image](https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/7050b1f7-9b31-4e97-9702-4e2f8560a300)

      Figure 1 - General presentation of the site
  Figure 1 shows the general layout of the site, which has at least 10 pages: registration, login, main page, villa page, villa details, contact, profile, search, comments, visit planning and management accessible only to the administrator. The main page has several layouts, integrating within itself a closer combination of the other pages.

# User registration and login

  Below, the functionality and structure of the login and registration pages, as well as the operation with the database, in this context, are presented.
  <p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/358d82de-4c91-4e37-bb08-6b8d9837419d">
</p>

       Figure 2 - The session table in the database
  The figure shown shows an SQL query that queries the sessions table of a database named [eUseControlVillaAgency2]. The query selects the first 1000 rows from the [Sessions] table and displays the following columns: SessionId, Username, CookieString, and ExpireTime.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/92ff6fc5-4f37-4e06-bfc1-3066c24949c8">
</p>
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/fc7afdeb-593d-43c5-b816-d7d4a43c4abd">
</p>

      Figure 3 - Registration page
  As shown in Figure 3 above, the registration page is a form with 4 fields. And after pressing REGISTER we can notice how a new user is added to the database.

<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/6cb3819d-26ef-4b63-a470-b8a7283005d8">
</p>
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/e89764ad-edcc-4538-a21c-5eb9417c8e84">
</p>

      Figure 4 – Login
Figure 4 shows the login process for a new user. If the login data is invalid, an error message will be displayed.

<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/c8db68fc-4fdd-452a-af20-88a62b7ab80c">
</p>
      
      Figure 5 – Logged user
  Once the user logs in, the section below the header will display their username and the functional logout option.

# Profile page
  Logged in users have access to the profile page.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/f6f393a6-b661-41ff-a94d-20c0091ed83b)">
</p>
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/0446ca8f-0cb7-47bd-8c3c-66c58c61c96e">
</p>

      Figure 6 - Profile page
  Figure 6 shows the default fields and image of a profile that the user fills out. Once the user presses UPDATE, the profile data is updated and saved in the database.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/29c85653-8116-48a8-b996-8377d36f40a1">
</p>
     
      Figure 7 - User profile table
  Figure 7 shows the user profile data.

# Property pages and their details
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/e2f7021c-75b3-4e83-9bab-d1536ee6f37a">
</p>
     
      Figure 8 - Property pages
  Figure 8 shows the villas page, each with visual and textual details.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/c520b5ce-8062-4904-b1ff-b8b47de1b3f1">
</p>

   
      Figure 9 - Properties details page
  Figure 9 shows how when you click on a property, you are redirected to the page with details about the given property.

# Contact and sorting pages
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/ec9c28f8-37d7-4ff5-919b-f306fe6ee551">
</p>
     
      Figure 10 – Contact page
Figure 10 shows the contact page, where users have the option to send messages to moderators.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/8e5f7f4e-037b-4079-8b5a-30886f24aa40">
</p>
    
      Figure 11 – Sorting page
  The sorting page offers only one sorting option: by category.

# Search pages
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/b5bb6af6-edf3-4c65-aad3-a8f5dc566c5a">
</p>
    
      Figure 12 - Search page
  The search page offers 3 search options: by name, by maximum and minimum price.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/c361b1c4-70fb-4966-b3f6-313ebae91187">
</p>
   
      Figure 13 - Results of search
  Figure 13 shows the result of searching for villas with the maximum price of 584500.

# Review pages
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/9f30ee2f-eb97-4a64-b775-7553d8e7c11a">
</p>
    
      Figure 14 – Review page
  Logged in users have the opportunity to leave a review, as well as exclusively delete their own review.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/7e5c9125-8cda-410e-87ac-a4a3390b44e4">
</p>

      Figure 15 – The review table

# Visit schedule page
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/a46d419a-5c09-484a-aba6-9e9dd7f2effc">
</p>
    
      Figure 16 – Visit schedule page
  Figure 16 shows the process of recording a visit.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/52781628-6c84-4ef0-96fa-51cce105bfda">
</p>
     
      Figure 17 – The planned visit
  Figure 17 shows the planned visit.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/428e6f0b-7909-4a0c-9cf1-1ed0856c4dbb">
</p>
    
      Figure 18 – The visits table

# Access filters
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/72244531-5e8e-486f-997b-123e4c4a5db3">
</p>
   
      Figure 19 – View administrator
  Figure 19 shows the visited site, with the administrator role. Additionally, we can see that a new page has appeared, which was not available to regular users: the Management page.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/e6132e7f-ac82-4797-a022-721af58e8f42">
</p>
   
      Figure 20 – Villa management
  On the management page you can see the implementation of all CRUD actions - creating, reading, updating and deleting villas.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/2cf557cd-4850-4f4b-be73-6ad156866988">
</p>
    
      Figure 21 – Table of villas

# Project structure
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/efcc948d-3205-4b24-b076-55d564f015f9">
</p>
     
      Figure 22 - Project levels
  As shown in the figure above, the project is divided into 4 levels: BusinessLogic, Domain, Helpers and PresentationLayer.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/3260ded3-5cb4-44a6-8c8a-c79be981b107">
</p>
    
      Figure 23 – Business Logic
  Business Logic is organized as follows: the Core map, the DBModels, where the context of the different entities is located, the Interfaces and classes such as SessionBL, BusinessLogic.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/143406895/ca6aff54-f669-4320-b67b-9e7786c72f82">
</p>
   
      Figure 24 – Domain
  Entities such as User, Villa are present at the Domain level and access roles are also illustrated.
<p align="center">
  <img src="https://github.com/mihaela-chiaburu/VillaAgency/assets/145832879/1836807f-b1ee-4c16-9804-f1302328a045">
</p>

      Figure 25 - Helpers
  The Helpers tier has helper classes for certain functions such as hashing
