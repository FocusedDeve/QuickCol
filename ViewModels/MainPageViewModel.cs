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
                Title = "Bienvenu sur QuickCol",
                Description ="L'application dédié à la collecte de fonds",
                Image = "slide1.png"
            });

            CarousselItems.Add(new CarousselItem()
            {
                Title = "Pour les Agents de collecte",
                Description = "Planifier vos rendez-vous en créant votre itinéraire, Scanner le QR code des client et procedez à une collecte",
                Image = "slide1.png"
            });

            CarousselItems.Add(new CarousselItem()
            {
                Title = "Espace Client",
                Description = "Creer votre compte pour faciliter l'accès aux informations à votre agent commercial, Planifer vos Rendez-vous",
                Image = "slide1.png"
            });
        }
    }
}
