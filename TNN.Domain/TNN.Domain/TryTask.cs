namespace TNN.Domain.Tasks;
internal class TryTask
{
    public static void Try(Action action, short attemps = 3)
    {
        while (true)
        {
            try
            {
                action();
                if (attemps == 0)
                    throw new ApplicationException($"Fail with {attemps} attemps for execute {nameof(action)}");
            }
            catch
            {
                Thread.Sleep(1000);
                attemps--;
            }
        }
    }
}
