using N10Tester.Service.Interfaces;

namespace N10Tester.Service.Services;

public class CliService : ICliService
{
    public string DoTheWork(string[] args)
    {
        if (args.Length <= 0)
        {
            throw new ArgumentException("No arguments are given.");
        }
        int length = args.Length;
        if (args[0] == "--version")
        {
            return "N10 v1.0\n" +
                "Copyright 2023!\n";
        }
        if (args[0] == "sync")
        {
            // logic
            return "result of logic";
        }
        if ((args[0] == "check"))
        {

        }
    }
}
