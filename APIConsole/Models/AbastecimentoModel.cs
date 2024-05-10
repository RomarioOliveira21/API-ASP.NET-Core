using APIConsole.Services;
using System.Data.SqlClient;
using System.Text;

namespace APIConsole.Models
{
    public class AbastecimentoModel
    {
        public List<object> GetAbastecimentosPorBico(int bico)
        {
            StringBuilder sql = new("SELECT A.AV_AUT as 'ID',A.AE_AUT as 'BICO',A.AF_AUT as 'QTD',A.AG_AUT as 'VALOR_UNIT',");

            sql.Append(" A.AH_AUT as 'TOTAL',A.AI_AUT as 'DATA',A.AJ_AUT as 'HORA',A.AB_AUT as 'STATUS',A.VENDEDOR_AUT as 'VENDEDOR',A.ECFSELECAO_AUT,");
            sql.Append(" CONVERT(varchar, A.AU_AUT, 103) AS 'DATA_ABS',V.nome_ven,CARTAO_AUT FROM AAUTOMPO A WITH (NOLOCK)");
            sql.Append(" LEFT JOIN AVENDEGE V ON A.VENDEDOR_AUT = V.codigo_ven");
            sql.Append(" WHERE ((COALESCE(AB_AUT,'')='' OR AB_AUT = NULL) OR (AB_AUT = 0)) AND COALESCE(SPAGO_AUT,'')=''");
            sql.Append(" AND A.AE_AUT = @Bico ORDER BY AV_AUT DESC");

            SqlConnection conexao = new(Database.GetConnectionString());
            conexao.Open();

            SqlCommand comando = new(sql.ToString(), conexao);

            comando.Parameters.AddWithValue("@Bico", bico);

            SqlDataReader reader = comando.ExecuteReader();

            List<object> lista = [];

            while (reader.Read())
            {
                // Adiciona os resultados em um objeto anônimo
                var result = new
                {
                    id = reader.GetInt32(0),
                    bico = reader.GetString(1),
                    quantidade = reader.GetDecimal(2),
                    valor_unitario = reader.GetDecimal(3),
                    valor_total = reader.GetDecimal(4),
                    data = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    hora = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    status = reader.IsDBNull(7) ? "" : reader.GetString(7),
                    codigo_frentista = reader.IsDBNull(8) ? "" : reader.GetString(8)

                };

                lista.Add(result);
            }

            reader.Close();
            conexao.Close();
            return lista;
        }
    }
}
