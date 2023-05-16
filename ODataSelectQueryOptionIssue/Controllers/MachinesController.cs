using ODataSelectQueryOptionIssue.Data;
using ODataSelectQueryOptionIssue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataSelectQueryOptionIssue.Controllers
{
    public class MachinesController : ODataController
    {
        private readonly ProjectDbContext db;

        public MachinesController(ProjectDbContext db)
        {
            this.db = db;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Machine>> Get()
        {
            return db.Machines.ToList();
        }
    }
}
