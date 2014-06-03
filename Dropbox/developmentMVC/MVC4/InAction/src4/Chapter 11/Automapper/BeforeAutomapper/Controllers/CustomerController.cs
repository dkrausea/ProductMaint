using System.Web.Mvc;
using Core;

namespace BeforeAutomapper.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerRepository _repository;

        public CustomerController()
            : this(new CustomerRepository()) {}

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            var customers = _repository.GetAll();
            return View(customers);
        }

        public ViewResult Show(int id)
        {
            var customer = _repository.GetById(id);
            return View(customer);
        }
    }
}