using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DbService;

namespace MvCAPI.Controllers
{
    public class ApprovedUsersController : ApiController
    {
        private readonly IMyFakeDbService _db;
        public ApprovedUsersController()
        {
            this._db = new MyFakeDbService();
        }
        public IHttpActionResult PostApprovedUsers([Bind(Include="Email, FirstName, LastName")]ApprovedUser approvedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.UserExists(approvedUser))
            {
                return Content(HttpStatusCode.NotFound, "Email exists Already");
            }

            _db.AddUser(approvedUser);
            return CreatedAtRoute("DefaultApi", new {id = approvedUser.Email}, approvedUser);
        }
    }
}
