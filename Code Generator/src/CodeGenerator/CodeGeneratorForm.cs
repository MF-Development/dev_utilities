using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

using CodeGenerator.SQLServer.DataAccess;
using KYSSPluginInterfaces;

namespace CodeGenerator
{
    public partial class CodeGeneratorForm : Form
    {
        #region Variables
        private static string _version = "4.3.0";

        //default config file name
        private string _configurationFilePath = "KYSSgenerator.config";
        private string _defaultNameSpaceUtility = "WebApplication";

        private static string _namespaceBase = string.Empty;
        private static string _entityUsingStatements = String.Empty;
        private static string _entityDataProviderUsingStatements = String.Empty;

        private static string _entityBaseName = String.Empty;
        private static string _entityDataProviderBaseName = String.Empty;
        
        private static string _connectionStringName = String.Empty;

        private static bool _upperCaseFieldNames = false;
        private static bool _upperCaseFirstCharacter = false;

        private static bool _createHTMLDataStructureFile = false;

        private static string _attributeClassesNamespace = String.Empty;

        private static string _preNameOfClass = String.Empty;

        #region Plugins
        
        private static bool _usePlugins = false;

        private static PluginLoader _pluginLoader = null;

        private static string _pluginRootPath = string.Empty;
        
        #endregion

        #endregion

        #region Properties
        public string ConnectionString
        {
            get 
            {
                string connectionString = String.Empty; 
                

                if (IsWindowsAuthentication.Checked)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionStringWindowsAuthentication"].ToString();
                    connectionString = connectionString.Replace("[SERVER_NAME]", ServerName.Text.Trim());
                    connectionString = connectionString.Replace("[DATABASE_NAME]", DatabaseList.Text);
                }
                else
                {
                    connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
                    connectionString = connectionString.Replace("[SERVER_NAME]", ServerName.Text.Trim());
                    connectionString = connectionString.Replace("[DATABASE_NAME]", DatabaseList.Text);
                    connectionString = connectionString.Replace("[USER_ID]", UserName.Text.Trim());
                    connectionString = connectionString.Replace("[PASSWORD]", Password.Text);
                }

                return connectionString;
            }
        }
        public string ConfigurationFilePath
        {
            get
            {
                return _configurationFilePath;
            }
            set
            {
                _configurationFilePath = value;
            }
        }
        public PluginLoader PluginLoader
        {
            get
            {
                if (_pluginLoader == null)
                {
                    if (!string.IsNullOrEmpty(_pluginRootPath))
                    {
                        _pluginLoader = new PluginLoader(_pluginRootPath);

                    }
                }

                //add current plugins selected
                if (_pluginLoader != null)
                {
                    List<string> pluginsSelected = new List<string>();

                    for (int i = 0; i < PluginList.Items.Count; i++)
                    {
                        if (PluginList.GetItemCheckState(i) == CheckState.Checked 
                            && !_pluginLoader.PluginsSelected.Contains(PluginList.Items[i].ToString()))
                        {
                            _pluginLoader.PluginsSelected.Add(PluginList.Items[i].ToString());
                        }
                    }
                }
                
                return _pluginLoader;
            }
        }


        #endregion

        public CodeGeneratorForm()
        {
            InitializeComponent();
        }

        #region Form Events

        private void CodeGeneratorForm_Load(object sender, EventArgs e)
        {
            this.Text = "KYSS Code Generator (ver " + _version + ")";
        }

        private void NewConfigurationFileMenu_Click(object sender, EventArgs e)
        {
            NewConfigurationFile();
        }

        private void OpenConfigurationFileMenu_Click(object sender, EventArgs e)
        {
            OpenConfigurationFile();
        }

        private void DBConnectButton_Click(object sender, EventArgs e)
        {
            PopulateDatabaseList();
        }

        private void DatabaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTablesList();
        }

        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < TablesList.Items.Count; i++)
            {
                TablesList.SetItemChecked(i, SelectAllTables.Checked);               
            }
        }

        private void PluginDirectoryButton_Click(object sender, EventArgs e)
        {
            string directory = SelectDirectory(PluginRootPath.Text);

            if (!String.IsNullOrEmpty(directory))
            {
                PluginRootPath.Text = directory;
            }
        }

        private void PluginRootPath_TextChanged(object sender, EventArgs e)
        {
            PopulatePluginList();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Generate();
            MainTabControl.SelectedTab = GeneratedCode;
            Cursor.Current = Cursors.Arrow;

            SaveConfigurationSettings();
        }

        private void IncludeViews_CheckedChanged(object sender, EventArgs e)
        {
            PopulateTablesList();
        }

        private void ClipboardButton_Click(object sender, EventArgs e)
        {
            if (GenearatedCodeTab.SelectedTab.Text == CodeTab.Text)
            {
                Clipboard.SetText(CodeTextBox.Text);
            }
            else
            {
                Clipboard.SetText(SQLTextBox.Text);
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Configuration Settings
        private void NewConfigurationFile()
        {
            string configFile = NewConfigFileName(Directory.GetCurrentDirectory(), "Config Files (*.config)|*.config");
            if (!String.IsNullOrEmpty(configFile))
            {
                ConfigurationFilePath = configFile;
                LoadGenerator();
            }
        }

        private void OpenConfigurationFile()
        {
            string configFilePath = SelectFile(Directory.GetCurrentDirectory(), "Config Files (*.config)|*.config");
            if (!String.IsNullOrEmpty(configFilePath))
            {
                ConfigurationFilePath = configFilePath;
                LoadGenerator();
            }
        }

        private void SaveConfigurationSettings()
        {
            StringBuilder sb = new StringBuilder();

            //Configurations Tab
            foreach (Control config in ConfigurationTab.Controls)
            {
                foreach (Control c in config.Controls)
                {
                    sb.Append(PopulateConfigurationSettingFromControl(c));
                }
            }


            //Plugins Tab
            foreach (Control plugins in OtherSettings.Controls["Plugins"].Controls)
            {
                foreach (Control c in plugins.Controls)
                {
                    sb.Append(PopulateConfigurationSettingFromControl(c));
                }
               
            }

            //Miscellaneous Tab
            foreach (Control misc in OtherSettings.Controls["Miscellaneous"].Controls)
            {
                foreach (Control c in misc.Controls)
                {
                    sb.Append(PopulateConfigurationSettingFromControl(c));
                }
            }


            //Tables Tab
            sb.Append("*TablesSelectedForDatabase*," + DatabaseList.Text + "\n");
            sb.Append(PopulateConfigurationSettingFromControl(TablesList));

            CreateTextFile("", ConfigurationFilePath, sb.ToString());
        }

        private void LoadConfigurationSettings()
        {
            string configFileName = ConfigurationFilePath;

            if (File.Exists(configFileName))
            {
                Hashtable configSettings = new Hashtable();
                StreamReader file = new StreamReader(configFileName);
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    string[] s = ((String)line).Split(',');
                    configSettings.Add(s[0].ToString(), s[1].ToString());
                }

                file.Close();

                StringBuilder sb = new StringBuilder();
                foreach (Control group in ConfigurationTab.Controls)
                {
                    foreach (Control c in group.Controls)
                    {
                        PopulateControlDataFromConfigurationSetting(configSettings, c);
                    }
                }

                //Plugins Tab
                foreach (Control plugins in OtherSettings.Controls["Plugins"].Controls)
                {
                    foreach (Control c in plugins.Controls)
                    {
                        PopulateControlDataFromConfigurationSetting(configSettings, c);
                    }
                }

                //Miscellaneous Tab
                foreach (Control misc in OtherSettings.Controls["Miscellaneous"].Controls)
                {
                    foreach (Control c in misc.Controls)
                    {
                        PopulateControlDataFromConfigurationSetting(configSettings, c);
                    }
                }
            }
        }

        private string PopulateConfigurationSettingFromControl(Control c)
        {
            StringBuilder sb = new StringBuilder();
            switch (c.GetType().Name)
            {
                case "TextBox":
                    sb.Append(((TextBox)c).Name + "," + ((TextBox)c).Text + "\n");
                    break;
                case "ComboBox":
                    sb.Append(((ComboBox)c).Name + "," + ((ComboBox)c).Text + "\n");
                    break;
                case "CheckBox":
                    sb.Append(((CheckBox)c).Name + "," + ((CheckBox)c).Checked + "\n");
                    break;
                case "CheckedListBox":
                    //control name
                    sb.Append("*" + ((CheckedListBox)c).Name + "*,\n");
                    for (int i = 0; i < ((CheckedListBox)c).Items.Count; i++)
                    {
                        if (((CheckedListBox)c).GetItemCheckState(i) == CheckState.Checked)
                        {
                            sb.Append(((CheckedListBox)c).Items[i].ToString() + ",checked\n");
                        }
                    }

                    break;
                case "GroupBox":
                    //get all controls contained in a group box
                    foreach (Control groupControl in c.Controls)
                    {
                        sb.Append(PopulateConfigurationSettingFromControl(groupControl));
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

        private void PopulateControlDataFromConfigurationSetting(Hashtable configSettings, Control c)
        {
            switch (c.GetType().Name)
            {
                case "TextBox":
                    if (configSettings.ContainsKey(((TextBox)c).Name))
                    {
                        ((TextBox)c).Text = configSettings[((TextBox)c).Name].ToString();
                    }
                    else
                    {
                        ((TextBox)c).Text = String.Empty;
                    }
                    break;
                case "ComboBox":
                    if (configSettings.ContainsKey(((ComboBox)c).Name))
                    {
                        ((ComboBox)c).Text = configSettings[((ComboBox)c).Name].ToString();
                    }
                    else
                    {
                        ((ComboBox)c).Text = String.Empty;
                    }
                    break;
                case "CheckBox":
                    if (configSettings.ContainsKey(((CheckBox)c).Name))
                    {
                        ((CheckBox)c).Checked = Convert.ToBoolean(configSettings[((CheckBox)c).Name].ToString());
                    }
                    else
                    {
                        ((CheckBox)c).Checked = false;  
                    }
                    break;
                case "GroupBox":
                    //set all controls contained in a group box
                    foreach (Control groupControl in c.Controls)
                    {
                        PopulateControlDataFromConfigurationSetting(configSettings, groupControl);
                    }
                    break;

                default:
                    break;
            }        
        }

        private void LoadPluginSelection()
        {
            string configFileName = ConfigurationFilePath;

            if (File.Exists(configFileName))
            {
                Hashtable configSettings = new Hashtable();
                StreamReader file = new StreamReader(configFileName);
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    string[] s = ((String)line).Split(',');
                    configSettings.Add(s[0].ToString(), s[1].ToString());
                }

                file.Close();

                //check previously checked plugins
                if (configSettings.ContainsKey("*PluginList*"))
                {
                    foreach (string plugin in configSettings.Keys)
                    {
                        int position = PluginList.FindStringExact(plugin);
                        if (position >= 0)
                        {
                            PluginList.SetItemChecked(position, true);
                        }
                    }
                }
            }
        }

        private void LoadTableSelection()
        {
            string configFileName = ConfigurationFilePath;

            if (File.Exists(configFileName))
            {
                Hashtable configSettings = new Hashtable();
                StreamReader file = new StreamReader(configFileName);
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    string[] s = ((String)line).Split(',');
                    configSettings.Add(s[0].ToString(), s[1].ToString());
                }

                file.Close();

                //if using the same database, check previously checked tables
                if (configSettings.ContainsKey("*TablesSelectedForDatabase*"))
                {
                    if (configSettings["*TablesSelectedForDatabase*"].ToString() == DatabaseList.Text)
                    {

                        foreach (string table in configSettings.Keys)
                        {
                            int position = TablesList.FindStringExact(table);
                            if (position >= 0)
                            {
                                TablesList.SetItemChecked(position, true);
                            }
                        }
                    }
                }
            }

        }

        public string NewConfigFileName(string initialDirectory, string fileTypes)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = fileTypes;
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Create a file";
            
            //return (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : null;

            if (dialog.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(dialog.FileName))
            {
                //create the file
                if (File.Exists(dialog.FileName))
                {
                    if (MessageBox.Show("A file with the same name already exists. Please try again.", "File Exists", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return String.Empty;
                    }
                }

                //return Path.GetFileName(dialog.FileName);
                return Path.GetFileName(dialog.FileName);
            }
            else
            {
                return String.Empty;
            }
        }

        public string SelectFile(string initialDirectory, string fileTypes)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = fileTypes;
            dialog.AddExtension = true;
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a file";

            // VLAD : account for config file not being in the same folder as executable
            //return (dialog.ShowDialog() == DialogResult.OK) ? Path.GetFileName(dialog.FileName) : null;
            string configPath = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                configPath = dialog.FileName;
            }
            return configPath;                
        }

        public string SelectDirectory(string initialDirectory)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = initialDirectory;
            return (dialog.ShowDialog() == DialogResult.OK) ? dialog.SelectedPath : null;
        }

        #endregion

        #region Populate Form Data
        private void LoadGenerator()
        {
            this.Text = "KYSS Code Generator (ver " + _version + ")";
            //load configuration settings
            LoadConfigurationSettings();
            if (!String.IsNullOrEmpty(DatabaseList.Text))
            {
                string selectedDatabase = DatabaseList.Text;
                //connect and populate database list
                PopulateDatabaseList();
                DatabaseList.SelectedIndex = DatabaseList.FindStringExact(selectedDatabase);
            }
           
            PopulatePluginList();
        }

        private void PopulatePluginList()
        {
            PluginList.Items.Clear();

            _pluginRootPath = PluginRootPath.Text.Trim();

            if (PluginLoader != null)
            {
                PluginLoader.PluginRootPath = _pluginRootPath;

                if (!String.IsNullOrEmpty(PluginLoader.PluginRootPath))
                {
                    List<IKYSSEntityPlugin> plugins = PluginLoader.GetEntityPlugins(true);

                    foreach (IKYSSEntityPlugin plugin in plugins)
                    {
                        PluginList.Items.Add(plugin.GetType().Name);
                    }
                }
            }

            LoadPluginSelection();
        }

        private void PopulateDatabaseList()
        {
            DatabaseList.DataSource = null;
            DatabaseList.Items.Clear();

            CommonDataProvider.ConnectionString = this.ConnectionString;

            DatabaseList.DisplayMember = "name";
            DatabaseList.ValueMember = "name";
            DatabaseList.DataSource = CommonDataProvider.GetDataTable("SELECT name FROM sys.databases");
        }

        private void PopulateTablesList()
        {
            TablesList.Items.Clear();
            SelectAllTables.Checked = false;

            CommonDataProvider.ConnectionString = this.ConnectionString;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT NAME as TABLE_NAME, TYPE as TABLE_TYPE from sysobjects WHERE TYPE='U' ");

            if (IncludeViews.Checked)
            {
                query.Append(" OR TYPE='V' ");
            }

            query.Append(" AND NAME <> 'sysdiagrams'");
            query.Append(" AND NAME <> 'dtproperties'");
            query.Append(" ORDER BY TYPE, NAME");

            DataTable dt = CommonDataProvider.GetDataTable(query.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TABLE_TYPE"].ToString().ToUpper().Trim() == "V")
                {
                    TablesList.Items.Add("VIEW:" + dr["TABLE_NAME"].ToString());
                }
                else 
                {
                    TablesList.Items.Add(dr["TABLE_NAME"].ToString());
                }
            }


            //check previously checked tables if applicable
            LoadTableSelection();
        }
        #endregion

        #region Generate
        private void Generate()
        {
            StringBuilder code = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            StringBuilder html = new StringBuilder();            

            if (String.IsNullOrEmpty(BaseClassName.Text.Trim()))
            {
                BaseClassName.Text = DatabaseList.Text + "Base";
            }

            _entityBaseName = BaseClassName.Text.Trim();
            _entityDataProviderBaseName = DataProviderBassClassName.Text.Trim();
            
            // 2009.04.28 JSG added for plugin support
            _usePlugins = UsePlugins.Checked;

            _pluginRootPath = PluginRootPath.Text.Trim();

            //rjt - added multiple namespace settings
            string otherNameSpace = OtherNamespace.Text.Trim().Replace(";", ";" + Environment.NewLine);
            // enforce a default
            if (String.IsNullOrEmpty(UtilityNameSpace.Text)) UtilityNameSpace.Text = "WebApplication";

            _entityUsingStatements = EntityDataProviderNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + EntityDataProviderNamespace.Text.Trim() + ";" + Environment.NewLine;
            _entityUsingStatements += DataAccessNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + DataAccessNamespace.Text.Trim() + ";" + Environment.NewLine;
            _entityUsingStatements += ErrorNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + ErrorNamespace.Text.Trim() + ";" + Environment.NewLine + Environment.NewLine;
            _entityUsingStatements += otherNameSpace == String.Empty ? String.Empty : otherNameSpace + Environment.NewLine;
            _entityUsingStatements += UtilityNameSpace.Text.Trim() == String.Empty ? String.Empty : "using " + UtilityNameSpace.Text.Trim() + ".Utility.StringExtensions;" + Environment.NewLine + Environment.NewLine;


            _entityDataProviderUsingStatements = EntityNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + EntityNamespace.Text.Trim() + ";" + Environment.NewLine;
            _entityDataProviderUsingStatements += DataAccessNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + DataAccessNamespace.Text.Trim() + ";" + Environment.NewLine;
            _entityDataProviderUsingStatements += ErrorNamespace.Text.Trim() == String.Empty ? String.Empty : "using " + ErrorNamespace.Text.Trim() + ";" + Environment.NewLine + Environment.NewLine;
            _entityDataProviderUsingStatements += otherNameSpace == String.Empty ? String.Empty : otherNameSpace + Environment.NewLine;

            if (cPreNameClass.Checked == true)
            {
                _preNameOfClass = txtPreName.Text;
            }
            // 2009.05.20 JSG added for namespacing attribute classes
            _attributeClassesNamespace = AttributeClassesNamespace.Text.Trim();

            if (!string.IsNullOrEmpty(_attributeClassesNamespace) && !_attributeClassesNamespace.EndsWith("."))
            {
                _attributeClassesNamespace += ".";
            }

            //special condition for field names
            //this was done due to keywords being used as field names
            _upperCaseFieldNames = false;
            _upperCaseFirstCharacter = false;
            switch (FieldNameCase.Text)
            {
                case "Use Original":
                    //do nothing
                    break;
                case "Force Upper Case":
                    _upperCaseFieldNames = true;
                    break;
                case "Force Upper Case First Character":
                    _upperCaseFirstCharacter = true;
                    break;
            }

            _createHTMLDataStructureFile = CreateHTMLDataStructure.Checked;


            //rjt - added
            code.Append(CopyrightInformation());
            code.Append(EntityDirectives());

            string tableName = String.Empty;

            for (int i = 0; i < TablesList.Items.Count; i++)
            {
                if (TablesList.GetItemCheckState(i) == CheckState.Checked )
                {
                    //replace the prefix "VIEW:" if it exists
                    tableName = TablesList.Items[i].ToString().Replace("VIEW:", "");

                    string className = tableName;
                    if (!String.IsNullOrEmpty(_preNameOfClass))
                    {
                        className = String.Format("{0}_{1}", _preNameOfClass, tableName);
                    }
                    //Get the FIELD info for the selected TABLE
                    DataTable fieldInfoTable = GetFieldInfoTable(tableName);

                    code.Append(BuildEntity(ServerName.Text.Trim(), DatabaseList.Text, tableName, fieldInfoTable, className));

                    //write the custom partial class file - this will be what the programmer uses to extend the code
                    //entity
                    CreateTextFile(DatabaseList.Text + "\\partialClassStubs\\", className + ".Custom.cs", BuildCustomEntityClass(DatabaseList.Text, tableName, fieldInfoTable, className));
                    //entity data provider
                    CreateTextFile(DatabaseList.Text + "\\partialClassStubs\\", className + "DataProvider.Custom.cs", BuildCustomEntityDataProviderClass(DatabaseList.Text, tableName, className));
                }
            }

            CodeTextBox.Text = code.ToString();

            //do not write single entity class file if separate files are created
            if (!CreateSeparateFiles.Checked)
            {
                CreateTextFile(DatabaseList.Text, "Entity" + DatabaseList.Text + ".cs", CodeTextBox.Text);
            }
        }

        #region Entity Builder
        private string CopyrightInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
