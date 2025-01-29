using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        public IAnimalRepository animalRepository { get; }
        public  IVeterinarianRepository veterinarianRepository { get; }
        public IFarmRepository farmRepository { get; }
    }
}
