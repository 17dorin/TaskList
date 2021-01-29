using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class ToDo
    {
        public string TeamMember { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool Completed { get; set; }

        public ToDo(string team, string description, string dueDate)
        {
            this.TeamMember = team;
            this.Description = description;
            this.DueDate = dueDate;
            this.Completed = false;
        }
    }
}
