create table LinkField (
    [Value] NVARCHAR(255) not null,
   PersonId INT not null,
   Created datetime2 not null,
   Deleted datetime2 null,
   primary key ([Value]),
  unique ([Value], PersonId)
)

alter table LinkField 
    add constraint FK3D8080F2A008799E 
    foreign key (PersonId) 
    references Person
