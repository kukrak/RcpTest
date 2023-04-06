using RcpTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcpTest.RcpEngine
{
    internal class Firma2Reader : IRcpParser<DzienPracy>
    {
        public IEnumerable<DzienPracy> Read(string[] rcpData)
        {
            var dzienPracyList = new List<DzienPracy>();
            //line format: Kod_pracownika;data;godzina;WE/WY
            foreach (var line in rcpData)
            {
                var parts = line.Split(';');
                var dzienPracy = new DzienPracy
                {
                    KodPracownika = parts[0],
                    Data = DateTime.Parse(parts[1]),
                    GodzinaWejscia = parts[2]=="WE" ? TimeSpan.Parse(parts[3]) : TimeSpan.Zero,
                    GodzinaWyjscia = parts[2]=="WY" ? TimeSpan.Parse(parts[3]) : TimeSpan.Zero
                };
               
                if(dzienPracyList.Any(x => x.KodPracownika == dzienPracy.KodPracownika && x.Data == dzienPracy.Data))
                {
                    var dzienPracyToUpdate = dzienPracyList.First(x => x.KodPracownika == dzienPracy.KodPracownika && x.Data == dzienPracy.Data);
                    if (dzienPracy.GodzinaWejscia != TimeSpan.Zero)
                    {
                        dzienPracyToUpdate.GodzinaWejscia = dzienPracy.GodzinaWejscia;
                    }
                    else
                    {
                        dzienPracyToUpdate.GodzinaWyjscia = dzienPracy.GodzinaWyjscia;
                    }
                }
                else
                {
                    dzienPracyList.Add(dzienPracy);
                }
            }

            return dzienPracyList;
        }
    }
}
