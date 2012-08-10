namespace WebSample.UI.Controllers
{
    using System.Web.Mvc;

    [TransactionFilter]
    public abstract class TransactionalController : Controller
    {
    }
}