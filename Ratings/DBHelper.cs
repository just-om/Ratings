using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Ratings.Models;
using System.Data;
using System.Web.Http;

namespace Ratings
{
    public class RatingReviewService
    {
        private readonly string _connectionString;

        public RatingReviewService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddRating(RatingModel rating)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertRatings", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", rating.UserId);
                        command.Parameters.AddWithValue("@OrgId", rating.OrgId);
                        command.Parameters.AddWithValue("@OrgBranchId", rating.OrgBranchId);
                        command.Parameters.AddWithValue("@OrgMemId", rating.OrgMemId);
                        command.Parameters.AddWithValue("@Rating", rating.Rating);
                        command.Parameters.AddWithValue("@ReviewText", rating.ReviewText);
                        command.Parameters.AddWithValue("@CreatedOn", rating.CreatedOn);
                        command.Parameters.AddWithValue("@Title", rating.Title);
                        command.Parameters.AddWithValue("@Likes", rating.Likes);
                        command.Parameters.AddWithValue("@Dislikes", rating.Dislikes);
                        command.Parameters.AddWithValue("@isVerified", rating.IsVerified);
                        command.Parameters.AddWithValue("@ReportCount", rating.ReportCount);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex; 
                    }
                }
            }
        }

        public List<RatingModel> GetUserRatingsById(int orgMemId, int orgId, int orgBranchId)
        {
            List<RatingModel> userRatings = new List<RatingModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserRatingsbyId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrgMemId", orgMemId);
                    command.Parameters.AddWithValue("@OrgId", orgId);
                    command.Parameters.AddWithValue("@OrgBranchId", orgBranchId);
             
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRatings.Add(new RatingModel
                            {
                                UserId = (int)reader["UserId"],
                                OrgId = (int)reader["OrgId"],
                                OrgBranchId = (int)reader["OrgBranchId"],
                                OrgMemId = (int)reader["OrgMemId"],
                                Rating = (int)reader["Rating"],
                                ReviewText = reader["ReviewText"] is DBNull ? null : (string)reader["ReviewText"],
                                CreatedOn = (DateTime)reader["CreatedOn"],
                                Title = reader["Title"] is DBNull ? null : (string)reader["Title"],
                                Likes = reader["Likes"] is DBNull ? 0 : (int)reader["Likes"],
                                Dislikes= reader["Dislikes"] is DBNull ? 0 : (int)reader["Dislikes"],
                                IsVerified = DBNull.Value.Equals(reader["isVerified"]) ? true : (bool)reader["isVerified"],
                                ReportCount = reader["ReportCount"] is DBNull ? 0 : (int)reader["ReportCount"]
                            });


                        }
                    }
                }
            }

            return userRatings;
        }

        public List<RatingModel> GetUserRatingsByOrgId(int orgId)
        {
            List<RatingModel> userRatings = new List<RatingModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserRatingsbyOrgId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrgId", orgId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRatings.Add(new RatingModel
                            {
                                UserId = (int)reader["UserId"],
                                OrgId = (int)reader["OrgId"],
                                OrgBranchId = (int)reader["OrgBranchId"],
                                OrgMemId = (int)reader["OrgMemId"],
                                Rating = (int)reader["Rating"],
                                ReviewText = reader["ReviewText"] is DBNull ? null : (string)reader["ReviewText"],
                                CreatedOn = (DateTime)reader["CreatedOn"],
                                Title = reader["Title"] is DBNull ? null : (string)reader["Title"],
                                Likes = reader["Likes"] is DBNull ? 0 : (int)reader["Likes"],
                                Dislikes = reader["Dislikes"] is DBNull ? 0 : (int)reader["Dislikes"],
                                IsVerified = DBNull.Value.Equals(reader["isVerified"]) ? true : (bool)reader["isVerified"],
                                ReportCount = reader["ReportCount"] is DBNull ? 0 : (int)reader["ReportCount"],
                            });


                        }
                    }
                }
            }

            return userRatings;
        }




        public List<RatingModel> GetUserRatingsByBranchId(int orgBranchId, int orgId)
        {
            List<RatingModel> userRatings = new List<RatingModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserRatingsbyBranchId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrgBranchId", orgBranchId);
                    command.Parameters.AddWithValue("OrgId", orgId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRatings.Add(new RatingModel
                            {
                                UserId = (int)reader["UserId"],
                                OrgId = (int)reader["OrgId"],
                                OrgBranchId = (int)reader["OrgBranchId"],
                                OrgMemId = (int)reader["OrgMemId"],
                                Rating = (int)reader["Rating"],
                                ReviewText = reader["ReviewText"] is DBNull ? null : (string)reader["ReviewText"],
                                CreatedOn = (DateTime)reader["CreatedOn"],
                                Title = reader["Title"] is DBNull ? null : (string)reader["Title"],
                                Likes = reader["Likes"] is DBNull ? 0 : (int)reader["Likes"],
                                Dislikes = reader["Dislikes"] is DBNull ? 0 : (int)reader["Dislikes"],
                                IsVerified = DBNull.Value.Equals(reader["isVerified"]) ? true : (bool)reader["isVerified"],
                                ReportCount = reader["ReportCount"] is DBNull ? 0 : (int)reader["ReportCount"]
                                
                            });

                        }
                    }
                }
            } 

            return userRatings;
        }

        public void UpdateRatingCounts(int ratingId, string actionType)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateRatingCount", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", ratingId);
                        command.Parameters.AddWithValue("@ActionType", actionType);

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
                

            
           
            
        }

    }
}