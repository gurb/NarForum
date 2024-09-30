## scafollding database commands

- open package manager console
- choose Persistence as Default Project
- set api as start up project
- "add-migration InitialMigration" enter command
- "Update-Database" enter command

# example
> add-migration Forum11 -c ForumDbContext
> update-database -Context ForumDbContext

> add-migration Id3 -c ForumIdentityDbContext
> update-database -Context ForumIdentityDbContext

> remove-migration -c ForumIdentityDbContext