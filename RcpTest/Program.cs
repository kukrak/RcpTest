using NLog;
using RcpTest.RcpEngine;

namespace RcpTest
{
    internal class Program
    {
        static Logger _logger  = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            _logger.Info("Start");
            _logger.Info("Firma1");
            try
            {
                //get all files with .csv extension from directory
                var firma1Files = Directory.GetFiles(@"C:\Users\kubak\source\repos\RcpTest\RcpTest\InputData\Firma1\", "*.csv");
                foreach (var file in firma1Files)
                {
                    var rcpData = File.ReadAllLines(file);
                    var firma1Reader = new Firma1Reader();
                    var dzienPracyList = firma1Reader.Read(rcpData);
                    foreach (var dzienPracy in dzienPracyList)
                    {
                        _logger.Info($"KodPracownika: {dzienPracy.KodPracownika}, Data: {dzienPracy.Data}, GodzinaWejscia: {dzienPracy.GodzinaWejscia}, GodzinaWyjscia: {dzienPracy.GodzinaWyjscia}");
                    }
                }

                _logger.Info("Firma2");
                var firma2Files = Directory.GetFiles(@"C:\Users\kubak\source\repos\RcpTest\RcpTest\InputData\Firma2\", "*.csv");
                foreach (var file in firma2Files)
                {
                    var rcpData = File.ReadAllLines(file);
                    var firma2Reader = new Firma2Reader();
                    var dzienPracyList = firma2Reader.Read(rcpData);
                    foreach (var dzienPracy in dzienPracyList)
                    {
                        _logger.Info($"KodPracownika: {dzienPracy.KodPracownika}, Data: {dzienPracy.Data}, GodzinaWejscia: {dzienPracy.GodzinaWejscia}, GodzinaWyjscia: {dzienPracy.GodzinaWyjscia}");
                    }
                }
                
            }
            catch (Exception ex)
            {

                _logger.Error(ex.Message);
            }


            _logger.Info("End");
        }
    }
}