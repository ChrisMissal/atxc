create table LinkField (
    LinkFieldId INT not null,
    PersonId INT not null,
    TenantId UNIQUEIDENTIFIER not null,
    [Value] NVARCHAR(255) null,
    Created datetime2 not null,
    primary key (LinkFieldId),
    unique (PersonId, [Value])
)

alter table LinkField 
    add constraint FK3D8080F2A008799E 
    foreign key (PersonId) 
    references Person
