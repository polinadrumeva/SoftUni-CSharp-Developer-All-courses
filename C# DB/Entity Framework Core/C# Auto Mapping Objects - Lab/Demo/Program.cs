using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Data.Models;
using Demo.DTOs;

namespace Demo
{
    public class Program
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            //Manual Mapping
            var employees = db.Employees.Select(e => new EmployeeDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,  
                MiddleName = e.MiddleName,
                DepartmentName = e.Department.Name,
                Salary = e.Salary
            }).ToList();
            

            //Auto Mapping
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

            var employeeDToAuto = db.Employees.ProjectTo<EmployeeDTO>(config).ToList();

            //Custom Mapping
            var configr = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()
                                .ForMember(d => d.FullName, e => e.MapFrom(op => $"{op.FirstName} {op.LastName}")));

            var employeeDToCustomAuto = db.Employees.ProjectTo<EmployeeDTO>(configr).ToList();
        }
    }
}