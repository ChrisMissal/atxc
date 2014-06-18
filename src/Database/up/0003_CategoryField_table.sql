create table CategoryField (
    CategoryFieldId INT not null,
    PersonId INT not null,
    TenantId UNIQUEIDENTIFIER not null,
    [Value] NVARCHAR(255) null,
    Created datetime2 not null,
    primary key (CategoryFieldId),
    unique (PersonId, [Value])
)

alter table CategoryField 
    add constraint FK8AFAA992A008799E 
    foreign key (PersonId) 
    references Person
