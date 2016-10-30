using System;
using System.Data.SqlClient;
using System.IO;

namespace Task_01_05_and_08
{
    public class Program
    {
        private const string ConnectionString = "Server=.; database=NORTHWND; Integrated Security=true";
        private static readonly string Separator = new string('-', 40);

        private static SqlConnection dbCon;

        public static void Main()
        {
            dbCon = new SqlConnection(ConnectionString);
            dbCon.Open();

            Console.WriteLine("Conection is open");

            using (dbCon)
            {
                /// 01. Write a program that retrieves from the Northwind sample database in MS SQL Server the number
                /// of rows in the Categories table.
                RetrieveNumberOfRows(dbCon);

                /// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.
                RetriveCategoriesNameAnddescription(dbCon);

                /// 03. Write a program that retrieves from the Northwind database all product 
                /// categories and the names of the products in each category.
                /// Can you do this with a single SQL query (with table join)?
                RetriveCategoriesAndProducts(dbCon);

                /// 04. Write a method that adds a new product in the products table in the Northwind database.
                /// Use a parameterized SQL command.
                int newProductID = AddProductToDBTable(dbCon, "NewProduct", 1, 1, "10x5", 15.35m, 10, 0, 0, false);
                Console.WriteLine("NewProduct id is {0}.", newProductID);
                Console.WriteLine(Separator);

                /// 05. Write a program that retrieves the images for all categories in the Northwind database 
                /// and stores them as JPG files in the file system.
                RetriveImigiesForCategories(dbCon);
                Console.WriteLine("Pictures are in folder images.");

                /// 08. Write a program that reads a string from the console and finds all products that contain this string.
                /// Ensure you handle correctly characters like ', %, ", \ and _.

                Console.WriteLine("Enter text for searching in products: ");
                string input = Console.ReadLine();
                SearchProductsContainingString(dbCon, input);
            }
        }

        public static void SearchProductsContainingString(SqlConnection dbCon, string input)
        {
            string escapedInput = EscapeSpacialCharactersFromInput(input);

            string sqlStringCommand = string.Format(
                @"
            SELECT ProductName
            FROM Products
            WHERE ProductName LIKE '%{0}%'", 
            escapedInput);

            SqlCommand allProducts = new SqlCommand(sqlStringCommand, dbCon);
            SqlDataReader reader = allProducts.ExecuteReader();

            while (reader.Read())
            {
                string productName = (string)reader["ProductName"];
                Console.WriteLine("{0}", productName);
            }
        }

        public static string EscapeSpacialCharactersFromInput(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'')
                {
                    input = input.Substring(0, i) + "'" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '%')
                {
                    input = input.Substring(0, i) + "\\" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '\\')
                {
                    input = input.Substring(0, i) + "/" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '_')
                {
                    input = input.Substring(0, i) + "/" + input.Substring(i, input.Length - i);
                    i++;
                }
            }

            return input;
        }

        public static void RetriveImigiesForCategories(SqlConnection dbCon)
        {
            string sqlStringCommand = "SELECT CategoryName,Picture From Categories";
            SqlCommand allPictures = new SqlCommand(sqlStringCommand, dbCon);
            SqlDataReader reader = allPictures.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    categoryName = categoryName.Replace('/', '_');
                    byte[] fileContent = (byte[])reader["Picture"];
                    string imageFileName = string.Format(@"..\..\images\{0}.jpg", categoryName);
                    WriteBinaryFile(imageFileName, fileContent);
                }
            }
        }

        private static void WriteBinaryFile(string imageFileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(imageFileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        private static int AddProductToDBTable(
            SqlConnection dbCon,
            string productName,
            int supplierID,
            int categoryID,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued)
        {
            string sqlStringCommand = @"
                INSERT INTO Products(productName, supplierID, categoryID, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder,reorderLevel, discontinued)
                VALUES(@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder,@reorderLevel, @discontinued)";

            SqlCommand addProducts = new SqlCommand(sqlStringCommand, dbCon);
            addProducts.Parameters.AddWithValue("@productName", productName);
            addProducts.Parameters.AddWithValue("@supplierID", supplierID);
            addProducts.Parameters.AddWithValue("@categoryID", categoryID);
            addProducts.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            addProducts.Parameters.AddWithValue("@unitPrice", unitPrice);
            addProducts.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            addProducts.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            addProducts.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            addProducts.Parameters.AddWithValue("@discontinued", discontinued);

            addProducts.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordID = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordID;
        }

        private static void RetriveCategoriesAndProducts(SqlConnection dbCon)
        {
            string sqlStringCommand = @"
                SELECT c.CategoryName, p.ProductName
                FROM Categories c
                JOIN Products p
                ON c.CategoryID=p.CategoryID
                ORDER BY c.CategoryName";

            SqlCommand allCategoriesAndProducts = new SqlCommand(sqlStringCommand, dbCon);
            SqlDataReader reader = allCategoriesAndProducts.ExecuteReader();
            string stringFormat = "{0} ---> {1}";

            using (reader)
            {
                while (reader.Read())
                {
                    string category = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];

                    Console.WriteLine(stringFormat, category, product);
                }
            }

            Console.WriteLine(Separator);
        }

        private static void RetriveCategoriesNameAnddescription(SqlConnection dbCon)
        {
            string sqlStringCommand =
                        " SELECT [CategoryName], [Description] FROM Categories";

            SqlCommand sqlCommand =
                new SqlCommand(sqlStringCommand, dbCon);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string stringFormat = "{0} ---> {1}";

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine(stringFormat, categoryName, description);
                }
            }

            Console.WriteLine(Separator);
        }

        private static void RetrieveNumberOfRows(SqlConnection dbCon)
        {
            string sqlStringCommand = "SELECT COUNT(*) FROM Categories";
            string stringFormat = "Categories number of rows is {0}";
            SqlCommand cmdCountRows = new SqlCommand(sqlStringCommand, dbCon);

            int categoriesRowsCount = (int)cmdCountRows.ExecuteScalar();

            Console.WriteLine();
            Console.WriteLine(stringFormat, categoriesRowsCount);
            Console.WriteLine(Separator);
        }
    }
}