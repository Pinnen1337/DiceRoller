using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.Models
{
    public class RollSave
    {
        private static RollSave instance;
        public static RollSave Instance => instance ??= new RollSave();

        
        public int Hits { get; set; }
        public int Wounds { get; set; }
        public int Saves { get; set; }

        
        public int[] HitsCounter { get; set; } = new int[6];
        public int[] WoundsCounter { get; set; } = new int[6];
        public int[] SavesCounter { get; set; } = new int[6];

        private RollSave() { }

    }
}
