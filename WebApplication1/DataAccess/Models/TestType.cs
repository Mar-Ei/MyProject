using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TestType
    {
        public TestType()
        {
            TestsResults = new HashSet<TestsResult>();
        }

        public int TestTypeId { get; set; }
        public string? TestName { get; set; }

        public virtual ICollection<TestsResult> TestsResults { get; set; }
    }
}
