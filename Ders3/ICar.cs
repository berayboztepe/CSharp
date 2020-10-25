using System;
using System.Collections.Generic;
using System.Text;

namespace Ders3
{
    //Car sınıfı bu interface'yi miras alması, Car'ı miras alan tüm sınıfların, bu interfacedeki tüm metodlara sahip olması gerektiği
    //anlamına gelir.
    //public koymak zorunlu değil, public olmak zorunda.
    interface ICar
    {
        public void Calistir();
        public void Hizlan();
        public void Yavasla();
        public void Dur();
    }
}
