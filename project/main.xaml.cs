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
using MongoDB.Bson;
using MongoDB.Driver;

namespace project
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //adding
            string id = idtext.Text;
            string title = titletext.Text;
            string hody = hodytext.Text;
            string[,] arr = {{ "чладья", "чконь", "чслон", "чферзь", "чкороль", "чслон", "чконь", "чладья" },
            { "чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { "бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            { "бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" } }
            ;
            string[] hodyone = hody.Split(',');
            int count = 0;
            for(int i=0; i< 8; i++)
            {
                for(int j=0; j < 8; j++)
                {
                    string figure = hodyone[count];
                    count++;
                    if (figure == "null") 
                    {
                      arr[i, j] = null; 
                    }
                    else
                    {
                        arr[i, j] = figure;
                    }
                }
            }
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("partii");
            if (id != "" && title != "" && arr != null)
            {
                var insert = new BsonDocument();
                insert.Add("id", id);
                insert.Add("title", title);
                insert.Add("hody", new BsonArray(arr));
                collection.InsertOne(insert);
                MessageBox.Show(insert["hody"].ToString());
            }
        }    
    }
}
