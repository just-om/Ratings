using Ratings;
using Ratings.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

public class RatingReviewController : ApiController
{
    private readonly RatingReviewService _service;

    public RatingReviewController()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        _service = new RatingReviewService(connectionString);
    }

    [HttpPost]
    [Route("api/addRating")]
    public IHttpActionResult AddRating([FromBody] RatingModel rating)
    {
        try
        {
            rating.CreatedOn = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _service.AddRating(rating);

            return Ok("Rating added successfully");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("api/getUserRatingsById")]

    public IHttpActionResult GetUserRatingsById(int orgMemId, int orgId, int orgBranchId)
    {
        try
        {
            List<RatingModel> userRatings = _service.GetUserRatingsById(orgMemId, orgId, orgBranchId);
            return Ok(userRatings);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("api/getUserRatingsById")]
    public IHttpActionResult GetUserRatingsByOrgId(int orgId)
    {
        try
        {
            List<RatingModel> userRatings = _service.GetUserRatingsByOrgId(orgId);
            return Ok(userRatings);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("api/getUserRatingsById")]
    public IHttpActionResult GetUserRatingsByBranchId(int orgBranchId,int orgId)
    {
        try
        {
            List<RatingModel> userRatings = _service.GetUserRatingsByBranchId(orgBranchId,orgId);
            return Ok(userRatings);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

}

