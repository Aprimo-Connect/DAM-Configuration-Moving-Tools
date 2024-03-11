using Aprimo.DAM.ConfigurationMover.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Aprimo.DAM.ConfigurationMover
{
    public partial class SettingsSelector : Form
    {
        private ExportHelper exportHelper;
        private AccessHelper accessHelper;
        private string aprimoDamUrl;
        public SettingsSelector(AccessHelper accessHelper, ExportHelper exportHelper, string aprimoDamUrl)
        {
            this.exportHelper = exportHelper;
            this.accessHelper = accessHelper;
            this.aprimoDamUrl = aprimoDamUrl;
            InitializeComponent();
            //fill in list boxes with values of user groups and settings, we won't need role settings for exporting values
            var allSettingDefinitions = exportHelper.GetSettingDefinitions(accessHelper, aprimoDamUrl, "datatype <> 'role'");
            List<Item> dataSourceSettings = allSettingDefinitions.Select(x => new Item(x.Name, x.Name)).ToList<Item>();
            dataSourceSettings.Sort();
            lbSelectSettings.DataSource = dataSourceSettings;
            lbSelectSettings.DisplayMember = "Label";
            lbSelectSettings.ValueMember = "ID";

            var allUserGroups = exportHelper.GetUserGroups(accessHelper, aprimoDamUrl);
            List<Item> dataSourceUserGroups = allUserGroups.Select(x => new Item(x.Name, x.Id)).ToList<Item>();
            dataSourceUserGroups.Sort();
            lbSelectUserGroups.DataSource = dataSourceUserGroups;
            lbSelectUserGroups.DisplayMember = "Label";
            lbSelectUserGroups.ValueMember = "ID";
        }

    }

    public partial class Item : IComparable<Item>
    {
        public string Label { get; set; }
        public string ID { get; set; }

        public Item(string lbl, string id)
        {
            Label = lbl;
            ID = id;
        }
        public int CompareTo(Item compareItem)
        {
            // A null value means that this object is greater.
            if (compareItem == null)
                return 1;

            else
                return this.Label.CompareTo(compareItem.Label);
        }
    }
}
