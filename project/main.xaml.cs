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
            vivod();
        }
        public async void vivod()
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<partia>("partii");
            //var filter = new BsonDocument();
            //var results = collection.Find(filter).ToList();
            List<partia> list = await collection.AsQueryable().ToListAsync<partia>();

            items.ItemsSource = list;
            partia b = (partia)items.Items.GetItemAt(0);
            idtext.Text = b.Id.ToString();
            titletext.Text = b.Title.ToString();
            string hody = b.MASSIV.ToString();
            hody = hody.Trim(']');
            hody = hody.Trim('[');
            hodytext.Text = hody;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //adding

            string title = titletext.Text;
            string arr = hodytext.Text;
            string[,] arr1 = {{ "чладья", "чконь", "чслон", "чферзь", "чкороль", "чслон", "чконь", "чладья" },
            { "чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { "бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            { "бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" } }
            ;
            string[] hodyone = arr.Split(',');
            int count = 0;
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        string figure = hodyone[count];
                        count++;
                        if (figure == "null")
                        {
                            arr1[i, j] = null;
                        }
                        else
                        {
                            arr1[i, j] = figure;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("PLS 64 figures");
                string[,] arr2 =
            {
            { "чладья", "чконь", "чслон", "чферзь", "чкороль", "чслон", "чконь", "чладья" },
            { "чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { "бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            { "бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" }
            };
                arr1 = arr2;
            }
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("partii");
            if (title != "" && arr != null)
            {
                var insert = new BsonDocument();
                insert.Add("title", title);
                insert.Add("arr", new BsonArray(arr1));
                collection.InsertOne(insert);
            }
        }
        private void mouseup(object sender, MouseButtonEventArgs e)
        {
            partia b = (partia)items.SelectedItem;
            idtext.Text = b.Id.ToString();
            titletext.Text = b.Title.ToString();
            string hody = b.MASSIV.ToString();
            hody = hody.Trim(']');
            hody = hody.Trim('[');
            hodytext.Text = hody;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //updating
            string title = titletext.Text;
            string arr = hodytext.Text;
            string[,] arr1 = {{ "чладья", "чконь", "чслон", "чферзь", "чкороль", "чслон", "чконь", "чладья" },
            { "чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { "бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            { "бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" } }
            ;
            string[] hodyone = arr.Split(',');
            int count = 0;
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        string figure = hodyone[count];
                        count++;
                        if (figure == "null")
                        {
                            arr1[i, j] = null;
                        }
                        else
                        {
                            arr1[i, j] = figure;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("PLS 64 figures");
                string[,] arr2 =
            {
            { "чладья", "чконь", "чслон", "чферзь", "чкороль", "чслон", "чконь", "чладья" },
            { "чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка","чпешка" },
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { null,null,null,null,null,null,null,null},
            { "бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка","бпешка" },
            { "бладья","бконь","бслон","бферзь","бкороль","бслон","бконь","бладья" }
            };
                arr1 = arr2;
            }
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("partii");
            if (title != "" && arr != null)
            {
                ObjectId id = ObjectId.Parse(idtext.Text);
                var filter = new BsonDocument("_id", id);
                var coll = collection.Find(filter).ToList();
                MessageBox.Show(coll.ToString());
                var insert = new BsonDocument();
                insert.Add("title", title);
                insert.Add("arr", new BsonArray(arr1));
                var replaceall =
                collection.ReplaceOneAsync(new BsonDocument("_id", id), insert);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //deleting
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("partii");
            ObjectId id = ObjectId.Parse(idtext.Text);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var delete=collection.DeleteOneAsync(filter);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //searching
            string title = titletext.Text;
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("partii");
            var filter = new BsonDocument("title",title);
            var info = collection.Find(filter).ToList();
            foreach(var p in info)
            {

                title = p["title"].ToString();
                string arr = p["arr"].ToString();
                NavigationService.Navigate(new search(title, arr));
            }
        }
    }
}
