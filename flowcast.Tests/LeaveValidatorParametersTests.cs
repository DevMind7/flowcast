using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Tests
{
    public class LeaveValidatorParametersTests
    {
        [Fact]
        public void Properties_AreSetCorrectly()
        {
            var parameters = new LeaveValidatorParameters
            {
                Duration = 5,
                MaxDuration = 10
            };

            Assert.Equal(5, parameters.Duration);
            Assert.Equal(10, parameters.MaxDuration);
        }
    }
}
