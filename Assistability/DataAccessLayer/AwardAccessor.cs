/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/08
/// 
/// This class has the methods that will be used
/// Currently a shell
/// </summary>
/// <remarks>
/// Nathaniel Webber
/// 2021/03/11
/// Added Database functionality
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
    public class AwardAccessor : IAwardAccessor
    {
        public int CreateNewAward(int userID, string awardName, string awardDescription)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_create_new_award", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID_Award", SqlDbType.Int);
            cmd.Parameters.Add("@AwardName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@AwardDescription", SqlDbType.NVarChar, 255);
            //cmd.Parameters.Add("@GoalID", SqlDbType.Int);
            //cmd.Parameters.Add("@GoalTypeID", SqlDbType.Int);

            cmd.Parameters["@UserID_Award"].Value = userID;
            cmd.Parameters["@AwardName"].Value = awardName;
            cmd.Parameters["@AwardDescription"].Value = awardDescription;
            //cmd.Parameters["@GoalID"].Value = goalID;
            //cmd.Parameters["@GoalTypeID"].Value = goalTypeID;

            try
            {
                conn.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (result != 1)
                {
                    throw new ApplicationException("The '" + awardName + "' Award could not be added.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int DeleteAward(int awardID)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_delete_award", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AwardID", SqlDbType.Int);

            cmd.Parameters["@AwardID"].Value = awardID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ApplicationException("The Award could not be deleted.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int SafelyDeactivateAwardByAwardName(int awardID)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_safely_deactivate_award", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AwardID", SqlDbType.Int);

            cmd.Parameters["@AwardID"].Value = awardID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ApplicationException("The Award could not be deactivated.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<Award> SelectAllAwards(bool active = true)
        {
            List<Award> awards = new List<Award>();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_all_awards", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        awards.Add(new Award()
                        {
                            AwardID = reader.GetInt32(0),
                            AwardName = reader.GetString(1),
                            AwardDescription = reader.GetString(2),
                            GoalID = reader.GetInt32(3),
                            GoalTypeID = reader.GetInt32(4),
                            Active = reader.GetBoolean(5)
                        }); 
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return awards;
        }

        public List<Award> SelectAwardByAwardID(int awardID)
        {
            List<Award> awards = new List<Award>();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_award_by_awardID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AwardID", SqlDbType.Int);
            cmd.Parameters["@AwardID"].Value = awardID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award award = new Award();
                        award.AwardID = reader.GetInt32(0);
                        award.AwardName = reader.GetString(1);
                        award.AwardDescription = reader.GetString(2);
                        award.GoalID = reader.GetInt32(3);
                        award.GoalTypeID = reader.GetInt32(4);
                        award.Active = reader.GetBoolean(5);

                        awards.Add(award);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conn.Close();
            }

            return awards;
        }

        public Award SelectAwardByUserIDAndAwardName(int userID, string awardName)
        {
            Award awards = new Award();

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_select_award_by_userID_and_awardname", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID_Award", SqlDbType.Int);
            cmd.Parameters.Add("@AwardName", SqlDbType.NVarChar, 50);

            cmd.Parameters["@UserID_Award"].Value = userID;
            cmd.Parameters["@AwardName"].Value = awardName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        awards.AwardID = reader.GetInt32(0);
                        awards.AwardName = reader.GetString(1);
                        awards.AwardDescription = reader.GetString(2);
                        awards.GoalID = reader.GetInt32(3);
                        awards.GoalTypeID = reader.GetInt32(4);
                        awards.Active = reader.GetBoolean(5);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return awards;
        }

        public int UpdateAward(Award newAward, Award oldAward)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_update_award", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AwardID", SqlDbType.Int);
            cmd.Parameters.Add("@NewAwardName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewAwardDescription", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@OldAwardName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldAwardDescription", SqlDbType.NVarChar, 255);

            cmd.Parameters["@AwardID"].Value = oldAward.AwardID;
            cmd.Parameters["@NewAwardName"].Value = newAward.AwardName;
            cmd.Parameters["@NewAwardDescription"].Value = newAward.AwardDescription;
            cmd.Parameters["@OldAwardName"].Value = oldAward.AwardName;
            cmd.Parameters["@OldAwardDescription"].Value = oldAward.AwardDescription;

            try
            {
                conn.Open();
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

            return result;
        }
    }
}
