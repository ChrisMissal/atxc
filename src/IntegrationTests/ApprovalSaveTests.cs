namespace IntegrationTests
{
    using System;
    using Core.Entities;
    using NHibernate;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using Shouldly;

    public class ApprovalSaveTests
    {
        private readonly ISession _session;
        private readonly Approval _approval;

        public ApprovalSaveTests(ISession session, ISpecimenBuilder fixture)
        {
            _session = session;
            var person = fixture.Create<Person>();
            _session.SaveOrUpdate(person);
            _approval = new Approval { Person = person };
            _session.SaveOrUpdate(_approval);
        }

        public void should_save_Approval()
        {
            var approval = _session.Get<Approval>(_approval.Id);
            approval.Slug.ShouldNotBe(Guid.Empty.ToString());
        }
    }
}
