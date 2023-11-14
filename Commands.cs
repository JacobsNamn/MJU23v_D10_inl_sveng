using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU23v_D10_inl_sveng {
    internal class Commands {
        public static void LoadCommand(string[] args) {
            string filePath = Program.DefaultFile;
            if (args.Length == 1) {
                filePath = @"dict\" + args[0];
            }
            try {
                using (StreamReader sr = new StreamReader(filePath)) {
                    Program.dictionary = new List<SweEngGloss>(); // Empty it!
                    string ?line = sr.ReadLine();
                    while (line != null) {
                        SweEngGloss gloss = new SweEngGloss(line);
                        Program.dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
            
        }

        public static void ListCommand(string[] args) {
            foreach (SweEngGloss gloss in Program.dictionary) {
                Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
            }
        }

        private static string PrintGet(string text) {
            Console.Write(text);
            string? ret = Console.ReadLine();
            if (ret != null) {
                return ret;
            } else {
                return String.Empty;
            }
        }

        public static void NewCommand(string[] args) {
            if (args.Length == 1) { Console.WriteLine("'new' does not take one argument. Correct usage: new, new [swedish word] [english word]"); return; }
            if (args.Length > 1) {
                Program.dictionary.Add(new SweEngGloss(args[0], args[1]));
            } else {
                Program.dictionary.Add(new SweEngGloss(PrintGet("Write word in Swedish: "), PrintGet("Write word in English: ")));

            }
        }

        public static void DeleteCommand(string[] args) {
            if (Program.dictionary.Count == 0) { Console.WriteLine("Dictionary list is empty."); return; }
            if (args.Length == 1) { Console.WriteLine("'delete' does not take one argument. Correct usage: delete, delete [swedish word] [english word]"); return; }

            string word_swe, word_eng;
            if (args.Length > 1) {
                word_swe = args[0]; word_eng = args[1];
            } else {
                word_swe = PrintGet("Write word in Swedish: ");
                word_eng = PrintGet("Write word in English: ");
            }

            SweEngGloss[] glossaries = Program.dictionary.Where(g => g.word_swe == word_swe && g.word_eng == word_eng).ToArray();
            if (glossaries.Length == 0) {
                Console.WriteLine($"No result \"{word_swe}\" \"{word_eng}\" found.");
            } else {
                foreach (SweEngGloss glossary in glossaries) {
                    Program.dictionary.Remove(glossary);
                }
            }
        }

        public static void TranslateCommand(string[] args) {
            string word = "";
            if (args.Length > 0) {
                word = args[0];
            } else {
                word = PrintGet("Write word to be translated: ");
            }

            foreach (SweEngGloss gloss in Program.dictionary) {
                if (gloss.word_swe == word)
                    Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                if (gloss.word_eng == word)
                    Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
            }
        }

        public static void HelpCommand(string[] args) {
            Console.WriteLine(
                "Commands:\n" +
                "load - Load default file.\n" +
                "load [filename] - Load file from dict/\n" +
                "list - Show all translations.\n" +
                "new - Add a new translation to the dictionary.\n" +
                "new [swedish word] [english word]\n" +
                "delete - Delete set of words from the dictionary.\n" +
                "delete [swedish word] [english word]\n" +
                "translate - Translate a word+\n" +
                "translate [word]"
                );
        }

    }
}
