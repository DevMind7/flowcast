using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flowcast.Application.Modules.Leave;

namespace flowcast.Tests
{
    public class LeaveValidatorParametersTests
    {
        [Fact]
        public async Task Execute_ReturnsValidResult_WhenParametersAreCorrect()
        {
            var parameters = new Dictionary<string, string>
            {
                { "startDate", "2025-07-24" },
                { "endDate", "2025-07-26" },
                { "availableDays", "5" }
            };

            var result = await LeaveValidatorParameters.Execute(parameters);

            Assert.True(result.Success);
            Assert.Contains("Demande valide", result.Message);
        }

        [Fact]
        public async Task Execute_ReturnsError_WhenEndDateBeforeStartDate()
        {
            var parameters = new Dictionary<string, string>
            {
                { "startDate", "2025-07-26" },
                { "endDate", "2025-07-24" },
                { "availableDays", "5" }
            };

            var result = await LeaveValidatorParameters.Execute(parameters);

            Assert.False(result.Success);
            Assert.Contains("La date de fin doit être après la date de début", result.Message);
        }
    }
}
