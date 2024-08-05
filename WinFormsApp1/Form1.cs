using Npgsql;
using NpgsqlTypes;
using OfficeOpenXml;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection();

        List<string> resultados = new List<string>();
        TabelaMeli tabelaMeli = new TabelaMeli();
        string connectionString;
        public Form1()
        {
            InitializeComponent();
            connectionString = "Host=xxx;Port=5433;Database=xxx;Username=xxx;Password=xxx;";
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
                MessageBox.Show("Conexão realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de conexão com o banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conn.Close();
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Consultar_Click(object sender, EventArgs e)
        {

            string skus = richTextBox1.Text;
            List<string> skuList = skus.Split(',').Select(s => s.Trim()).ToList();

            string skuValues = string.Join(",", skuList.Select(s => $"'{s}'"));
            string query = $"SELECT codigo_auxiliar, altura, largura, comprimento,\n" +
                           $"peso_bruto, descricao_reduzida\n" +
                           $"FROM sysemp.produto WHERE codigo_auxiliar IN ({skuValues})";
            DatabaseConnection dbConnection = new DatabaseConnection(connectionString);

            dbConnection.ExecuteQuery(query);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string sku = reader.GetString(0);
                            decimal altura = reader.GetDecimal(1);
                            decimal largura = reader.GetDecimal(2);
                            decimal comprimento = reader.GetDecimal(3);
                            decimal pesoBruto = reader.GetDecimal(4);
                            string descricao = reader.GetString(5);

                            double pesoBrutoDouble = Convert.ToDouble(pesoBruto);
                            double valorFreteDouble = tabelaMeli.TabMeliFull(pesoBrutoDouble);



                            string resultado = $"SKU: {sku}, " +
                             $" Altura: {altura.ToString(CultureInfo.InvariantCulture)}, " +
                             $" Largura: {largura.ToString(CultureInfo.InvariantCulture)}, " +
                             $" Comprimento: {comprimento.ToString(CultureInfo.InvariantCulture)}, " +
                             $" Peso bruto: {pesoBruto.ToString(CultureInfo.InvariantCulture)}, " +
                             $" Descrição: {descricao}, " +
                             $" Valor do frete: {valorFreteDouble.ToString(CultureInfo.InvariantCulture)}\n";

                            resultados.Add(resultado);
                        }
                    }
                }
            }

            richTextBox2.Text = string.Join(Environment.NewLine, resultados);


        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            resultados.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btExExcel_Click(object sender, EventArgs e)
        {
            try
            {

                string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pastaMeuApp = Path.Combine(pastaDocumentos, "MeuApp");


                if (!Directory.Exists(pastaMeuApp))
                {
                    Directory.CreateDirectory(pastaMeuApp);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string caminhoArquivo = Path.Combine(pastaMeuApp, $"arquivo_{timestamp}.xlsx");


                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


                ExportaExcel1 exportador = new ExportaExcel1();
                exportador.ExportarResultadosParaExcel(resultados, caminhoArquivo);
                MessageBox.Show("Download executado com sucesso para a pasta Meus Documentos / MeuApp", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
