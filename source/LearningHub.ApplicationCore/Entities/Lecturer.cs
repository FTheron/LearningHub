using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.ApplicationCore.Entities
{
    public class Lecturer : BaseEntity
    {
        public long LecturerId { get; set; }

        public string Name { get; set; }
    }
}
