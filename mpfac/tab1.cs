using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Data.SqlClient;


namespace mpfac
{
    public partial class tab1 : Form
    {
        private GeoCoordinateWatcher Watcher = null;


        public tab1()
        {
            InitializeComponent();
        }




        private void map1_MouseClick(object sender, MouseEventArgs e)
        {
            var point = map1.FromLocalToLatLng(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
            textcity.Text = point.Lat + "";
            textcountry.Text = point.Lng + "";


        }

        private void map1_MouseMove(object sender, MouseEventArgs e)
        {
            var point = map1.FromLocalToLatLng(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
            double lat = point.Lat;
            double lon = point.Lng;
            labelLat.Text = lat + "";
            labelLon.Text = lon + "";
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    MessageBox.Show("Cannot find location data");
                }
                else
                {
                    var latgeo = Watcher.Position.Location.Latitude;
                    var longeo = Watcher.Position.Location.Longitude;
                    map1.Position = new PointLatLng(latgeo, longeo);
                    GMapMarker marker = new GMarkerGoogle(map1.Position, GMarkerGoogleType.red_small);
                    marker.ToolTip = new GMapBaloonToolTip(marker);
                    Brush ToolTipBackColor = new SolidBrush(Color.WhiteSmoke);
                    marker.ToolTip.Fill = ToolTipBackColor;
                    marker.ToolTipText = "\n    You are Here";
                    marker.ToolTip.Font = new Font("Times New ROman", 12, FontStyle.Italic);
                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);

                    map1.Overlays.Add(markers);
                    map1.MinZoom = 5;
                    map1.MaxZoom = 100;
                    map1.Zoom = 10;
                    map1.Zoom++;
                    map1.Zoom--;

                }
            }
        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            {
                Application.Exit();
            }
        }

        private void iconmaxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestore.Visible = true;
            iconmaxi.Visible = false;
        }

        private void iconrestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestore.Visible = false;
            iconmaxi.Visible = true;
        }

        private void iconmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
         }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\FYP\Visual Studio 2015\Projects\WindowsFormsApplication5\DB\MPSDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ABDUL\ONEDRIVE\DOCUMENTS\VISUAL STUDIO 2015\PROJECTS\MPFAC1\MPFAC\MPSDB.MDF;Integrated Security=True;Connect Timeout=30");
            String query = "INSERT INTO Navi_Para( target_id,prog_number, tot, tgt_alt, tgt_lat, tgt_lng) VALUES(@tgt, @prog, @tot, @tgt_alt, @tgt_lat, @tgt_lng)";

            SqlCommand command = new SqlCommand(query, con);


            command.Parameters.AddWithValue("@tgt", textBox12.Text );
            command.Parameters.AddWithValue("@prog", textBox16.Text );
            command.Parameters.AddWithValue("@tot", textBox15.Text );
            command.Parameters.AddWithValue("@tgt_alt", textBox14.Text );
            command.Parameters.AddWithValue("@tgt_lat", textcity.Text );
            command.Parameters.AddWithValue("@tgt_lng", textcountry.Text );
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message.ToString(), "Error Message");
            }
        }

        private void tab1_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCKiRwwwnOlmbfo1ro66TkhLMxkoDoo83Q";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map1.DragButton = MouseButtons.Left;
            map1.MapProvider = GMapProviders.GoogleMap;
            map1.ShowCenter = false;
            Watcher = new GeoCoordinateWatcher();
            // Catch the StatusChanged event.

            Watcher.StatusChanged += Watcher_StatusChanged;
            // Start the watcher.

            Watcher.Start();
        }

       
    }
}
