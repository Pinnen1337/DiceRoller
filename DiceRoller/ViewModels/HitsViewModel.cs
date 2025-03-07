using DiceRoller.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.ViewModels
{
    public class HitsViewModel : INotifyPropertyChanged
    {
        private int hits;
        private int[] hitCounts = new int[6];

        public event PropertyChangedEventHandler PropertyChanged;

        public int Hits
        {
            get => hits;
            set
            {
                hits = value;
                OnPropertyChanged();
            }
        }

        public int[] HitCounts
        {
            get => hitCounts;
            set
            {
                hitCounts = value;
                OnPropertyChanged();
            }
        }

        public void RollHits(int diceCount, int bsThreshold)
        {
            (Hits, HitCounts) = Models.DiceRoller.RollHits(diceCount, bsThreshold);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
