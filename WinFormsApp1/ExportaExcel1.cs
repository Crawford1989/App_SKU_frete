using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OfficeOpenXml;

namespace WinFormsApp1
{
    internal class ExportaExcel1
    {
        public void ExportarResultadosParaExcel(List<string> resultados, string caminhoArquivo)
        {
            using (var excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Seu Nome";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                
                var worksheet = excelPackage.Workbook.Worksheets.Add("Resultados");
                worksheet.Cells["A1"].Value = "SKU";
                worksheet.Cells["B1"].Value = "Altura";
                worksheet.Cells["C1"].Value = "Largura";
                worksheet.Cells["D1"].Value = "Comprimento";
                worksheet.Cells["E1"].Value = "Peso bruto";
                worksheet.Cells["F1"].Value = "Descrição";
                worksheet.Cells["G1"].Value = "Valor do frete";

                
                for (int i = 0; i < resultados.Count; i++)
                {
                    string resultado = resultados[i];
                    string[] campos = resultado.Split(new[] { ", " }, StringSplitOptions.None);

                    worksheet.Cells[i + 2, 1].Value = campos[0].Replace("SKU: ", "").Trim();

                    
                    if (decimal.TryParse(campos[1].Replace("Altura: ", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal altura))
                    {
                        worksheet.Cells[i + 2, 2].Value = altura;
                    }
                    else
                    {
                        worksheet.Cells[i + 2, 2].Value = "Erro";
                    }

                    if (decimal.TryParse(campos[2].Replace("Largura: ", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal largura))
                    {
                        worksheet.Cells[i + 2, 3].Value = largura;
                    }
                    else
                    {
                        worksheet.Cells[i + 2, 3].Value = "Erro";
                    }

                    if (decimal.TryParse(campos[3].Replace("Comprimento: ", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal comprimento))
                    {
                        worksheet.Cells[i + 2, 4].Value = comprimento;
                    }
                    else
                    {
                        worksheet.Cells[i + 2, 4].Value = "Erro";
                    }

                    if (decimal.TryParse(campos[4].Replace("Peso bruto: ", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal pesoBruto))
                    {
                        worksheet.Cells[i + 2, 5].Value = pesoBruto;
                    }
                    else
                    {
                        worksheet.Cells[i + 2, 5].Value = "Erro";
                    }

                    worksheet.Cells[i + 2, 6].Value = campos[5].Replace("Descrição: ", "").Trim();

                   
                    string valorFreteStr = campos[6].Replace("Valor do frete: ", "").Trim();
                    if (double.TryParse(valorFreteStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double valorFrete))
            {
                worksheet.Cells[i + 2, 7].Value = valorFrete;
            }
            else
            {
                Console.WriteLine($"Erro ao converter o valor do frete: {valorFreteStr}");
                worksheet.Cells[i + 2, 7].Value = valorFrete;
            }

                    
                    worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[i + 2, 3].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[i + 2, 4].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[i + 2, 5].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[i + 2, 7].Style.Numberformat.Format = "#,##0.00";
                }


                
                File.WriteAllBytes(caminhoArquivo, excelPackage.GetAsByteArray());

                Console.WriteLine($"Arquivo salvo em: {caminhoArquivo}");
            }
        }
    }
}
