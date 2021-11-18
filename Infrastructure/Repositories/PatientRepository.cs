
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly IConfiguration configuration;

        public PatientRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        async Task<int> IBaseRepository<Patient>.AddAsync(Patient entity)
        {
            var sp = "Medications.uspCreatePatient";
            var param = new DynamicParameters();
            param.Add("@FirstName", entity.FirstName);
            param.Add("@LastName", entity.LastName);
            param.Add("@EmailAddress", entity.EmailAddress);
            param.Add("@Province", entity.ProvinceCode);


            param.Add("@PatientId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql: sp, param: param, commandType: CommandType.StoredProcedure);

                var retValue = param.Get<int>("@PatientId"); 
                if (retValue <= 0 )
                    throw new Exception($"There was an error creating the record. The return value is { retValue }.");

                return retValue;
            }
        }

        Task<int> IBaseRepository<Patient>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IReadOnlyList<Patient>> IBaseRepository<Patient>.GetAllAsync()
        {
            var sp = "Medications.uspGetPatients";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result =   await connection.QueryAsync<Patient>(sp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        async Task<IReadOnlyList<Patient>> IBaseRepository<Patient>.Search(string province, string medications)
        {
            var sp = "Medications.uspSearchPatientByProvinceMedication";
            var param = new DynamicParameters();
            param.Add("@Province", province);
            param.Add("@MedicationList", medications);

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Patient>(sql: sp, param: param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        async Task<Patient> IBaseRepository<Patient>.GetByIdAsync(int patientId)
        {
            var sp = "Medications.uspGetPatientById";
            var param = new DynamicParameters();
            param.Add("@PatientId", patientId);

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Patient>(sql: sp, param: param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        async Task<int> IBaseRepository<Patient>.UpdateAsync(int patientId)
        {
            var sp = "Medications.uspDeactivatePatient";
            var param = new DynamicParameters();    
            param.Add("@PatientId", patientId);

            param.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql: sp, param: param, commandType: CommandType.StoredProcedure);

                var retValue = param.Get<int>("@ReturnValue");
                if (retValue <= 0)
                    throw new Exception($"There was an error creating the record. The return value is { retValue }.");

                return retValue;
            }
        }

        async Task<int> IBaseRepository<Patient>.UpdateAsync(Patient entity)
        {
            var sp = "Medications.uspUpdatePatient";
            var param = new DynamicParameters();
            param.Add("@PatientId", entity.PatientId);
            param.Add("@FirstName", entity.FirstName);
            param.Add("@LastName", entity.LastName);
            param.Add("@EmailAddress", entity.EmailAddress);
            param.Add("@Province", entity.ProvinceCode);

            param.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql: sp, param: param, commandType: CommandType.StoredProcedure);

                var retValue = param.Get<int>("@ReturnValue");
                if (retValue <= 0)
                    throw new Exception($"There was an error creating the record. The return value is { retValue }.");

                return retValue;
            }
        }
    }
}
