create table Approval (
    ApprovalId INT not null,
    TenantId UNIQUEIDENTIFIER not null,
    Slug NVARCHAR(255) not null,
    PersonId INT not null,
    Deleted datetime2 null,
    primary key (ApprovalId)
)