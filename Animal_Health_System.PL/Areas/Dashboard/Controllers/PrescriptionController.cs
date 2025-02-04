using Animal_Health_System.BLL.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PrescriptionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<PrescriptionController> logger;

        public PrescriptionController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PrescriptionController> logger)
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
