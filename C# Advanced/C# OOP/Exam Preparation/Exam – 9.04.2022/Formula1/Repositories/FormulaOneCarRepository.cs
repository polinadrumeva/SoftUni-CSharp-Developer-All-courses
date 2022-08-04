using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models { get { return (List<IFormulaOneCar>)models; } }

        private FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar carToFind = this.models.FirstOrDefault(c => c.Model == name);
            if (carToFind != null)
            {
                return carToFind;
            }

            return null;
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
