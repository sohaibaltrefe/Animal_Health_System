using Animal_Health_System.BLL.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductionRecordController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ProductionRecordController> logger;

        public ProductionRecordController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductionRecordController> logger)
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
