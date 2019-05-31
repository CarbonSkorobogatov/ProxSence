using System;

namespace ProxSenceWebProj.Models
{
    public class PageBreakModel
    {
        public int AllProjectsCategory { get; set; }
        public int TotalProjectsPerPage { get; set; }
        public int Page { get; set; }
        public int AllPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)AllProjectsCategory / TotalProjectsPerPage);
            }
        }
    }
}