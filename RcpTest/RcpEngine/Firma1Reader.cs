using RcpTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcpTest.RcpEngine
{
    internal class Firma1Reader : IRcpParser<DzienPracy>
    {
        public IEnumerable<DzienPracy> Read(string[] rcpData)
        {
            var dzienPracyList = new List<DzienPracy>();
            foreach (var line in rcpData)
            {
                var parts = line.Split(';');
                var dzienPracy = new DzienPracy
                {
                    KodPracownika = parts[0],
                    Data = DateTime.Parse(parts[1]),
                    GodzinaWejscia = TimeSpan.Parse(parts[2]),
                    GodzinaWyjscia = TimeSpan.Parse(parts[3])
                };
                
                dzienPracyList.Add(dzienPracy);
                
            }
            return dzienPracyList;
        }
    }
}
