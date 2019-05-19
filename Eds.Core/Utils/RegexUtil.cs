using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eds.Core.Utils
{
    public class RegexUtil
    {
        public void ProcText()
        {
            string msg = "QU SHAITMU  .BJSXCXA 111250  M11  FI MU5734/AN B-5819  DT BJS KWE 111250 M28A  -  POS  CAS 249,LAT N 26.697,LON E105.336,ALT 24600,FOB 9200,UTC 124951  ";
            var mc = Regex.Match(msg, @"ALT\s*(\d+)");
            string tt = mc.Groups[1].Value.ToString();


            string report = "QU SHAITMU  .DDLXCXA 051808  M1E  FI MU717/AN B-2022  DT DDL ORD 051808 M40A  -  ALT LOW  CAS 153,LAT N 41.966,LON W 87.933,ALT 725,FOB 40785,GS  137.56,UTC 180800 ";
            //QU SHAITMU  .BJSXCXA 040432  M1E  FI MU2164/AN B-2375  DT BJS XIY 040432 M69A  -  ALT LOW  CAS 248,LAT N 34.529,LON E108.581,ALT 6760,FOB 11240,GS   274,UTC 04  3209";
            //QU SHAITMU  .BKKXCXA 041112  M1E  FI MU2059/AN B-2375  DT BKK SEL 041112 M94A  -  ALT LOW  CAS 255,LAT N 37.475,LON E127.796,ALT 30991,FOB 19320,GS   481,UTC 1  11206  
            //QU SHAITMU  .BJSXCXA 151028  M1E  FI MU2443/AN B-2375  DT BJS PEK 151028 M02A  -  ALT LOW  CAS 145,LAT N 40.218,LON E116.584,ALT 2175,FOB 13640,GS   144,UTC 10  2813  
            report = Regex.Replace(report, @"[\r\n]", " ");
            var mc2 = Regex.Match(report, @"ALT\s+(\d+),FOB\s+(\d+),GS\s+((\d+).+(\d+)),UTC\s+(\d+)");


            //string msg =rr.name;
            //var cc  = Regex.Match(msg, @"ALT\s*(\d+)");
            //string m11Alt = cc.Groups[1].Value.ToString();

            //string str1="M1E QU SHAITMU  .BJSXCXA 061325  M1E  FI MU2384/AN B-2375  DT BJS HHA 061325 M99A  -  ALT LOW  CAS 186,LAT N 28.251,LON E113.195,ALT 3582,FOB 22360,GS   203,UTC 13  2539 ";
            //string str2 = "M11 QU SHAITMU  .BJSXCXA 061341  M11  FI MU2384/AN B-2375  DT BJS HHA 061341 M17A  -  POS  CAS 297,LAT N 28.874,LON E111.621,ALT 23658,FOB 19640,UTC 134133 ";

            //string msg1 = Regex.Match(str1, @"ALT\s*(\d+)").Groups[1].Value;
            //string msg2 = Regex.Match(str2, @"ALT\s*(\d+)").Groups[1].Value;

            //string report = "NEWDES ZPPP,FOB  124,UTC 082619,ETA 0901";
            //var mc = Regex.Match(report, @"NEWDES\s+([A-Z\-\*]{4}),FOB\s+(\d+),UTC\s+(\d+),ETA\s+(\d+)");


        }

    }
}
