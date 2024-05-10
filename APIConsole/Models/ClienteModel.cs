using APIConsole.Services;
using System.Data.SqlClient;
using System.Text;

namespace APIConsole.Models
{
    public class ClienteModel
    {
        public List<object> GetClientes(int codigo)
        {

            List<object> lista = [];

            try
            {
                StringBuilder sql = new("select codigo_cli , cgccpf_cli, nome_cli, cidade_cli from ACLIENGE where codigo_cli = @ID");

                using (SqlConnection conexao = new(Database.GetConnectionString()))
                {
                    conexao.Open();

                    SqlCommand comando = new(sql.ToString(), conexao);

                    comando.Parameters.AddWithValue("@ID", codigo);

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        // Adiciona os resultados em um objeto anônimo
                        var result = new
                        {
                            id = reader.GetString(0),
                            codigo = reader.GetString(1),
                            cnpj_cpf = reader.GetString(2),
                            nome = reader.GetString(3),
                        };

                        lista.Add(result);
                    }
                }
                
                return lista;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return lista;
            }
        }
    }
}
