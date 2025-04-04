﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.ViewModels
{
    public class WoundsViewModel : INotifyPropertyChanged
    {
        private int wounds = 0;
        private int[] woundsCounter = new int[6];

        public event PropertyChangedEventHandler PropertyChanged;

        public int Wounds
        {
            get => wounds;
            set
            {
                wounds = value;
                OnPropertyChanged();
            }
        }

        public int[] WoundsCounter
        {
            get => woundsCounter;
            set
            {
                woundsCounter = value;
                OnPropertyChanged();
            }
        }
        public void RollWounds(int hits, int strength, int toughness)
        {
            (Wounds, WoundsCounter) = Models.DiceRoller.RollWounds(hits, strength, toughness);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
