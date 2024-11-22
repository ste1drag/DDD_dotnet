using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Entities
{
    public class Breed : Entity
    {
        #region Properties
        public string Name { get; init; }
        public WeightRange MaleIdealWeight { get; init; }
        public WeightRange FemaleIdealWeight { get; init; }
        #endregion

        #region Constructors
        public Breed(Guid id, string name, WeightRange maleIdealWeight, WeightRange femaleIdealWeightRange)
        {
            Id = id;
            Name = name;
            MaleIdealWeight = maleIdealWeight;
            FemaleIdealWeight = femaleIdealWeightRange;
        }
        #endregion
    }
}
