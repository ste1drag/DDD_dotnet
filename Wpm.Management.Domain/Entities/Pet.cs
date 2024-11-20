using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities
{
    public class Pet : Entity
    {
        #region Properties
        public string Name { get; init; }
        public int Age { get; init; }
        public string Color { get; init; }
        public Weight Weight { get; private set; }
        public WeightClass WeightClass { get; private set; }
        public SexOfPet SexOfPet { get; init; }
        public BreedId BreedId { get; init; }
        #endregion

        #region Constructors
        
        public Pet(Guid id, string name, int age, string color, SexOfPet sexOfPet, BreedId breedId)
        {
            Id = id;
            Name = name;
            Age = age;
            Color = color;
            SexOfPet = sexOfPet;
            BreedId = breedId;
        }

        #endregion

        #region Methods
        public void SetWeight(Weight weight, IBreedService breedService)
        {
            Weight = weight;
            SetWeightClass(breedService);
        }
        public void SetWeightClass(IBreedService breedService)
        {
            Breed? desiredBreed = breedService.GetBreed(BreedId.Value);

            if(desiredBreed == null)
            {
                throw new Exception("Breed does not exist");
            }

            var (from, to) = SexOfPet switch
            {
                SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
                SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
                _ => throw new NotImplementedException()
            };

            WeightClass = Weight.Value switch
            {
                _ when Weight.Value < from => WeightClass.Underweight,
                _ when Weight.Value > to => WeightClass.Overweight,
                _ => WeightClass.Ideal
            };
        }

        #endregion
    }

    public enum SexOfPet
    {
        Male,
        Female
    }

    public enum WeightClass
    {
        Unknown,
        Ideal,
        Underweight,
        Overweight
    }
}
