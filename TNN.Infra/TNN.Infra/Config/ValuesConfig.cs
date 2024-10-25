namespace TNN.Infra.Config;
public static class ValuesConfig
{
    public static ScrappingValues ScrappingProperties = new();
    public class ScrappingValues
    {
        public string Host { get; set; } = null!;
        public string UserClient { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UrlCreateExpense { get; set; } = null!;
    }
}
