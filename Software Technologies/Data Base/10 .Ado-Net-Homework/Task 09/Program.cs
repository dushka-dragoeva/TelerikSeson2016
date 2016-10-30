using System;
using MySql.Data.MySqlClient;

namespace Task_09
{
    public class Program
    {
        public static void Main()
        {
            /// 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + 
            /// MySQL Workbench GUI administration tool.
            /// Create a MySQL database to store Books(title, author, publish date and ISBN).
            /// Write methods for listing all books, finding a book by name and adding a book.
            Console.WriteLine("Please enter pass");
            string pass = Console.ReadLine();

            string connectionString = "Server=localhost;Database=Library;Uid=root;Pwd=" + pass + ";";
            MySqlConnection dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                int newBook = AddNewBookToDBTable(dbConnection, "King Lion", "James Clavel", DateTime.Parse("2015.10.10"), 1234567890123);
                int newBook1 = AddNewBookToDBTable(dbConnection, "Untouchables", "Unknown", DateTime.Parse("2015.10.10"), 1234567890123);
                int newBook2 = AddNewBookToDBTable(dbConnection, "C# intro", "Svetlin Nakov", DateTime.Parse("2015.10.10"), 1234567890123);
                System.Console.WriteLine("Inserted new product with Id: {0}", newBook);
                Console.WriteLine(new string('-', 30));

                ListAllBooksFromDBTable(dbConnection);
                Console.WriteLine(new string('-', 30));

                Console.Write("Please enter text to search a book:");
                string input = Console.ReadLine();
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("Products that contain: {0}", input);
                SearchAllBooksThatContainString(dbConnection, input);
            }
        }

        private static void SearchAllBooksThatContainString(MySqlConnection dbConnection, string input)
        {
            input = EscapeInputString(input);

            string sqlStringCommand = string.Format(
                @"
                    SELECT title
                    FROM Books
                    WHERE title LIKE '%{0}%'", 
                input);

            MySqlCommand allProducts = new MySqlCommand(sqlStringCommand, dbConnection);
            MySqlDataReader reader = allProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string bookName = (string)reader["title"];
                    Console.WriteLine("{0}", bookName);
                }
            }
        }

        private static string EscapeInputString(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'')
                {
                    input = input.Substring(0, i) + "'" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '_')
                {
                    input = input.Substring(0, i) + "/" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '%')
                {
                    input = input.Substring(0, i) + "\\" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '&')
                {
                    input = input.Substring(0, i) + "\\" + input.Substring(i, input.Length - i);
                    i++;
                }
            }

            return input;
        }

        private static void ListAllBooksFromDBTable(MySqlConnection dbConnection)
        {
            string sqlStringCommand = @"
                    SELECT * FROM Books";

            MySqlCommand allBooks = new MySqlCommand(sqlStringCommand, dbConnection);
            MySqlDataReader reader = allBooks.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    Console.WriteLine("{0} -> {1}, {2}, {3}", title, author, publishDate.ToString(), reader["isbn"]);
                }
            }
        }

        private static int AddNewBookToDBTable(MySqlConnection dbConnection, string title, string author, DateTime publishDate, ulong isbn)
        {
            string sqlStringCommand = @"
                    INSERT INTO Books(title, author, publishDate, isbn)
                    VALUES (@title, @author, @publishDate, @isbn)";

            MySqlCommand insertBook = new MySqlCommand(sqlStringCommand, dbConnection);
            insertBook.Parameters.AddWithValue("@title", title);
            insertBook.Parameters.AddWithValue("@author", author);
            insertBook.Parameters.AddWithValue("@publishDate", publishDate);
            insertBook.Parameters.AddWithValue("@isbn", isbn);

            insertBook.ExecuteNonQuery();

            return (int)insertBook.LastInsertedId;
        }
    }
}