using Animal_Health_System.BLL.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PregnancyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<PregnancyController> logger;

        public PregnancyController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PregnancyController> logger)
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
