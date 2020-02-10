using Microsoft.AspNetCore.Mvc.Filters;

namespace XlsToEf.Core.Example.Infrastructure
{
    public class UnitOfWork : ActionFilterAttribute
    {
        private readonly XlsToEfDbContext _xlsToEfDbContext;

        UnitOfWork(XlsToEfDbContext xlsToEfDbContext)
        {
            _xlsToEfDbContext = xlsToEfDbContext;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _xlsToEfDbContext.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _xlsToEfDbContext.CloseTransaction(filterContext.Exception);
        }
    }
}