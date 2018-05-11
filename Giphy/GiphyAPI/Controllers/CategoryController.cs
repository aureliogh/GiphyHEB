using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiphyAPI.Controllers
{
    //Main prefix for all calls
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        //Variable carrying Giphy Data Context
        private GiphySQLDataContext Db = new GiphySQLDataContext();

        //GET call to retrieve user by username
        [HttpGet]
        [Route("byIdUser/{iduser:int:length(1m10)}")]
        public HttpResponseMessage GetCategoryByIDUser(int idUser)
        {
            try
            {
                var cat = (from u in Db.tbl_categoriesByUsers
                           where u.id_user == idUser
                           select u).ToList(); // .FirstOrDefault();

                var code = (cat != null)
                    ? HttpStatusCode.OK
                    : HttpStatusCode.NotFound;
                return Request.CreateResponse(code, cat);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        

        //POST new user
        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddCategory([FromBody] tbl_user user)
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
    }
}
