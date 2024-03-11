using Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Aprimo.DAM.ConfigurationMover
{
    public partial class ConnectionsDetails : Form
    {
        public string ConnectionsFile;
        public List<ConnectionDTO> SavedConnections;
        public ConnectionsDetails()
        {
            ConnectionsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               string.Format("ConnectionDetails.xml"));
            InitializeComponent();
            SavedConnections = new List<ConnectionDTO>();
            if (File.Exists(ConnectionsFile))
            {
                var document = XDocument.Load(ConnectionsFile);
                SavedConnections = GetConnectionDetails(document);
                List<Item> dataSourceConnections = SavedConnections.Select(x => new Item(x.name, x.name)).ToList<Item>();
                dataSourceConnections.Sort();
                cbSelectEnvironment.DataSource = dataSourceConnections;
                cbSelectEnvironment.DisplayMember = "Label";
                cbSelectEnvironment.ValueMember = "ID";
            }                                   
        }

        public ConnectionsDetails(ConnectionDTO connectionToSave)
        {
            ConnectionsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               string.Format("ConnectionDetails.xml"));
            InitializeComponent();
            tbClientID.Text = connectionToSave.clientId;
            tbUsername.Text = connectionToSave.username;
            tbUserToken.Text = connectionToSave.token;
            tbRegistration.Text = connectionToSave.registration;
            tbConnectionName.Text = connectionToSave.name;
            btnSelectEnv.Enabled = false;            
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<ConnectionDTO> connections = new List<ConnectionDTO>();
            ConnectionDTO connectionToSave = new ConnectionDTO()
            {
                name = tbConnectionName.Text,
                clientId = tbClientID.Text,
                username = tbUsername.Text,
                token = tbUserToken.Text,
                registration = tbRegistration.Text
            };
            
            if (File.Exists(ConnectionsFile))
            {                
                var document = XDocument.Load(ConnectionsFile);
                connections = GetConnectionDetails(document);

                if (!connections.Any(c => c.name.Equals(connectionToSave.name)))
                {
                    connections.Add(connectionToSave);
                }
                else
                {
                    connections.Remove(connections.Where(c => c.name.Equals(connectionToSave.name)).FirstOrDefault());
                    connections.Add(connectionToSave);
                }               
            }
            else
            {
                connections.Add(connectionToSave);
            }
            WriteConnectionDetails(connections);
        }

        private void WriteConnectionDetails(List<ConnectionDTO> connections)
        {
            Console.WriteLine("Saving connection details to file...");
            using (TextWriter writer = File.CreateText(ConnectionsFile))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<connections>");
                foreach (ConnectionDTO connection in connections)
                {
                    writer.WriteLine("  <connection Name=\"{0}\" >", HttpUtility.HtmlEncode(connection.name));
                    writer.WriteLine("    <registration>{0}</registration>", HttpUtility.HtmlEncode(connection.registration));
                    writer.WriteLine("    <username>{0}</username>", HttpUtility.HtmlEncode(connection.username));
                    writer.WriteLine("    <clientId>{0}</clientId>", HttpUtility.HtmlEncode(connection.clientId));
                    writer.WriteLine("    <token>{0}</token>", HttpUtility.HtmlEncode(connection.token));
                    writer.WriteLine("  </connection>");
                }
                writer.WriteLine("</connections>");
                writer.Flush();
            }
               
        }

        public List<ConnectionDTO> GetConnectionDetails(XDocument document)
        {
            var connections = from c in document.Descendants("connection")
                              select new ConnectionDTO
                              {
                                  name = Attributes.GetHtmlDecodedStringValue(c.Attribute("Name")),
                                  registration = Elements.GetHtmlDecodedStringValue(c.Element("registration")),
                                  username = Elements.GetHtmlDecodedStringValue(c.Element("username")),
                                  clientId = Elements.GetHtmlDecodedStringValue(c.Element("clientId")),
                                  token = Elements.GetHtmlDecodedStringValue(c.Element("token"))
                              };

            return connections.ToList();
        }            
        
        public partial class ConnectionDTO
        {
            public string name { get; set; }
            public string registration { get; set; }
            public string username { get; set; }
            public string clientId { get; set; }
            public string token { get; set; }

        }

        
    }
}
