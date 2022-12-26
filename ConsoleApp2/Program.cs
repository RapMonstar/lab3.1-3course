/*3 лаба 
Спроектировать базу (мин 3 таблицы)
1 связь многие ко многим
1 связь 1 ко многим
Далее реализовать консольное приложение, 
которое позволит менять таблички 
(добавить, удалить, обновление и извлечение)*/

using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data.SqlClient;


string connectionString = "Data Source=.\\SQLEXPRESS;Database=TEST_DB;Trusted_Connection=True;";
using (SqlConnection connection = new SqlConnection(connectionString))
{
    await connection.OpenAsync();

    while (true)
    {
        
            Console.Write("Выберите действие: " +
        "1 - добавить" +
        " 2 - удалить" +
        " 3 - извлечь\n");

        int choise = Convert.ToInt32(Console.ReadLine());

        
            if (choise == 1)
            {
                Console.WriteLine("В какую таблицу вы хотите добавить данные?" +
                    " 1 - Person" +
                    " 2 - Position");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Введите PersonId:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите PersonName:");
                    string? name = Console.ReadLine();
                    SqlCommand command = new SqlCommand($"INSERT INTO Person (PersonId, PersonName) VALUES ({id},'{ name }')", connection);
                    Console.WriteLine($"Добавлено {command.ExecuteNonQuery()} строк") ;
                }
                else if (option == 2)
                {
                    Console.WriteLine("Введите PositionId:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите PositionName:");
                    string? name = Console.ReadLine();
                    SqlCommand command = new SqlCommand($"INSERT INTO Position (PositionId, PositionName) VALUES ({id},'{name}')", connection);
                    Console.WriteLine($"Добавлено {command.ExecuteNonQuery()} строк");
                }
            }
            else if (choise == 2)
            {
                Console.WriteLine("В какой таблице вы хотите удалить данные?" +
                    " 1 - Person" +
                    " 2 - Position");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Id какой записи вы хотите удалить?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    SqlCommand command = new SqlCommand($"DELETE FROM Person where PersonId = {id}", connection);
                    Console.WriteLine($"Удалено {command.ExecuteNonQuery()} строк");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Id какой записи вы хотите удалить?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    SqlCommand command = new SqlCommand($"DELETE FROM Position where PositionId = {id}", connection);
                    Console.WriteLine($"Удалено {command.ExecuteNonQuery()} строк");
                }
            }
            else if (choise == 3)
            {
                Console.WriteLine("Какую таблицу вы хотите извлечь?" +
                    " 1 - Person" +
                    " 2 - Position");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    string queryString =
                        "SELECT PersonId, PersonName FROM Person;";
                    SqlCommand command = new SqlCommand(
                            queryString, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}",
                                reader[0], reader[1]));
                        }
                    }
                }
                else if (option == 2)
                {
                    string queryString =
                        "SELECT PositionId, PositionName FROM Position;";
                    SqlCommand command = new SqlCommand(
                            queryString, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}",
                                reader[0], reader[1]));
                        }
                    }
                }
            }
        
        Console.WriteLine("Для продолжения нажмите любую клавишу...");
        Console.ReadLine();
    }
}