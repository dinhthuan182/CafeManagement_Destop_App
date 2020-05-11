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

namespace CafeManagerDestopApp
{
    public partial class TableManager : UserControl
    {
        public Network.Network apiNetwork = new Network.Network();
        List<TableItem> allTable = new List<TableItem>();
        public TableManager()
        {
            InitializeComponent();
            loadData();
        }
        private async void loadData()
        {
            var tables = await apiNetwork.GetAllTable();

            if (tables != null) {
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
                        TableCardCell item = new TableCardCell();

                        if (table.user_id != null)
                        {
                            item.setTable(id: table.id, name: table.name, state: 1);
                        }
                        else
                        {
                            if (table.status == "Using")
                            {
                                item.setTable(id: table.id, name: table.name, state: 2);
                            }
                            else
                            {
                                item.setTable(id: table.id, name: table.name, state: 3);
                            }
                        }
                        index++;

                        tableList.Controls.Add(item, x, y);
                    

                    }   
                }   
            }
        }
        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i > 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }

    }
}
