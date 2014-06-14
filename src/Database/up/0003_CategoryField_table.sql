create table CategoryField (
    [Value] NVARCHAR(255) not null,
    PersonId INT not null,
    TenantId UNIQUEIDENTIFIER not null,
    Created datetime2 not null,
    Deleted datetime2 null,
    primary key ([Value], PersonId),
    unique ([Value], PersonId)
)

alter table CategoryField 
    add constraint FK8AFAA992A008799E 
    foreign key (PersonId) 
    references Person
