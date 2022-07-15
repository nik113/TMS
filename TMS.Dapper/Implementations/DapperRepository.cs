using Dapper;
using TMS.Dapper.Interfaces;
using TMS.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Dapper.Implementations
{
    public class DapperRepository : IDapperRepository
    {
		private readonly IConfiguration _config;
		private string Connectionstring = "DefaultConnection";

		public DapperRepository(IConfiguration config)
		{
			_config = config;
		}
		public void Dispose()
		{

		}

		public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
		{
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
		}

		public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
		{
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			return db.Query<T>(sp, parms, commandType: commandType).ToList();
		}

		public DbConnection GetDbconnection()
		{
			return new SqlConnection(_config.GetConnectionString(Connectionstring));
		}
		public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
		{
			int result;
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			try
			{
				if (db.State == ConnectionState.Closed)
					db.Open();

				using var tran = db.BeginTransaction();
				try
				{
					result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
					tran.Commit();
				}
				catch (Exception ex)
				{
					tran.Rollback();
					throw ex;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (db.State == ConnectionState.Open)
					db.Close();
			}
			return result;
		}

		public int ExecuteReturnInt(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
		{
			int result;
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			try
			{
				if (db.State == ConnectionState.Closed)
					db.Open();

				using var tran = db.BeginTransaction();
				try
				{
					result = db.ExecuteScalar<int>(sp, parms, commandType: commandType, transaction: tran);
					tran.Commit();
				}
				catch (Exception ex)
				{
					tran.Rollback();
					throw ex;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (db.State == ConnectionState.Open)
					db.Close();
			}
			return result;
		}


		public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
		{
			T result;
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			try
			{
				if (db.State == ConnectionState.Closed)
					db.Open();

				using var tran = db.BeginTransaction();
				try
				{
					result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
					tran.Commit();
				}
				catch (Exception ex)
				{
					tran.Rollback();
					throw ex;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (db.State == ConnectionState.Open)
					db.Close();
			}

			return result;
		}

		public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
		{
			T result;
			using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
			try
			{
				if (db.State == ConnectionState.Closed)
					db.Open();

				using var tran = db.BeginTransaction();
				try
				{
					result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
					tran.Commit();
				}
				catch (Exception ex)
				{
					tran.Rollback();
					throw ex;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (db.State == ConnectionState.Open)
					db.Close();
			}

			return result;
		}
	}
}
