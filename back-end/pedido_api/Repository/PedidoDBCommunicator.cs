using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using pedido_api.Dto;
using pedido_api.Entities;

namespace pedido_api.Repository
{
    public class PedidoDBCommunicator
    {
        public string conn_s = "server=localhost;database=pedidodb;uid=main;pwd=161099;port=3306";
        //IEnumerable<string>
        public List<PedidoGetDto> GetAll()
        {
            List<PedidoGetDto> pedidos = new List<PedidoGetDto>();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conn_s;
            MySqlCommand command = new MySqlCommand("SELECT * FROM pedido", conn);
            conn.Open();
            MySqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                string aux = " ";
                if (Convert.ToDateTime(data["data_vencimento"]).Date.Subtract(DateTime.Now).TotalDays <= 0)
                {
                    aux = "vencido";
                }
                else if (Convert.ToDateTime(data["data_vencimento"]).Date.Subtract(DateTime.Now).TotalDays <= 3)
                {
                    aux = "quase vencendo";
                }
                else
                {
                    aux = "válido";
                }
                PedidoGetDto pdto = new PedidoGetDto(Convert.ToInt32(data["id"]), data["nome_produto"].ToString(), Convert.ToDecimal(data["valor"]), Convert.ToDateTime(data["data_vencimento"]), aux);
                pedidos.Add(pdto);
            }
            conn.Close();
            return pedidos;
        }
        
        public PedidoGetDto GetPorId(int Id)
        {
            
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conn_s;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM pedido WHERE pedido.id = {Id}", conn);
            conn.Open();
            MySqlDataReader data = command.ExecuteReader();
            Boolean nulo = data.Read();
            if (!nulo)
            {
                return null;
            }
            string aux = " ";
            if (Convert.ToDateTime(data["data_vencimento"]).Date.Subtract(DateTime.Now).TotalDays <= 0)
            {
                aux = "vencido";
            }
            else if (Convert.ToDateTime(data["data_vencimento"]).Date.Subtract(DateTime.Now).TotalDays <= 3)
            {
                aux = "quase vencendo";
            }
            else
            {
                aux = "válido";
            }
            PedidoGetDto pdto = new PedidoGetDto(Convert.ToInt32(data["id"]), data["nome_produto"].ToString(), Convert.ToDecimal(data["valor"]), Convert.ToDateTime(data["data_vencimento"]), aux);
            conn.Close();
            return pdto;
        }

        public int PostEspecifico(PedidoPostDto PPost)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conn_s;
            MySqlCommand command = new MySqlCommand("INSERT INTO pedido VALUES(NULL, @nome, @valor, @data)", conn);
            command.Parameters.AddWithValue("@nome", PPost.NomeProduto);
            command.Parameters.AddWithValue("@valor", PPost.Valor);
            command.Parameters.AddWithValue("@data", PPost.DataVencimento);
            conn.Open();
            int data = command.ExecuteNonQuery();
            MySqlCommand command2 = new MySqlCommand("SELECT MAX(id) FROM pedido", conn);
            MySqlDataReader data2 = command2.ExecuteReader();
            data2.Read();
            int ret = Convert.ToInt32(data2[0]);
            conn.Close();
            return ret;
        }

        public Boolean PutEspecifico(int id, PedidoGetDto PPut)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conn_s;
            MySqlCommand command = new MySqlCommand($"UPDATE pedido SET nome_produto = @nome, valor = @valor, data_vencimento = @data WHERE id = {id}", conn);
            command.Parameters.AddWithValue("@nome", PPut.NomeProduto);
            command.Parameters.AddWithValue("@valor", PPut.Valor);
            command.Parameters.AddWithValue("@data", PPut.DataVencimento);
            conn.Open();
            int data = command.ExecuteNonQuery();
            if (data > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean DeleteEspecifico(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = conn_s;
            MySqlCommand command = new MySqlCommand($"DELETE FROM pedido WHERE id = {id}", conn);
            conn.Open();
            int data = command.ExecuteNonQuery();
            if (data > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
            
    }
        
}
