using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extetions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<Customer> Search(this IQueryable<Customer> customers, string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return customers;

            var lowerCaseSearchTerm = SearchTerm.Trim().ToLower();

            return customers.Where(c => c.Givenname.ToLower().Contains(lowerCaseSearchTerm));

        }


    }
}
