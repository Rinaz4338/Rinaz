using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rinaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            Fill();
        }
        public void Fill()
        {
            sp_grid.ItemsSource = DK_R.GetContext().Prepods.ToList();
            cp_grid.ItemsSource = DK_R.GetContext().ContactPerson.ToList();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cp_grid.SelectedItem != null) { Delete_w d = new Delete_w(cp_grid.SelectedItem,"ContactPerson"); d.Show(); }
            else if (sp_grid.SelectedItem != null) { Delete_w p = new Delete_w(sp_grid.SelectedItem,"Prepod");p.Show(); }
            else { MessageBox.Show("Выберите строку"); } 
                
        }
           

        private void sp_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void update_b_Click(object sender, RoutedEventArgs e)
        {
            Filll();
        }
        void Filll()
        {
            DK_R m = new DK_R();
            var q = from Prepods in m.Prepods select Prepods;
            sp_grid.ItemsSource = q.ToList();
            var qq = from ContactPerson in m.ContactPerson select ContactPerson;
            cp_grid.ItemsSource = qq.ToList();
        }

        private void addd_prepod_Click(object sender, RoutedEventArgs e)
        {
            add_prepod a = new add_prepod();
            a.Show();
        }

        private void upd_prepod_Click(object sender, RoutedEventArgs e)
        {
            if (sp_grid.SelectedItem != null)
            {
                update_prepod u = new update_prepod(sp_grid.SelectedItem);
                u.Show();
            }
            else{
                MessageBox.Show("Выбрана другая таблица");

            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            List<Prepods> prepods;
            
            using (DK_R usersEntities = new DK_R())
            {
                prepods = usersEntities.Prepods.ToList().OrderBy(s => s.FIO).ToList();
               
                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                Word.Paragraph paragraph =
                document.Paragraphs.Add();
                Word.Range range = paragraph.Range;
                range.Text = Convert.ToString(prepods.FirstOrDefault().FIO);
                paragraph.set_Style("Заголовок 1");
                range.InsertParagraphAfter();
                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table studentsTable =
                document.Tables.Add(tableRange, prepods.Count() + 1, 11);
                studentsTable.Borders.InsideLineStyle =
                studentsTable.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
                studentsTable.Range.Cells.VerticalAlignment =
                Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = studentsTable.Cell(1, 1).Range;
                cellRange.Text = "id";
                cellRange = studentsTable.Cell(1, 2).Range;
                cellRange.Text = "Серия паспорта";
                cellRange = studentsTable.Cell(1, 3).Range;
                cellRange.Text = "Номер_паспорта";
                cellRange = studentsTable.Cell(1, 4).Range;
                cellRange.Text = "ФИО";
                cellRange = studentsTable.Cell(1, 5).Range;
                cellRange.Text = "Возраст";
                cellRange = studentsTable.Cell(1, 6).Range;
                cellRange.Text = "Пол";
                cellRange = studentsTable.Cell(1, 7).Range;
                cellRange.Text = "Семейное положение";
                cellRange = studentsTable.Cell(1, 8).Range;
                cellRange.Text = "Образование";
                cellRange = studentsTable.Cell(1, 9).Range;
                cellRange.Text = "Адрес";
                cellRange = studentsTable.Cell(1, 10).Range;
                cellRange.Text = "Телефон";
                cellRange = studentsTable.Cell(1, 11).Range;
                cellRange.Text = "id_специализации";
                studentsTable.Rows[1].Range.Bold = 1;
                studentsTable.Rows[1].Range.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int i = 1;
                foreach (var currentrep in prepods)
                {
                    cellRange = studentsTable.Cell(i + 1, 1).Range;
                    cellRange.Text = currentrep.id.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 2).Range;
                    cellRange.Text = currentrep.seria_pasport.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 3).Range;
                    cellRange.Text = currentrep.FIO.ToString();
                    cellRange.ParagraphFormat.Alignment =
                     Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 4).Range;
                    cellRange.Text = currentrep.age.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 5).Range;
                    cellRange.Text = currentrep.FIO.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 6).Range;
                    cellRange.Text = currentrep.pol.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 7).Range;
                    cellRange.Text = currentrep.semeinoe_polojenie.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 8).Range;
                    cellRange.Text = currentrep.obrazovanie.ToString();
                    cellRange.ParagraphFormat.Alignment =
                     Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 9).Range;
                    cellRange.Text = currentrep.address.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 10).Range;
                    cellRange.Text = currentrep.phone.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 11).Range;
                    cellRange.Text = currentrep.id_specialization.ToString();
                    cellRange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    i++;
                }
                Word.Paragraph countStudentsParagraph = document.Paragraphs.Add();
                Word.Range countStudentsRange =
                countStudentsParagraph.Range;
                countStudentsRange.Text = $"Количество преподавателей -{prepods.Count()}";
                countStudentsRange.Font.Color = Word.WdColor.wdColorDarkRed;
                countStudentsRange.InsertParagraphAfter();
                document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

                app.Visible = true;
                document.SaveAs2(@"D:\outputFileWord.docx");
                document.SaveAs2(@"D:\outputFilePdf.pdf",
                Word.WdExportFormat.wdExportFormatPDF);

            }
        }
    }
}
