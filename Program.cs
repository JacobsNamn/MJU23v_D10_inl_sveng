namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        public static List<SweEngGloss> dictionary = new List<SweEngGloss>();
        public static string DefaultFile = @"dict\sweeng.lis";

        static void Main(string[] program_args)
        {
            
            Console.WriteLine("Welcome to the dictionary app!");
            do
            {
                Console.Write("> ");
                string[] arr = Console.ReadLine().Split(" ");
                string command = arr[0];
                string[] args = arr.Skip(1).ToArray();
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (command == "load")
                {
                    Commands.LoadCommand(args);
                }
                else if (command == "list")
                {
                    Commands.ListCommand(args);
                }
                else if (command == "new")
                {
                    Commands.NewCommand(args);
                }
                else if (command == "delete")
                {
                    Commands.DeleteCommand(args);
                }
                else if (command == "translate")
                {
                    if (args.Length == 1)
                    {
                        foreach(SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == args[0])
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == args[0])
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                    else if (args.Length == 0)
                    {
                        Console.WriteLine("Write word to be translated: ");
                        string s = Console.ReadLine();
                        foreach (SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == s)
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == s)
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{command}'");
                }
                // TODO: Lägg till hjälpkommando.
            }
            while (true);
        }
    }
}