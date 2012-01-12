//===============================================================================
// OracleHelper based on Microsoft Data Access Application Block (DAAB) for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//
// OracleHelper.cs
//
// This file contains the implementations of the OracleHelper and OracleHelperParameterCache
// classes.
//
// The DAAB for MS .NET Provider for Oracle has been tested in the context of this Nile implementation,
// but has not undergone the generic functional testing that the SQL version has gone through.
// You can use it in other .NET applications using Oracle databases.  For complete docs explaining how to use
// and how it's built go to the originl appblock link. 
// For this sample, the displayName resides in the Nile namespaces not the Microsoft.ApplicationBlocks namespace
//==============================================================================

using System;
using System.Data;
using System.Xml;
using System.Collections;
using Oracle.DataAccess.Client;

namespace CodeBuilder.DataSource.Exporter
{
	/// <summary>
	/// The OracleHelper class is intended to encapsulate high performance, scalable best practices for 
	/// common uses of OracleClient.
	/// </summary>
	public sealed class OracleHelper
	{
		#region private utility methods & constructors

		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new OracleHelper()".
		private OracleHelper() {}

		/// <summary>
		/// This method is used to attach array's of OracleParameters to an OracleCommand.
		/// 
		/// This method will assign a value of DbNull to any parameter with a direction of
		/// InputOutput and a value of null.  
		/// 
		/// This behavior will prevent default values from being used, but
		/// this will be the less common case than an intended pure output parameter (derived as InputOutput)
		/// where the user provided no input value.
		/// </summary>
		/// <param displayName="command">The command to which the parameters will be added</param>
		/// <param displayName="commandParameters">an array of OracleParameters tho be added to command</param>
		private static void AttachParameters(OracleCommand command, OracleParameter[] commandParameters)
		{
			foreach (OracleParameter p in commandParameters)
			{
				//check for derived output value with no value assigned
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}
				
				command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// This method assigns an array of values to an array of OracleParameters.
		/// </summary>
		/// <param displayName="commandParameters">array of OracleParameters to be assigned values</param>
		/// <param displayName="parameterValues">array of objects holding the values to be assigned</param>
		private static void AssignParameterValues(OracleParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null)) 
			{
				//do nothing if we get no data
				return;
			}

