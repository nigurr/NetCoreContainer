using System;

namespace dev.Model
{
    public class TestResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public DateTime? Created { get; set; } = null;
        public DateTime? Updated { get; set; } = null;
    }
}   