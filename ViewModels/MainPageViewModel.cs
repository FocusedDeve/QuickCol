using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickCol.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<CarousselItem> CarousselItems { get; set; } = new();

        public MainPageViewModel()
        {
            CarousselItems.Add(new CarousselItem()
            {
                Title = "hEUREUX DE VOUS REVOIR ",
                Description ="lapp dedier à la collecte de fonds",
                Image = "slide1.png"
            });

            CarousselItems.Add(new CarousselItem()
            {
                Title = "pour les agens ",
                Description = "lapp dedier à la collecte de fond s lorem ipsuum jhtfhctydddrxgfjxffffffjhggdcsdcdskcbkbckdsk s vjdqvc cbzekqjcq  bkqqkyfek  kfq bfulbqzbcq qbqbflqq  vnsqergggxxxxxxxxxxxxxxxxxxxxxxxn wg wx",
                Image = "slide1.png"
            });

            CarousselItems.Add(new CarousselItem()
            {
                Title = "pour LES CLIENTS ",
                Description = "lapp dedier à la collecte de fonds",
                Image = "slide1.png"
            });
        }
    }
}
