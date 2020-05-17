using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagerDestopApp.Entitys;
using PusherClient;

namespace CafeManagerDestopApp
{
    public partial class TableManager : UserControl
    {
        private static Pusher _pusher;
        private static Channel _chatChannel;
        //private static PresenceChannel _presenceChannel;
        //private static string _name;

        public Network.Network apiNetwork = new Network.Network();
        List<TableItem> allTable = new List<TableItem>();

        public TableManager()
        {
            InitializeComponent();
            LoadData();
            InitPusher();
        }

        // Pusher Initiation / Connection
        private async void InitPusher()
        {
            _pusher = new Pusher("625e6f2e093b6e564050", new PusherOptions()
            {
                Encrypted = true,
                Cluster = "ap1"
            });

            // Setup private channel
            _chatChannel = _pusher.SubscribeAsync("mobile").Result;

            // Inline binding!
            _chatChannel.Bind("changeStateTable-event", (dynamic data) =>
            {
                updateTables();
            });
            await _pusher.ConnectAsync();
        }

        private async void updateTables()
        {
            var tables = await apiNetwork.GetAllTable();
            if (tables != null)
            {
                allTable = tables;

                foreach (TableItem item in tables)
                {
                    TableCardCell cell = (tableList.Controls.Find(Name = item.id.ToString(), true).First() as TableCardCell);
                    cell.SetTable(item);
                }
            }
        }

        private async void LoadData()
        {
            var tables = await apiNetwork.GetAllTable();

            if (tables != null)
            {
                allTable = tables;

                tableList.Controls.Clear();

                tableList.ColumnStyles.Clear();
                tableList.RowStyles.Clear();
                var rowCount = tables.Count % 5 > 0 ? (tables.Count / 5) + 1 : tables.Count / 5;

                tableList.ColumnCount = 5;
                tableList.RowCount = rowCount;

                var index = 0;

                for (int y = 0; y < rowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    var row = new RowStyle(SizeType.Absolute)
                    {
                        Height = 150
                    };
                    tableList.RowStyles.Add(row);
                    for (int x = 0; x < 5; x++)
                    {
                        var columns = new ColumnStyle(SizeType.Percent)
                        {
                            Width = 20
                        };
                        tableList.ColumnStyles.Add(columns);
                        //item
                        var table = tables[index];
                        TableCardCell item = new TableCardCell() { Name = table.id.ToString()};
                        item.SetTable(table);

                        index++;
                        tableList.Controls.Add(item, x, y);


                    }
                }
            }
        }

        public void ShowDetail(TableDetailItem newDetail, TableItem newTable)
        {
            this.tableDetail.Update(newDetail, newTable);
        }
    }
}
