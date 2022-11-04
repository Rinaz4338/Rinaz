using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rinaz
{
    /// <summary>
    /// Логика взаимодействия для update_prepod.xaml
    /// </summary>
    public partial class update_prepod : Window
    {
        private Prepods _p;
        public update_prepod(object selectedItem)
        {
            InitializeComponent();
            _p = selectedItem as Prepods;
             tb1.Text=_p.seria_pasport ;
            tb2.Text = _p.nomer_pasport;
            tb3.Text = _p.FIO;
            tb4.Text = _p.age.ToString();
            tb5.Text = _p.pol;
            tb6.Text = _p.semeinoe_polojenie;
            tb7.Text = _p.obrazovanie;
            tb8.Text = _p.address;
            tb9.Text = _p.phone.ToString();
            tb10.Text = _p.id_specialization.ToString();
                
        }

        private void upd_prepod_b_Click(object sender, RoutedEventArgs e)
        {
            int b;
            bool isnum1 = Int32.TryParse(tb1.Text, out b);
            bool isnum2 = Int32.TryParse(tb2.Text, out b);
            bool isnum3 = Int32.TryParse(tb4.Text, out b);
            bool isnum4 = Int32.TryParse(tb9.Text, out b);
            bool isnum5 = Int32.TryParse(tb10.Text, out b);
            if (isnum1 && isnum2 && isnum3 && isnum4 && isnum5)
            {
                using (DK_R r = new DK_R())
                { 
               
                    Prepods p = new Prepods();

                    p = r.Prepods.Find(_p.id);
                    if (p != null)
                    {
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

                        // r.Database.ExecuteSqlCommand("SET IDENTITY_INSERT master.dbo.Prepod ON;");
                        r.SaveChanges();
                        // r.Database.ExecuteSqlCommand("SET IDENTITY_INSERT master.dbo.Prepod OFF");
                      
                    }
                }
            }
            this.Close();
        }
    }
}