@"
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version {0}).
// Generated on {1}
//-----------------------------------------------------------------------------------//
", _version, DateTime.Now.ToString());

            return sb.ToString();
        }
        private string BuildEntity(string serverName, string databaseName, string tableName, DataTable fieldInfoTable, string className)
        {
            DataTable primaryKeyFields = GetPrimaryKeys(tableName);
            DataTable identityFields = GetPrimaryKeys(tableName, true);

            if (primaryKeyFields.Rows.Count == 0)
            {
                System.Diagnostics.Debug.Write("\n\nNO PRIMARY KEY FOR " + tableName);
            }
            
            //Added to check if "table" is really a View (views will be read-only entities)
            bool isView = false;
            if (IncludeViews.Checked)
            {
                isView = IsView(tableName);
            }

            StringBuilder sb = new StringBuilder();
            string entityCode = BuildEntityClass(databaseName, fieldInfoTable, primaryKeyFields, isView, tableName);
            string entityDataProviderCode = BuildEntityDataProvider(primaryKeyFields, fieldInfoTable, tableName, isView);

            //creates separate files for each entity/entity data provider class
            if (CreateSeparateFiles.Checked)
            {
                string copyright = CopyrightInformation();
                string directives = EntityDirectives();
                entityCode = copyright + directives + entityCode;
                entityDataProviderCode = copyright + entityDataProviderCode;

                entityCode = CodeReplace(entityCode, tableName, className);
                entityDataProviderCode = CodeReplace(entityDataProviderCode, tableName, className);

                //write the class file
                CreateTextFile(DatabaseList.Text + "\\generated\\", className + ".generated.cs", entityCode);
                CreateTextFile(DatabaseList.Text + "\\generated\\", className + "DataProvider.generated.cs", entityDataProviderCode);
            }

            //Generate the C# code
            sb.Append(entityCode);
            sb.Append(entityDataProviderCode);

            //Return code with [] replacements
            return CodeReplace(sb.ToString(), tableName, className);
        }
        private string EntityDirectives()
        {
            StringBuilder sb = new StringBuilder();
            //Using Section
            sb.Append(
@"
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Linq;
");
            
            if (!IsWindowsApplication.Checked && 1 == 2)
            {
                sb.Append(
@"
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

");
            }

            //rjt - added 2009.06.15
            sb.Append(_entityUsingStatements);

            // 2009.04.28 JSG Added -- Create custom using statements where needed
            if (_usePlugins)
            {
                List<IKYSSEntityPlugin> plugins = 
                    PluginLoader.GetEntityPlugins(false);

                sb.AppendLine("#region Plugin Namespaces\n");
                _namespaceBase = UtilityNameSpace.Text;
                if( String.IsNullOrEmpty(_namespaceBase))
                    _namespaceBase = _defaultNameSpaceUtility;

                foreach (IKYSSEntityPlugin plugin in plugins)
                {
                    foreach (string ns in plugin.GetNamespaces(_namespaceBase))
                    {
                        sb.AppendLine("using " + ns + ";");
                    }
                }

                sb.AppendLine();
                sb.AppendLine("#endregion\n");
            }

            return sb.ToString();
        }
        private string BuildEntityClass(string databaseName, DataTable fieldInfoTable, DataTable primaryKeyFields, bool isView, string tableName)
        {
            StringBuilder sb = new StringBuilder();

            // Check for interface market plugins
            string interfaceMarkers = string.Empty;

            if (_usePlugins)
            {
                List<IKYSSEntityPlugin> plugins =
                    PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityIntrerfaceMarkerPlugin), false);

                foreach (IKYSSEntityPlugin plugin in plugins)
                {
                    string body = plugin.GetBody("[CLASSNAME]", fieldInfoTable);
                    if (interfaceMarkers.Length > 0)
                    {
                        interfaceMarkers += ", ";
                    }
                    interfaceMarkers += body;
                }
            }

            // Create the inheritance chain
            string inheritanceChain = _entityBaseName;

            if (!String.IsNullOrEmpty(interfaceMarkers))
            {
                if (!String.IsNullOrEmpty(_entityBaseName))
                {
                    inheritanceChain = _entityBaseName + ", " + interfaceMarkers;
                }
                else
                {
                    inheritanceChain = interfaceMarkers;    
                }
            }


             //Entity header
            sb.Append("namespace " + EntityNamespace.Text.Trim() + "\n");
            sb.Append("{");

            sb.Append(
@"
    #region [CLASSNAME] Entity

    /// <summary>
    /// Data object representation of the [CLASSNAME] database table
    /// </summary>
    [Serializable]
    public partial class [CLASSNAME]" + (String.IsNullOrEmpty(inheritanceChain) ? String.Empty : " : " + inheritanceChain) + @"
    {
");

            //Generate each inner section
            sb.Append(BuildEntityFieldEnum(fieldInfoTable));
            sb.Append(BuildEntityPrivateVariables(fieldInfoTable));
            sb.Append(BuildEntityConstructors(fieldInfoTable));
            sb.Append(BuildEntityProperties(tableName, fieldInfoTable));
            sb.Append(BuildPropertyValueGetAndSetMethods(fieldInfoTable));
            sb.Append(BuildEntityFactoryMethods());
            sb.Append(BuildEntityMethods(fieldInfoTable, primaryKeyFields, isView, tableName));

            //Entity footer
            sb.Append("    }\n\n");
            sb.Append("    #endregion\n\n");
            sb.Append("}\n");            

            return sb.ToString();
        }              
        private string BuildEntityFieldEnum(DataTable fieldInfoTable)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region Field Enum Declarations\n");
            sb.Append("        public enum DBFieldName\n");
            sb.Append("        {\n");

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (ShouldProcessField(dr))
                {
                    sb.Append("           " + dr["COLUMN_NAME"].ToString() + ",\n");
                }
            }

            sb.Append("        }\n");
            sb.Append("        #endregion\n\n");
            return sb.ToString();
        }
        private string BuildEntityPrivateVariables(DataTable fieldInfoTable)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region Class Member Declarations\n");
            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (ShouldProcessField(dr))
                {
                    sb.Append("        private string _" + dr["COLUMN_NAME"].ToString() + " = String.Empty;\n");
                }

            }


            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }
        private string BuildEntityConstructors(DataTable fieldInfoTable)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region Constructors\n");
            sb.Append("        public [CLASSNAME]()\n");
            sb.Append("        {\n");
            sb.Append("        }\n\n");
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Full constructor to be used to create and populate entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        public [CLASSNAME](");
            //Each field as a parameter

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (ShouldProcessField(dr))
                {
                    sb.Append(" string " + dr["COLUMN_NAME"] + ",");
                }
            }

            //Remove last comma
            sb.Remove(sb.Length - 1, 1);

            sb.Append(")\n");
            sb.Append("        {\n");

            //Set the private variables with the parameter values
            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (ShouldProcessField(dr))
                {
                    sb.Append("            this._" + dr["COLUMN_NAME"] + " = " + dr["COLUMN_NAME"] + ";\n");
                }
            }

            sb.Append("        }\n");
            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }

        /// <summary>
        /// Generate method SetProperty that overrides default implementation in KYSSEntityBase to avoid
        /// using too much reflection
        /// </summary>
        /// <param name="fieldInfoTable"></param>
        /// <returns></returns>
        private string BuildPropertyValueGetAndSetMethods(DataTable fieldInfoTable)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder set = new StringBuilder();
            StringBuilder get = new StringBuilder();

            if (fieldInfoTable != null && fieldInfoTable.Rows.Count > 0)
            {
                sb.Append("        #region Entity Specific Loading\n");

                set.Append("        public override void SetProperty(string propertyName, string value)\n");
                set.Append("        {\n");
                set.Append("            switch(propertyName.ToLower())\n");
                set.Append("            {\n");

                get.Append("        public override string GetProperty(string propertyName)\n");
                get.Append("        {\n");
                get.Append("            string returnValue = string.Empty;\n");
                get.Append("            switch(propertyName.ToLower())\n");
                get.Append("            {\n");

                foreach (DataRow dr in fieldInfoTable.Rows)
                {
                    if (ShouldProcessField(dr))
                    {
                        set.Append("                case \"" + dr["COLUMN_NAME"].ToString().ToLower() + "\":\n");
                        set.Append("                    this." + dr["COLUMN_NAME"].ToString() + " = value;\n");
                        set.Append("                    break;\n");

                        get.Append("                case \"" + dr["COLUMN_NAME"].ToString().ToLower() + "\":\n");
                        get.Append("                    returnValue = this." + dr["COLUMN_NAME"].ToString() + ";\n");
                        get.Append("                    break;\n");
                    }
                }

                set.Append("                default:\n");
                set.Append("                    base.SetCustomProperty(propertyName, value);\n");
                set.Append("                    break;\n");
                set.Append("            }\n");
                set.Append("        }\n");

                get.Append("                default:\n");
                get.Append("                    returnValue = base.GetCustomProperty(propertyName);\n");
                get.Append("                    break;\n");
                get.Append("            }\n");
                get.Append("            return returnValue;\n");
                get.Append("        }\n");

                sb.Append(set.ToString());
                sb.Append("\n");
                sb.Append(get.ToString());
                sb.Append("\n");
                sb.Append("        #endregion\n\n");

            }
            return sb.ToString();
        }

        private string BuildEntityProperties(String tableName, DataTable fieldInfoTable)
        {
            StringBuilder sb = new StringBuilder();

            // Get plugin properties if any exist
            // 2009.04.28 JSG Added -- Create custom using statements where needed
            if (_usePlugins)
            {
                List<IKYSSEntityPlugin> plugins =
                    PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityStaticPropertyPlugin),false);

                if (plugins.Count > 0)
                {
                    sb.AppendLine("        #region Plugin Class Property Declarations");
                }

                StringBuilder staticPropertiesBuilder = new StringBuilder();

                foreach (IKYSSEntityPlugin plugin in plugins)
                {
                    string body = plugin.GetBody(tableName, fieldInfoTable);
                    staticPropertiesBuilder.Append(body);
                }

                string staticProperties = staticPropertiesBuilder.ToString();

                if (!string.IsNullOrEmpty(staticProperties))
                {
                    // Pad correctly:
                    staticProperties = staticProperties.Replace("\n", "\n        ");

                    sb.Append(staticProperties);
                }

                if (plugins.Count > 0)
                {
                    sb.AppendLine("\n        #endregion\n");
                }
            }
            sb.Append("        #region Class Property Declarations\n");

            //Generate a Property per each Field
            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (ShouldProcessField(dr))
                {
                    StringBuilder propertyBodies = new StringBuilder();

                    if (_usePlugins)
                    {
                        // Get possible handler plugins to override the default property generation code
                        List<IKYSSEntityPlugin> plugins =
                            PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityInstancePropertyHandlerPlugin), false);

                        // Pass this row into each plugin, giving it a chance to "handle" the responsibility
                        // instead of the default code generation.
                        foreach (IKYSSEntityPlugin plugin in plugins)
                        {
                            DataTable rowTable = fieldInfoTable.Clone();
                            DataRow newRow = rowTable.NewRow();
                            newRow.ItemArray = dr.ItemArray;
                            rowTable.Rows.Add(newRow);

                            string body = plugin.GetBody(string.Empty, rowTable, _attributeClassesNamespace);
                            propertyBodies.Append(body);
                        }
                    }

                    if (propertyBodies.Length < 1)
                    {
                        string PrimaryKeyFieldAttribute = (dr["IsPrimaryKey"].ToString().ToLower() == "true" ? string.Format("        [{0}IsPrimaryKeyField(true)]\n", _attributeClassesNamespace) : string.Empty);

                        string maxLengthAttribute = String.Empty;
                        string numericPrecision = String.Empty;
                        string numericScale = String.Empty;
                        //rjt 2009.08.24 - added MaxLength, NumericPrecision and NumericScale attributes to entity properties
                        if (!String.IsNullOrEmpty(dr["character_maximum_length"].ToString()))
                        {
                            maxLengthAttribute = string.Format("        [{0}MaxLength(" + dr["character_maximum_length"].ToString() + ")]\n", _attributeClassesNamespace);
                        }

                        if (!String.IsNullOrEmpty(dr["numeric_precision"].ToString()))
                        {
                            numericPrecision = string.Format("        [{0}NumericPrecision(" + dr["numeric_precision"].ToString() + ")]\n", _attributeClassesNamespace);
                        }

                        if (!String.IsNullOrEmpty(dr["numeric_scale"].ToString()))
                        {
                            // Andrew 03.16.2011
                            // HARD Code the scale to 2 for most fields
                            // if KYSS_NumericScale exists as an extended property, use that
                            string numericScaleValue = dr["numeric_scale"].ToString();
                            int iNumericScale = Convert.ToInt16(numericScaleValue);
                            if (!String.IsNullOrEmpty(dr["numericscale"].ToString()))
                            {
                                numericScaleValue = dr["numericscale"].ToString();
                            }
                            else
                            {
                                if (iNumericScale != 0) numericScaleValue = "2";
                            }
                            if (iNumericScale != 0)
                            {
                                numericScale = string.Format("        [{0}NumericScale(" + numericScaleValue + ")]\n", _attributeClassesNamespace);
                            }
                        }

                        string attributeDeclarations = ConfigurationManager.AppSettings[dr["DATA_TYPE"].ToString()];

                        sb.Append(string.Format("        [{0}IsDatabaseField(true)]\n", _attributeClassesNamespace));
                        string displayCaption = dr["DISPLAY_CAPTION"].ToString();
                        if (!string.IsNullOrEmpty(displayCaption))
                        {
                            sb.Append(string.Format("        [{0}DisplayCaption(\"{1}\")]\n", _attributeClassesNamespace, displayCaption));
                        }
                        if (!string.IsNullOrEmpty(PrimaryKeyFieldAttribute))
                        {
                            sb.Append(PrimaryKeyFieldAttribute);
                        }

                        sb.Append(string.Format("        [{0}IsRequiredField(" + dr["IS_REQUIRED"].ToString() + ")]\n", _attributeClassesNamespace));

                        sb.Append(string.Format("        [{0}FieldType(CommonDataProvider.FieldTypes." + ConfigurationManager.AppSettings[dr["DATA_TYPE"].ToString()] + ")]\n", _attributeClassesNamespace));
                        if (!string.IsNullOrEmpty(maxLengthAttribute))
                        {
                            sb.Append(maxLengthAttribute);
                        }
                        if (!string.IsNullOrEmpty(numericPrecision))
                        {
                            sb.Append(numericPrecision);
                        }
                        if (!string.IsNullOrEmpty(numericScale))
                        {
                            sb.Append(numericScale);
                        }

                        string specialHandlingOptions = dr["SpecialDataHandling"].ToString();
                        bool allowNullAsDefault = false;
                        string stringExtValue = string.Empty;
                        
                        if (!String.IsNullOrEmpty(specialHandlingOptions))
                        {
                            sb.Append(string.Format("        [{0}SpecialDataHandlingAttribute(\"" + dr["SpecialDataHandling"].ToString() + "\")]\n", _attributeClassesNamespace));

                            String[] options = specialHandlingOptions.Split(',');

                            foreach (string option in options)
                            {
                                if (option.ToLower() == "allownullasdefault" )
                                {
                                    allowNullAsDefault = true;
                                    string nativeType = dr["DATA_TYPE"].ToString();
                                    if (nativeType.StartsWith("I", StringComparison.OrdinalIgnoreCase) || nativeType.Equals("tinyint", StringComparison.OrdinalIgnoreCase))
                                    {
                                        stringExtValue = ".ToInt()";
                                    }
                                    else if (nativeType.StartsWith("Dec", StringComparison.OrdinalIgnoreCase) || nativeType.StartsWith("Num", StringComparison.OrdinalIgnoreCase) )
                                    {
                                        stringExtValue = ".ToDouble()";
                                    }
                                    else if (nativeType.StartsWith("Date", StringComparison.OrdinalIgnoreCase))
                                    {
                                        stringExtValue = ".ToShortDate()";
                                        allowNullAsDefault = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            string nativeType = dr["DATA_TYPE"].ToString();
                            if (nativeType.StartsWith("Dec", StringComparison.OrdinalIgnoreCase) || nativeType.StartsWith("Num", StringComparison.OrdinalIgnoreCase))
                            {
                                stringExtValue = ".ToDouble()";
                            }
                        }

                        sb.Append(string.Format("        [{0}HasDatabaseDefault(" + dr["HAS_DATABASE_DEFAULT"].ToString() + ")]\n", _attributeClassesNamespace));
                        sb.Append("        public string " + dr["COLUMN_NAME"].ToString() + "\n");
                        sb.Append("        {\n");
                        sb.Append("            get {  return _" + dr["COLUMN_NAME"].ToString() + "; }\n");
                        sb.Append("            set\n");
                        sb.Append("            {\n");
                        if (allowNullAsDefault)
                        {
                            sb.Append("              if (String.IsNullOrEmpty(" + dr["COLUMN_NAME"].ToString() + "))\n");
                            sb.Append("              {\n");
                            sb.Append("                   if (!_" + dr["COLUMN_NAME"].ToString() + stringExtValue + ".Equals(value" + stringExtValue + "))\n");
                            sb.Append("                   {\n");
                            sb.Append("                       _" + dr["COLUMN_NAME"].ToString() + " = value;\n");
                            sb.Append("                       AddChangedField([CLASSNAME].DBFieldName." + dr["COLUMN_NAME"].ToString() + ".ToString(), value);\n");
                            sb.Append("                   }\n");
                            sb.Append("              }\n");
                            sb.Append("              else\n");
                            sb.Append("              {\n");
                        }

                        string fieldName = dr["COLUMN_NAME"].ToString();
                        if (!String.IsNullOrEmpty(stringExtValue) && !allowNullAsDefault && !fieldName.Equals("LastChangeUser", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append("                if ( this.IsNewEntity )\n");
                            sb.Append("                {\n");
                            sb.Append("                    if (!_" + dr["COLUMN_NAME"].ToString() + ".Equals(value" + "))\n");
                            sb.Append("                    {\n");
                            sb.Append("                       AddChangedField([CLASSNAME].DBFieldName." + dr["COLUMN_NAME"].ToString() + ".ToString(), value);\n");
                            sb.Append("                       _" + dr["COLUMN_NAME"].ToString() + " = value;\n");
                            sb.Append("                    }\n");
                            sb.Append("                }\n");
                            sb.Append("                else\n");
                            sb.Append("                {\n");
                        }

                        if (!fieldName.Equals("LastChangeUser", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append("                    if (!_" + dr["COLUMN_NAME"].ToString() + stringExtValue + ".Equals(value" + stringExtValue + "))\n");
                            sb.Append("                    {\n");
                        }

                        sb.Append("                       _" + dr["COLUMN_NAME"].ToString() + " = value;\n");

                        if (fieldName.Equals("LastChangeUser", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append("                       // This field is always logged as a change\n");
                        }
                        sb.Append("                       AddChangedField([CLASSNAME].DBFieldName." + dr["COLUMN_NAME"].ToString() + ".ToString(), value);\n");
                        if (!fieldName.Equals("LastChangeUser", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append("                    }\n");
                        }
                        if (allowNullAsDefault)
                        {
                            sb.Append("                 }\n");
                        }
                        if (!String.IsNullOrEmpty(stringExtValue) && !allowNullAsDefault && !fieldName.Equals("LastChangeUser", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append("                 }\n");
                        }
                        sb.Append("            }\n");
                        sb.Append("        }\n\n");
                    }
                    else
                    {
                        sb.Append(propertyBodies.ToString());
                    }
                }
            }
            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }
        /// <summary>
        /// These methods are used to create an entity that may have default values. Programmer could
        /// override the ApplyDefaults() method to prepopulate entity upon creation.
        /// </summary>
        /// <returns></returns>
        private string BuildEntityFactoryMethods()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"        #region Factory Methods
        
        /// <summary>
        /// Factory for creating an entity instance without default values
        /// </summary>
        /// <returns></returns>
        public static [CLASSNAME] CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name=""applyDefaults"">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static [CLASSNAME] CreateEntity(bool applyDefaults)
        {
            if (applyDefaults)
            {
                return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithDefaultValues);
            }
            else
            {
                return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
            }
        }

        /// <summary>
        /// Factory for creating an entity instance in the specified style, WithDefaultValues or WithoutDefaultValues
        /// </summary>
        /// <param name=""options"">Specifies the creation style</param>
        /// <returns>[CLASSNAME] instance</returns>
        public static [CLASSNAME] CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            [CLASSNAME] entity = new [CLASSNAME]();

            if (options == CreateEntityFactoryMethodOptionsEnum.WithDefaultValues)
            {
                entity.ApplyDefaults();
            }

            return entity;
        }

        #endregion

");

            return sb.ToString();
        }
        private string BuildEntityMethods(DataTable fieldInfoTable, DataTable primaryKeyFields, bool isView, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            //string primaryKeyField = GetPrimaryKey(fieldInfoTable);

            sb.Append("        #region Methods\n");

            //Get Entity Name Method
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Returns the name of the entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>Entity Name</returns>\n");
            sb.Append("        public static string GetEntityName()\n");
            sb.Append("        {\n");
            sb.Append("            return typeof([CLASSNAME]).Name;\n");
            sb.Append("        }\n\n");

            //Get Entity TableName Method
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Returns the actual table name of the entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>Table Name</returns>\n");
            sb.Append("        public static string GetTableName()\n");
            sb.Append("        {\n");
            sb.Append("            return \"[TABLENAME]\";\n");
            sb.Append("        }\n\n");

            bool isReadOnly = IsReadOnlyTable(tableName);

            if (primaryKeyFields.Rows.Count > 0 && (isView != true || isReadOnly))
            {
                // Retrieves a single entity of [tablename] data based on primary key
                sb.Append("        /// <summary>\n");
                sb.Append("        /// Retrieves entity information by ");
                string fields = string.Empty;
                foreach (DataRow dr in primaryKeyFields.Rows)
                {
                    if (fields.Length > 0)
                    {
                        fields += ", ";
                    }
                    fields += dr["COLUMN_NAME"].ToString();
                }
                sb.AppendLine(fields);
                sb.Append("        /// </summary>\n");
                foreach (DataRow dr in primaryKeyFields.Rows)
                {
                    sb.AppendLine("        /// <param name=\"" + dr["COLUMN_NAME"].ToString() + "\">" + dr["COLUMN_NAME"].ToString() + "</param>");
                }
                sb.Append("        /// <returns>Entity</returns>\n");
                sb.Append("        public static [CLASSNAME] GetByPrimaryKey(" + CreateMethodParameters(primaryKeyFields, true) + ")\n");
                sb.Append("        {\n");
                sb.Append("        	    [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
                sb.Append("        	    [CLASSNAME] [tablename] = provider.GetByPrimaryKey(" + CreateMethodParameters(primaryKeyFields, false) + ");\n\n");
                sb.Append("        	    if ([tablename] == null)\n");
                sb.Append("        	    {\n");
                sb.Append("        		    [tablename] = new [CLASSNAME]();\n");
                sb.Append("        	    }\n\n");
                sb.Append("        	    return [tablename];\n");
                sb.Append("         }\n\n");
            }

            // Retrieves a list of [tablename] data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Retrieves a list of all [tablename] data\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>DataTable</returns>\n");
            sb.Append("        public static DataTable GetDataTable()\n");
            sb.Append("        {\n");
            sb.Append("            [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
            
            sb.Append("            return provider.GetDataTable();\n");
            sb.Append("        }\n\n");

            // Retrieves a list of [tablename] data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Retrieves a list of [tablename] data by parameters\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"parameters\">Collection of parameters to search by</param>\n");
            sb.Append("        /// <returns>Entity of type [CLASSNAME]</returns>\n");
            sb.Append("        public static DataTable GetDataTable(Hashtable parameters)\n");
            sb.Append("        {\n");
            sb.Append("            [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
            sb.Append("            return provider.GetDataTable(parameters);\n");
            sb.Append("        }\n\n");

            // Retrieves an entity of [tablename] by parameters
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Retrieves an entity by parameters\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"parameters\">Collection of parameters to search by</param>\n");
            sb.Append("        /// <returns>Entity of type [CLASSNAME]</returns>\n");
            sb.Append("        public static [CLASSNAME] GetEntity(Hashtable parameters)\n");
            sb.Append("        {\n");
            sb.Append("            [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
            sb.Append("            return provider.GetEntity(parameters);\n");
            sb.Append("        }\n\n");

            if ((!isView && !isReadOnly))
            {
                // Saves Entity to database
                sb.Append("        #region CRUD Abstract Method Implementations\n");

                string saveMethod =
@"
        /// <summary>
        /// Saves Entity to database
        /// </summary>
        public override bool Save()
        {
            bool success = false;

            if (IsEntityModified)
            {
                PreSave();

                bool canSave = CanSave();

                if (!canSave)
                {
                    return false;
                }

                ApplyMandatoryDefaults();
                
                if (IsValid(this))
                {
                    [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();
                    success = provider.Save(this);
                }
            }
            else
            {
                success = true;
            }

            PostSave(success);

            return success;
        }
";            
                sb.Append(saveMethod);

                string deleteMethod =
@"
        /// <summary>
        /// Deletes Entity from database
        /// </summary>
        public override bool Delete()
        {
            bool success = false;

            PreDelete();

            bool canDelete = CanDelete();

            if (!canDelete)
            {
                return false;
            }

            [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();
            success = provider.Delete(this);

            PostDelete(success);

            return success;
        }
";
                sb.Append(deleteMethod);
                sb.AppendLine();
                sb.Append("        #endregion\n");
                sb.AppendLine();
            }

            // Creates a datatable with Entity data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates a datatable with Entity data\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>Datatable</returns>\n");
            sb.Append("        public override DataTable DataBind()\n");
            sb.Append("        {\n");
            sb.Append("             [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
            sb.Append("             return provider.DataBind(this);\n");
            sb.Append("        }\n\n");
            
            // Creates a Entity from table data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates a datatable with Entity data\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>[CLASSNAME]</returns>\n");
            sb.Append("        public static [CLASSNAME] DataBind(DataRow dr)\n");
            sb.Append("        {\n");
            sb.Append("             [CLASSNAME]DataProvider provider = new [CLASSNAME]DataProvider();\n");
            sb.Append("             return provider.DataBind(dr);\n");
            sb.Append("        }\n\n");

            // Creates an Entity from a copy of table data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates an Entity using a copy of the provided data row\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>[CLASSNAME]</returns>\n");
            sb.Append("        public static [CLASSNAME] DataBindCopy(DataRow dr)\n");
            sb.Append("        {\n");
            sb.Append("             object[] itemArray = dr.ItemArray;\n");
            sb.Append("             DataTable table = dr.Table.Clone();\n");
            sb.Append("             table.Rows.Add(itemArray);\n");
            sb.Append("             return DataBind(table.Rows[0]);\n");
            sb.Append("        }\n\n");
            sb.Append("        #endregion\n\n");

            // KYSS Plugins for instance methods
            if (_usePlugins)
            {
                List<IKYSSEntityPlugin> plugins =
                    PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityInstanceMethodPlugin), false);

                if (plugins.Count > 0)
                {
                    sb.AppendLine("        #region Plugin Instance Methods\n");

                    foreach (IKYSSEntityPlugin plugin in plugins)
                    {

                        string body = plugin.GetBody(tableName, fieldInfoTable);

                        if (!string.IsNullOrEmpty(body))
                        {
                            sb.Append(body);
                        }
                    }

                    sb.AppendLine("        #endregion");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// create stub class
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string BuildCustomEntityClass(string databaseName, string tableName, DataTable fieldInfoTable, string className)
        {
            StringBuilder sb = new StringBuilder();

            //Using Section
            sb.Append("//----------------------------------------------------------------------------------------//\n");
            sb.Append("// The following code has been generated using the Code Generator (version " + _version + ").\n");
            sb.Append("//---------------------------------------------------------------------------------------//\n\n");

            sb.Append(
@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Text;
            
");

            sb.Append(_entityUsingStatements);

            //Extended Entity Section
            sb.Append(
@"
namespace " + EntityNamespace.Text.Trim() + @"
{
    #region [CLASSNAME] Entity
        
    /// <summary>
    /// This class extends generated [CLASSNAME]
    /// </summary>                
    public partial class [CLASSNAME]
    {
        #region Custom Methods

        #endregion
 ");

            // KYSS Plugins for instance custom methods            
            if (_usePlugins)
            {
                List<IKYSSEntityPlugin> plugins =
                    PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityInstanceMethodCustomPlugin), false);

                if (plugins.Count > 0)
                {
                    string filePath = DatabaseList.Text + "\\partialClassStubs\\";

                    sb.AppendLine("\n\n        #region Plugins Instance Custom Methods\n");

                    foreach (IKYSSEntityPlugin plugin in plugins)
                    {
                        string body = plugin.GetBody(tableName, fieldInfoTable, filePath);

                        if (!string.IsNullOrEmpty(body))
                        {
                            sb.Append(body);
                        }
                    }
                    sb.AppendLine("");
                    sb.AppendLine("        #endregion");
                }
            }

sb.Append(
@"
    }

    #endregion
}");

            string classDefinition = sb.ToString();

            //Return code with [] replacements
            return CodeReplace(sb.ToString(), tableName, className);
        }
        private string BuildCustomEntityDataProviderClass(string databaseName, string tableName, string className)
        {
            StringBuilder sb = new StringBuilder();

            //Using Section
            sb.Append("//----------------------------------------------------------------------------------------//\n");
            sb.Append("// The following code has been generated using the Code Generator (version " + _version + ").\n");
            sb.Append("//---------------------------------------------------------------------------------------//\n\n");

            sb.Append(
@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Text;
            
");

            sb.Append(_entityDataProviderUsingStatements);
            //Data Provider Section
            sb.Append(
@"
namespace " + EntityDataProviderNamespace.Text.Trim() + @"
{
    #region [CLASSNAME] Entity Data Provider
        
    /// <summary>
    /// This class extends generated [CLASSNAME]DataProvider
    /// </summary>                
    public partial class [CLASSNAME]DataProvider
    {
        #region Custom Methods

        #endregion
    }

    #endregion
}");
            //Return code with [] replacements
            return CodeReplace(sb.ToString(), tableName, className);
        }

        #endregion

        #region Build Entity Data Provider
        private string BuildEntityDataProvider(DataTable primaryKeyFields, DataTable fieldInfoTable, string tableName, bool isView)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

");
            //rjt - added 2009.06.15
            sb.Append(_entityDataProviderUsingStatements);

            sb.Append("namespace " + EntityDataProviderNamespace.Text.Trim() + "\n");
            sb.Append("{\n");

            //Data Provider Header
            sb.Append("    #region [CLASSNAME] Data Provider\n\n");
            //sb.Append("namespace " + Namespace.Text.Trim() + ".Entity.Data\n");
            sb.Append("    public partial class [CLASSNAME]DataProvider" + (String.IsNullOrEmpty(_entityBaseName) ? String.Empty : " : " + _entityDataProviderBaseName) + "<[CLASSNAME]>\n");
            sb.Append("    {\n");
            sb.Append("        public [CLASSNAME]DataProvider() { }\n\n");

            sb.Append("        #region Members\n");
            //keep region in case it is needed later
            sb.Append("        #endregion\n\n");

            sb.Append("        #region Properties\n");
            //keep region in case it is needed later
            sb.Append("        #endregion\n\n");

            bool isReadOnly = IsReadOnlyTable(tableName);

            //Generate each inner section
            //only add CRUD methods if is not a view
            if (!isView)
            {
                sb.Append(BuildEntityDataProviderCrudMethods(primaryKeyFields, isReadOnly));
            }

            if (!isView && !isReadOnly)
            {                
//                sb.Append(BuildEntityDataProviderCrudMethods(primaryKeyFields));

                bool handledSetIdentity = false;

                if (_usePlugins)
                {                    
                    List<IKYSSEntityPlugin> plugins =
                        PluginLoader.GetEntityPlugins(typeof(KYSSPluginInterfaces.IEntityDataProviderCRUDMethodPlugin), false);

                    StringBuilder pluginBodies = new StringBuilder();

                    foreach (IEntityDataProviderCRUDMethodPlugin plugin in plugins)
                    {                        
                        string body = plugin.GetBody(tableName, fieldInfoTable);
                        pluginBodies.Append(body);

                        handledSetIdentity = plugin.HandledSetIdentity;
                    }

                    if (pluginBodies.Length > 0)
                    {
                        sb.AppendLine();
                        sb.AppendLine("        #region Plugin CRUD Methods");
                        sb.AppendLine();

                        sb.Append(pluginBodies.ToString());

                        sb.AppendLine();
                        sb.AppendLine("        #endregion");
                        sb.AppendLine();
                    }
                }
                
                if (!handledSetIdentity)
                {
                    foreach (DataRow dr in fieldInfoTable.Rows)
                    {
                        string isIdentity = dr["IS_IDENTITY"].ToString().ToLower();

                        if (isIdentity == "true")
                        {
                            sb.AppendLine("        protected override void SetIdentity([CLASSNAME] entity, string identity)");
                            sb.AppendLine("        {");
                            sb.AppendLine("            base.SetIdentity(entity, identity);");
                            sb.AppendLine("");
                            sb.AppendLine("            entity." + dr["COLUMN_NAME"].ToString() + " = identity;");
                            sb.AppendLine("        }");
                        }
                    }
                }
            }

            //RJT - REMOVED DUE TO KYSS.CORE
            //sb.Append(BuildEntityDataProviderCustomCrudMethods());
            
            //sb.Append(BuildEntityDataProviderDataBindMethods(primaryKeyFields));

            //RJT - REMOVED DUE TO KYSS.CORE
            //sb.Append(BuildEntityDataProviderPrivateHelperMethods());

            //Data Provider Footer
            sb.Append("    }\n\n");
            sb.Append("    #endregion\n\n");
            sb.Append("}\n");

            return sb.ToString();
        }
        private string BuildEntityDataProviderCrudMethods(DataTable primaryKeyFields, bool isReadOnly)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("        #region CRUD Methods\n\n");

            //do not build CRUD if primary key does not exist
            if (primaryKeyFields != null && primaryKeyFields.Rows.Count > 0)
            {
                // Used to get single Entity data by primary key
                sb.Append("        /// <summary>\n");
                sb.Append("        /// Used to retrieve Entity data by primary key\n");
                sb.Append("        /// </summary>\n");
                sb.Append(CreateCommentParameters(primaryKeyFields));
                sb.Append("        /// <returns>Entity</returns>\n");
                sb.Append("        public [CLASSNAME] GetByPrimaryKey(" + CreateMethodParameters(primaryKeyFields, true) + ")\n");
                sb.Append("        {\n");
                sb.Append("            Hashtable parameters = new Hashtable();\n");

                sb.Append(CreateHashTableParameters(primaryKeyFields));

                //--RJT added to support dynamic query
                sb.Append("            [CLASSNAME] entity = GetEntity(parameters);\n");
                sb.Append("            return entity;\n");
                sb.Append("        }\n\n");
            }

            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }
        private string BuildEntityDataProviderCustomCrudMethods()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region Custom CRUD Methods\n");
            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }
        private string BuildEntityDataProviderDataBindMethods(DataTable primaryKeyFields)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region DataBind Methods - TODO: MOVE TO BASE\n");
            // Creates datatable and populates it with entity data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates datatable and populates it with entity data\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"[CLASSNAME]\">Entity</param>\n");
            sb.Append("        /// <returns>DataTable</returns>\n");
            sb.Append("        public DataTable DataBind([CLASSNAME] [tablename])\n");
            sb.Append("        {\n");
            sb.Append("            DataTable dt = null;\n");
            sb.Append("            try\n");
            sb.Append("            {\n");
            sb.Append("                dt = CreateEntityFromDataRow([tablename]);\n");
            sb.Append("            }\n");
            sb.Append("            catch\n");
            sb.Append("            {\n");
            sb.Append("                //no data\n");
            sb.Append("            }\n");
            sb.Append("            return dt;\n");
            sb.Append("        }\n\n");

            // Creates a datatable with Entity data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates an Entity from a datarow\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <returns>[CLASSNAME]</returns>\n");
            sb.Append("        public [CLASSNAME] DataBind(DataRow dr)\n");
            sb.Append("        {\n");
            sb.Append("             [CLASSNAME] [tablename] = new [CLASSNAME]();\n");
            sb.Append("             try\n");
            sb.Append("             {\n");
            sb.Append("                 [tablename] = PoplulateFromDataRow(dr);\n");
            sb.Append("             }\n");
            sb.Append("             catch\n");
            sb.Append("             {\n");
            sb.Append("                 //no data\n");
            sb.Append("             }\n");
            sb.Append("             \n");
            sb.Append("             return [tablename];\n");
            sb.Append("        }\n\n");

            // Returns a list of [tablename] data
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Returns a list of [classname] data\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"storedProc\">Stored procedure name</param>\n");
            sb.Append("        /// <param name=\"parameters\">Hashtable of parameters to narrow search</param>\n");
            sb.Append("        /// <returns>DataTable</returns>\n");
            sb.Append("        public DataTable GetDataTable(string storedProc, Hashtable parameters)\n");
            sb.Append("        {\n");
            sb.Append("            DataSet ds = CommonDataProvider.GetDataSet(storedProc, parameters, true, this.ConnectionName );\n");
            sb.Append("            DataTable dt = new DataTable();\n");
            sb.Append("            if (ds.Tables.Count > 0)\n");
            sb.Append("            {\n");
            sb.Append("                if (ds.Tables[0].Rows.Count > 0)\n");
            sb.Append("                {\n");
            sb.Append("                    dt = ds.Tables[0];\n");
            sb.Append("                }\n");
            sb.Append("                else\n");
            sb.Append("                {\n");
            sb.Append("                    //return structure only\n");
            sb.Append("                    dt = ds.Tables[0].Clone();\n");
            sb.Append("                }\n");
            sb.Append("            }\n\n");
            sb.Append("            return dt;\n");
            sb.Append("        }\n");
            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }
        private string BuildEntityDataProviderPrivateHelperMethods()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        #region Provider Private Helper Methods\n");

            //Creates data table structure from entity
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Creates data table structure from entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"[tablename]\">Entity</param>\n");
            sb.Append("        /// <returns>Data Table (structure only)</returns>\n");
            sb.Append("        private DataTable CreateTable([CLASSNAME] [tablename])\n");
            sb.Append("        {\n");
            sb.Append("            DataTable table = new DataTable();\n");
            sb.Append("            Type typeDef = [tablename].GetType();\n");
            sb.Append("            PropertyInfo[] piCollection = typeDef.GetProperties();\n");
            sb.Append("            for (int i = 0; i < piCollection.Length; i++)\n");
            sb.Append("            {\n");
            sb.Append("                PropertyInfo pi = (PropertyInfo)piCollection.GetValue(i);\n");
            sb.Append("                table.Columns.Add(pi.Name);\n");
            sb.Append("            }\n");
            sb.Append("\n");
            sb.Append("            return table;\n");
            sb.Append("        }            \n");
            sb.Append("            \n");

            // Populates Entity from data reader
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Populates Entity from data reader\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"reader\">SqlDataReader</param>\n");
            sb.Append("        /// <returns>Entity</returns>\n");
            sb.Append("        private [CLASSNAME] PoplulateFromSqlDataReader(SqlDataReader reader)\n");
            sb.Append("        {\n");
            sb.Append("            //itterates through the properties in the [CLASSNAME] class\n");
            sb.Append("            //to set the values of these properties\n");
            sb.Append("            [CLASSNAME] [tablename] = new [CLASSNAME]();\n\n");
            sb.Append("        	    //do not track entity changes on initial load\n");
            sb.Append("        	    [tablename].EnableEntityStateTracking = false;\n\n");
            sb.Append("            Type typeDef = [tablename].GetType();\n");
            sb.Append("            PropertyInfo[] piCollection = typeDef.GetProperties();\n");
            sb.Append("            for (int i = 0; i < piCollection.Length; i++)\n");
            sb.Append("            {\n");
            sb.Append("                PropertyInfo pi = (PropertyInfo)piCollection.GetValue(i);\n");
            sb.Append("                pi.SetValue([tablename], Convert.ToString(reader[pi.Name]), new object[] { });\n");
            sb.Append("            }\n\n");
            sb.Append("        	    //re-enable tracking entity changes after initial load\n");
            sb.Append("        	    [tablename].EnableEntityStateTracking = true;\n");
            sb.Append("        	    [tablename].CurrentEntityState = EntityBase.EntityState.ExistingUnmodified;\n\n");
            sb.Append("            return [tablename];\n");
            sb.Append("        }\n\n");
            
            // Populates Entity from DataRow
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Populates Entity from DataRow\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"DataRow\">DataRow</param>\n");
            sb.Append("        /// <returns>Entity</returns>\n");
            sb.Append("        private [CLASSNAME] PoplulateFromDataRow(DataRow dr)\n");
            sb.Append("        {\n");
            sb.Append("            PropertyAttributeType attributeType = new PropertyAttributeType();\n");
            sb.Append("            //itterates through the properties in the [CLASSNAME] class\n");
            sb.Append("            //to set the values of these properties\n");
            sb.Append("            [CLASSNAME] [tablename] = new [CLASSNAME]();\n\n");
            sb.Append("        	    //do not track entity changes on initial load\n");
            sb.Append("        	    [tablename].EnableEntityStateTracking = false;\n\n");
            sb.Append("            Type typeDef = [tablename].GetType();\n");
            sb.Append("            PropertyInfo[] piCollection = typeDef.GetProperties();\n");
            sb.Append("            for (int i = 0; i < piCollection.Length; i++)\n");
            sb.Append("            {\n");
            sb.Append("                try\n");
            sb.Append("                {\n");
            sb.Append("                    PropertyInfo pi = (PropertyInfo)piCollection.GetValue(i);\n");
            sb.Append("                    if (attributeType.IsDatabaseField(pi))\n");
            sb.Append("                    {\n");
            sb.Append("                        pi.SetValue([tablename], Convert.ToString(dr[pi.Name]), new object[] { });\n");
            sb.Append("                    }\n");
            sb.Append("                }\n");
            sb.Append("                catch (Exception ex)\n");
            sb.Append("                {\n");
            sb.Append("                    //property does not exist in table\n");
            sb.Append("                    //ExceptionHandler.Log(ex);\n");
            sb.Append("                    ErrorHandler.AddError(ex.Message);\n");
            sb.Append("                }\n");
            sb.Append("            }\n\n");
            sb.Append("        	   //re-enable tracking entity changes after initial load\n");
            sb.Append("        	   [tablename].EnableEntityStateTracking = true;\n");
            sb.Append("        	   [tablename].CurrentEntityState = EntityBase.EntityState.ExistingUnmodified;\n\n");
            sb.Append("            return [tablename];\n");
            sb.Append("        }\n\n");

            // Populates DataTable from Entity
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Populates DataTable from Entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"[CLASSNAME]\">Entity</param>\n");
            sb.Append("        /// <returns>DataTable</returns>\n");
            sb.Append("        private DataTable CreateEntityFromDataRow([CLASSNAME] [tablename])\n");
            sb.Append("        {\n");
            sb.Append("            DataTable table = CreateTable([tablename]);\n");
//            sb.Append("            DataTable table = new DataTable();\n");
            //sb.Append("            Type typeDef = [tablename].GetType();\n");
            //sb.Append("            PropertyInfo[] piCollection = typeDef.GetProperties();\n");
            //sb.Append("            for (int i = 0; i < piCollection.Length; i++)\n");
            //sb.Append("            {\n");
            //sb.Append("                PropertyInfo pi = (PropertyInfo)piCollection.GetValue(i);\n");
            //sb.Append("                table.Columns.Add(pi.Name);\n");
            //sb.Append("            }\n");
            sb.Append("\n");
            sb.Append("            //get values from entity to populate new data row\n");
            sb.Append("            Hashtable ht = PopulateHashtable([tablename]);\n");
            sb.Append("            if (ht.Keys.Count > 0)\n");
            sb.Append("            {\n");
            sb.Append("                //create new data row and populate it with entity values\n");
            sb.Append("                DataRow dr = table.NewRow();\n");
            sb.Append("                foreach (string key in ht.Keys)\n");
            sb.Append("                {\n");
            sb.Append("                    dr[key.ToString()] = ht[key.ToString()];\n");
            sb.Append("                }\n");
            sb.Append("\n");
            sb.Append("                table.Rows.Add(dr);\n");
            sb.Append("            }\n");
            sb.Append("\n");
            sb.Append("            return table;\n");
            sb.Append("\n");
            sb.Append("        }\n\n");
            
            //sb.Append("            DataTable table = new DataTable();\n");
            //sb.Append("            Hashtable ht = PopulateHashtable([tablename]);\n\n");
            //sb.Append("            //build the table\n");
            //sb.Append("            foreach (string key in ht.Keys)\n");
            //sb.Append("            {\n");
            //sb.Append("                table.Columns.Add(key.ToString());\n");
            //sb.Append("            }\n\n");
            //sb.Append("            //add the data\n");
            //sb.Append("            DataRow dr = table.NewRow();\n");
            //sb.Append("            foreach (string key in ht.Keys)\n");
            //sb.Append("            {\n");
            //sb.Append("                dr[key.ToString()] = ht[key.ToString()];\n");
            //sb.Append("            }\n");
            //sb.Append("            table.Rows.Add(dr);\n\n");
            //sb.Append("            return table;\n");
            //sb.Append("        }\n\n");

            // Populates Hashtable from Entity
            sb.Append("        /// <summary>\n");
            sb.Append("        /// Populates Hashtable from Entity\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        /// <param name=\"[CLASSNAME]\">Entity</param>\n");
            sb.Append("        /// <returns>Hashtable</returns>\n");
            sb.Append("        private Hashtable PopulateHashtable([CLASSNAME] [tablename])\n");
            sb.Append("        {\n");
            sb.Append("            PropertyAttributeType attributeType = new PropertyAttributeType();\n");
            sb.Append("            Hashtable fields = new Hashtable();\n");
            sb.Append("            Type typeDef = [tablename].GetType();\n\n");
            sb.Append("            PropertyInfo[] piCollection = typeDef.GetProperties();\n");
            sb.Append("            for (int i = 0; i < piCollection.Length; i++)\n");
            sb.Append("            {\n");
            sb.Append("                PropertyInfo pi = (PropertyInfo)piCollection.GetValue(i);\n");
            sb.Append("                if (attributeType.IsDatabaseField(pi))\n");
            sb.Append("                {\n");
            sb.Append("                    if (pi.GetValue([tablename], new object[] { }) != null)\n");
            sb.Append("                    {\n");
            sb.Append("                        if (!String.IsNullOrEmpty(pi.GetValue([tablename], new object[] { }).ToString()))\n");
            sb.Append("                        {\n");
            sb.Append("                            fields.Add(pi.Name, pi.GetValue([tablename], new object[] { }).ToString());\n");
            sb.Append("                        }\n");
            sb.Append("                    }\n");
            sb.Append("                }\n");
            sb.Append("            }\n\n");
            sb.Append("            return fields;\n");
            sb.Append("        }\n\n");
            sb.Append("        #endregion\n\n");

            return sb.ToString();
        }

        #endregion

        #region SQL Generation methods
        #endregion

        #region HTML Data Structure builder
        private string BuildHTMLDataStructure(string serverName, string databaseName, string tableName, string className)
        {
            StringBuilder sb = new StringBuilder();
            DataTable primaryKeyFields = GetPrimaryKeys(tableName);

            //Get the FIELD info for the selected TABLE
            DataTable fieldInfoTable = GetFieldInfoTable(tableName);

            string rowColor = "#0d0d0d";

            if (_createHTMLDataStructureFile)
            {
                sb.Append("<table><tr style=\"font-weight:bold;background-color:#006B6B;\"><td colspan=4>" + tableName + "</td></tr>\n");
                sb.Append("<tr style=\"background-color:#009999;\"><td>Column Name</td><td>Data Type</td><td>Size</td><td>Is Required?</td></tr>\n");
            }

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (rowColor == "#E6FFFF")
                {
                    rowColor = "#FFFFFF";
                }
                else
                {
                    rowColor = "#E6FFFF";
                }                

                //field,dataType,isRequired,maxlen,precision,scale
                sb.Append("<tr style=\"background-color:" + (primaryKeyFields.Select("COLUMN_NAME = '" + dr["COLUMN_NAME"].ToString() + "'") != null ? "#80FFFF" : rowColor) + ";\">");
                sb.Append("<td>" + dr["COLUMN_NAME"].ToString() + "</td><td>" + dr["DATA_TYPE"].ToString()
                    + "</td><td>" + dr["CHARACTER_MAXIMUM_LENGTH"].ToString() + "</td><td>" + (primaryKeyFields.Select("COLUMN_NAME = '" + dr["COLUMN_NAME"].ToString() + "'") != null ? "true" : dr["IS_REQUIRED"].ToString()) + "</td></tr>\n");

            }

            sb.Append("</table>\n");

            return sb.ToString();
        }
        #endregion

        #region ASP Form Builder
        private string BuildTelerikGridForm(string tableName, DataTable primaryKeyFields, bool isView, bool isReadOnly, string className)
        {            
            StringBuilder sb = new StringBuilder();

            sb.Append("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"[CLASSNAME]GridControl.ascx.cs\" Inherits=\"Controls_[CLASSNAME]GridControl\" %>\n");
            sb.Append("\n");
            sb.Append("<%@ Register Assembly=\"Telerik.Web.UI\" Namespace=\"Telerik.Web.UI\" TagPrefix=\"telerik\" %>\n");
            sb.Append("\n");
            sb.Append("<telerik:RadGrid ID=\"[CLASSNAME]Grid\" runat=\"server\" Skin=\"Default\" AutoGenerateEditColumn=\"False\"\n");
            sb.Append("    GridLines=\"None\" OnNeedDataSource=\"[CLASSNAME]Grid_NeedDataSource\" \n");
            sb.Append("    AllowPaging=\"True\" AllowSorting=\"True\" OnItemCommand=\"[CLASSNAME]Grid_ItemCommand\">\n");
            sb.Append("    <PagerStyle Mode=\"NextPrevAndNumeric\" />\n");
            sb.Append("    <MasterTableView CommandItemDisplay=\"Top\">\n");
            sb.Append("        <RowIndicatorColumn>\n");
            sb.Append("            <HeaderStyle Width=\"20px\"></HeaderStyle>\n");
            sb.Append("        </RowIndicatorColumn>\n");
            sb.Append("        <ExpandCollapseColumn>\n");
            sb.Append("            <HeaderStyle Width=\"20px\"></HeaderStyle>\n");
            sb.Append("        </ExpandCollapseColumn>\n");
            sb.Append("        <EditFormSettings EditFormType=\"WebUserControl\" UserControlName=\"~/Controls/[CLASSNAME]FormControl.ascx\">\n");
            sb.Append("        </EditFormSettings>\n");
            sb.Append("        <Columns>  \n");

            if (primaryKeyFields.Rows.Count > 0 && (!isView && !isReadOnly))
            {
                sb.Append("	            <telerik:GridButtonColumn CommandName=\"Edit\" ButtonType=\"LinkButton\" Text=\"Edit\" CommandArgument=\"Edit\" UniqueName=\"EditButton\"/>\n");
                sb.Append("	            <telerik:GridButtonColumn CommandName=\"Delete\" ConfirmText=\"Delete this item?\" ButtonType=\"LinkButton\" Text=\"Delete\" UniqueName=\"DeleteButton\" />  \n");
            }
            else 
            {
                sb.Append("	            <telerik:GridButtonColumn CommandName=\"Edit\" ButtonType=\"LinkButton\" Text=\"View\" CommandArgument=\"Edit\" UniqueName=\"EditButton\"/>\n");
            }

            sb.Append("        </Columns>  \n");
            sb.Append("    </MasterTableView>\n");
            sb.Append("    <FilterMenu EnableTheming=\"True\">\n");
            sb.Append("        <CollapseAnimation Type=\"OutQuint\" Duration=\"200\"></CollapseAnimation>\n");
            sb.Append("    </FilterMenu>\n");
            sb.Append("</telerik:RadGrid>\n");

            return CodeReplace(sb.ToString(), tableName, className);
        }

        private string BuildTelerikGridCodeBehind(string tableName, DataTable primaryKeyFields, bool isView, bool isReadOnly, string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
@"
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

");

            sb.Append("using " + EntityNamespace.Text.Trim() + ";\n");
            sb.Append("using " + ErrorNamespace.Text.Trim() + ";\n");
            sb.Append("\n");

            sb.Append("using Telerik.Web.UI;\n");
            sb.Append("\n");
            sb.Append("public partial class Controls_[CLASSNAME]GridControl : GridControlBase\n");
            sb.Append("{\n");
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("    #region Members\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Properties\n");
            sb.Append("\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Methods\n");
            sb.Append("\n");

            sb.Append("    private void PopulateGrid(bool allowRebind)\n");
            sb.Append("    { \n");
            sb.Append("        //gets payroll notes for current company\n");
            sb.Append("        [CLASSNAME]Grid.DataSource = [CLASSNAME].GetDataTable();\n");
            if (primaryKeyFields.Rows.Count > 0)
            {
                string dataKeyNames = CreateFormattedFieldsString(primaryKeyFields, "[CLASSNAME].DBFieldName.{0}.ToString()", 
                                                                    new string[] { "COLUMN_NAME" },
                                                                    ", ",
                                                                    ", ",
                                                                    "");

                sb.Append("        [CLASSNAME]Grid.MasterTableView.DataKeyNames = new string[] { " + dataKeyNames + " };\n");
                sb.Append("        if (allowRebind)\n");
                sb.Append("        {\n");
                sb.Append("            [CLASSNAME]Grid.Rebind();\n");
                sb.Append("        }\n");
            }
            
            sb.Append("    }\n");

            sb.Append("\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region AJAX Events\n");
            sb.Append("\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Form Events\n");
            sb.Append("    protected void Page_Load(object sender, EventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    protected void [CLASSNAME]Grid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("        base.ConfigureGrid([CLASSNAME].GetEntityName(), source as RadGrid, e);\n");            
            sb.Append("        PopulateGrid(false);\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    protected void [CLASSNAME]Grid_ItemCommand(object source, GridCommandEventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("        switch (e.CommandName.ToLower())\n");
            sb.Append("        {\n");
            sb.Append("            case \"initinsert\":\n");
            sb.Append("                //add new\n");
            sb.Append("                ControlBase.EditSuccessful = false;\n");
            sb.Append("                break;\n");
            sb.Append("            case \"edit\":\n");
            sb.Append("                ControlBase.EditSuccessful = false;\n");
            sb.Append("                break;\n");
            sb.Append("            case \"update\":\n");
            sb.Append("                e.Canceled = !ControlBase.EditSuccessful;\n");
            sb.Append("                break;\n");


            if (primaryKeyFields.Rows.Count > 0 && (!isView && !isReadOnly))
            {
                sb.Append("            case \"delete\":\n");
                sb.Append("                GridDataItem item = e.Item as GridDataItem;\n");
                sb.Append("                [CLASSNAME] entity = new [CLASSNAME]();\n");
                string entityKeyFields = CreateFormattedFieldsString(primaryKeyFields,
                                                "                entity.{0} = item.OwnerTableView.DataKeyValues[item.ItemIndex][[CLASSNAME].DBFieldName.{0}.ToString()].ToString();",
                                                new string[] { "COLUMN_NAME" },
                                                "\n",
                                                "\n",
                                                "\n");

                sb.Append(entityKeyFields + "\n");
                sb.Append("                entity.Delete();\n");
                sb.Append("                break;\n");
            }

            sb.Append("            case \"cancel\":\n");
            sb.Append("                break;\n");
            sb.Append("        }\n");
            sb.Append("    }\n");
            sb.Append("    \n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("}\n");
            return CodeReplace(sb.ToString(), tableName, className);
        }

        private string BuildTelerikForm(string tableName, DataTable primaryKeyFields, bool isView, bool isReadOnly, string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"[CLASSNAME]FormControl.ascx.cs\" Inherits=\"Controls_[CLASSNAME]FormControl\" %>\n");
            sb.Append("\n");
            sb.Append("<%@ Register assembly=\"Telerik.Web.UI\" namespace=\"Telerik.Web.UI\" tagprefix=\"telerik\" %>\n");
            sb.Append("\n");
            sb.Append("<table width=\"500px\">\n");
            sb.Append("    <tr valign=\"top\">\n");
            sb.Append("        <td>\n");
            sb.Append("            <table width=\"100%\">\n");

            DataTable fieldInfoTable = GetFieldInfoTable(tableName);
            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (!dr["IsPrimaryKey"].Equals("true"))
                {
                    sb.Append(AddTelerikFormControl(dr["COLUMN_NAME"].ToString(), dr["DATA_TYPE"].ToString()));
                }
            }
            
            sb.Append("            </table>\n");
            sb.Append("        </td>\n");
            sb.Append("    </tr>\n");
            sb.Append("    <tr>\n");
            sb.Append("        <td>\n");
            sb.Append("            <asp:Panel ID=\"ControlButtonPanel\" runat=\"server\">\n");
            sb.Append("                <asp:Button ID=\"SaveButton\" runat=\"server\" Text=\"Save\" CommandName=\"Update\" OnClick=\"SaveButton_Click\" />\n");
            sb.Append("                &nbsp;<asp:Button ID=\"DeleteButton\" runat=\"server\" Text=\"Delete\" CommandName=\"Delete\" OnClick=\"DeleteButton_Click\" />\n");
            sb.Append("                &nbsp;<asp:Button ID=\"CancelButton\" runat=\"server\" Text=\"Cancel\" CommandName=\"Cancel\" />\n");
            sb.Append("            </asp:Panel>\n");
            sb.Append("        </td>\n");
            sb.Append("    </tr>\n");
            sb.Append("</table>\n");

            if (primaryKeyFields.Rows.Count > 0 && (!isView && !isReadOnly))
            {
                foreach (DataRow dr in primaryKeyFields.Rows)
                {
                    sb.AppendLine("<asp:Label ID=\"" + dr["COLUMN_NAME"] + "\" Text='<%# Eval(\"" + dr["COLUMN_NAME"] + "\")%>' runat=\"server\" Visible=\"false\"></asp:Label>");
                }
            }

            return CodeReplace(sb.ToString(), tableName, className);
        }

        private string AddTelerikFormControl(string controlName, string dataType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("                <tr>\n");
            sb.Append("                    <td>\n");
            sb.Append("                        <asp:Label ID=\"" + controlName + "_LABEL\" runat=\"server\" Text=\"" + controlName + ":\"></asp:Label>\n");
            sb.Append("                    </td>\n");

            sb.Append("                    <td>&nbsp;\n");
            sb.Append("                    </td>\n");

            sb.Append("                    <td>\n");

            switch (dataType)
            { 
                case "bit":
                    //checkbox
                    sb.Append("                        <asp:CheckBox ID=\"" + controlName + "\" Text=\"" + controlName + "\" runat=\"server\" />\n");
                    break;
                case "double":
                case "decimal":
                case "number":
                case "numeric":
                case "int":
                case "tinyint":
                case "integer":
                case "money":
                    //numeric
                    sb.Append("                        <telerik:RadNumericTextBox ID=\"" + controlName + "\" runat=\"server\"></telerik:RadNumericTextBox>\n");
                    break;
                case "date":
                case "datetime":
                    //date field
                    sb.Append("                        <telerik:RadDatePicker ID=\"" + controlName + "\" runat=\"server\"></telerik:RadDatePicker>\n");
                    break;
                default:
                    //textbox
                    sb.Append("                        <telerik:RadTextBox ID=\"" + controlName + "\" runat=\"server\"></telerik:RadTextBox>\n");
                    break;
            }
            sb.Append("\n");
            sb.Append("                    </td>\n");
            sb.Append("                </tr>\n");

            return sb.ToString();
        }

        private string BuildTelerikFormCodeBehind(string tableName, DataTable primaryKeyFields, bool isView, bool isReadOnly, string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using System.Web;\n");
            sb.Append("using System.Web.UI;\n");
            sb.Append("using System.Web.UI.WebControls;\n");
            sb.Append("\n");
            sb.Append("using " + EntityNamespace.Text.Trim() + ";\n");
            sb.Append("using " + ErrorNamespace.Text.Trim() + ";\n");
            sb.Append("\n");
            sb.Append("using Telerik.Web.UI;\n");
            sb.Append("\n");
            sb.Append("public partial class Controls_[CLASSNAME]FormControl : ControlBase\n");
            sb.Append("{\n");
            sb.Append("\n");
            sb.Append("    #region Members\n");
            sb.Append("    private bool _isLoaded = false;\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Properties\n");

            sb.Append("    /// <summary>\n");
            sb.Append("    /// Use GuidField for primary key\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    public string UniqueKey\n");
            sb.Append("    {\n");
            sb.Append("        get \n");
            sb.Append("        {\n");
            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("            return " + primaryKeyFields.Rows[0]["COLUMN_NAME"] + ".Text;\n");
            }
            else
            {
                sb.Append("            //TODO: Composite key or no primary key - add your own key\n ");
                sb.Append("            ErrorHandler.AddError(\"UniqueKey property not implemented. Composite key or no primary key so you must create a custom implementation.\");\n");
                sb.Append("            return String.Empty;\n ");
            }

            sb.Append("        }\n");
            sb.Append("        set \n");
            sb.Append("        {\n");

            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("            " + primaryKeyFields.Rows[0]["COLUMN_NAME"] + ".Text = value;\n");
            }
            else
            {
                sb.Append("           //TODO: Composite key or no primary key - add your own key\n ");
                sb.Append("            ErrorHandler.AddError(\"UniqueKey property not implemented. Composite key or no primary key so you must create a custom implementation.\");\n");
            }

            sb.Append("        }\n");
            sb.Append("    }\n");
            
            sb.Append("\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// True = Show , False = Hide\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    public bool ShowButtonPanel\n");
            sb.Append("    {\n");
            sb.Append("        set\n");
            sb.Append("        {\n");
            sb.Append("            ControlButtonPanel.Visible = value;\n");
            sb.Append("        }\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// Set when control is loaded\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    private bool IsLoaded\n");
            sb.Append("    {\n");
            sb.Append("        get {\n");
            sb.Append("            return _isLoaded;\n");
            sb.Append("        }\n");
            sb.Append("        set \n");
            sb.Append("        {\n");
            sb.Append("            _isLoaded = value; \n");
            sb.Append("        }\n");
            sb.Append("    }\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Methods\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// Method used to load page data.\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    public void LoadPage()\n");
            sb.Append("    {\n");
            sb.Append("        Populate();\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// Populates page data\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    private void Populate()\n");
            sb.Append("    {\n");
            sb.Append("        Populate(this.UniqueKey);    \n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    private void Populate(string id)\n");
            sb.Append("    {\n");
            sb.Append("        //get saved data\n");
            sb.Append("        [CLASSNAME] entity = new [CLASSNAME]();\n");
            sb.Append("        if (!String.IsNullOrEmpty(id))\n");
            sb.Append("        {\n");


            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("            entity = [CLASSNAME].GetByPrimaryKey(id);\n");
            }
            else
            {
                sb.Append("//TODO - Composite key or no primary key so you must get data\n");
            }
            
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        ControlBase.PopulateUIFromEntity(entity, this);\n");
            sb.Append("\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// Saves page data\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    /// <returns>True if successful</returns>\n");
            sb.Append("    public bool Save()\n");
            sb.Append("    {\n");
            sb.Append("        IsLoaded = true;\n");
            sb.Append("        bool success = false;\n");
            sb.Append("\n");


            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("        [CLASSNAME] entity = new [CLASSNAME]();\n");
                sb.Append("        if (!String.IsNullOrEmpty(this.UniqueKey))\n");
                sb.Append("        {\n");
                sb.Append("            entity = [CLASSNAME].GetByPrimaryKey(this.UniqueKey);\n");
                sb.Append("        }\n");
                sb.Append("\n");
                sb.Append("        //update with form data\n");
                sb.Append("        entity = ([CLASSNAME])PopulateEntityFromUI(entity, this);\n");
                sb.Append("\n");
                sb.Append("        success = entity.Save();\n");
            }
            else
            {
                sb.Append("        //TODO - no primary key so you must create your own save.\n");
                sb.Append("        ErrorHandler.AddError(\"Save Method not implemented. Composite Key or no primary key so you must create a custom implementation.\");\n");
            }

            sb.Append("\n");
            sb.Append("        //set for use with grid\n");
            sb.Append("        ControlBase.EditSuccessful = success;\n");
            sb.Append("\n");
            sb.Append("        if (success)\n");
            sb.Append("        {\n");

            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("            //update the unique key field\n");
                sb.Append("            this.UniqueKey = entity." + primaryKeyFields.Rows[0]["COLUMN_NAME"].ToString() + ";\n");
            }

            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        return success;\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    /// <summary>\n");
            sb.Append("    /// Deletes current page data\n");
            sb.Append("    /// </summary>\n");
            sb.Append("    /// <returns>True if successful</returns>\n");
            sb.Append("    public bool Delete()\n");
            sb.Append("    {\n");
            sb.Append("        IsLoaded = true;\n");
            sb.Append("        bool success = false;\n");
            sb.Append("				\n");

            if (primaryKeyFields.Rows.Count == 1 && (!isView && !isReadOnly))
            {
                sb.Append("        if (!String.IsNullOrEmpty(this.UniqueKey))\n");
                sb.Append("        {\n");
                sb.Append("            [CLASSNAME] entity = new [CLASSNAME]();\n");
                sb.Append("            entity." + primaryKeyFields.Rows[0]["COLUMN_NAME"].ToString() + " = this.UniqueKey;\n");
                sb.Append("            success = entity.Delete();\n");
                sb.Append("        }\n");
            }
            else
            {
                sb.Append("        //TODO - Composite key or no primary key so you must create your own delete\n");
                sb.Append("        ErrorHandler.AddError(\"Delete Method not implemented. Composite key or no primary key so you must create a custom implementation.\");\n");
            }
           
            sb.Append("				\n");
            sb.Append("        return success;\n");
            sb.Append("        \n");
            sb.Append("    }\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region AJAX Events\n");
            sb.Append("\n");
            sb.Append("    #endregion\n");
            sb.Append("\n");
            sb.Append("    #region Form Events\n");
            sb.Append("    protected void Page_Load(object sender, EventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("\n");
            sb.Append("    }\n");
            sb.Append("    protected void SaveButton_Click(object sender, EventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("        this.Save();\n");
            sb.Append("    }\n");
            sb.Append("\n");
            sb.Append("    protected void DeleteButton_Click(object sender, EventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("        this.Delete();\n");
            sb.Append("    }\n");
            sb.Append("\n");

            sb.Append("    protected override void OnPreRender(EventArgs e)\n");
            sb.Append("    {\n");
            sb.Append("        if (!IsLoaded)\n");
            sb.Append("        {\n");
            sb.Append("            //load page data\n");
            sb.Append("            LoadPage();\n");
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        base.OnPreRender(e);\n");
            sb.Append("    }\n");
            sb.Append("    #endregion\n");
            sb.Append("    \n");
            sb.Append("}\n");

            return CodeReplace(sb.ToString(), tableName, className);
        }
        #endregion

        #region Helper Methods
        private string CodeReplace(string code, string tableName, string className)
        {
            //Replace TABLE instances
            code = code.Replace("[TABLENAMEQUOTED]", String.Format("\"{0}\"", tableName));
            code = code.Replace("[TABLENAME]", tableName);
            code = code.Replace("[CLASSNAME]", className);

            //lower first character
            tableName = tableName.Substring(0, 1).ToLower() + tableName.Substring(1, tableName.Length - 1);
            code = code.Replace("[tablename]", tableName);
            className = className.Substring(0, 1).ToLower() + className.Substring(1, className.Length - 1);
            code = code.Replace("[classname]", className);

            return code;
        }

        private string UCaseFieldName(string word)
        {
            return word.ToUpper();
        }

        private string UCaseFirstCharacter(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1);
        }

        private string LCaseFirstCharacter(string word)
        {
            return word.Substring(0, 1).ToLower() + word.Substring(1, word.Length - 1);
        }

        private void CreateTextFile(string path, string fileName, string fileContents)
        {
            // Handle case when "fileName" may contain full path to the file instead of just file name
            if (!string.IsNullOrEmpty(fileName))
                fileName = Path.GetFileName(fileName);

            if (!String.IsNullOrEmpty(path))
            {
                if (Directory.Exists(path) == false)
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    fileName = di.FullName + "\\" + fileName;
                }
                else
                {
                    fileName = Directory.GetCurrentDirectory() + "\\" + path + "\\" + fileName;
                }
            }
            else
            {
                //empty path so create file in current path
                fileName = Directory.GetCurrentDirectory() + "\\" + fileName;
            }

            TextWriter tw = new StreamWriter(fileName);
            tw.Write(fileContents);
            tw.Close();
        }

        #endregion

        #endregion

        #region Database Info Methods
        private DataTable GetPrimaryKeys(string tableName)
        {
            return GetPrimaryKeys(tableName, false);
        }
        private DataTable GetPrimaryKeys(string tableName, bool getRowGuids)
        {
            string query =
@"
SELECT c.name as COLUMN_NAME
FROM sysindexkeys k
INNER JOIN syscolumns c ON c.id=k.id AND c.colid=k.colid
INNER JOIN sysindexes i ON i.id=k.id AND i.indid=k.indid
INNER JOIN sysobjects p ON i.name=p.name AND i.id=p.parent_obj AND p.xtype='PK' 
INNER JOIN sysobjects t ON i.id=t.id AND t.xtype='U' AND t.name = '{0}'
ORDER BY COLUMN_NAME ASC
";
            query = string.Format(query, tableName);
            
            DataTable dt = CommonDataProvider.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (_upperCaseFieldNames)
                    {
                        dr["COLUMN_NAME"] = UCaseFieldName(dr["COLUMN_NAME"].ToString());
                    }
                    else if (_upperCaseFirstCharacter)
                    {
                        dr["COLUMN_NAME"] = UCaseFirstCharacter(dr["COLUMN_NAME"].ToString());
                    }
                }
            }

            if (dt.Rows.Count == 0 || getRowGuids )
            {
                query = String.Format(@"SELECT name as COLUMN_NAME FROM syscolumns WHERE id = OBJECT_ID('{0}') AND COLUMNPROPERTY( id, name, 'IsRowGuidCol') = 1", tableName);
                dt = CommonDataProvider.GetDataTable(query);
                foreach (DataRow dr in dt.Rows)
                {
                    if (_upperCaseFieldNames)
                    {
                        dr["COLUMN_NAME"] = UCaseFieldName(dr["COLUMN_NAME"].ToString());
                    }
                    else if (_upperCaseFirstCharacter)
                    {
                        dr["COLUMN_NAME"] = UCaseFirstCharacter(dr["COLUMN_NAME"].ToString());
                    }
                }
            }
            return dt;
        }

        private DataTable GetPrimaryKeyInfoTable(DataTable fieldInfoTable)
        {
            DataTable primaryKeyFieldsTable = fieldInfoTable.Select(
                "IsPrimaryKey = 'true'", "COLUMN_NAME ASC").CopyToDataTable();

            return primaryKeyFieldsTable;
        }

        /// <summary>
        /// Returns the schema information from the physical table and any KYSS-specific extended proeprties
        /// </summary>
        /// <param name="tableName"></param>
        /// <remarks>
        /// Valid KYSS extended properties are:
        /// 
        /// KYSS_Is_Required = {true|false}
        /// If true, then add IsRequired attribute in entity, regardless of the underlying schema info
        /// If false, no special action taken
        /// KYSS_Excluded = {true|false}
        /// If true, do not include this in the generated entity
        /// If false or not present, generate it as normal
        /// KYSS_Default_Value = {string}
        /// Specifies the value auto-generated for ApplyDefaults and ApplyMandatoryDefaults
        /// KYSS_Display_Caption = string
        /// Specifies friendly name to display inside of error messages and for field labels
        /// KYSS_Is_Approvable = string
        /// Specifies whether or not the entity is available 
        /// KYSS_SpecialDataHandling
        /// Comma separated list of fields that may have some hardcoded characteristics
        /// KYSS_NumericScale
        /// overrides us setting scale to 2 by default
        /// </remarks>
        /// <returns></returns>
        private DataTable GetFieldInfoTable(string tableName)
        {
            string sql =
@"
SELECT 
    DISTINCT information_schema.columns.column_name,
    information_schema.columns.column_name AS original_column_name,
    information_schema.columns.data_type,
    CASE information_schema.columns.is_nullable
        WHEN 'YES'
            THEN 'false'
        ELSE
            'true'
    END AS is_required,
    information_schema.columns.character_maximum_length,
    information_schema.columns.numeric_precision,
    information_schema.columns.numeric_scale,    
    sys.identity_columns.is_identity AS is_identity,
    CASE
		WHEN
			information_schema.columns.column_default IS NULL 
		THEN
			'false'
		ELSE
			'true'
	END AS has_database_default,
    CASE 
         WHEN EXISTS
         (
            SELECT c.name as ColumnName
            FROM sysindexkeys k
            INNER JOIN syscolumns c ON c.id=k.id AND c.colid=k.colid
            INNER JOIN sysindexes i ON i.id=k.id AND i.indid=k.indid
            INNER JOIN sysobjects p ON i.name=p.name AND i.id=p.parent_obj AND p.xtype='PK' 
            INNER JOIN sysobjects t ON i.id=t.id AND t.xtype='U' AND t.name = '{0}' 
                AND c.name = information_schema.columns.column_name
        ) THEN 
            'true'
		WHEN (COLUMNPROPERTY(OBJECT_ID('{0}'), information_schema.columns.column_name, 'isRowGuidCol')) = 1
		THEN
			'true'
        ELSE 
            'false'    
    END AS isprimarykey,
    CASE
		WHEN (COLUMNPROPERTY(OBJECT_ID('{0}'), information_schema.columns.column_name, 'isRowGuidCol')) = 1
		THEN
			'true'
		ELSE
			'false'
	END AS is_rowguid,
    -- JSG / RJT 2009.08.31 Below are extended properties with the form KYSS_Display_Caption, etc
    'false' AS excluded, 
    CAST(NULL AS nvarchar(500)) AS display_caption,
    CAST(NULL AS nvarchar(500)) AS default_value,
    CAST(NULL as nvarchar(500)) as field_group,
    CAST(NULL as nvarchar(500)) as is_approvable,
    CAST(NULL as nvarchar(1000)) as specialdatahandling,
    CAST(NULL as nvarchar(10)) as numericscale
FROM
    information_schema.columns
    LEFT JOIN sys.identity_columns
    ON Object_name(sys.identity_columns.object_id) = information_schema.columns.table_name
        AND information_schema.columns.column_name = sys.identity_columns.name
    LEFT JOIN sys.index_columns ON Object_name(sys.index_columns.object_id) = information_schema.columns.table_name
        AND information_schema.columns.column_name = Col_name(sys.index_columns.object_id,sys.index_columns.column_id)
WHERE  
    information_schema.columns.table_name = '{0}'
";
            sql = string.Format(sql, tableName);

            DataTable dt = CommonDataProvider.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                //make first character of column name upper case 
                if (_upperCaseFieldNames)
                {
                    dr["COLUMN_NAME"] = UCaseFieldName(dr["COLUMN_NAME"].ToString());
                }
                else if (_upperCaseFirstCharacter)
                {
                    dr["COLUMN_NAME"] = UCaseFirstCharacter(dr["COLUMN_NAME"].ToString());
                }

                //primary key is auto-generated in database so it is not a required field
                if (dr["ISPRIMARYKEY"].ToString().ToLower() == "true")
                {
                    if (dr["IS_IDENTITY"].ToString().ToLower() == "true")
                    {
                        dr["IS_REQUIRED"] = "false"; //IDENTITY column is false because it is auto-generated (no validation needed)
                    }
                }
            }

            AddExtendedPropertiesToFieldInfoTable(tableName, dt);

            return dt;
        }

        private void AddExtendedPropertiesToFieldInfoTable(string tableName, DataTable fieldInfoTable)
        {
            const string columnNameKey = "COLUMN_NAME";

            string sql =
@"
SELECT 
	ex.objname as column_name,
	ex.name as attribute_name,
	ex.value as attribute_value
FROM		
	fn_listextendedproperty(NULL, 'user', 'dbo', 'table', '{0}', 'column', null) AS ex
";
            sql = string.Format(sql, tableName);

            DataTable dt = CommonDataProvider.GetDataTable(sql);

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                string columnName = dr[columnNameKey].ToString();
                DataRow[] rows = dt.Select(string.Format("{0} = '{1}'", columnNameKey, columnName));
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        string extendedAttribtueName = row["ATTRIBUTE_NAME"].ToString();
                        string extendedAttributeValue = row["ATTRIBUTE_VALUE"].ToString();

                        extendedAttribtueName = extendedAttribtueName.Replace("KYSS_", "");

                        //rjt: added to prevent errors when other attributes exist on fields
                        if (fieldInfoTable.Columns.Contains(extendedAttribtueName))
                        {
                            dr[extendedAttribtueName] = extendedAttributeValue;
                        }
                    }
                }
            }
        }

        private bool IsView(string tableName) 
        {
            bool isView = false;
            CommonDataProvider.ConnectionString = this.ConnectionString;
            string query = "SELECT NAME as TABLE_NAME, TYPE as TABLE_TYPE from sysobjects WHERE NAME = '" + tableName + "'";
            DataTable dt = CommonDataProvider.GetDataTable(query);

            if (dt != null && dt.Rows.Count > 0) 
            {
                if (dt.Rows[0]["TABLE_TYPE"].ToString().ToUpper().Trim() == "V")
                {
                    isView = true;
                }
            }

            return isView;
        }

        private bool IsReadOnlyTable(string tableName)
        {
            bool isReadOnly = false;
            CommonDataProvider.ConnectionString = this.ConnectionString;
            // 2009.11.02: Checking whether KYSS_Is_ReadOnly is defined 
            string query = "SELECT COUNT(*) FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', '{0}', null, null) ex WHERE ex.name = 'KYSS_Is_ReadOnly' AND value = 'true'";
            query = string.Format(query, tableName);
            
            int count = Convert.ToInt32(CommonDataProvider.ExecuteScalar(query));

            if (count > 0)
            {
                isReadOnly = true;
            }

            return isReadOnly;
        }

        #endregion

        #region String Formatting Methods
        private string CreateStoredProcedureParameters(DataTable fieldsTable)
        {
            return CreateFormattedFieldsString(fieldsTable,
                "     @{0} {1} ({2})",
                new string[] { "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" },
                ",\n",
                ",\n",
                "\n");
        }

        private string CreateWhereClause(DataTable primaryKeyFieldsTable)
        {
            string whereClause = String.Empty;
            if (primaryKeyFieldsTable.Rows.Count > 0)
            {
                // Defaults for single condition
                whereClause = "WHERE\n";
                string andFragment = string.Empty;

                // Use when multiple conditions exist in the fieldsTable
                if (primaryKeyFieldsTable.Rows.Count > 1)
                {
                    whereClause = "WHERE 1=1\n";
                    andFragment = "AND ";
                }

                whereClause += CreateFormattedFieldsString(primaryKeyFieldsTable,
                     "    " + andFragment + "[{0}] = @{0}",
                     new string[] { "COLUMN_NAME" },
                     "\n",
                     "\n",
                     "\n");
            }

            return whereClause;
        }

        private string CreateCommentParameters(DataTable fieldsTable)
        {
            return CreateFormattedFieldsString(fieldsTable,
                                                "        /// <param name=\"{0}\">{0}</param>",
                                                new string[] { "COLUMN_NAME" },
                                                "\n",
                                                "\n",
                                                "\n");
        }

        private string CreateMethodParameters(DataTable fieldsTable, bool includeDataType)
        { 
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in fieldsTable.Rows)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }

                if (includeDataType)
                {
                    sb.Append("string ");
                }

                sb.Append(dr["COLUMN_NAME"].ToString());
            }

            return sb.ToString();
        }

        private string CreateFieldAssignment(DataTable fieldsTable)
        {
            return CreateFormattedFieldsString(fieldsTable,
                                                "            this.{0} = {0};",
                                                new string[] { "COLUMN_NAME" },
                                                "\n",
                                                "\n",
                                                "\n");
        }

        private string CreateHashTableParameters(DataTable fieldsTable)
        {
            return CreateFormattedFieldsString(fieldsTable,
                                                "             parameters.Add(\"{0}\", {0});",
                                                new string[] { "COLUMN_NAME" },
                                                "\n",
                                                "\n",
                                                "\n");
        }

        private string CreateDeleteHashTableParameters(DataTable fieldsTable)
        {
            return CreateFormattedFieldsString(fieldsTable,
                                                "             parameters.Add(\"{0}\", [tablename].{0});",
                                                new string[] { "COLUMN_NAME" },
                                                "\n",
                                                "\n",
                                                "\n");
        }

        private string CreateFormattedFieldsString(DataTable fieldsTable, string formatString, string[] fieldNames, string suffixFirst, string suffixMiddle, string suffixLast)
        {
            StringBuilder sb = new StringBuilder();            
            int index = 0;
            int lastIndex = fieldsTable.Rows.Count;

            foreach (DataRow dr in fieldsTable.Rows)
            {
                List<string> values = new List<string>(fieldNames.Length);
                foreach (string fieldName in fieldNames)
                {
                    values.Add(dr[fieldName].ToString());
                }
                
                string line = formatString;

                if (index == 0 && lastIndex > 1)
                {
                    line = line + suffixFirst;
                }
                else if (index == lastIndex -1)
                {
                    line = line + suffixLast;
                }
                else
                {
                    line = line + suffixMiddle;
                }
                
                sb.Append(String.Format(line, values.ToArray()));

                index++;
            }

            return sb.ToString();
        }
        #endregion

        #region Helper Methods

        private bool ShouldProcessField(DataRow row)
        {
            string excluded = row["EXCLUDED"].ToString().ToLower();
            string dataType = row["DATA_TYPE"].ToString().ToLower();

            bool result = true;

            if (excluded == "true" || dataType == "timestamp")
            {
                result = false;
            }

            return result;
        }

        #endregion

        private void ConfigurationTab_Click(object sender, EventArgs e)
        {

        }

        private void cPreNameClass_CheckedChanged(object sender, EventArgs e)
        {
            txtPreName.Enabled = cPreNameClass.Checked;
        }
    }

}
