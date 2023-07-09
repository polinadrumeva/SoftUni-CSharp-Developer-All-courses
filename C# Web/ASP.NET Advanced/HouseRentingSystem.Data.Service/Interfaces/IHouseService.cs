using HouseRentingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Service.Interfaces
{
	public interface IHouseService
	{
		Task<IEnumerable<IndexViewModel>> GetLastThreeHousesAsync();
	}
}
