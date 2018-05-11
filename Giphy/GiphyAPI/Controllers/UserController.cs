using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiphyAPI.Controllers
{
    //Main prefix for all calls
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        //Variable carrying Giphy Data Context
        private GiphySQLDataContext Db = new GiphySQLDataContext();

        //GET call to retrieve user by username
        [HttpGet]
        [Route("byUsername/{username:minlength(8):maxlength(20)}")]
        public HttpResponseMessage GetUserByUsername(string username)
        {
            try
            {
                var usr = (from u in Db.tbl_users
                           where u.username == username
                           select u).ToList(); // .FirstOrDefault();

                var code = (usr != null)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.NotFound;
                return Request.CreateResponse(code, usr);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //GET call to retrieve user by username
        [HttpGet]
        [Route("byEmail/{email:minlength(8):maxlength(60)}")]
        public HttpResponseMessage GetUserByEmail(string email)
        {
            try
            {
                var usr = (from u in Db.tbl_users
                           where u.email == email
                           select u).ToList(); // .FirstOrDefault();

                var code = (usr != null)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.NotFound;
                return Request.CreateResponse(code, usr);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //POST new user
        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddUser([FromBody] tbl_user user)
        {
            try
            {
                Db.tbl_users.InsertOnSubmit(user);
                Db.SubmitChanges();
                var entity = Db.tbl_users.FirstOrDefault(u => u.username == user.username);
                return Request.CreateResponse(HttpStatusCode.OK, entity);


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //Updates User 
        [HttpPut]
        [Route("Update/{id:int:length(1,10)}")]
        public HttpResponseMessage UpdateUser(int id, [FromBody] tbl_user user)
        {
            try
            {
                var entity = Db.tbl_users.FirstOrDefault(e => e.id_user == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with ID = " + id.ToString() + " not found. Update Cancelled");
                }
                else
                {
                    entity.lastlogin = user.lastlogin;                    
                    Db.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
