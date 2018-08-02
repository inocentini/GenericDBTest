using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Util
{
    public abstract class Database
    {
        // <summary>
        /// Connection string
        /// </summary>
        private string sConnection = string.Empty;

        /// <summary>
        /// Connection object
        /// </summary>
        private IDbConnection connection = null;

        /// <summary>
        /// Transaction object for groups of operations
        /// </summary>
        private IDbTransaction transaction = null;

        /// <summary>
        /// Retrieves the Connection object
        /// Method to be implemented by the specialized class because it depends on the DataBase used
        /// </summary>
        /// <returns>
        /// The Connection object
        /// </returns>
        public abstract IDbConnection GetConnection();

        /// <summary>
        /// Retrieves the Commands Execution object
        /// Method to be implemented by the specialized class because it depends on the DataBase used
        /// </summary>
        /// <returns>
        /// The Commads object
        /// </returns>
        public abstract IDbCommand GetCommand(string sSql);

        /// <summary>
        /// Retrieves the Data Adapter object
        /// Method to be implemented by the specialized class because it depends on the DataBase used
        /// </summary>
        /// <returns>
        /// The Data Adapter object
        /// </returns>
        public abstract IDbDataAdapter GetAdapter(IDbCommand command);

        /// <summary>
        /// Create a new instance of the class <see cref="Database"/>
        /// </summary>
        public Database()
        {
        }

        /// <summary>
        /// Opens the connection with the DataBase
        /// </summary>
        public void Open()
        {
            if (connection == null)
            {
                // Get the connection object from the heir class
                connection = GetConnection();
            }

            connection.Open();
        }

        /// <summary>
        /// Closes the connection
        /// </summary>
        public void Close()
        {
            // The connection.State can the used to check situations in which the connection should not be closed
            // in order to avoid errors, it's not needed if the class is used correctly in your program
            if (connection != null) // && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Commits the operations on the current transaction
        /// </summary>
        public void CommitTransaction()
        {
            if (transaction != null) // Checks if the transaction exists
            {
                transaction.Commit();
                transaction.Dispose(); // Free the transaction resources
                transaction = null;
            }
        }

        /// <summary>
        /// Rollsback the operations on the current transaction
        /// </summary>
        public void RollbackTransaction()
        {
            if (transaction != null) // Checks if the transaction exists
            {
                transaction.Rollback();
                transaction.Dispose(); // Free the transaction resources
                transaction = null;
            }
        }

        /// <summary>
        /// Run the SQL command with the provided parameters
        /// </summary>
        /// <param name="sSql">The SQL command</param>
        /// <param name="parameters">The SQL command parameters</param>
        /// <returns>The value on the first column of the first line returned by the command</returns>
        public string SqlExecute(string sSql, Dictionary<string, object> parameters = null)
        {
            // Get the command object from the heir class
            var command = GetCommand(sSql);

            // Checks if there's any parameters
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    // Creates the parameter relative to the Commands object
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = item.Key;
                    parameter.Value = item.Value;

                    // Add the parameter to the Commands object
                    command.Parameters.Add(parameter);
                }
            }

            // Checks if there's an active transaction
            if (transaction != null)
            {
                // If there is, executes the command inside the transaction
                command.Transaction = transaction;
            }

            // Executes the command and takes the value on the first column of the first line
            var result = (string)command.ExecuteScalar();

            // Free the command resources
            command.Dispose();

            return result;
        }

        /// <summary>
        /// Run the SQL select with the provided parameters
        /// </summary>
        /// <param name="sSql">The SQL select</param>
        /// <param name="parameters">The SQL select parameters</param>
        /// <param name="commandType">The SQL command type</param>
        /// <returns>The Data Set returned by the SQL select</returns>
        public DataSet SqlSelect(string sSql, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            // Creates a new Data Set
            var dataSet = new DataSet();

            // Retrieves the Commands object
            var command = GetCommand(sSql);

            // Retrieves the Data Adapter object
            var adapter = GetAdapter(command);

            // Checks if there's any parameters
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    // Creates the paramater relative to the Commands object
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = item.Key;
                    parameter.Value = item.Value;

                    // Add the parameter to the Commands object
                    command.Parameters.Add(parameter);
                }
            }

            // Set the type of the command to be executed
            command.CommandType = commandType;

            // Checks if there's an active transaction 
            if (transaction != null)
            {
                // If there is, execute the command inside the transaction
                command.Transaction = transaction;
            }

            // Use the Data Adapter to fill the Data Set with the data returned from the SQL select
            adapter.Fill(dataSet);

            // Free the command resources
            command.Dispose();

            return dataSet;
        }
    }
}
