using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class PostCV
    {
        int id;
        string title;
        string content;
        int idCV;
        DateTime publicDate;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public int IdCV { get => idCV; set => idCV = value; }
        public DateTime PublicDate { get => publicDate; set => publicDate = value; }

        public PostCV(DataRow data)
        {
            this.Id = (int)data["Id"];
            this.Title = data["TieuDe"].ToString();
            this.Content = data["NoiDung"].ToString();
            this.IdCV = (int)data["IdCV"];
            this.PublicDate = (DateTime)data["NgayDang"];
        }

        public PostCV(string title, string content, int idCV)
        {
            Title = title;
            Content = content;
            IdCV = idCV;
            Id = -1;
            PublicDate = DateTime.Now;
        }

        public bool NotNull()
        {
            var properties = typeof(PostCV).GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(this);

                if (value == null || value.ToString() == "")
                {
                    System.Windows.MessageBox.Show($"{property.Name} trống");
                    return false;
                }
            }
            return true;
        }
    }
}
