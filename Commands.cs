using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU23v_D10_inl_sveng {
    internal class Commands {
        public static void LoadCommand(string[] args) {
            // TODO: Innehållet av båda if:arna kan kombineras.
            if (args.Length == 1) {
                // TODO: Try/catch.
                using (StreamReader sr = new StreamReader(@"dict\" + args[0])) {
                    Program.dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null) {
                        SweEngGloss gloss = new SweEngGloss(line);
                        Program.dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            } else if (args.Length == 0) {
                // TODO: Try/catch.
                using (StreamReader sr = new StreamReader(Program.DefaultFile)) {
                    Program.dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null) {
                        SweEngGloss gloss = new SweEngGloss(line);
                        Program.dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        internal static void ListCommand(string[] args) {
            foreach (SweEngGloss gloss in Program.dictionary) {
                Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
            }
        }
    }
}
