/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Accessor for Routine objects
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessInterfaces;
using DataStorageModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoutineAccessor : IRoutineAccessor
    {
        /// <summary>
        /// William Clark
        /// Created: 2021/02/26
        /// 
        /// Selects a list of RoutineSteps objects from the database assigned to the Routine
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routine">The Routine for which to select all RoutineSteps assigned</param>
        /// <exception>No RoutineSteps found</exception>
        /// <returns>A list of RoutineStep objects</returns>
        List<RoutineStep> IRoutineAccessor.SelectRoutineStepsByRoutine(Routine routine)
        {
            List<RoutineStep> steps = new List<RoutineStep>();

            // Retrieve a connection from factory
            var conn = DBConnection.GetDBConnection();

            // Retrieve a command
            var cmd = new SqlCommand("sp_select_routinesteps_by_routinename", conn);

            // Set command type to stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameter to command
            cmd.Parameters.Add("@RoutineName", SqlDbType.NVarChar, 50);

            // Set parameter to value
            cmd.Parameters["@RoutineName"].Value = routine.Name;

            // Execute command
            try
            {
                // Open connection
                conn.Open();

                // Execute command
                var reader = cmd.ExecuteReader();

                // Capture results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var routineStepID = reader.GetInt32(0);
                        var routineStepName = reader.GetString(1);
                        var routineStepDescription = reader.GetString(2);
                        var entryDate = reader.GetDateTime(3);
                        DateTime? editDate = null;
                        if (!reader.IsDBNull(4))
                        {
                            editDate = reader.GetDateTime(4);
                        }
                        else
                        {
                            editDate = null;
                        }
                        DateTime? removalDate;
                        if (!reader.IsDBNull(5))
                        {
                            removalDate = reader.GetDateTime(5);
                        }
                        else
                        {
                            removalDate = null;
                        }
                        var stepOrderNumber = reader.GetInt32(6);
                        var active = reader.GetBoolean(7);

                        var step = new RoutineStep(routineStepID, routine.Name, routineStepName, routineStepDescription, entryDate, editDate, removalDate, stepOrderNumber, active);

                        steps.Add(step);
                    }
                    reader.Close();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return steps;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        /// 
        /// Updates a specific Routine
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="oldRoutine">The Routine to update</param>
        /// <param name="newRoutine">The New Routine</param>
        /// <exception cref="ApplicationException">Routine could not be udpated</exception>
        /// <returns>If the routine was successfully updated</returns>
        public bool UpdateRoutine(Routine oldRoutine, Routine newRoutine)
        {
            int result = 0;
            // Retrieve a connection from factory
            var conn = DBConnection.GetDBConnection();

            // Retrieve a command
            var cmd = new SqlCommand("sp_update_routine", conn);

            // Set command type to stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameter to command
            cmd.Parameters.Add("@RoutineName", SqlDbType.NVarChar, 50);

            // Set parameter to value
            cmd.Parameters["@RoutineName"].Value = oldRoutine.Name;

            // Add parameter to command
            cmd.Parameters.Add("@RoutineDescription", SqlDbType.NVarChar, 150);

            // Set parameter to value
            cmd.Parameters["@RoutineDescription"].Value = newRoutine.Description;

            // Add parameter to command
            cmd.Parameters.Add("@UserID_Client", SqlDbType.Int);

            // Set parameter to value
            cmd.Parameters["@UserID_Client"].Value = oldRoutine.UserAccountID_Client;

            // Add parameter to command
            cmd.Parameters.Add("@UserID_Admin", SqlDbType.Int);

            // Set parameter to value
            cmd.Parameters["@UserID_Admin"].Value = oldRoutine.UserAccountID_Admin;

            // Add parameter to command
            cmd.Parameters.Add("@EditDate", SqlDbType.DateTime);

            if (newRoutine.EditDate.HasValue)
            {
                // Set parameter to value
                cmd.Parameters["@EditDate"].Value = newRoutine.EditDate;
            }
            else
            {
                // Set parameter to value
                cmd.Parameters["@EditDate"].Value = DBNull.Value;
            }

            // Add parameter to command
            cmd.Parameters.Add("@RemovalDate", SqlDbType.DateTime);

            if (newRoutine.RemovalDate.HasValue)
            {
                // Set parameter to value
                cmd.Parameters["@RemovalDate"].Value = newRoutine.RemovalDate;
            }
            else
            {
                // Set parameter to value
                cmd.Parameters["@RemovalDate"].Value = DBNull.Value;
            }

            // Add parameter to command
            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            // Set parameter to value
            cmd.Parameters["@Active"].Value = newRoutine.Active;

            // Execute command
            try
            {
                // Open connection
                conn.Open();

                // Execute command
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result == 1 ;

        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Selects all active routines for a UserAccount listed as the Client
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountId of the client</param>
        /// <exception cref="ApplicationException">Routines could not be found</exception>
        /// <returns>A list of Routines</returns>
        public List<Routine> SelectActiveRoutinesByUserAccountIDClient(int userAccountID)
        {
            List<Routine> routines = new List<Routine>();

            // Retrieve a connection from factory
            var conn = DBConnection.GetDBConnection();

            // Retrieve a command
            var cmd = new SqlCommand("sp_select_active_routines_by_useraccountid", conn);

            // Set command type to stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameter to command
            cmd.Parameters.Add("@UserID_Client", SqlDbType.Int);

            // Set parameter to value
            cmd.Parameters["@UserID_Client"].Value = userAccountID;

            // Execute command
            try
            {
                // Open connection
                conn.Open();

                // Execute command
                var reader = cmd.ExecuteReader();

                // Capture results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var routineName = reader.GetString(0);
                        var routineDescription = reader.GetString(1);
                        var userIDAdmin = reader.GetInt32(2);
                        var entryDate = reader.GetDateTime(3);
                        DateTime? editDate = null;
                        if (!reader.IsDBNull(4))
                        {
                            editDate = reader.GetDateTime(4);
                        }
                        else
                        {
                            editDate = null;
                        }
                        DateTime? removalDate;
                        if (!reader.IsDBNull(5))
                        {
                            removalDate = reader.GetDateTime(5);
                        }
                        else
                        {
                            removalDate = null;
                        }

                        var routine = new Routine(routineName, routineDescription, userAccountID, userIDAdmin,
                            true, entryDate, editDate, removalDate);

                        routines.Add(routine);
                    }
                    reader.Close();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return routines;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Creates a RoutineStepCompletion
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routineStep">The RoutineStep to complete</param>
        /// <param name="userAccount">The User who completed the step</param>
        /// <exception cref="ApplicationException">RoutineStep could not be completed</exception>
        /// <returns>True if completion stored</returns>
        public bool CreateRoutineStepCompletion(RoutineStep routineStep, UserAccount userAccount)
        {
            int result = 0;

            // Retrieve a connection from factory
            var conn = DBConnection.GetDBConnection();

            // Retrieve a command
            var cmd = new SqlCommand("sp_create_routinestepcompletion", conn);

            // Set command type to stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameter to command
            cmd.Parameters.Add("@UserID_Client", SqlDbType.Int);

            // Set parameter to value
            cmd.Parameters["@UserID_Client"].Value = userAccount.UserAccountID;

            // Add parameter to command
            cmd.Parameters.Add("@RoutineStepID", SqlDbType.Int);

            // Set parameter to value
            cmd.Parameters["@RoutineStepID"].Value = routineStep.RoutineStepID;

            // Add parameter to command
            cmd.Parameters.Add("@RoutineName", SqlDbType.NVarChar, 50);

            // Set parameter to value
            cmd.Parameters["@RoutineName"].Value = routineStep.RoutineName;

            // Execute command
            try
            {
                // Open connection
                conn.Open();

                // Execute command
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result == 1;
        }
    }
}
