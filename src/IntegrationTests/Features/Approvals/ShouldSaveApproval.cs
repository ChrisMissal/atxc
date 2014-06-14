namespace IntegrationTests.Features.Approvals
{
    using System;
    using Core.Entities;
    using NHibernate;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using Shouldly;

    public class ShouldSaveApproval
    {
        private readonly int _approvalId;

        public ShouldSaveApproval(ISession session, ISpecimenBuilder fixture)
        {
            var person = fixture.Create<Person>();
            session.SaveOrUpdate(person);
            var approval = new Approval { Person = person };
            session.SaveOrUpdate(approval);
            _approvalId = approval.Id;
        }

        public void Slug_should_not_be_empty_Guid_or_missing(ISession session)
        {
            var approval = session.Get<Approval>(_approvalId);
            approval.Slug.ShouldNotBeNullOrEmpty();
            approval.Slug.ShouldNotBe(Guid.Empty.ToString("n"));
        }
    }
}
