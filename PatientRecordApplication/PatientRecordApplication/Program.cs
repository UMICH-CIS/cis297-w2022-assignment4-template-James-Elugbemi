using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\ProgramData\output.txt";
            
            Console.WriteLine("Enter the patient ID>>> ");
            string ID = Console.ReadLine();
            Console.WriteLine("Enter the patient name>>> ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the patient balance>>> ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            Patient medicalRecords = new Patient(ID, name, balance);
            
            string key;
            decimal decKey;

            IDFinder finder = new IDFinder();
            BalFinder bfinder = new BalFinder();
            
            finder.finder(fileName, key);

            Console.WriteLine("\n \n \n");

            bfinder.finder(fileName, decKey);

        }
    }

   
    class Patient
    {
        private string IDnumber;
        private string name;
        private decimal balance;

        public Patient()
        {

        }

        public Patient(string ID, string nym, decimal bal)
        {
            IDnumber = ID;
            name = nym;
            balance = bal;

        }

        public void setID()
        {
            IDnumber = Console.ReadLine();
        }

        public void setName()
        {
            name = Console.ReadLine();
        }

        public void setBalance()
        {
            balance = Convert.ToDecimal(Console.ReadLine());
        }

        public void PatientToFile(string fname)
        {
            if(new FileInfo( fname ).Length == 0)
            {
            File.WriteAllText(fname, IDnumber + "," + name + "," + balance.ToString());
            }
            else
            {
                File.AppendAllText(fname, "\n"+ IDnumber + "," + name + "," + balance.ToString());
            }

        }

        public void ReadFile(string fname)
        {
            Console.WriteLine( File.ReadAllText(fname) );
        }

    }

    class Reader
    {
        public Reader()
        {

        }

        public void readRecords(string file)
        {
            string[] lines = File.ReadAllLines(file);
            Console.WriteLine(String.Join(Environment.NewLine, lines));
        }
    }
    
    class IDFinder
    {
        public IDFinder()
        {

        }

        public void finder(string file, string IDNum)
        {
            string[] lines = File.ReadAllLines(file);
            
            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains(IDNum))
                {
                    Console.WriteLine(lines[i]);
                }
            }

        }



    }

    class BalFinder
    {
        public BalFinder()
        {

        }

        public void finder(string file, decimal balance)
        {
            string[] lines = File.ReadAllLines(file);
            

            for(int i = 0; i < lines.Length; i++)
            {
                decimal result = Convert.ToDecimal( lines[i].Substring( ( lines[i].LastIndexOf(",") + 1 ) ) );
                if(result >= balance)
                {
                    Console.WriteLine(lines[i]);
                }
            }

        }



    }


}
