using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU23v_D10_inl_sveng {
    public class SweEngGloss {
        public string word_swe, word_eng;
        public SweEngGloss(string word_swe, string word_eng) {
            this.word_swe = word_swe; this.word_eng = word_eng;
        }
        public SweEngGloss(string line) {
            string[] words = line.Split('|');
            this.word_swe = words[0]; this.word_eng = words[1];
        }
    }
}
