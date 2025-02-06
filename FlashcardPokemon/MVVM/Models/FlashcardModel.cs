using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp9.MVVM.Models
{
    class FlashcardModel
    {
        
        public string Name {  get; set; }
        public string TintedImage {  get; set; }   
        
        public string NormalImage { get; set; }
        public List<string> Choices { get; set; }
        public string Answer {  get; set; }
    }
}
