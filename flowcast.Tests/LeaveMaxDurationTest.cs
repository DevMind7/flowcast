using flowcast.Application.Modules.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Tests
{
    public class LeaveMaxDurationTest
    {
        [Fact]
        public void Validate_ReturnsTrue_WhenDurationIsWithinLimit()
        {
            // Arrange
            var parameters = new Dictionary<string, string>
            {
                { "startDate", "2024-07-01" },
                { "endDate", "2024-07-10" }  // 10 jours → OK
            };

            // Act
            var result = LeaveMaxDurationValidator.Validate(parameters);

            // Assert
            Assert.True(result.Success);
            Assert.Contains("Durée conforme", result.Message);
        }

        [Fact]
        public void Validate_ReturnsFalse_WhenDurationExceedsLimit()
        {
            var parameters = new Dictionary<string, string>
            {
                { "startDate", "2024-07-01" },
                { "endDate", "2024-08-01" }  // 32 jours → dépasse la limite
            };

            var result = LeaveMaxDurationValidator.Validate(parameters);

            Assert.False(result.Success);
            Assert.Contains("dépasse la limite autorisée", result.Message);
        }

    }
}