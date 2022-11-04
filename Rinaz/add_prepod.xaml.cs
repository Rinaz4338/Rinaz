using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rinaz
{
    /// <summary>
    /// Логика взаимодействия для add_prepod.xaml
    /// </summary>
    public partial class add_prepod : Window
    {
        public add_prepod()
        {
            InitializeComponent();
        }
        
        
        private void add_prepod_b_Click(object sender, RoutedEventArgs e)
        {
            int b;          
            bool isnum3 = Int32.TryParse(tb4.Text, out b);
            bool isnum4 = Int32.TryParse(tb9.Text, out b);
            bool isnum5 = Int32.TryParse(tb10.Text, out b);
            if (isnum3&& isnum4 && isnum5)
            {
                using (DK_R r = new DK_R())
                
                    using (var transaction = r.Database.BeginTransaction())
                    {
                        Prepods p = new Prepods();
                        p.seria_pasport = tb1.Text;
                        p.nomer_pasport = tb2.Text;
                        p.FIO = tb3.Text;
                        p.age = int.Parse(tb4.Text);
                        p.pol = tb5.Text;
                        p.semeinoe_polojenie = tb6.Text;
                        p.obrazovanie = tb7.Text;
                        p.address = tb8.Text;
                        p.phone = int.Parse(tb9.Text);
                        p.id_specialization = int.Parse(tb10.Text);
                        r.Prepods.Add(p);
                        r.SaveChanges();
                        transaction.Commit();
                    }
                
            }
            else { MessageBox.Show("Ошибка ввода"); }
            this.Close();
        }
    }
}
