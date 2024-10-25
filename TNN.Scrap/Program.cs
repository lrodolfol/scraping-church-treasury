using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using TNN.Domain.Entities;
using TNN.Infra.Di;
using TNN.Scrap.Tasks;

var pathDrive = @"driver\chromedriver.exe";

LoadConfig.CreateConfiguration();
var service = LoadConfig.InjectValues(pathDrive);

var chromeDriver = service.GetRequiredService<ChromeDriver>();

var createExpense = new CreateExpense(new List<Expense>(), chromeDriver);