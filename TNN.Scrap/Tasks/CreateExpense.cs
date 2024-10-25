using OpenQA.Selenium.Chrome;
using TNN.Domain.Entities;
using TNN.Infra.Config;

namespace TNN.Scrap.Tasks;
internal class CreateExpense
{
    private readonly List<Expense> _expenseves;
    private readonly ChromeDriver _driver;

    public CreateExpense(List<Expense> expenseves, ChromeDriver driver)
    {
        _expenseves = expenseves;
        _driver = driver;
    }

    public void Generate()
    {
        if (_expenseves is null || _expenseves.Count == 0)
            return;

        _driver.Navigate().GoToUrl(ValuesConfig.ScrappingProperties.UrlCreateExpense);
    }
}
