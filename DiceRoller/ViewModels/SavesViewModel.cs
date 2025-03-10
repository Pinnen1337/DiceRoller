using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.ViewModels
{
    class SavesViewModel : INotifyPropertyChanged
    {
        private int saves = 0;
        private int[] savesCounter = new int[6];

        public event PropertyChangedEventHandler PropertyChanged;

        public int Saves
        {
            get => saves;
            set
            {
                saves = value;
                OnPropertyChanged();
            }
        }

        public int[] SavesCounter
        {
            get => savesCounter;
            set
            {
                savesCounter = value;
                OnPropertyChanged();
            }
        }
        public void RollSaves(int wounds, int saveThreshold, int apValue)
        {
            (Saves, SavesCounter) = Models.DiceRoller.RollSaves(wounds, saveThreshold, apValue);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
