using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for UCTopCV.xaml
    /// </summary>
    public partial class UCTopCV : UserControl
    {
        public UCTopCV()
        {
            InitializeComponent();
            List<PostCV> list = PostCVDAO.Instance.getAllPostCV();
            foreach (PostCV item in list)
            {
                newFeedList.Items.Add(new UCRateCV(item.Id));
            }
        }
    }
}
