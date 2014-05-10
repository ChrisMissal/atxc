namespace UI.Transactions
{
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Microsoft.Practices.ServiceLocation;
    using NHibernate;

    public class TransactionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var session = ServiceLocator.Current.GetInstance<ISession>();
            session.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var session = ServiceLocator.Current.GetInstance<ISession>();
            if (session == null)
                return;

            var transaction = session.Transaction;
            if (!transaction.IsActive)
                return;

            if (actionExecutedContext.Exception != null)
                transaction.Rollback();
            else
                transaction.Commit();
        }
    }
}