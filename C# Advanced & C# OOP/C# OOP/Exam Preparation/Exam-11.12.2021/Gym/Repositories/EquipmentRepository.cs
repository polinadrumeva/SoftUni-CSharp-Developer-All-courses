namespace Gym.Repositories
{
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipmentRepository;
        public IReadOnlyCollection<IEquipment> Models { get { return (List<IEquipment>)equipmentRepository; } }

        public EquipmentRepository()
        {
            this.equipmentRepository = new List<IEquipment>();
        }
        public void Add(IEquipment model)
        {
           this.equipmentRepository.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment equipmentToFind = this.equipmentRepository.FirstOrDefault(e => e.GetType().Name == type);
            if (equipmentToFind != null)
            {
                return equipmentToFind;
            }

            return null;
        }

        public bool Remove(IEquipment model)
        {
            IEquipment equipmentToRemove = this.equipmentRepository.FirstOrDefault(e => e == model);
            if (equipmentToRemove != null)
            {
                this.equipmentRepository.Remove(equipmentToRemove);
                return true;

            }

            return false;   
        }
    }
}
