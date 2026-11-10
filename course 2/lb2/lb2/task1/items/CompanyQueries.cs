using lb2.task1.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb2.task1.items
{
    internal class CompanyQueries
    {
        private List<Company> companies;

        public CompanyQueries(List<Company> companies)
        {
            this.companies = companies;
        }

        public List<Company> GetAll()
        {
            return companies;
        }

        public List<Company> GetFoodCompanies()
        {
            return companies.Where(c => c.Name.Contains("Food")).ToList();
        }

        public List<Company> GetMarketingCompanies()
        {
            return companies.Where(c => c.BusinessProfile == "Маркетинг").ToList();
        }

        public List<Company> GetMarketingOrITCompanies()
        {
            return companies.Where(c => c.BusinessProfile == "Маркетинг" || c.BusinessProfile == "IT").ToList();
        }

        public List<Company> GetCompaniesWithMoreThan100Employees()
        {
            return companies.Where(c => c.EmployeesCount > 100).ToList();
        }

        public List<Company> GetCompaniesWith100To300Employees()
        {
            return companies.Where(c => c.EmployeesCount >= 100 && c.EmployeesCount <= 300).ToList();
        }

        public List<Company> GetLondonCompanies()
        {
            return companies.Where(c => c.Address.Contains("London")).ToList();
        }

        public List<Company> GetCompaniesWithWhiteDirector()
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last() == "White").ToList();
        }

        public List<Company> GetCompaniesOlderThanTwoYears()
        {
            return companies.Where(c =>  c.FoundationDate < DateTime.Now.AddYears(-2)).ToList();
        }

        public List<Company> GetCompaniesOlderThan150Days()
        {
            return companies.Where(c => c.FoundationDate < DateTime.Now.AddDays(-150)).ToList();
        }

        public List<Company> GetBlackDirectorAndWhiteName()
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last() == "Black" && c.Name.Contains("White")).ToList();
        }
    }
}
