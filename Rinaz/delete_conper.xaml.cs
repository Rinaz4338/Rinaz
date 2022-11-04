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
    /// Логика взаимодействия для delete_conper.xaml
    /// </summary>
    public partial class Delete_w : Window
    {
        private Prepods _p;
        private ContactPerson _person;
        public Delete_w(object selecteditem, string table)
        {
            InitializeComponent();
            if (table == "ContactPerson")
            {
                _person = selecteditem as ContactPerson;
                tb1.Text = _person.ContactPersonId.ToString();

            }
            else if (table == "Prepod")
            {
                _p = selecteditem as Prepods;
                tb1.Text = _p.id.ToString();
            }
        }

            private void Delete_c_Click(object sender, RoutedEventArgs e)
        {

            bool n1 = int.TryParse(tb1.Text, out int a);
            if (n1)
            {
                using (DK_R r = new DK_R())
                {if (_person != null)
                    {
                        ContactPerson c = new ContactPerson();
                        int add = int.Parse(tb1.Text);
                        var ad = r.ContactPerson.Single(o => o.ContactPersonId == add);
                        
                        if (c != null)
                        {
                            r.ContactPerson.Remove(ad);
                            r.SaveChanges();
                        }
                    }
                    else if(_p!=null){
                        Prepods p = new Prepods();
                        int add = int.Parse(tb1.Text);
                       var ad = r.Prepods.Single(o=>o.id == add);
                        if (p != null)
                        {
                            r.Prepods.Remove(ad);
                            r.SaveChanges();
                        }
                    }
                }
            }
            this.Close();
        }
      
    }
}
