using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain
{
    public interface IBreedService
    {
        Breed? GetBreed(Guid id);
    }

    public class FakeBreedService : IBreedService
    {
        public readonly List<Breed> breeds =
            [
                new Breed(Guid.NewGuid(), "Beagle", new WeightRange(10m,20m), new WeightRange(11m,18m)),
                new Breed(Guid.NewGuid(), "Staffordshire Terrier", new WeightRange(10m,20m), new WeightRange(11m,18m))
            ];

        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Breed is not valid");
            }

            Breed? result = breeds.Find(breed => breed.Id == id);

            return result ?? throw new ArgumentException("Breed was not found");
        }
    }
}
