using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
namespace AIS_exchangeOffice.classes
{
    public class wordOtchets_print
    {
        public void otchetClients_print(string file_path, string[] data)
        {
            try
            {
                int j = data.Length;
                try
                {
                    Word.Application app = new Word.Application();

                    Object wdMiss = System.Reflection.Missing.Value;
                    Document doc = app.Documents.Open(file_path);
                    Range r = doc.Range();

                    Table t = doc.Tables[2];
                    t.Rows.Add(t.Rows[1]);
                    t.Cell(1, 1).Range.Text = "инд. номер";
                    t.Cell(1, 2).Range.Text = "фамилия";
                    t.Cell(1, 3).Range.Text = "имя";
                    t.Cell(1, 4).Range.Text = "отчество";
                    t.Cell(1, 5).Range.Text = "дата рождения";
                    t.Cell(1, 6).Range.Text = "серия паспорта";
                    t.Cell(1, 7).Range.Text = "номер паспорта";

                    for (int i = 0; i < data.Length; i++)
                    {
                        var data_edit = data[i].Split(' ');
                        t.Rows.Add(t.Rows[i + 2]);
                        t.Cell(i + 2, 1).Range.Text = data_edit[0];
                        t.Cell(i + 2, 2).Range.Text = data_edit[1];
                        t.Cell(i + 2, 3).Range.Text = data_edit[2];
                        t.Cell(i + 2, 4).Range.Text = data_edit[3];
                        t.Cell(i + 2, 5).Range.Text = data_edit[4];
                        t.Cell(i + 2, 6).Range.Text = data_edit[5];
                        t.Cell(i + 2, 7).Range.Text = data_edit[6];
                    }
                    var items = new Dictionary<string, string>
                {
                    { "_<date_update>_", DateTime.Now.ToString() }
                };
                    Object missing = Type.Missing;
                    foreach (var item in items)
                    {
                        Word.Find find = app.Selection.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;

                        Object wrap = Word.WdFindWrap.wdFindContinue;
                        Object replace = Word.WdReplace.wdReplaceAll;

                        find.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);
                    }
                    doc.SaveAs(Environment.CurrentDirectory + "\\wordDocs\\" + DateTime.Now.ToString("yyyMMdd_HHmmss_") + "otchetClients.docx");
                    app.Visible = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
        }
        public void otchetBuyValues_print(string file_path, string[] data)
        {
            try
            {
                int j = data.Length;
                try
                {
                    Word.Application app = new Word.Application();

                    Object wdMiss = System.Reflection.Missing.Value;
                    Document doc = app.Documents.Open(file_path);
                    Range r = doc.Range();

                    Table t = doc.Tables[2];
                    t.Rows.Add(t.Rows[1]);
                    t.Cell(1, 1).Range.Text = "инд. номер";
                    t.Cell(1, 2).Range.Text = "фамилия";
                    t.Cell(1, 3).Range.Text = "имя";
                    t.Cell(1, 4).Range.Text = "отчество";
                    t.Cell(1, 5).Range.Text = "валюта";
                    t.Cell(1, 6).Range.Text = "количество валюты";
                    t.Cell(1, 7).Range.Text = "сумма";
                    t.Cell(1, 8).Range.Text = "точная дата";
                    for (int i = 0; i < data.Length; i++)
                    {
                        var data_edit = data[i].Split(' ');
                        t.Rows.Add(t.Rows[i + 2]);
                        t.Cell(i + 2, 1).Range.Text = data_edit[0];
                        t.Cell(i + 2, 2).Range.Text = data_edit[1];
                        t.Cell(i + 2, 3).Range.Text = data_edit[2];
                        t.Cell(i + 2, 4).Range.Text = data_edit[3];
                        t.Cell(i + 2, 5).Range.Text = data_edit[4];
                        t.Cell(i + 2, 6).Range.Text = data_edit[5];
                        t.Cell(i + 2, 7).Range.Text = data_edit[6];
                        t.Cell(i + 2, 8).Range.Text = data_edit[7] + " " + data_edit[8];
                    }
                    var items = new Dictionary<string, string>
                {
                    { "_<date_update>_", DateTime.Now.ToString() }
                };
                    Object missing = Type.Missing;
                    foreach (var item in items)
                    {
                        Word.Find find = app.Selection.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;

                        Object wrap = Word.WdFindWrap.wdFindContinue;
                        Object replace = Word.WdReplace.wdReplaceAll;

                        find.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);
                    }
                    doc.SaveAs(Environment.CurrentDirectory + "\\wordDocs\\" + DateTime.Now.ToString("yyyMMdd_HHmmss_") + "otchetBuyValues.docx");
                    app.Visible = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
        }
        public void otchetSellValues_print(string file_path, string[] data)
        {
            try
            {
                int j = data.Length;
                try
                {
                    Word.Application app = new Word.Application();

                    Object wdMiss = System.Reflection.Missing.Value;
                    Document doc = app.Documents.Open(file_path);
                    Range r = doc.Range();

                    Table t = doc.Tables[2];
                    t.Rows.Add(t.Rows[1]);
                    t.Cell(1, 1).Range.Text = "инд. номер";
                    t.Cell(1, 2).Range.Text = "фамилия";
                    t.Cell(1, 3).Range.Text = "имя";
                    t.Cell(1, 4).Range.Text = "отчество";
                    t.Cell(1, 5).Range.Text = "валюта";
                    t.Cell(1, 6).Range.Text = "количество валюты";
                    t.Cell(1, 7).Range.Text = "сумма";
                    t.Cell(1, 8).Range.Text = "точная дата";
                    for (int i = 0; i < data.Length; i++)
                    {
                        var data_edit = data[i].Split(' ');
                        t.Rows.Add(t.Rows[i + 2]);
                        t.Cell(i + 2, 1).Range.Text = data_edit[0];
                        t.Cell(i + 2, 2).Range.Text = data_edit[1];
                        t.Cell(i + 2, 3).Range.Text = data_edit[2];
                        t.Cell(i + 2, 4).Range.Text = data_edit[3];
                        t.Cell(i + 2, 5).Range.Text = data_edit[4];
                        t.Cell(i + 2, 6).Range.Text = data_edit[5];
                        t.Cell(i + 2, 7).Range.Text = data_edit[6];
                        t.Cell(i + 2, 8).Range.Text = data_edit[7] + " " + data_edit[8];
                    }
                    var items = new Dictionary<string, string>
                {
                    { "_<date_update>_", DateTime.Now.ToString() }
                };
                    Object missing = Type.Missing;
                    foreach (var item in items)
                    {
                        Word.Find find = app.Selection.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;

                        Object wrap = Word.WdFindWrap.wdFindContinue;
                        Object replace = Word.WdReplace.wdReplaceAll;

                        find.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);
                    }
                    doc.SaveAs(Environment.CurrentDirectory + "\\wordDocs\\" + DateTime.Now.ToString("yyyMMdd_HHmmss_") + "otchetSellValues.docx");
                    app.Visible = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
        }
    }
}

