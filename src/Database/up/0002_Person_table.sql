create table Person (
    PersonId INT not null,
   Slug NVARCHAR(255) not null,
   Name NVARCHAR(50) not null,
   Bio NVARCHAR(160) not null,
   Email NVARCHAR(255) not null,
   Location NVARCHAR(255) not null,
   Joined datetime2 null,
   Approved datetime2 null,
   Deleted datetime2 null,
   primary key (PersonId)
)
