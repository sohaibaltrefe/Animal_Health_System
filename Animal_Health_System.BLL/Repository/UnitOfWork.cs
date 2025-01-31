using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Microsoft.Extensions.Logging;
using System;

namespace Animal_Health_System.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly ILoggerFactory loggerFactory;

        public IAnimalRepository animalRepository { get; }
        public IVeterinarianRepository veterinarianRepository { get; }
        public IFarmRepository farmRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.loggerFactory = loggerFactory;

            // Corrected: Passing the required ILogger<T> to repositories
            animalRepository = new AnimalRepository(context, loggerFactory.CreateLogger<AnimalRepository>());
            veterinarianRepository = new VeterinarianRepository(context, loggerFactory.CreateLogger<VeterinarianRepository>());
            farmRepository = new FarmRepository(context );
        }
    }
}
