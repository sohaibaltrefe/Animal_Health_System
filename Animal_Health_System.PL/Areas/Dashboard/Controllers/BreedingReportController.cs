using Animal_Health_System.BLL.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    public class BreedingReportController : Controller
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<BreedingReportController> logger;

        public BreedingReportController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BreedingReportController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
