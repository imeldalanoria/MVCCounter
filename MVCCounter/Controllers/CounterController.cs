using MVCCounter.DAL;
using MVCCounter.Models;
using MVCCounter.Service;
using System.Linq;
using System.Web.Mvc;

namespace MVCCounter.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;

        public CounterController()
        {
            _counterService = new CounterService();
        }
        public ActionResult Index()
        {
            var count = _counterService.GetAll().FirstOrDefault();

            if (count==null)
            {
                _counterService.Add(new Count { CountNo = 1 });
                count = _counterService.GetAll().FirstOrDefault();
            }

            return View(ConvertToModel(count));
        }

        [HttpPost]
        public ActionResult Index(CountModel countModel)
        {
            ModelState.Clear();

            if (countModel.CountNo <10)
            {
                countModel.CountNo++;
                _counterService.Update(ConvertToEntity(countModel));
            }
            else
            {
                ModelState.AddModelError("CountNo", "Already reached the maximum number.");
            }
            return View(countModel);
        }

        private Count ConvertToEntity(CountModel model)
        {
            Count count = new Count();
            count.Id = model.Id;
            count.CountNo = model.CountNo;
            return count;
        }
        private CountModel ConvertToModel(Count countTable)
        {
            CountModel countModel = new CountModel();
            countModel.Id = countTable.Id;
            countModel.CountNo = countTable.CountNo;
            return countModel;
        }

    }
}