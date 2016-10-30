using System;
using System.Data.OleDb;

namespace Task_06_07
{
    public class Program
    {
        private const string ConnectionString =
               @"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source=..\..\nameAndScore.xlsx;
                Extended Properties = ""Excel 12.0 Xml;HDR=YES"";";

        private static readonly string Separator = new string('-', 40);

        private static OleDbConnection dbCon;

        private static void Main()
        {
            dbCon = new OleDbConnection(ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                /// 06. Create an Excel file with 2 columns: name and score:
                /// Write a program that reads your MS Excel file through the OLE DB data provider
                /// and displays the name and score row by row.
                ReadDataFromExelFile(dbCon);
                Console.WriteLine(Separator);

                /// 07.Implement appending new rows to the Excel file.
                AddRowToExelfile(dbCon, "Petia Milanova", 33);
            }
        }

        private static void AddRowToExelfile(OleDbConnection dbCon, string name, double score)
        {
            string addStringComand = string.Format("INSERT INTO [Sheet1$](Name,Score) VALUES ('{0}', '{1}')", name, score);
            OleDbCommand addComand = new OleDbCommand(addStringComand, dbCon);
            string success = "Row added.";
            string exeptionString = " Exel error occur: ";

            try
            {
                addComand.ExecuteNonQuery();
                Console.WriteLine(success);
            }
            catch (OleDbException exeption)
            {
                Console.WriteLine(exeptionString, exeption);
            }
        }

        private static void ReadDataFromExelFile(OleDbConnection dbCon)
        {
            string stringCommand = @"SELECT * FROM [Sheet1$]";
            OleDbCommand xslCommand = new OleDbCommand(stringCommand, dbCon);
            OleDbDataReader reader = xslCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("{0} - {1}", name, score);
                }
            }
        }
    }
}
