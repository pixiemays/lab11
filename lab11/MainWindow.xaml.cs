using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace lab11;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        using (DatabaseContext contextDb = new DatabaseContext())
        {
            if (contextDb.Database.EnsureCreated())
            {
                contextDb.Add(new Category { Name = "ЖКХ" });
                contextDb.SaveChanges();
                contextDb.Add(new User { Name = "Петров" });
                contextDb.SaveChanges();
                contextDb.Add(new Payment { Description = "Платеж за месяц", DateTime = DateTime.Now, CategoryId = 1, UserId = 1 });
                contextDb.SaveChanges();
            }
            
            DG.ItemsSource =  contextDb.Payments.Include(x => x.User).Include(x => x.Category).ToList(); ;
        }
    }
}