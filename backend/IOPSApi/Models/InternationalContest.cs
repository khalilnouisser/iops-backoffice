using System;
using System.Collections.Generic;

namespace IOPSBackend.Models
{
    public class InternationalContest : Contest
    {
        public ICollection<NationalContest> NationalContests { get; set; }

        public ICollection<SuperAdmin> Admins { get; set; }

	}
}
