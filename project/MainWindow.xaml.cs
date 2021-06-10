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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            element.Navigate(new SignRegist());
        }
        public static bool chekingRegist(string name, string password)
        {
            bool mogno = false;
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("test");
            if (name != "" && password!="")
            {
                var filter = new BsonDocument
                ("$and", new BsonArray
                {
                new BsonDocument("name",name),
                new BsonDocument("password", password)
                }
                );
                var text = collection.Find(filter).ToList();
                try
                {
                    text[0].ToString();
                    MessageBox.Show("Enter another login or password");
                }
                catch (Exception)
                {
                    mogno = true;
                }
                         
            }
            return mogno;
        }
        public static bool regist(string name, string password)
        {
            bool mogno = false;
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("test");
            if (name != "" && password!="" && chekingRegist(name,password))
            {
                var insert = new BsonDocument
                (new BsonDocument
                {{"name" , name},{"password",password} }
                );
                collection.InsertOne(insert);
                mogno = true;
            }
            return mogno;
        }
        public static bool login(string name, string password)
        {
            bool mogno = false;
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("test");
            if (name != "" && password != "")
            {
                var filter = new BsonDocument
                ("$and", new BsonArray
                {
                new BsonDocument("name",name),
                new BsonDocument("password", password)
                }
                );
                var text = collection.Find(filter).ToList();
                try
                {
                    text[0].ToString();
                    MessageBox.Show("WELLCUM!!!!");
                    mogno = true;
                }
                catch (Exception)
                {
                    mogno = false;
                }
            }
            return mogno;
        }
    }
}
