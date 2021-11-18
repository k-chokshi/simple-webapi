
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using System.Data.SqlClient;
using Dapper;

namespace Infrastructure.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IConfiguration configuration;

        public ProvinceRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        Task<int> IBaseRepository<Province>.AddAsync(Province entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IBaseRepository<Province>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IReadOnlyList<Province>> IBaseRepository<Province>.GetAllAsync()
        {
            var sql = "SELECT * FROM Medications.Province";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Province>(sql);
                return result.ToList();
            }
        }

        Task<Province> IBaseRepository<Province>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Province>> IBaseRepository<Province>.Search(string parma1, string param2)
        {
            throw new NotImplementedException();
        }

        Task<int> IBaseRepository<Province>.UpdateAsync(Province entity)
        {
            throw new NotImplementedException();
        }
        Task<int> IBaseRepository<Province>.UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
