using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public IAnimalRepository animalRepository { get; private set; }
        public IVeterinarianRepository veterinarianRepository { get; private set; }
        public IFarmRepository farmRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context,
                          ILogger<UnitOfWork> logger,
                          IAnimalRepository animalRepository,
                          IVeterinarianRepository veterinarianRepository,
                          IFarmRepository farmRepository)
        {
            _context = context;
            _logger = logger;

            // Inject repositories
            animalRepository = animalRepository;
            veterinarianRepository = veterinarianRepository;
            farmRepository = farmRepository;
        }

        // Commit changes to database
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
