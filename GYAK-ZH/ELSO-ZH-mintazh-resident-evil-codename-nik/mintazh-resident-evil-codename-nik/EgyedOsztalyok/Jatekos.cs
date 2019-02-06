﻿using System;
namespace mintazhresidentevilcodenamenik
{

    public class Jatekos : IJatekos
    {
        public string Nev { get; set; }
        public int Eletero { get; set; }
        public int Sebzes { get; set; }
        public JatekosKarakter Karakter { get; set; }

        public void Tamadas(IEllenseg ellenseg)
        {
            ellenseg.Eletero -= Sebzes;
            OnTalalat(ellenseg);
        }

        public delegate void TalalatEventHandler(object source, TalalatEventArgs args);
        public event TalalatEventHandler Talalat;

        protected virtual void OnTalalat(IEllenseg ellenseg)
        {
            if (Talalat != null)
                Talalat(this, new TalalatEventArgs()
                {
                    Ellenseg = ellenseg,
                    Idobelyeg = DateTime.Now,
                    Jatekos = this
                });
        }

        public override string ToString()
        {
            return string.Format(
            
                "{0} ({1})" , Nev, Eletero

                );
        }

    }
}
