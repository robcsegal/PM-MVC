using System;
using System.Collections.Generic;

namespace PMMVC.Data.ProjectManagement
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
