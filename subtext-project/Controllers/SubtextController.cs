using Microsoft.AspNetCore.Mvc;
using SubtextProject;
using System.Collections.Generic;

namespace subtext_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubtextController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<int> Post([FromBody]Subtext subtext)
        {
            return subtext.FindAllSubtextPositions();
        }
    }
}
