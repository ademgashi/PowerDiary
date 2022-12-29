using PowerDiary.Application;

namespace PowerDiary.Core.Tests
{
    public class ChatHistoryServiceTests
    {
       

        private ChatHistoryService CreateService()
        {
            return new ChatHistoryService(ContextMock.GetMockDBContext("ChatTests_DB"));
        }

        [Fact]
        public void GetChatHistory_Granularity_MinuteByMinute()
        {
            //arrange
            var service = CreateService();

            // Act
            var result = service.GetChatHistory(Granularity.MinuteByMinute);
            
            // Assert
            Assert.Equal(6, result.Count());
        }


        [Fact]
        public void GetChatHistory_Granularity_Hourly()
        {
            //arrange
            var service = CreateService();

            // Act
            var result = service.GetChatHistory(Granularity.Hourly);

            // Assert
            Assert.Equal("6 chat events", result.FirstOrDefault()?.Message);
        }

    }
}
