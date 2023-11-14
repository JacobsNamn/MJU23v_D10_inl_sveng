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
                    foreach(SweEngGloss gloss in dictionary)
                    {
                        Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command == "new")
                {
                    if (args.Length == 2)
                    {
                        dictionary.Add(new SweEngGloss(args[0], args[1]));
                    }
                    else if(args.Length == 0)
                    {
                        Console.WriteLine("Write word in Swedish: ");
                        string s = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string e = Console.ReadLine();
                        dictionary.Add(new SweEngGloss(s, e));
                    }
                    // TODO: Lägg till fall där argumenten är 2.
                }
                else if (command == "delete")
                {
                    if (args.Length == 2)
                    {
                        int index = -1;
                        for (int i = 0; i < dictionary.Count; i++) { // TODO: Förkorta.
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == args[0] && gloss.word_eng == args[1])
                                index = i;
                        }
                        dictionary.RemoveAt(index);
                    }
                    else if (args.Length == 0)
                    {
                        Console.WriteLine("Write word in Swedish: ");
                        string s = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string e = Console.ReadLine();
                        int index = -1;
                        for (int i = 0; i < dictionary.Count; i++) // TODO: Förkorta.
                        {
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == s && gloss.word_eng == e)
                                index = i;
                        }
                        dictionary.RemoveAt(index); // FIXME: Checka om out-of-bounds först.
                    }
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