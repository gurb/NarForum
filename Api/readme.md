## scafollding database commands

- open package manager console
- choose Persistence as Default Project
- set api as start up project
- "add-migration InitialMigration" enter command
- "Update-Database" enter command

# example
> add-migration Forum2 -c ForumDbContext
> update-database -Context ForumDbContext

> add-migration Id1 -c ForumIdentityDbContext
> update-database -Context ForumIdentityDbContext

> remove-migration -c ForumIdentityDbContext