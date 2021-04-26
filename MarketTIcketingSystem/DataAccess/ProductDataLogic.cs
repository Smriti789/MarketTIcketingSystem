using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTIcketingSystem.DataAccess
{
    class ProductDataLogic
    {
		public DataTable GetProductList()
		{
			DataTable dataTable = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
				{
					string query = $"SELECT [ProjectId] ,[ProjectTitle] ,[ProjectDescription] ,[IsSystemGenerated] ,[IsActive]" +
										$"FROM Project ORDER BY [ProjectId] ASC";
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

		public bool AddProduct(string projectName, string projectDescription, bool isActive, bool isSystemGenerated)
		{
			using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
			{
				string query = $"INSERT INTO [dbo].[Project] ([IsSystemGenerated], [IsActive], [ProjectTitle], [ProjectDescription])" +
							   $"VALUES" +
							   $"(@IsSystemGenerated, @IsActive, @ProjectTitle, @ProjectDescription)";
				SqlCommand sqlCommand = new SqlCommand(query, connection);
				sqlCommand.Parameters.AddWithValue("@IsSystemGenerated", isSystemGenerated);
				sqlCommand.Parameters.AddWithValue("@IsActive", isActive);
				sqlCommand.Parameters.AddWithValue("@ProjectTitle", projectName);
				sqlCommand.Parameters.AddWithValue("@ProjectDescription", projectDescription);
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
		public bool GetProjectInfo(int projectId, out string projectName, out string projectDescription, out bool isActive, out bool isSystemGenerated)
		{

			DataTable dataTable = new DataTable();
			try
			{
				using (SqlConnection sqlconnection = new SqlConnection(Helper.Helper.ConnectionString))
				{
					string query = $"Select [ProjectId] ,[ProjectTitle] ,[ProjectDescription] ,[IsSystemGenerated] ,[IsActive] From [dbo].[Project] Where ProjectId = @projectId";
					SqlCommand sqlcommand = new SqlCommand(query, sqlconnection);
					sqlcommand.Parameters.AddWithValue("@projectId", projectId);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
					sqlconnection.Open();
					sqlDataAdapter.Fill(dataTable);
					sqlconnection.Close();

					if (dataTable.Rows.Count == 1)
					{
						projectName = dataTable.Rows[0]["ProjectTitle"].ToString();
						projectDescription = dataTable.Rows[0]["ProjectDescription"].ToString();
						isActive = bool.Parse(dataTable.Rows[0]["IsActive"].ToString());
						isSystemGenerated = bool.Parse(dataTable.Rows[0]["IsSystemGenerated"].ToString());
						return true;
					}
					else
					{
						projectName = string.Empty;
						projectDescription = string.Empty;
						isActive = false;
						isSystemGenerated = false;
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		public bool UpdateProject(int projectId, string projectName, string projectDescription, bool isActive, bool isSystemGenerated)
		{
			using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
			{
				string query = $"Update [dbo].[Project] Set [IsSystemGenerated]=@isSystemGenerated, [IsActive]=@isActive, [ProjectTitle]=@projectTitle, [ProjectDescription]=@projectDescription Where ProjectId=@projectId";

				/*string query = $"UPDATE [dbo].[Project] SET  [IsSystemGenerated], [IsActive], [ProjectTitle], [ProjectDescription]" +
							   $"VALUES" +
							   $"@IsSystemGenerated, @IsActive, @ProjectTitle, @ProjectDescription Where ProjectId=@projectID" ;
				*/
				SqlCommand sqlCommand = new SqlCommand(query, connection);
				sqlCommand.Parameters.AddWithValue("@isSystemGenerated", isSystemGenerated);
				sqlCommand.Parameters.AddWithValue("@isActive", isActive);
				sqlCommand.Parameters.AddWithValue("@projectTitle", projectName);
				sqlCommand.Parameters.AddWithValue("@projectDescription", projectDescription);
				sqlCommand.Parameters.AddWithValue("@projectId", projectId);
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
