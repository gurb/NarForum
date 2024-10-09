# NarForum Database Update

EF Core is used on the database side of the forum software. If you want to make any changes to the DB, you can learn how to do it with this documentation.

**NOTE** :  If you are considering making a critical change to the database, I strongly recommend that you backup your existing database beforehand.

Let's proceed with an example case. I did not add the fields required to store the PostCounter and HeadingCounter values of the users to the ForumUser table before. However, I need these fields now, so we need to update the existing database.

We make updates to the database code first. That is, we do not write SQL, we make the necessary changes using EF Core via C#. First, we need to open the **ForumUser** class that we will modify. The classes representing the database tables in the project are located in the **Domain** layer. However, The classes used for the Persistence layer are located there. The classes defined for the Identity layer are located in the Models folder in the Identity layer. The distinction here is made intentionally. The parts not related to Identity are defined as models in the Domain layer. As a result, the **ForumUser** table is in the **Models** folder in the **Identity** layer. Let's open that class and make the following additions:

```
public class ForumUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    ...
    public int PostCounter { get; set; }
    public int HeadingCounter { get; set; }
}
```

After adding the HeadingCounter and PostCounter fields, we need to create ef migrations:

* Open Package Manager Console on Visual Studio (View > Other Windows > Package Manager Console)
* Choose **Identity** as Default project
* Set **Api** as start up project
* enter this command
  * add-migration Id5 -c ForumIdentityDbContext
  * *(My last migration was [DATESTAMP]_Id4. So new migration name should be Id5)*
* After build succeeded, check your migration.
* Let's update local db in development environment:
* enter this command:
  * update-database -Context ForumIdentityDbContext
* Check your local database from **pgAdmin**. Look at your **db_forum_identity** database, find the table named **Users**. (Schemas > public > Tables > Users) Everything looks good, the update worked well on local db.
* Let's update our API on the server.

### Update API on Windows Server IIS

You can look publish options for the API from NarForum Software Installation Windows Server. Publish your API project and navigate the publish folder. You only need to copy the currently updated files to the server. There is no point in uploading files that are not updated to the server. (**IMPORTANT** But if you updated any nuget package especially EF Core packages on the API, Identity, Persistence or related project then you may encounter errors about package version when you run the api. So copy all files and replace with old files on the server as a solution. But just don't update appsettings.json file, and web.config file.)

* After copying the necessary files, save them in a temporary folder on the server for now.
* Stop api.domain-name.com on IIS Manager.
* Right-Click api.domain-name.com and click Explorer. (I recommend backup your all files in this folder before paste updated files in this folder)
* Paste updated files from temporary folder and paste **api.domain-name.com** folder.
* Start api.domain-name.com site on IIS Manager again.
* Check your db from pgAdmin on the server. View the _EFMigrationsHistory. The migration named **Id5** is applied successfully.
