using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTIcketingSystem.DataAccess
{
	class EmployeeDataLogic
	{
		public DataTable GetEmployeeList()
		{
			DataTable dataTable = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
				{
					string query = $"SELECT [IsSystemGenerated],[IsActive],[EmployeeId],[FullName],[Contact],[Email],[RoleId],[UserName],[Password],[PasswordSalt],[IsApproved],[IsLockedOut],[CreateDate]" +
										$"FROM HrEmployee ORDER BY [EmployeeId] ASC";
					SqlCommand sqlcommand = new SqlCommand(query, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
					connection.Open();
					sqlDataAdapter.Fill(dataTable);
					connection.Close();
					return dataTable;
				}
			}

			catch (Exception ex)
			{


				throw ex;
			}
		}
		public bool AddEmployee(string employeeName, string contact, string email, string roleID, bool isActive, string username, string password, string passwordsalt, string date, bool isApproved, bool isLockedOut, bool isSystemGenerated)
		{
			using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
			{
				string query = $"INSERT INTO [dbo].[HrEmployee] ([FullName] ,[Contact] ,[Email] ,[RoleId] ,[UserName] ,[Password] ,[PasswordSalt] ,[CreateDate] ,[IsApproved] ,[IsLockedOut] ,[IsActive] ,[IsSystemGenerated])" +
							   $"VALUES" +
							   $"(@Name, @Number, @Email, @id, @username, @password, @passwordsalt, @date, @approved, @lockedout, @active, @systemgenerated)";
				SqlCommand sqlCommand = new SqlCommand(query, connection);
				sqlCommand.Parameters.AddWithValue("@Name", employeeName);
				sqlCommand.Parameters.AddWithValue("@Number", contact);
				sqlCommand.Parameters.AddWithValue("@Email", email);
				sqlCommand.Parameters.AddWithValue("@id", roleID);
				sqlCommand.Parameters.AddWithValue("@username", username);
				sqlCommand.Parameters.AddWithValue("@password", password);
				sqlCommand.Parameters.AddWithValue("@passwordsalt", passwordsalt);
				sqlCommand.Parameters.AddWithValue("@date", date);
				sqlCommand.Parameters.AddWithValue("@approved", isApproved);
				sqlCommand.Parameters.AddWithValue("@lockedout", isLockedOut);
				sqlCommand.Parameters.AddWithValue("@active", isActive);
				sqlCommand.Parameters.AddWithValue("@systemgenerated", isSystemGenerated);

				connection.Open();
				int rows = sqlCommand.ExecuteNonQuery();
				connection.Close();
				if (rows == 1)
				{
					return true;
				}
				else

				{
					return false;
				}
			}
		}

		public bool GetEmployeeInfo(int employeeId, out string employeeName, out string contact, out string email, out string roleID, out string username, out string password, out string passwordsalt,
			out string date, out bool isActive, out bool isSystemGenerated, out bool isApproved, out bool isLockedOut)
		{
			DataTable dataTable = new DataTable();
			try
			{
				using (SqlConnection sqlconnection = new SqlConnection(Helper.Helper.ConnectionString))
				{
					string query = $"Select [EmployeeId] ,[FullName] ,[Contact] ,[Email] ,[RoleId] ,[UserName] ,[Password] ,[PasswordSalt] ,[CreateDate] ,[IsApproved] ,[IsLockedOut] ," +
					$"[IsActive] ,[IsSystemGenerated] From [dbo].[Employee] Where EmployeeId = @employeeId";
					SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
					sqlcommand.Parameters.AddWithValue("@employeeId", employeeId);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
					sqlconnection.Open();
					sqlDataAdapter.Fill(dataTable);
					sqlconnection.Close();

					if (dataTable.Rows.Count == 1)
					{
						employeeName = dataTable.Rows[0]["FullName"].ToString();
						contact = dataTable.Rows[0]["Contact"].ToString();
						email = dataTable.Rows[0]["Email"].ToString();
						roleID = dataTable.Rows[0]["RoleId"].ToString();
						username = dataTable.Rows[0]["UserName"].ToString();
						password = dataTable.Rows[0]["Password"].ToString();
						passwordsalt = dataTable.Rows[0]["PasswordSalt"].ToString();
						date = dataTable.Rows[0]["CreateDate"].ToString();
						isActive = bool.Parse(dataTable.Rows[0]["IsActive"].ToString());
						isSystemGenerated = bool.Parse(dataTable.Rows[0]["IsSystemGenerated"].ToString());
						isApproved = bool.Parse(dataTable.Rows[0]["IsApproved"].ToString());
						isLockedOut = bool.Parse(dataTable.Rows[0]["IsLockedOut"].ToString());
						return true;
					}
					else
					{
						employeeName = string.Empty;
						contact = string.Empty;
						email = string.Empty;
						roleID = string.Empty;
						username = string.Empty;
						password = string.Empty;
						passwordsalt = string.Empty;
						date = string.Empty;
						isActive = false;
						isSystemGenerated = false;
						isApproved = false;
						isLockedOut = true;
						return false;
					}
				}
			}

			catch (Exception ex)
			{

				throw ex;
			}

		}
		public bool UpdateEmployee( int employeeid, string employeeName, string contact, string email, string roleID, bool isActive, string username, string password, string passwordsalt, string date, bool isApproved, bool isLockedOut, bool isSystemGenerated)
		{

			using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
			{
				string query =$"Update [dbo].[Employee] Set [FullName]=@Name ,[Contact]=@Number ,[Email]=@Email ,[RoleId]=@id ,[UserName]=@username ,[Password]=@password ,[PasswordSalt]=@passwordsalt ," +
					$"[CreateDate]=@date ,[IsApproved]=@approved ,[IsLockedOut]=@lockedout ,[IsActive]=@active ,[IsSystemGenerated]=@systemgenerated Where EmployeeId=@employeeId";

				SqlCommand sqlCommand = new SqlCommand(query, connection);
				sqlCommand.Parameters.AddWithValue("@Name", employeeName);
				sqlCommand.Parameters.AddWithValue("@Number", contact);
				sqlCommand.Parameters.AddWithValue("@Email", email);
				sqlCommand.Parameters.AddWithValue("@id", roleID);
				sqlCommand.Parameters.AddWithValue("@username", username);
				sqlCommand.Parameters.AddWithValue("@password", password);
				sqlCommand.Parameters.AddWithValue("@passwordsalt", passwordsalt);
				sqlCommand.Parameters.AddWithValue("@date", date);
				sqlCommand.Parameters.AddWithValue("@approved", isApproved);
				sqlCommand.Parameters.AddWithValue("@lockedout", isLockedOut);
				sqlCommand.Parameters.AddWithValue("@active", isActive);
				sqlCommand.Parameters.AddWithValue("@systemgenerated", isSystemGenerated);
				sqlCommand.Parameters.AddWithValue("@employeeId", employeeid);

				connection.Open();
				int rows = sqlCommand.ExecuteNonQuery();
				connection.Close();
				if (rows == 1)
				{
					return true;
				}
				else

				{
					return false;
				}
			}
		}
	}
}
