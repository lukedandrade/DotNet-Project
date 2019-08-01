using System.Data.SqlClient;
using DotNet_Project.models;
using System.Data.SQLite;

namespace DbHandler
{

    public class Handler{
        public string data_source {get; set;}
        public string initial_catalog {get; set;}
        public string user_id {get; set;}
        private string password {get; set;}

        public Handler(string d_s, string i_c, string u_i, string p){
           this.data_source = d_s;
           this.initial_catalog = i_c;
           this.user_id = u_i;
           this.password = p;
        }

        public DotNet_Project.models.Carta SearchCard(string cardname){
            Carta my_card = new Carta();
            string conn_string = $"Data Source={this.data_source};Initial Catalogue={this.initial_catalog};User ID={this.user_id};Password={this.password}";
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand order = new SqlCommand(
                "SELECT * FROM Carta WHERE name=@nome_da_carta FETCH FIRST", conn
            );
            order.Parameters.Add(new SqlParameter("nome_da_carta", cardname));
            SqlDataReader reader = order.ExecuteReader();

            if (reader.Read()){
                while(reader.Read()){
                    my_card.id = reader.GetInt64(0);
                    my_card.name = reader.GetString(1);
                    my_card.url = reader.GetString(2);
                }
                conn.Close();
                return my_card;
            }
            else{
                conn.Close();
                my_card.id = 0;
                my_card.name = "Não encontrada";
                my_card.url = "Não encontrada";
                return my_card;
            }
            
        }

        public string InsertCard(Carta my_card){
            string conn_string = $"Data Source={this.data_source};Initial Catalogue={this.initial_catalog};User ID={this.user_id};Password={this.password}";
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            try{
                SqlCommand order = new SqlCommand(
                    "INSERT INTO Carta (name, url) VALUES (@name, @url)", conn
                );
                order.Parameters.Add(new SqlParameter("name", my_card.name));
                order.Parameters.Add(new SqlParameter("url", my_card.url));
                order.ExecuteNonQuery();
                conn.Close();        
                return "Carta Inserida";
            }
            catch (SqlException er){
                conn.Close();
                return "Falha na inserção";
            }
        }

        public DotNet_Project.models.Carta LiteSearchCard(string cardname){
            Carta my_card = new Carta();
            string conn_string = $"Data Source={this.data_source};";
            SQLiteConnection conn = new SQLiteConnection(conn_string);
            conn.Open();
            SQLiteCommand order = new SQLiteCommand(
                "SELECT * FROM Carta WHERE name=@nome_da_carta FETCH FIRST", conn
            );
            order.Parameters.Add(new SQLiteParameter("nome_da_carta", cardname));
            SQLiteDataReader reader = order.ExecuteReader();

            if (reader.Read()){
                while(reader.Read()){
                    my_card.id = reader.GetInt64(0);
                    my_card.name = reader.GetString(1);
                    my_card.url = reader.GetString(2);
                }
                conn.Close();
                return my_card;
            }
            else{
                conn.Close();
                my_card.id = 0;
                my_card.name = "Não encontrada";
                my_card.url = "Não encontrada";
                return my_card;
            }
        }

        public string LiteInsertCard(Carta my_card){
            string conn_string = $"Data Source={this.data_source};";
            SQLiteConnection conn = new SQLiteConnection(conn_string);
            conn.Open();
            try{
                SQLiteCommand order = new SQLiteCommand(
                    "INSERT INTO Carta (name, url) VALUES (@name, @url)", conn    
                );
                order.Parameters.Add(new SQLiteParameter("name", my_card.name));
                order.Parameters.Add(new SQLiteParameter("url", my_card.url));
                order.ExecuteNonQuery();
                conn.Close();
                return "Carta Inserida";
            }
            catch (SQLiteException er){
                conn.Close();
                return "Falha na inserção";
            }
            

        }
    }
}