			// we must have the same number of values as we pave parameters to put them in
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			//iterate through the OracleParameters, assigning the values from the corresponding position in the 
			//value array
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				commandParameters[i].Value = parameterValues[i];
			}
		}

		/// <summary>
		/// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
		/// to the provided command.
		/// </summary>
		/// <param displayName="command">the OracleCommand to be prepared</param>
		/// <param displayName="connection">a valid OracleConnection, on which to execute this command</param>
		/// <param displayName="transaction">a valid OracleTransaction, or 'null'</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters to be associated with the command or 'null' if no parameters are required</param>
		private static void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters)
		{
			//if the provided connection is not open, we will open it
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
			}

			//associate the connection with the command
			command.Connection = connection;

			//set the command text (stored procedure displayName or Oracle statement)
			command.CommandText = commandText;

			//if we were provided a transaction, assign it.
			if (transaction != null)
			{
				command.Transaction = transaction;
			}

			//set the command type
			command.CommandType = commandType;

			//attach the command parameters if they are provided
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}

			return;
		}


		#endregion private utility methods & constructors

		#region ExecuteNonQuery

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteNonQuery(connectionString, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create & open an OracleConnection, and dispose of it after we are done.
			using (OracleConnection cn = new OracleConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns no resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else 
			{
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset and takes no parameters) against the provided OracleConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteNonQuery(connection, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset) against the specified OracleConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{	
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, connection, (OracleTransaction)null, commandType, commandText, commandParameters);
			
			//finally, execute the command.
			return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns no resultset) against the specified OracleConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleConnection connection, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else 
			{
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset and takes no parameters) against the provided OracleTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteNonQuery(transaction, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns no resultset) against the specified OracleTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//finally, execute the command.
			return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns no resultset) against the specified 
		/// OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OracleTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populet the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteNonQuery

		#region ExecuteDataSet

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteDataset(connectionString, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create & open an OracleConnection, and dispose of it after we are done.
			using (OracleConnection cn = new OracleConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteDataset(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the database specified in 
		/// the conneciton string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populet the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the provided OracleConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteDataset(connection, commandType, commandText, (OracleParameter[])null);
		}
		
		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the specified OracleConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, connection, (OracleTransaction)null, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataSet
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			//return the dataset
			return ds;						
		}
		
		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the specified OracleConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleConnection connection, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteDataset(transaction, commandType, commandText, (OracleParameter[])null);
		}
		
		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the specified OracleTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataSet
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			//return the dataset
			return ds;
		}
		
		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the specified 
		/// OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OracleTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteDataSet
		
		#region ExecuteReader

		/// <summary>
		/// this enum is used to indicate weather the connection was provided by the caller, or created by OracleHelper, so that
		/// we can set the appropriate CommandBehavior when calling ExecuteReader()
		/// </summary>
		private enum OracleConnectionOwnership	
		{
			/// <summary>Connection is owned and managed by OracleHelper</summary>
			Internal, 
			/// <summary>Connection is owned and managed by the caller</summary>
			External
		}


		/// <summary>
		/// Create and prepare an OracleCommand, and call ExecuteReader with the appropriate CommandBehavior.
		/// </summary>
		/// <remarks>
		/// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
		/// 
		/// If the caller provided the connection, we want to leave it to them to manage.
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection, on which to execute this command</param>
		/// <param displayName="transaction">a valid OracleTransaction, or 'null'</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters to be associated with the command or 'null' if no parameters are required</param>
		/// <param displayName="connectionOwnership">indicates whether the connection parameter was provided by the caller, or created by OracleHelper</param>
		/// <returns>OracleDataReader containing the results of the command</returns>
		private static OracleDataReader ExecuteReader(OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, OracleConnectionOwnership connectionOwnership)
		{	
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
			
			//create a reader
			OracleDataReader dr;

			// call ExecuteReader with the appropriate CommandBehavior
			if (connectionOwnership == OracleConnectionOwnership.External)
			{
				dr = cmd.ExecuteReader();
			}
			else
			{
				dr = cmd.ExecuteReader((CommandBehavior)((int)CommandBehavior.CloseConnection));
			}

			return (OracleDataReader) dr;
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteReader(connectionString, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create & open an OraclebConnection
			OracleConnection cn = new OracleConnection(connectionString);
			cn.Open();

			try
			{
				//call the private overload that takes an internally owned connection in place of the connection string
				return ExecuteReader(cn, null, commandType, commandText, commandParameters, OracleConnectionOwnership.Internal);
			}
			catch
			{
				//if we fail to return the OracleDataReader, we need to close the connection ourselves
				cn.Close();
				throw;
			}
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(connString, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else 
			{
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the provided OracleConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteReader(connection, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the specified OracleConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//pass through the call to the private overload using a null transaction value and an externally owned connection
			return ExecuteReader(connection, (OracleTransaction)null, commandType, commandText, commandParameters, OracleConnectionOwnership.External);
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the specified OracleConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleConnection connection, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				AssignParameterValues(commandParameters, parameterValues);

				return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else 
			{
				return ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param>  
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteReader(transaction, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a resultset) against the specified OracleTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///   OracleDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or PL/SQL command</param> 
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//pass through to private overload, indicating that the connection is owned by the caller
			return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OracleConnectionOwnership.External);
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a resultset) against the specified
		/// OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  OracleDataReader dr = ExecuteReader(trans, "GetOrders", 24, 36);
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an OracleDataReader containing the resultset generated by the command</returns>
		public static OracleDataReader ExecuteReader(OracleTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				AssignParameterValues(commandParameters, parameterValues);

				return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteReader

		#region ExecuteScalar
		
		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-Oracle command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteScalar(connectionString, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-Oracle command</param>
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create & open an OracleConnection, and dispose of it after we are done.
			using (OracleConnection cn = new OracleConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteScalar(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a 1x1 resultset) against the database specified in 
		/// the conneciton string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populet the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset and takes no parameters) against the provided OracleConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-Oracle command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteScalar(connection, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset) against the specified OracleConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-OleDb command</param>
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, connection, (OracleTransaction)null, commandType, commandText, commandParameters);
			
			//execute the command & return the results
			return cmd.ExecuteScalar();
		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a 1x1 resultset) against the specified OracleConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param displayName="connection">a valid OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleConnection connection, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populet the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset and takes no parameters) against the provided OracleTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-OleDb command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OracleParameters
			return ExecuteScalar(transaction, commandType, commandText, (OracleParameter[])null);
		}

		/// <summary>
		/// Execute an OracleCommand (that returns a 1x1 resultset) against the specified OracleTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param displayName="commandText">the stored procedure displayName or T-OleDb command</param>
		/// <param displayName="commandParameters">an array of OracleParameters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OracleCommand cmd = new OracleCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//execute the command & return the results
			return cmd.ExecuteScalar();

		}

		/// <summary>
		/// Execute a stored procedure via an OracleCommand (that returns a 1x1 resultset) against the specified
		/// OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param displayName="transaction">a valid OracleTransaction</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OracleTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we got parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0)) 
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populet the cache)
				OracleParameter[] commandParameters = OracleHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of OracleParameters
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
				//otherwise we can just call the SP without params
			else 
			{
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteScalar
	}

	/// <summary>
	/// OracleHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
	/// ability to discover parameters for stored procedures at run-time.
	/// </summary>
	public sealed class OracleHelperParameterCache
	{
		#region private methods, variables, and constructors

		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new OracleHelperParameterCache()".
		private OracleHelperParameterCache() {}

		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// resolve at run-time the appropriate set of OracleParameters for a stored procedure
		/// </summary>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="includeReturnValueParameter">whether or not to include ther return value parameter</param>
		/// <returns></returns>
		private static OracleParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			using (OracleConnection cn = new OracleConnection(connectionString)) 
			using (OracleCommand cmd = new OracleCommand(spName,cn))
			{
				cn.Open();
				cmd.CommandType = CommandType.StoredProcedure;

				OracleCommandBuilder.DeriveParameters(cmd);

				if (!includeReturnValueParameter) 
				{
					if (ParameterDirection.ReturnValue == cmd.Parameters[0].Direction)				
						cmd.Parameters.RemoveAt(0);									
				}
			
				OracleParameter[] discoveredParameters = new OracleParameter[cmd.Parameters.Count];

				cmd.Parameters.CopyTo(discoveredParameters, 0);

				return discoveredParameters;
			}
		}

		//deep copy of cached OracleParameter array
		private static OracleParameter[] CloneParameters(OracleParameter[] originalParameters)
		{
			OracleParameter[] clonedParameters = new OracleParameter[originalParameters.Length];

			for (int i = 0, j = originalParameters.Length; i < j; i++)
			{
				clonedParameters[i] = (OracleParameter)((ICloneable)originalParameters[i]).Clone();
			}

			return clonedParameters;
		}

		#endregion private methods, variables, and constructors

		#region caching functions

		/// <summary>
		/// add parameter array to the cache
		/// </summary>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandText">the stored procedure displayName or T-OleDb command</param>
		/// <param displayName="commandParameters">an array of OracleParameters to be cached</param>
		public static void CacheParameterSet(string connectionString, string commandText, params OracleParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;

			paramCache[hashKey] = commandParameters;
		}

		/// <summary>
		/// retrieve a parameter array from the cache
		/// </summary>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="commandText">the stored procedure displayName or T-OleDb command</param>
		/// <returns>an array of OracleParameters</returns>
		public static OracleParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;

			OracleParameter[] cachedParameters = (OracleParameter[])paramCache[hashKey];
			
			if (cachedParameters == null)
			{			
				return null;
			}
			else
			{
				return CloneParameters(cachedParameters);
			}
		}

		#endregion caching functions

		#region Parameter Discovery Functions

		/// <summary>
		/// Retrieves the set of OracleParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <returns>an array of OracleParameters</returns>
		public static OracleParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return GetSpParameterSet(connectionString, spName, false);
		}

		/// <summary>
		/// Retrieves the set of OracleParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param displayName="connectionString">a valid connection string for an OracleConnection</param>
		/// <param displayName="spName">the displayName of the stored procedure</param>
		/// <param displayName="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
		/// <returns>an array of OracleParameters</returns>
		public static OracleParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter":"");

			OracleParameter[] cachedParameters;
			
			cachedParameters = (OracleParameter[])paramCache[hashKey];

			if (cachedParameters == null)
			{			
				cachedParameters = (OracleParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
			}
			
			return CloneParameters(cachedParameters);
		}

		#endregion Parameter Discovery Functions

	}
}
