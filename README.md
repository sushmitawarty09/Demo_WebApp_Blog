# Demo Dev Blog Application
This is a full stack .NET application for creating Dev related blogs. This web app is built with the help of ASP.NET Core MVC and Entity Framework Core. This application has all CRUD operations being performed. The database connected is MS SQL Server.
We have following pages
- Home page - A welcome page. We have menu options here with which we can navigate to various other pages like adding blog posts, showing blog list or adding new tags or showing list of tags. 
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/e2e6880f-8d77-4caa-9707-9ec620c54f7d)

- Show all tags page - Tags are categories under which a blog can fall into. Tags can be used to search blogs or group of blogs which have same keywords.
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/d93cde12-f9a7-4e00-b333-c7a265301b0f)

- Add a new Tag page - here users can choose to add new Tags
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/d23311bb-808b-4692-a70e-91f157278ea0)

- Edit a Tag info page - Here user can edit an existing tag info like name or display name. User can also choose to delete the tag alltogether.
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/2ff38f99-6915-46f0-8a44-0fd9eae91cda)

- Add a new Blog post page - In this page, user can create a new blog with details like heading, page title, content - this uses a rich text editor using which we can format the blog content text. User can also add publish date using date calendar field and also add the existing created tags to the post.
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/12f813c0-ceab-4530-bc13-bf9299a49557)

- Show all Blogs page - list of all blogs that are created. We can also see the tags related to the blogs.
  ![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/4678a46f-08a7-4097-934e-febff77cda25)

- Finally, user can also Edit or delete a blog post.

The project code is divided into a clear model view controller pattern which helps with decoupling user-interface (view), data (model), and application logic (controller). 

All the classes directly corresponding to DB Tables like BlogPost, Tag etc are stored inside Domain folder.

We have Repositories folder - which uses repository pattern which mediates between domain and data mapping layers using a collection, like interface for accessing the domain objects. It acts like a middle layer between the rest of the application and data access logic. This makes us isolate all the data access code from the rest of the application. Advantage is that any changes to the data access code logic can be done at one place.

The web application is connected to MS SQL Server which has a BlogPostDB. It has 2 master data tables- BlogPost, Tags and a reference data table BlogPostTag - This table stores Id's of BlogPost and Tags in a 1..n relationship. i.e. one BlogPost to many Tags.
![image](https://github.com/sushmitawarty09/Demo_WebApp_Blog/assets/172192920/0ce73cd5-1911-4ba3-ab51-e32ab0804d01)


