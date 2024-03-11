using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Web;
using System.Windows.Forms;
using Aprimo.DAM.ConfigurationMover.Models.DTOs;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.ClassificationImportDTO;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.FileTypeImportDTO;

namespace Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers
{
    public class Utils
    {
        public Logger logger;
        public List<FieldGroupDTO> fieldGroups { get; set; } 
        public List<ClassificationDTO> classifications { get; set; }

        public List<FieldDefinitionDTO> fieldDefinitions { get; set; }

        public List<LanguageDTO> languages { get; set; }

        public List<FileTypeDTO> fileTypes { get; set; }

        public List<UserGroupDTO> userGroups { get; set; }

        public List<WatermarkDTO> watermarks { get; set; }

        public List<RuleDTO> rules { get; set; }

        public List<SettingCategoryDTO> categories { get; set; }

        public List<SettingDefinitionDTO> settingDefinitions { get; set; }

          
        public Utils(Logger logger)
        {
            this.logger = logger;
        }
        #region FieldGroups

        /// <summary>
        /// Parses the xml and generates a list of field groups.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<FieldGroupDTO> GetFieldGroups(XDocument document)
        {
            var fieldgroups = from c in document.Descendants("fieldGroup")
                              select new FieldGroupDTO
                              {
                                  Name = Attributes.GetHtmlDecodedStringValue(c.Attribute("Name")),
                                  Action = Attributes.GetStringValue(c.Attribute("Action")),
                                  Tag = Elements.GetHtmlDecodedStringValue(c.Element("tag"))
                              };

            if (fieldgroups.Any(c => String.IsNullOrEmpty(c.Name)))
            {
                throw new ApplicationException("A fieldgroup Name element contains an empty value");
            }

            return fieldgroups.ToList();
        }

        /// <summary>
        /// Writes the field groups to the file
        /// </summary>
        /// <param name="fieldGroups"></param>
        /// <param name="fileName"></param>
        public void ExportFieldGroupsToFile(List<FieldGroupDTO> fieldGroups, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fieldGroups.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<fieldGroups>");

                foreach (FieldGroupDTO group in fieldGroups.OrderBy(g => g.Name))
                {
                    WriteFieldGroup(group, writer);
                    logger.LogInfo(string.Format("Processed field group {0}", group.Name));
                    progressBar.PerformStep();
                }

                writer.WriteLine("</fieldGroups>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;            
        }

        /// <summary>
        /// Writes one fieldgroup to the output file.
        /// </summary>
        /// <param name="currentGroup"></param>
        /// <param name="writer"></param>
        private void WriteFieldGroup(FieldGroupDTO currentGroup, TextWriter writer)
        {
            Console.WriteLine("Processing fieldgroup {0} - {1}", currentGroup.Name, currentGroup.Action);

            writer.WriteLine("  <fieldGroup Name=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(currentGroup.Name), currentGroup.Action);
            if (!string.IsNullOrEmpty(currentGroup.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentGroup.Tag));
            else
                writer.WriteLine("    <tag></tag>");
            writer.WriteLine("  </fieldGroup>");
        }

        /// <summary>
        /// Parses the xml and generates a list of field group members.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<FieldGroupDTO> GetFieldGroupMembers(XDocument document)
        {
            var fieldgroups = from c in document.Descendants("fieldGroup")
                              select new FieldGroupDTO
                              {
                                  Name = Attributes.GetHtmlDecodedStringValue(c.Attribute("Name")),
                                  Fields =  GetGroupFields(c.Elements("field"))
                              };

            if (fieldgroups.Any(c => String.IsNullOrEmpty(c.Name)))
            {
                throw new ApplicationException("A fieldgroup Name element contains an empty value");
            }

            return fieldgroups.ToList();
        }

        /// <summary>
        /// Writes the field group members to the file
        /// </summary>
        /// <param name="fieldGroups"></param>
        /// <param name="fileName"></param>
        public void ExportFieldGroupMembersToFile(List<FieldGroupDTO> fieldGroups, string fileName)
        {
            Console.WriteLine("Writing to file...");
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<fieldGroups>");

                foreach (FieldGroupDTO group in fieldGroups.OrderBy(g => g.Name))
                {
                    writer.WriteLine("  <fieldGroup Name=\"{0}\">", HttpUtility.HtmlEncode(group.Name));

                    foreach (FieldDefinitionDTO field in group.Fields)
                    {
                        WriteFieldGroupMember(field, writer);
                    }

                    writer.WriteLine("  </fieldGroup>");
                }

                writer.WriteLine("</fieldGroups>");
                writer.Flush();
            }
        }

        /// <summary>
        /// Writes one fieldgroup member to the output file.
        /// </summary>
        /// <param name="currentGroup"></param>
        /// <param name="writer"></param>
        private static void WriteFieldGroupMember(FieldDefinitionDTO currentField, TextWriter writer)
        {
            Console.WriteLine("Processing fieldgroup member {0}", currentField.Name);

            writer.WriteLine("    <field Name=\"{0}\" SortIndex=\"{1}\"></field>", HttpUtility.HtmlEncode(currentField.Name), currentField.SortIndex);
        }

        #endregion

        #region Fields

        /// <summary>
        /// Parses the xml and generates a list of fields.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        internal List<FieldDefinitionDTO> GetFieldDefinitions(XDocument document)
        {
            List<FieldDefinitionDTO> fields = new List<FieldDefinitionDTO>();
            foreach(var f in document.Descendants("field"))
            {
                fields.Add(new FieldDefinitionDTO
                {
                    Label = Elements.GetHtmlDecodedStringValue(f.Element("label")),
                    Labels = GetLabels(f.Element("labels")),
                    HelpText = Elements.GetHtmlDecodedStringValue(f.Element("helpText")),
                    HelpTexts = GetHelpTexts(f.Element("helpTexts")),
                    Name = Attributes.GetHtmlDecodedStringValue(f.Attribute("Name")),
                    Action = Attributes.GetStringValue(f.Attribute("Action")),
                    Scope = Elements.GetStringValue(f.Element("scope")),
                    DataType = Elements.GetStringValue(f.Element("dataType")),
                    IsInheritable = Elements.ConvertStringToBoolean(f.Element("isInheritable")),
                    EnableSearching = Elements.ConvertStringToBoolean(f.Element("enableSearching")),
                    ContainsUniqueIdentifiers = Elements.ConvertStringToBoolean(f.Element("containsUniqueIdentifiers")),
                    ReadOnly = Elements.ConvertStringToBoolean(f.Element("readOnly")),
                    IsRequired = Elements.ConvertStringToBoolean(f.Element("isRequired")),
                    FieldGroups = GetFieldGroups(f.Element("fieldGroups")),
                    Options = GetOptions(f.Element("options")),
                    RelationType = Elements.GetStringValue(f.Element("relationType")),
                    MaxLength = Elements.ConvertStringToInt(f.Element("maxLength")),
                    DefaultValue = Elements.GetStringValue(f.Element("default")),
                    DefaultTriggers = GetTriggers(f.Element("defaultTriggers")),
                    ResetToDefaultFields = GetFieldDefinitionIds(GetResetFields(f.Element("resetToDefaultFields"))),
                    ValidationValue = Elements.GetStringValue(f.Element("validation")),
                    ValidationTrigger = Elements.GetStringValue(f.Element("validationTrigger")),
                    ValidationMessage = Elements.GetStringValue(f.Element("validationMessage")),
                    StorageMode = Elements.GetStringValue(f.Element("storageMode")),
                    LanguageMode = Elements.GetStringValue(f.Element("languageMode")),
                    EnabledLanguages = GetEnabledLanguages(f.Element("enabledLanguages")),
                    ContentType = Elements.GetStringValue(f.Element("contentType")),
                    MultiValue = Elements.ConvertStringToBoolean(f.Element("multiValue")),
                    Tag = Elements.GetHtmlEncodedStringValue(f.Element("tag"), ""),
                    IsDynamicOptionList = Elements.ConvertStringToBoolean(f.Element("isDynamicOptionList")),
                    Accuracy = Elements.ConvertStringToDecimal(f.Element("accuracy")),
                    MinLength = Elements.ConvertStringToInt(f.Element("minLength")),
                    SortIndex = Elements.ConvertStringToInt(f.Element("sortIndex")),
                    InlineStyle = Elements.GetHtmlEncodedStringValue(f.Element("inlineStyle"), ""),
                    AllowReferences = Elements.GetStringValue(f.Element("allowReferences")),
                    RegularExpression = Elements.GetHtmlDecodedStringValue(f.Element("regularExpression")),
                    Inheritance = Elements.GetStringValue(f.Element("inheritance")),
                    SortOrder = Elements.GetStringValue(f.Element("sortOrder")),
                    Range = Elements.GetHtmlDecodedStringValue(f.Element("range")),
                    ParentClassifications = GetClassifications(f.Element("parentClassifications")),
                    ParentContentTypes = GetContentTypes(f.Element("parentContentTypes")),
                    ParentLabel = Elements.GetHtmlDecodedStringValue(f.Element("parentLabel")),
                    ParentLabels = GetLabels(f.Element("parentLabels")),
                    ChildClassifications = GetClassifications(f.Element("childClassifications")),
                    ChildContentTypes = GetContentTypes(f.Element("childContentTypes")),
                    ChildLabel = Elements.GetHtmlDecodedStringValue(f.Element("childLabel")),
                    ChildLabels = GetLabels(f.Element("childLabels")),
                    LinkClassifications = GetClassifications(f.Element("linkClassifications")),
                    LinkContentTypes = GetContentTypes(f.Element("linkContentTypes")),
                    ShowSummaryImage = Elements.ConvertStringToBoolean(f.Element("showSummaryImage")),
                    SummaryField = GetFieldDefinitionIds(new List<string>() { Elements.GetStringValue(f.Element("summaryField")) }).FirstOrDefault(),
                    DatePattern = Elements.GetHtmlDecodedStringValue(f.Element("datePattern")),
                    YearMonthPattern = Elements.GetHtmlDecodedStringValue(f.Element("yearMonthPattern")),
                    DateTimePattern = Elements.GetHtmlDecodedStringValue(f.Element("dateTimePattern")),
                    UseUTC = Elements.ConvertStringToBoolean(f.Element("useUTC")),
                    TimePattern = Elements.GetHtmlDecodedStringValue(f.Element("timePattern")),
                    ListSource = Elements.GetHtmlDecodedStringValue(f.Element("listSource")),
                    AllowSearchingOnNestedPropertiesAndFields = Elements.ConvertStringToBoolean(f.Element("allowSearchingOnNestedPropertiesAndFields")),
                    Filter = Elements.GetStringValue(f.Element("filter")),
                    DefaultView = Elements.GetStringValue(f.Element("defaultView")),
                    LinkRedordsToSelectedClassification = Elements.ConvertStringToBoolean(f.Element("linkRedordsToSelectedClassification")),
                    RootClassification = GetRootClassification(f.Element("rootClassification")),
                    MultiLine = Elements.ConvertStringToBoolean(f.Element("multiLine"))
                });
            }

            if (fields.Any(f => String.IsNullOrEmpty(f.Name)))
            {
                throw new ApplicationException("A Field Name element contains an empty value");
            }
            if (fields.Any(f => String.IsNullOrEmpty(f.DataType)))
            {
                throw new ApplicationException("A Field DataType element contains an empty value");
            }
            if (fields.Any(f => String.IsNullOrEmpty(f.Scope)))
            {
                throw new ApplicationException("A Field Scope element contains an empty value");
            }
            
            return fields.ToList();
        }

        /// <summary>
        /// gets all field group ids based on field group names from export file
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private List<string> GetFieldGroups(XElement element)
        {
            if(fieldGroups == null)
            {
                throw new Exception("GetFieldGroups: Field groups are not cached");
            }
            List<string> groups = new List<string>();

            foreach (XElement item in element.Descendants("fieldGroup"))
            {
                string val = Elements.GetHtmlDecodedStringValue(item);
                if (!string.IsNullOrEmpty(val) && !groups.Contains(val))
                {
                    if (fieldGroups.Any(x => x.Name.Equals(val)))
                    {                        
                        groups.Add(fieldGroups.Where(x => x.Name.Equals(val)).FirstOrDefault().Id);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("GetFieldGroups: WARNING - field group id not found in destination environment for {0}", val));
                    }
                }
            }

            return groups;
        }

        /// <summary>
        /// gets all field group names based id for export
        /// </summary>
        /// <param name="fieldGroupIds"></param>
        /// <returns></returns>
        private List<string> GetFieldGroupNames(List<string> fieldGroupIds)
        {
            if (fieldGroups == null)
            {
                throw new Exception("GetFieldGroups: Field groups are not cached");
            }

            List<string> fieldGroupNames = new List<string>();
            foreach(var id in fieldGroupIds)
            {
                if(fieldGroups.Any(x => x.Id.Equals(id)))
                {
                    fieldGroupNames.Add(fieldGroups.Where(x => x.Id.Equals(id)).FirstOrDefault().Name);
                }
            }
            return fieldGroupNames;
        }

        /// <summary>
        /// gets all field group ids based names for import
        /// </summary>
        /// <param name="fieldGroupNames"></param>
        /// <returns></returns>
        private List<string> GetFieldGroupIds(List<string> fieldGroupNames)
        {
            if (fieldGroups == null)
            {
                throw new Exception("GetFieldGroups: Field groups are not cached");
            }

            List<string> fieldGroupIds = new List<string>();
            foreach (var name in fieldGroupNames)
            {
                if (fieldGroups.Any(x => x.Name.Equals(name)))
                {
                    fieldGroupIds.Add(fieldGroups.Where(x => x.Name.Equals(name)).FirstOrDefault().Id);
                }
            }
            return fieldGroupIds;
        }

        private List<string> GetTriggers(XElement element)
        {
            List<string> triggers = new List<string>();

            foreach (XElement item in element.Descendants("trigger"))
            {
                string val = Elements.GetStringValue(item);
                if (!string.IsNullOrEmpty(val) && !triggers.Contains(val))
                    triggers.Add(val);
            }

            return triggers;
        }

        private List<string> GetResetFields(XElement element)
        {
            List<string> resetFieldNames = new List<string>();

            foreach (XElement item in element.Descendants("resetField"))
            {
                string val = Elements.GetStringValue(item);
                if (!string.IsNullOrEmpty(val) && !resetFieldNames.Contains(val))
                {                    
                    resetFieldNames.Add(val);
                }
            }

            return GetFieldDefinitions(resetFieldNames);
        }
        /// <summary>
        /// Gets the list of language ids for Enabled Languages from XML
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private List<string> GetEnabledLanguages(XElement element)
        {
            List<string> languageIds = new List<string>();

            foreach (XElement item in element.Descendants("language"))
            {
                string val = Elements.GetStringValue(item);
                if (!string.IsNullOrEmpty(val) && !languageIds.Contains(val))
                {
                    var id = GetLanguageId(val);
                    if(!string.IsNullOrEmpty(id))
                        languageIds.Add(id);
                }
            }
            return languageIds;
        }

        /// <summary>
        /// get option names based on ids for export
        /// </summary>
        /// <param name="optionIds"></param>
        /// <returns></returns>
        private List<string> GetOptionNames(List<string> optionIds, string fieldName)
        {
            if (fieldDefinitions == null)
            {
                throw new Exception("GetOptionNames: Field definitions are not cached");
            }
            List<string> options = new List<string>();
            if (fieldDefinitions.Any(x => x.Name.Equals(fieldName)))
            {
                var fieldOptions = fieldDefinitions.Where(x => x.Name.Equals(fieldName)).FirstOrDefault().Options;
                foreach (string id in optionIds)
                {
                    options.Add(fieldOptions.Where(x => x.Id.Equals(id)).FirstOrDefault().Name);
                }
            }
            return options;
        }

        /// <summary>
        /// get option ids based on names for import
        /// </summary>
        /// <param name="optionNames"></param>
        /// <returns></returns>
        private List<string> GetOptionIds(List<string> optionNames, string fieldName)
        {
            if (fieldDefinitions == null)
            {
                throw new Exception("GetOptionNames: Field definitions are not cached");
            }
            List<string> options = new List<string>();
            if (fieldDefinitions.Any(x => x.Name.Equals(fieldName)))
            {
                var fieldOptions = fieldDefinitions.Where(x => x.Name.Equals(fieldName)).FirstOrDefault().Options;
                foreach (string optionName in optionNames)
                {
                    options.Add(fieldOptions.Where(x => x.Name.Equals(optionName)).FirstOrDefault().Id);
                }
            }
            return options;
        }

        /// <summary>
        /// get classification namepaths based on ids for export
        /// </summary>
        /// <param name="classificationId"></param>
        /// <returns></returns>
        private List<string> GetClassifications(List<string> classificationIds)
        {
            if (classifications == null)
            {
                throw new Exception("GetClassifications: Classifications are not cached");
            }
            List<string> classificationsToExport = new List<string>();

            foreach (string id in classificationIds)
            {                                
                if (classifications.Any(x => x.Id.Equals(id)))
                {
                    classificationsToExport.Add(classifications.Where(x => x.Id.Equals(id)).FirstOrDefault().NamePath);
                }
                
            }

            return classificationsToExport;
        }

        /// <summary>
        /// get classification id based on namepaths for import
        /// </summary>
        /// <param name="classificationId"></param>
        /// <returns></returns>
        public List<string> GetClassificationIds(List<string> namepaths)
        {
            if (classifications == null)
            {
                throw new Exception("GetClassificationIds: Classifications are not cached");
            }
            List<string> classificationIds = new List<string>();

            foreach (string namepath in namepaths)
            {
                if (classifications.Any(x => x.NamePath.Equals(namepath)))
                {
                    classificationIds.Add(classifications.Where(x => x.NamePath.Equals(namepath)).FirstOrDefault().Id);
                }

            }

            return classificationIds;
        }

        private List<string> GetClassifications(XElement element)
        {
            if (classifications == null)
            {
                throw new Exception("GetClassifications: Classifications are not cached");
            }
            List<string> classificationsToImport = new List<string>();

            foreach (XElement item in element.Descendants("classification"))
            {
                string val = Elements.GetStringValue(item);
                if (!string.IsNullOrEmpty(val) && !classificationsToImport.Contains(val))
                {
                    if(classifications.Any(x => x.NamePath.Equals(val)))
                    {
                        classificationsToImport.Add(classifications.Where(x => x.NamePath.Equals(val)).FirstOrDefault().Id);
                    }          
                    else
                    {
                        logger.LogInfo(string.Format("GetClassifications: WARNING - could not find classification id at destination for classification {0}", val));
                    }
                }
            }

            return classificationsToImport;
        }

        private List<string> GetContentTypes(XElement element)
        {
            //if (contentTypes == null)
            //{
            //    throw new Exception("GetContentTypes: ContentTypes are not cached");
            //}
            List<string> contentTypesToImport = new List<string>();

            foreach (XElement item in element.Descendants("contentType"))
            {
                string val = Elements.GetStringValue(item);
                //if (!string.IsNullOrEmpty(val) && !contentTypesToImport.Contains(val))
                //{
                //    if (classifications.Any(x => x.Equals(val)))
                //    {
                        contentTypesToImport.Add(val);
                //    }
                //    else
                //    {
                //        logger.LogInfo(string.Format("GetContentTypes: WARNING - could not find content type {0} at destination.", val));
                //    }
                //}
            }

            return contentTypesToImport;
        }

        /// <summary>
        /// Gets the labels from the xml. label per language is processed.
        /// </summary>
        /// <param name="parentElement"></param>
        /// <returns></returns>
        private List<LabelDTO> GetLabels(XElement parentElement)
        {
            List<LabelDTO> items = new List<LabelDTO>();

            if (parentElement != null)
            {
                foreach (XElement item in parentElement.Elements())
                {
                    if (item != null)
                    {
                        string text = System.Web.HttpUtility.HtmlDecode(item.Value);
                        string language = GetLanguageId(item.FirstAttribute.Value);

                        if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(language))
                        {
                            items.Add(new LabelDTO { Language = language, Text = text });
                        }
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// Gets the help texts from the xml. Help text per language is processed.
        /// </summary>
        /// <param name="parentElement"></param>
        /// <returns></returns>
        private List<HelpTextDTO> GetHelpTexts(XElement parentElement)
        {
            List<HelpTextDTO> items = new List<HelpTextDTO>();

            if (parentElement != null)
            {
                foreach (XElement item in parentElement.Elements())
                {
                    if (item != null)
                    {
                        string text = System.Web.HttpUtility.HtmlDecode(item.Value);
                        string language = GetLanguageId(item.FirstAttribute.Value);

                        if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(language))
                        {
                            items.Add(new HelpTextDTO { Language = language, Text = text });
                        }
                    }
                }
            }

            return items;
        }

        private ImageDTO GetImage(XElement parentElement)
        {
            if (parentElement == null) return new ImageDTO();

            var ext = parentElement.Attribute("extension");
            if (ext == null) return new ImageDTO();
            var size = Attributes.ConvertStringToInt(parentElement.Attribute("size"));
            var width = Attributes.ConvertStringToInt(parentElement.Attribute("width"));
            var height = Attributes.ConvertStringToInt(parentElement.Attribute("height"));
            var url = parentElement.Attribute("uri");

            return new ImageDTO
            {
                Extension = ext.Value,
                Size = size,
                Height = height,
                Width = width,
                Uri = url.Value
            };
        }

        /// <summary>
        /// get namepath for export as replacement for classification id
        /// </summary>
        /// <param name="clsId"></param>
        /// <returns></returns>
        private string GetRootClassification(string clsId)
        {
            if (classifications == null)
            {
                throw new Exception("GetRootClassification: Classifications are not cached");
            }            
            if (!string.IsNullOrEmpty(clsId))
            {
                if (classifications.Any(x => x.Id.Equals(clsId)))
                {
                    return classifications.Where(x => x.Id.Equals(clsId)).FirstOrDefault().NamePath;
                }                
            }
            return "";
        }

        /// <summary>
        /// get id for classification based on namepath from export file
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private string GetRootClassification(XElement element)
        {
            if (classifications == null)
            {
                throw new Exception("GetRootClassification: Classifications are not cached");
            }
            string val = Elements.GetStringValue(element);
            if (!string.IsNullOrEmpty(val))
            {
                if (classifications.Any(x => x.NamePath.Equals(val)))
                {
                    return classifications.Where(x => x.NamePath.Equals(val)).FirstOrDefault().Id;
                }
                else
                {
                    logger.LogInfo(string.Format("GetRootClassification: WARNING - could not find root classification id on destination for classification {0}", val));
                }
            }
            return Guid.Empty.ToString();
        }

        private List<OptionDTO> GetOptions(XElement element)
        {
            List<OptionDTO> options = new List<OptionDTO>();

            foreach (XElement item in element.Descendants("option"))
            {
                OptionDTO newOption = new OptionDTO()
                {
                    Name = Attributes.GetHtmlDecodedStringValue(item.Attribute("Value")),
                    Label = Attributes.GetHtmlDecodedStringValue(item.Attribute("Label")),
                    Image = GetImage(item.Element("image")),
                    Action = Attributes.GetStringValue(item.Attribute("Action"))
                };

                newOption.Labels = GetLabels(item.Element("labels"));

                if (!string.IsNullOrEmpty(newOption.Name))
                    options.Add(newOption);
            }

            return options;
        }
        
        private List<FieldDefinitionDTO> GetGroupFields(IEnumerable<XElement> elements)
        {
            var fields = new List<FieldDefinitionDTO>();

            foreach (XElement item in elements)
            {
                string name = Attributes.GetHtmlDecodedStringValue(item.Attribute("Name"));
                int index = Attributes.ConvertStringToInt(item.Attribute("SortIndex"));

                fields.Add(new FieldDefinitionDTO { Name = name, SortIndex = index });
            }

            return fields;
        }

        /// <summary>
        /// Writes the fields to the file
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="fileName"></param>
        internal void ExportFieldsToFile(List<FieldDefinitionDTO> fields, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fields.Count;
            progressBar.Step = 1;
            Console.WriteLine("Writing to file...");
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<fields>");

                foreach (FieldDefinitionDTO field in fields)
                {
                    logger.LogInfo(string.Format("Processing field definition {0}", field.Name));
                    WriteField(field, writer);                   
                    progressBar.PerformStep();
                }

                writer.WriteLine("</fields>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Writes one fieldgroup to the output file.
        /// </summary>
        /// <param name="currentField"></param>
        /// <param name="writer"></param>
        internal void WriteField(FieldDefinitionDTO currentField, TextWriter writer)
        {            
            
            writer.WriteLine("  <field Name=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(currentField.Name), currentField.Action);
            writer.WriteLine("    <label>{0}</label>", HttpUtility.HtmlEncode(currentField.Label));
            
            writer.WriteLine("    <labels>");
            foreach (LabelDTO label in currentField.Labels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </labels>");
            writer.WriteLine("    <helpText>{0}</helpText>", HttpUtility.HtmlEncode(currentField.HelpText));

            writer.WriteLine("    <helpTexts>");
            foreach (HelpTextDTO helpText in currentField.HelpTexts)
            {
                writer.WriteLine("      <helpText language=\"{0}\">{1}</helpText>", GetLanguageName(helpText.Language), HttpUtility.HtmlEncode(helpText.Text));
            }

            writer.WriteLine("    </helpTexts>");

            writer.WriteLine("    <scope>{0}</scope>", currentField.Scope);
            writer.WriteLine("    <dataType>{0}</dataType>", currentField.DataType);

            writer.WriteLine("    <enableSearching>{0}</enableSearching>", currentField.EnableSearching);
            writer.WriteLine("    <containsUniqueIdentifiers>{0}</containsUniqueIdentifiers>", currentField.ContainsUniqueIdentifiers);
            writer.WriteLine("    <isInheritable>{0}</isInheritable>", currentField.IsInheritable);
            writer.WriteLine("    <readOnly>{0}</readOnly>", currentField.ReadOnly);
            writer.WriteLine("    <isRequired>{0}</isRequired>", currentField.IsRequired);
            writer.WriteLine("    <fieldGroups>");
            foreach (string fieldGroupName in GetFieldGroupNames(currentField.FieldGroups))
            {
                writer.WriteLine("      <fieldGroup>{0}</fieldGroup>", fieldGroupName);
            }
            writer.WriteLine("    </fieldGroups>");            
            writer.WriteLine("    <options>");
            foreach (OptionDTO option in currentField.Options)
            {
                writer.WriteLine("      <option Value=\"{0}\" Label=\"{1}\" Action=\"{2}\" >",
                    System.Web.HttpUtility.HtmlEncode(option.Name),
                    System.Web.HttpUtility.HtmlEncode(option.Label),
                    option.Action);

                if (option.Image != null && !string.IsNullOrEmpty(option.Image.Uri))
                {
                    writer.WriteLine("        <image extension=\"{0}\" size=\"{1}\" width=\"{2}\" height=\"{3}\" uri=\"{4}\"></image>", option.Image.Extension, option.Image.Size, option.Image.Width, option.Image.Height, System.Web.HttpUtility.HtmlEncode(option.Image.Uri));
                }
                else
                    writer.WriteLine("        <image></image>");

                if (option.Labels != null)
                {
                    writer.WriteLine("        <labels>");
                    foreach (LabelDTO label in option.Labels)
                    {
                        writer.WriteLine("          <label language=\"{0}\">{1}</label>", label.Language, HttpUtility.HtmlEncode(label.Text));
                    }
                    writer.WriteLine("        </labels>");
                }
                else writer.WriteLine("        <labels></labels>");
                writer.WriteLine("      </option>");
            }

            writer.WriteLine("    </options>");
            
            writer.WriteLine("    <relationType>{0}</relationType>", currentField.RelationType);
            writer.WriteLine("    <maxLength>{0}</maxLength>", currentField.MaxLength);

            if (!string.IsNullOrEmpty(currentField.DefaultValue))
                writer.WriteLine("    <default>{0}</default>", HttpUtility.HtmlEncode(currentField.DefaultValue));
            else
                writer.WriteLine("    <default />");

            writer.WriteLine("    <defaultTriggers>");
            foreach (string trigger in currentField.DefaultTriggers)
            {
                writer.WriteLine("      <trigger>{0}</trigger>", trigger);
            }
            writer.WriteLine("    </defaultTriggers>");

            writer.WriteLine("    <resetToDefaultFields>");
            foreach (string trigger in GetFieldDefinitions(currentField.ResetToDefaultFields))
            {
                writer.WriteLine("      <resetField>{0}</resetField>", trigger);
            }
            writer.WriteLine("    </resetToDefaultFields>");

            if (!string.IsNullOrEmpty(currentField.ValidationValue))
                writer.WriteLine("    <validation>{0}</validation>", HttpUtility.HtmlEncode(currentField.ValidationValue));
            else
                writer.WriteLine("    <validation />");

            if (!string.IsNullOrEmpty(currentField.ValidationMessage))
                writer.WriteLine("    <validationMessage>{0}</validationMessage>", HttpUtility.HtmlEncode(currentField.ValidationMessage));
            else
                writer.WriteLine("    <validationMessage />");

            writer.WriteLine("    <validationTrigger>{0}</validationTrigger>", currentField.ValidationTrigger);
            writer.WriteLine("    <storageMode>{0}</storageMode>", currentField.StorageMode);
            writer.WriteLine("    <languageMode>{0}</languageMode>", currentField.LanguageMode);
            writer.WriteLine("    <enabledLanguages>");
            foreach (string languageId in currentField.EnabledLanguages)
            {
                writer.WriteLine("      <language>{0}</language>", GetLanguageName(languageId));
            }
            writer.WriteLine("    </enabledLanguages>");

            writer.WriteLine("    <multiValue>{0}</multiValue>", currentField.MultiValue);
            writer.WriteLine("    <contentType>{0}</contentType>", currentField.ContentType);

            if (!string.IsNullOrEmpty(currentField.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentField.Tag));
            else
                writer.WriteLine("    <tag></tag>");

            writer.WriteLine("    <minLength>{0}</minLength>", currentField.MinLength);
            writer.WriteLine("    <isDynamicOptionList>{0}</isDynamicOptionList>", currentField.IsDynamicOptionList ? "True" : "False");
            writer.WriteLine("    <accuracy>{0}</accuracy>", currentField.Accuracy);
            writer.WriteLine("    <sortIndex>{0}</sortIndex>", currentField.SortIndex);
            writer.WriteLine("    <inlineStyle>{0}</inlineStyle>", HttpUtility.HtmlEncode(currentField.InlineStyle));
            writer.WriteLine("    <aiEnabled>{0}</aiEnabled>", currentField.AIEnabled);
            writer.WriteLine("    <allowReferences>{0}</allowReferences>", currentField.AllowReferences);
            writer.WriteLine("    <regularExpression>{0}</regularExpression>", HttpUtility.HtmlEncode(currentField.RegularExpression));
            writer.WriteLine("    <inheritance>{0}</inheritance>", currentField.Inheritance);
            writer.WriteLine("    <sortOrder>{0}</sortOrder>", currentField.SortOrder);
            writer.WriteLine("    <range>{0}</range>", HttpUtility.HtmlEncode(currentField.Range));
            writer.WriteLine("    <parentClassifications>");
            foreach (var cls in GetClassifications(currentField.ParentClassifications))
            {
                writer.WriteLine("      <classification>{0}</classification>", cls);
            }
            writer.WriteLine("    </parentClassifications>");
            writer.WriteLine("    <parentContentTypes>");
            foreach (var cls in currentField.ParentContentTypes)
            {
                writer.WriteLine("      <contentType>{0}</contentType>", cls);
            }
            writer.WriteLine("    </parentContentTypes>");
            writer.WriteLine("    <parentLabel>{0}</parentLabel>", HttpUtility.HtmlEncode(currentField.ParentLabel));

            writer.WriteLine("    <parentLabels>");
            foreach (LabelDTO label in currentField.ParentLabels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </parentLabels>");

            writer.WriteLine("    <childClassifications>");
            foreach (var cls in GetClassifications(currentField.ChildClassifications))
            {
                writer.WriteLine("      <classification>{0}</classification>", cls);
            }
            writer.WriteLine("    </childClassifications>");
            writer.WriteLine("    <childContentTypes>");
            foreach (var cls in currentField.ChildContentTypes)
            {
                writer.WriteLine("      <contentType>{0}</contentType>", cls);
            }
            writer.WriteLine("    </childContentTypes>");
            writer.WriteLine("    <childLabel>{0}</childLabel>", HttpUtility.HtmlEncode(currentField.ChildLabel));

            writer.WriteLine("    <childLabels>");
            foreach (LabelDTO label in currentField.ChildLabels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }
            writer.WriteLine("    </childLabels>");

            writer.WriteLine("    <linkClassifications>");
            foreach (var cls in GetClassifications(currentField.LinkClassifications))
            {
                writer.WriteLine("      <classification>{0}</classification>", cls);
            }
            writer.WriteLine("    </linkClassifications>");
            writer.WriteLine("    <linkContentTypes>");
            foreach (var cls in currentField.LinkContentTypes)
            {
                writer.WriteLine("      <contentType>{0}</contentType>", cls);
            }
            writer.WriteLine("    </linkContentTypes>");

            writer.WriteLine("    <showSummaryImage>{0}</showSummaryImage>", currentField.ShowSummaryImage);
            if (!string.IsNullOrEmpty(currentField.SummaryField))
                writer.WriteLine("    <summaryField>{0}</summaryField>", GetFieldDefinitions(new List<string>() { currentField.SummaryField }).FirstOrDefault());
            else
                writer.WriteLine("    <summaryField></summaryField>");
           writer.WriteLine("    <datePattern>{0}</datePattern>", HttpUtility.HtmlEncode(currentField.DatePattern));
            writer.WriteLine("    <yearMonthPattern>{0}</yearMonthPattern>", HttpUtility.HtmlEncode(currentField.YearMonthPattern));
            writer.WriteLine("    <dateTimePattern>{0}</dateTimePattern>", HttpUtility.HtmlEncode(currentField.DateTimePattern));
            writer.WriteLine("    <useUTC>{0}</useUTC>", currentField.UseUTC);
            writer.WriteLine("    <timePattern>{0}</timePattern>", HttpUtility.HtmlEncode(currentField.TimePattern));
            writer.WriteLine("    <listSource>{0}</listSource>", HttpUtility.HtmlEncode(currentField.ListSource));            
            writer.WriteLine("    <allowSearchingOnNestedPropertiesAndFields>{0}</allowSearchingOnNestedPropertiesAndFields>", currentField.AllowSearchingOnNestedPropertiesAndFields);
            writer.WriteLine("    <filter>{0}</filter>", HttpUtility.HtmlEncode(currentField.Filter));
            writer.WriteLine("    <defaultView>{0}</defaultView>", HttpUtility.HtmlEncode(currentField.DefaultView));
            writer.WriteLine("    <linkRedordsToSelectedClassification>{0}</linkRedordsToSelectedClassification>", currentField.LinkRedordsToSelectedClassification);
            writer.WriteLine("    <rootClassification>{0}</rootClassification>", GetRootClassification(currentField.RootClassification));            
            writer.WriteLine("    <multiLine>{0}</multiLine>", HttpUtility.HtmlEncode(currentField.MultiLine));
            writer.WriteLine("  </field>");
        }

        #endregion

        #region SettingCategories

        /// <summary>
        /// Converts the xml document to a list of categories.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<SettingCategoryDTO> GetSettingCategories(XDocument document)
        {
            var categories = from c in document.Descendants("category")
                             select new SettingCategoryDTO
                             {
                                 Name = Attributes.GetHtmlDecodedStringValue(c.Attribute("Name")),
                                 Labels = GetLabels(c.Element("labels")),
                                 Tag = Elements.GetHtmlDecodedStringValue(c.Element("tag"))
                             };

            if (categories.Any(c => String.IsNullOrEmpty(c.Name)))
            {
                throw new ApplicationException("A settingcategory Name element contains an empty value");
            }

            return categories.ToList();
        }

        /// <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="fileName"></param>
        public void ExportSettingCategoriesToFile(List<SettingCategoryDTO> categories, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = categories.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<settingCategories>");

                foreach (var category in categories.OrderBy(c => c.Name))
                {
                    WriteCategory(category, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</settingCategories>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }


        /// <summary>
        /// Writes the category to the file.
        /// </summary>
        /// <param name="currentCategory"></param>
        /// <param name="writer"></param>
        private void WriteCategory(SettingCategoryDTO currentCategory, TextWriter writer)
        {
            Console.WriteLine("Processing setting category {0}", currentCategory.Name);

            writer.WriteLine("  <category Name=\"{0}\" >", HttpUtility.HtmlEncode(currentCategory.Name));
            writer.WriteLine("    <labels>");

            foreach (LabelDTO label in currentCategory.Labels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </labels>");
            if (!string.IsNullOrEmpty(currentCategory.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentCategory.Tag));
            else
                writer.WriteLine("    <tag></tag>");
            writer.WriteLine("  </category>");
        }

        #endregion

        #region SettingDefinitions

        /// <summary>
        /// Converts the xml document to a list of definitions.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<SettingDefinitionDTO> GetSettingDefinitions(XDocument document)
        {
            var definitions = from d in document.Descendants("definition")
                             select new SettingDefinitionDTO
                             {
                                 Name = Attributes.GetHtmlDecodedStringValue(d.Attribute("Name")),                                 
                                 Labels = GetLabels(d.Element("labels")),
                                 CategoryId = GetCategoryId(Elements.GetStringValue(d.Element("category"))),
                                 DataType = Elements.GetStringValue(d.Element("dataType")),
                                 RoleRequiredForChange = Elements.GetStringValue(d.Element("roleRequiredForChange")),
                                 UserGroupSettingMode = Elements.GetStringValue(d.Element("userGroupSettingMode")),
                                 HelpUrl = Elements.GetHtmlDecodedStringValue(d.Element("helpUrl")),
                                 AllowSystemSetting = Elements.ConvertStringToBoolean(d.Element("allowSystemSetting")),
                                 AllowUserSetting = Elements.ConvertStringToBoolean(d.Element("allowUserSetting")),
                                 DefaultValue = Elements.GetHtmlDecodedStringValue(d.Element("defaultValue")),
                                 Tag = Elements.GetHtmlDecodedStringValue(d.Element("tag")),
                                 Schema = Elements.GetHtmlDecodedStringValue(d.Element("schema")),
                                 RegularExpression = Elements.GetHtmlDecodedStringValue(d.Element("regularExpression")),
                                 Range = Elements.GetHtmlDecodedStringValue(d.Element("range"))
                             };

            if (definitions.Any(d => String.IsNullOrEmpty(d.Name)))
            {
                throw new ApplicationException("A setting definition Name element contains an empty value");
            }

            return definitions.ToList();
        }

        /// <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="definitions"></param>
        /// <param name="fileName"></param>
        public void ExportSettingDefinitionsToFile(List<SettingDefinitionDTO> definitions, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = definitions.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<settingDefinitions>");

                foreach (var definition in definitions.OrderBy(c => c.Name))
                {
                    WriteSettingDefinition(definition, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</settingDefinitions>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }


        /// <summary>
        /// Writes the definition to the file.
        /// </summary>
        /// <param name="currentDefinition"></param>
        /// <param name="writer"></param>
        private void WriteSettingDefinition(SettingDefinitionDTO currentDefinition, TextWriter writer)
        {            
            writer.WriteLine("  <definition Name=\"{0}\" >", HttpUtility.HtmlEncode(currentDefinition.Name));
            writer.WriteLine("    <labels>");

            foreach (LabelDTO label in currentDefinition.Labels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </labels>");
            writer.WriteLine("  <category>{0}</category>", GetCategoryName(currentDefinition.CategoryId));
            writer.WriteLine("  <dataType>{0}</dataType>",currentDefinition.DataType);
            writer.WriteLine("  <roleRequiredForChange>{0}</roleRequiredForChange>", HttpUtility.HtmlEncode(currentDefinition.RoleRequiredForChange));
            writer.WriteLine("  <userGroupSettingMode>{0}</userGroupSettingMode>", currentDefinition.UserGroupSettingMode);
            writer.WriteLine("  <helpUrl>{0}</helpUrl>", HttpUtility.HtmlEncode(currentDefinition.HelpUrl));
            writer.WriteLine("  <allowSystemSetting>{0}</allowSystemSetting>", currentDefinition.AllowSystemSetting);
            writer.WriteLine("  <allowUserSetting>{0}</allowUserSetting>", currentDefinition.AllowUserSetting);
            writer.WriteLine("  <defaultValue>{0}</defaultValue>", HttpUtility.HtmlEncode(currentDefinition.DefaultValue));
            writer.WriteLine("  <regularExpression>{0}</regularExpression>", HttpUtility.HtmlEncode(currentDefinition.RegularExpression));
            writer.WriteLine("  <range>{0}</range>", HttpUtility.HtmlEncode(currentDefinition.Range));
            writer.WriteLine("  <schema>{0}</schema>", HttpUtility.HtmlEncode(currentDefinition.Schema));
            if (!string.IsNullOrEmpty(currentDefinition.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentDefinition.Tag));
            else
                writer.WriteLine("    <tag></tag>");
            writer.WriteLine("  </definition>");
        }

        /// <summary>
        /// gets setting category name for export as replacement for category id
        /// </summary>
        /// <returns>list of field definition names</returns>
        private string GetCategoryName(string categoryId)
        {
            if (categories == null)
            {
                throw new Exception("GetCategoryName: Setting Categories are not cached");
            }            
           
            if (!string.IsNullOrEmpty(categoryId))
            {
                if (categories.Any(x => x.Id.Equals(categoryId)))
                {
                   return categories.Where(x => x.Id.Equals(categoryId)).FirstOrDefault().Name;
                }
            }
            
            return "";
        }

        /// <summary>
        /// gets setting category id for export as replacement for category name
        /// </summary>
        /// <returns>list of field definition names</returns>
        private string GetCategoryId(string categoryName)
        {
            if (categories == null)
            {
                throw new Exception("GetCategoryId: Setting Categories are not cached");
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                if (categories.Any(x => x.Name.Equals(categoryName)))
                {
                    return categories.Where(x => x.Name.Equals(categoryName)).FirstOrDefault().Id;
                }
            }

            throw new Exception(string.Format("Can't ingest setting defintion without category, category {0} not found at destination", categoryName));
        }

        #endregion

        #region SettingValues

        /// <summary>
        /// Reads the xml document and converts it into a list of setting definitions.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<SettingValueDTO> GetSettingValues(XDocument document)
        {
            var categories = from s in document.Descendants("setting")
                             select new SettingValueDTO
                             {
                                 SettingName = Attributes.GetHtmlDecodedStringValue(s.Attribute("Name")),
                                 SystemLevelValue = Elements.GetStringValue(s.Element("systemValue")),
                                 UserGroupLevelValues = GetUserGroupSettingValues(s.Element("userGroupValues")),                                 
                             };

            if (categories.Any(s => String.IsNullOrEmpty(s.SettingName)))
            {
                throw new ApplicationException("A setting Name element contains an empty value");
            }            

            return categories.ToList();
        }

        /// <summary>
        /// Extract user group level setting values
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetUserGroupSettingValues(XElement xElement)
        {
            if (userGroups == null)
            {
                throw new Exception("GetUserGroupSettingValues: User Groups are not cached");
            }
            
            Dictionary<string, string> retval = new Dictionary<string, string>();
            foreach (var userGroupValue in xElement.Descendants("userGroup"))
            {
                var userGroupName = Attributes.GetStringValue(userGroupValue.Attribute("Name"));
                if (userGroups.Any(x => x.Name.Equals(userGroupName)))
                {
                    retval.Add(userGroups.Where(x => x.Name.Equals(userGroupName)).FirstOrDefault().Id, Elements.GetStringValue(userGroupValue));
                }               
            }

            return retval;
        }        

        /// <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="fileName"></param>
        public void ExportSettingValuesToFile(List<SettingValueDTO> settings, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = settings.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<settingValues>");

                foreach (var setting in settings.OrderBy(s => s.SettingName))
                {                    
                    logger.LogInfo(string.Format("Processing file type {0}", setting.SettingName));
                    WriteSettingValues(setting, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</settingValues>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="fileName"></param>
        public void ExportRulesToFile(List<RuleDTO> rule, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = rule.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<rules>");

                foreach (var ruleItem in rule.OrderBy(r => r.Name))
                {
                    logger.LogInfo(string.Format("Processing rule {0}", ruleItem.Name));
                    WriteRule(ruleItem, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</rules>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }


        /// <summary>
        /// Writes the setting definition to the export file.
        /// </summary>
        /// <param name="currentSetting"></param>
        /// <param name="writer"></param>
        internal static void WriteSettingValues(SettingValueDTO currentSetting, TextWriter writer)
        {            
            writer.WriteLine("  <setting Name=\"{0}\" >", HttpUtility.HtmlEncode(currentSetting.SettingName));                       
           
            writer.WriteLine("  <systemValue>{0}</systemValue>", HttpUtility.HtmlEncode(currentSetting.SystemLevelValue));
            writer.WriteLine("  <userGroupValues>");
            foreach (var item in currentSetting.UserGroupLevelValues)
            {
                writer.WriteLine("   <userGroup Name=\"{0}\">{1}</userGroup>", HttpUtility.HtmlEncode(item.Key), HttpUtility.HtmlEncode(item.Value));
            }
            writer.WriteLine("  </userGroupValues>");

            writer.WriteLine("  </setting>");
        }

        #endregion

        //#region Roles

        ///// <summary>
        ///// Reads the xml document and converts it into a list of setting definitions.
        ///// </summary>
        ///// <param name="document"></param>
        ///// <returns></returns>
        //internal static List<SettingDefinitionDTO> GetRoleSettingDefinitions(XDocument document)
        //{
        //    var categories = from c in document.Descendants("setting")
        //                     select new SettingDefinitionDTO
        //                     {
        //                         Name = Attributes.GetHtmlEncodedStringValue(c.Attribute("Name")),
        //                         DataType = GetDataType(Attributes.GetStringValue(c.Attribute("DataType"))),
        //                         Action = Attributes.GetStringValue(c.Attribute("Action")),
        //                         SettingCategory = Elements.GetStringValue(c.Element("settingCategory")),
        //                         DefaultValue = Elements.GetStringValue(c.Element("defaultValue")),
        //                         AllValues = GetRoleSettingValueDTO(c.Element("allValues")),
        //                         AllowUserGroupSetting = Elements.ConvertStringToBoolean(c.Element("allowUserGroupSetting")),
        //                         AllowUserSetting = Elements.ConvertStringToBoolean(c.Element("allowUserSetting")),
        //                         RoleRequiredToChange = Elements.GetHtmlEncodedStringValue(c.Element("roleRequiredToChange")),
        //                         UserGroupSettingMode = Elements.GetStringValue(c.Element("userGroupSettingMode")),
        //                         Label = Elements.GetStringValue(c.Element("label")),
        //                         Labels = Elements.GetLabels(c.Element("labels")),
        //                         Range = Elements.GetStringValue(c.Element("range")),
        //                         RegularExpression = Elements.GetStringValue(c.Element("regularExpression")),
        //                         Tag = Elements.GetStringValue(c.Element("Tag"))
        //                     };

        //    if (categories.Any(c => String.IsNullOrEmpty(c.Name)))
        //    {
        //        throw new ApplicationException("A setting Name element contains an empty value");
        //    }
        //    if (categories.Any(c => c.DataType == SettingDataType.None))
        //    {
        //        throw new ApplicationException("A setting DataType element contains an empty value");
        //    }
        //    if (categories.Any(c => String.IsNullOrEmpty(c.SettingCategory)))
        //    {
        //        throw new ApplicationException("A setting SettingCategory element contains an empty value");
        //    }

        //    return categories.ToList();
        //}
        ///// <summary>
        ///// Extract details for all settings from all levels (system, site, user group and user level)
        ///// </summary>
        ///// <param name="xElement"></param>
        ///// <returns></returns>
        //private static SettingValueDTO GetRoleSettingValueDTO(XElement xElement)
        //{
        //    var values = new SettingValueDTO();

        //    var userGroupValuesElem = xElement.Element("userGroupValues");
        //    foreach (var userGroupValue in userGroupValuesElem.Descendants("userGroup"))
        //    {
        //        values.UserGroupLevelValues.Add(Attributes.GetStringValue(userGroupValue.Attribute("Name")), Elements.GetStringValue(userGroupValue));
        //    }

        //    var userValuesElem = xElement.Element("userValues");
        //    foreach (var userValue in userValuesElem.Descendants("user"))
        //    {
        //        values.UserLevelValues.Add(Attributes.GetStringValue(userValue.Attribute("Name")), Elements.GetStringValue(userValue));
        //    }

        //    return values;
        //}

        ///// <summary>
        ///// Writes the entries to the file
        ///// </summary>
        ///// <param name="definitions"></param>
        ///// <param name="fileName"></param>
        //internal static void ExportRolesToFile(List<SettingDefinitionDTO> definitions, string fileName)
        //{
        //    Console.WriteLine("Writing to file...");
        //    using (TextWriter writer = File.CreateText(fileName))
        //    {
        //        writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        //        writer.WriteLine("<settingDefinitions>");

        //        foreach (var definition in definitions.OrderBy(c => c.Name))
        //        {
        //            WriteRoleDefinition(definition, writer);
        //        }

        //        writer.WriteLine("</settingDefinitions>");
        //        writer.Flush();
        //    }
        //}

        ///// <summary>
        ///// Writes the setting definition to the export file.
        ///// </summary>
        ///// <param name="currentSetting">The current setting.</param>
        ///// <param name="writer">The writer.</param>
        //private static void WriteRoleDefinition(SettingDefinitionDTO currentSetting, TextWriter writer)
        //{
        //    writer.WriteLine("  <setting Name=\"{0}\" DataType=\"{1}\" Action=\"{2}\" >", HttpUtility.HtmlEncode(currentSetting.Name), currentSetting.DataType, currentSetting.Action);
        //    writer.WriteLine("    <label>{0}</label>", HttpUtility.HtmlEncode(currentSetting.Label));
        //    writer.WriteLine("    <labels>");
        //    foreach (var label in currentSetting.Labels)
        //    {
        //        writer.WriteLine("      <label language=\"{0}\">{1}</label>", label.Language, HttpUtility.HtmlEncode(label.Text));
        //    }
        //    writer.WriteLine("    </labels>");
        //    writer.WriteLine("    <settingCategory>{0}</settingCategory>", currentSetting.SettingCategory);
        //    writer.WriteLine("    <defaultValue>{0}</defaultValue>", HttpUtility.HtmlEncode(currentSetting.DefaultValue));
        //    writer.WriteLine("    <allValues>");
        //    writer.WriteLine("      <systemValue>{0}</systemValue>", HttpUtility.HtmlEncode(currentSetting.AllValues.SystemLevelValue));
        //    writer.WriteLine("      <siteValues>");
        //    foreach (var item in currentSetting.AllValues.SiteLevelValues)
        //    {
        //        writer.WriteLine("        <site Name=\"{0}\">{1}</site>", HttpUtility.HtmlEncode(item.Key), HttpUtility.HtmlEncode(item.Value));
        //    }
        //    writer.WriteLine("      </siteValues>");
        //    writer.WriteLine("      <userGroupValues>");
        //    foreach (var item in currentSetting.AllValues.UserGroupLevelValues)
        //    {
        //        writer.WriteLine("        <userGroup Name=\"{0}\">{1}</userGroup>", HttpUtility.HtmlEncode(item.Key), HttpUtility.HtmlEncode(item.Value));
        //    }
        //    writer.WriteLine("      </userGroupValues>");
        //    writer.WriteLine("      <userValues>");
        //    foreach (var item in currentSetting.AllValues.UserLevelValues)
        //    {
        //        writer.WriteLine("        <user Name=\"{0}\">{1}</user>", HttpUtility.HtmlEncode(item.Key), HttpUtility.HtmlEncode(item.Value));
        //    }
        //    writer.WriteLine("      </userValues>");
        //    writer.WriteLine("    </allValues>");
        //    writer.WriteLine("    <allowSiteSetting>{0}</allowSiteSetting>", currentSetting.AllowSiteSetting);
        //    writer.WriteLine("    <allowSystemSetting>{0}</allowSystemSetting>", currentSetting.AllowSystemSetting);
        //    writer.WriteLine("    <allowUserGroupSetting>{0}</allowUserGroupSetting>", currentSetting.AllowUserGroupSetting);
        //    writer.WriteLine("    <allowUserSetting>{0}</allowUserSetting>", currentSetting.AllowUserSetting);
        //    writer.WriteLine("    <allowAnonymousAccess>{0}</allowAnonymousAccess>", currentSetting.AllowAnonymousAccess);
        //    writer.WriteLine("    <userGroupSettingMode>{0}</userGroupSettingMode>", currentSetting.UserGroupSettingMode);
        //    writer.WriteLine("    <roleRequiredToChange>{0}</roleRequiredToChange>", HttpUtility.HtmlEncode(currentSetting.RoleRequiredToChange));
        //    writer.WriteLine("    <xmlSettingSchema>{0}</xmlSettingSchema>", HttpUtility.HtmlEncode(currentSetting.Schema));
        //    writer.WriteLine("    <range>{0}</range>", HttpUtility.HtmlEncode(currentSetting.Range));
        //    writer.WriteLine("    <regularExpression>{0}</regularExpression>", HttpUtility.HtmlEncode(currentSetting.RegularExpression));
        //    if (!string.IsNullOrEmpty(currentSetting.Tag))
        //        writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentSetting.Tag));
        //    else
        //        writer.WriteLine("    <tag></tag>");
        //    writer.WriteLine("  </setting>");
        //}

        //#endregion

        #region Classifications

        /// <summary>
        /// Reads the xml document and creates a list of classifications.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        internal List<ClassificationImportDTO> GetClassifications(XDocument document, bool provideFields)
        {
            List<ClassificationImportDTO> classifications = new List<ClassificationImportDTO>();            
            var classificationsList = provideFields ? document.Descendants("classification").Where(x => x.Element("fields").HasElements || x.Element("slaveClassifications").HasElements).ToList() : document.Descendants("classification");
            foreach (var c in classificationsList)
            {
                var cls = new ClassificationImportDTO()
                {
                    Name = Elements.GetHtmlDecodedStringValue(c.Element("name")),
                    NamePath = Attributes.GetHtmlDecodedStringValue(c.Attribute("Path")),
                    ParentPath = GetParentPath(c.Attribute("Path"), c.Element("name")),
                    IsRoot = Elements.ConvertStringToBoolean(c.Element("isRoot")),
                    Action = Attributes.GetStringValue(c.Attribute("Action")),
                    Labels = GetLabels(c.Element("labels")),
                    SortIndex = Elements.ConvertStringToInt(c.Element("sortIndex")),
                    SortOrder = Elements.GetStringValue(c.Element("sortOrder")),
                    Identifier = Elements.GetHtmlDecodedStringValue(c.Element("identifier")),
                    Slaveclassifications = !provideFields ? null : GetSlaveClassifications(c.Element("slaveClassifications")),
                    RegisteredFields = GetFieldsToRegister(c.Element("registeredFields")),
                    RegisteredFieldGroups = GetFieldGroupsToRegister(c.Element("registeredFieldGroups")),
                    Fields = !provideFields ? null : GetFieldsForClassification(c.Element("fields")),
                    Tag = Elements.GetHtmlDecodedStringValue(c.Element("tag"))
                };
                classifications.Add(cls);
            }                

            if (classifications.Any(c => String.IsNullOrEmpty(c.Name)))
            {
                throw new Exception("A Classification Name element contains an empty value");
            }                      

            return classifications.ToList();
        }


        private string GetParentPath(XAttribute attributeForPath, XElement elementForName)
        {            
            var fullPath = Attributes.GetHtmlDecodedStringValue(attributeForPath);
            var classificationName = Elements.GetHtmlDecodedStringValue(elementForName);
            var parentPath = fullPath.Replace(string.Format("/{0}", classificationName), "");
            return string.IsNullOrEmpty(parentPath) ? null : parentPath;
            
        }

        private ListItemsToAddRemove GetListStringItemsToAddRemove(XElement element)
        {
            var retVal = new ListItemsToAddRemove();
            if (element == null) return retVal;
            retVal.AddOrUpdate = Elements.GetStringListValue(element);
            retVal.Remove = new List<string>();
            return retVal;
        }

        private ListItemsToAddRemove GetFieldsToRegister(XElement element)
        {
            var retVal = new ListItemsToAddRemove();
            if (element == null) return retVal;
            retVal.AddOrUpdate = GetFieldDefinitionIds(Elements.GetStringListValue(element));
            retVal.Remove = new List<string>();
            return retVal;
        }

        private ListItemsToAddRemove GetFieldGroupsToRegister(XElement element)
        {
            var retVal = new ListItemsToAddRemove();
            if (element == null) return retVal;
            retVal.AddOrUpdate = GetFieldGroupIds(Elements.GetStringListValue(element));
            retVal.Remove = new List<string>();
            return retVal;
        }

        private ListItemsToAddRemove GetSlaveClassifications(XElement element)
        {
            var retVal = new ListItemsToAddRemove();
            retVal.AddOrUpdate = GetClassificationIds(Elements.GetStringListValue(element));
            retVal.Remove = new List<string>();
            return retVal;
        }

        private ClassificationFields GetFieldsForClassification(XElement element)
        {
            
            var retVal = new ClassificationFields();
            if (element == null) return retVal;
            retVal.addOrUpdate = new List<FieldsAddOrUpdate>();
            foreach (var item in element.Elements())
            {
                if (item == null) continue;
               
                var fieldName = item.Attribute("name").Value;
                var dataType = item.Attribute("dataType").Value;
                if (!string.IsNullOrEmpty(fieldName) && fieldDefinitions.Any(x => x.Name.Equals(fieldName)))
                {
                    FieldsAddOrUpdate field = new FieldsAddOrUpdate();
                    field.id = fieldDefinitions.Where(x => x.Name.Equals(fieldName)).FirstOrDefault().Id;
                    field.localizedValues = new List<LocalizedValues>();
                    foreach (var value in item.Elements())
                    {
                        if (value == null) continue;
                        var languageName = value.Attribute("language").Value;
                        var localizedValue = new LocalizedValues();
                        if (!string.IsNullOrEmpty(languageName) && languages.Any(x => x.Name.Equals(languageName)))
                        {                            
                            localizedValue.Language = GetLanguageId(languageName);
                        }
                        if (string.IsNullOrEmpty(languageName))
                        {
                            localizedValue.Language = languages.Where(x => x.Name.Equals("English (US English)")).FirstOrDefault().Id;
                        }
                        if (!string.IsNullOrEmpty(localizedValue.Language))
                        {
                            var fieldValue = System.Web.HttpUtility.HtmlDecode(value.Value);
                            if (dataType.Equals("classificationlist", StringComparison.InvariantCultureIgnoreCase))
                            {
                                localizedValue.Values = GetClassificationIds(HttpUtility.HtmlDecode(fieldValue).Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList());
                            }
                            else if (dataType.Equals("optionlist", StringComparison.InvariantCultureIgnoreCase))
                            {
                                localizedValue.Values = GetOptionIds(HttpUtility.HtmlDecode(fieldValue).Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList(), fieldName);
                            }
                            else
                            {
                                localizedValue.Value = HttpUtility.HtmlDecode(fieldValue);
                            }
                            field.localizedValues.Add(localizedValue);
                        }
                    }
                    retVal.addOrUpdate.Add(field);
                }
            }
            
            return retVal;
        }

        // <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="classifications"></param>
        /// <param name="fileName"></param>
        internal void ExportClassificationsToFile(List<ClassificationDTO> classifications, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = classifications.Count;
            progressBar.Step = 1;            
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<classifications>");

                foreach (ClassificationDTO classification in classifications.OrderBy(c => c.NamePath))
                {
                    logger.LogInfo(string.Format("Processing classification {0}", classification.NamePath));
                    WriteClassification(classification, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</classifications>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Exports the classification to the file.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="writer"></param>
        private void WriteClassification(ClassificationDTO item, TextWriter writer)
        {            
            writer.WriteLine("  <classification Path=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(item.NamePath), item.Action);
            writer.WriteLine("    <name>{0}</name>", HttpUtility.HtmlEncode(item.Name));
            writer.WriteLine("    <namePath>{0}</namePath>", HttpUtility.HtmlEncode(item.NamePath));
            writer.WriteLine("    <labels>");

            foreach (LabelDTO label in item.Labels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </labels>");
            writer.WriteLine("    <sortIndex>{0}</sortIndex>", item.SortIndex);
            writer.WriteLine("    <sortOrder>{0}</sortOrder>", item.SortOrder);
            writer.WriteLine("    <identifier>{0}</identifier>", HttpUtility.HtmlEncode(item.Identifier));
            writer.WriteLine("    <isRoot>{0}</isRoot>", item.IsRoot);
            writer.WriteLine("    <registeredFields>");
            foreach (string field in GetFieldDefinitions(item.RegisteredFields.Select(x => x.FieldId).ToList<string>()))
            {
                writer.WriteLine("      <registeredField>{0}</registeredField>", HttpUtility.HtmlEncode(field));
            }
            writer.WriteLine("    </registeredFields>");


            writer.WriteLine("    <registeredFieldGroups>");
            foreach (string fieldGroup in GetFieldGroupNames(item.RegisteredFieldGroups.Select(x => x.FieldGroupId).ToList<string>()))
            {
                writer.WriteLine("      <registeredFieldGroup>{0}</registeredFieldGroup>", HttpUtility.HtmlEncode(fieldGroup));
            }
            writer.WriteLine("    </registeredFieldGroups>");            

            if (!string.IsNullOrEmpty(item.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(item.Tag));
            else
                writer.WriteLine("    <tag></tag>");

            writer.WriteLine("    <slaveClassifications>");
            foreach (var slaves in item.Embedded.SlaveClassifications.SlaveItems)
            {
                writer.WriteLine("      <slave>{0}</slave>", HttpUtility.HtmlEncode(slaves.NamePath));
            }
            writer.WriteLine("    </slaveClassifications>");

            if (item.Embedded.Image != null && !string.IsNullOrEmpty(item.Embedded.Image.Uri))
            {
                writer.WriteLine("        <image extension=\"{0}\" size=\"{1}\" width=\"{2}\" height=\"{3}\" uri=\"{4}\"></image>", item.Embedded.Image.Extension, item.Embedded.Image.Size, item.Embedded.Image.Width, item.Embedded.Image.Height, System.Web.HttpUtility.HtmlEncode(item.Embedded.Image.Uri));
            }
            else
                writer.WriteLine("    <image></image>");

            writer.WriteLine("    <fields>");
            foreach (var fieldValue in item.Embedded.Fields.FieldItems)
            {
                foreach (var localizedValue in fieldValue.LocalizedValues)
                {
                    string valueToSet = "";
                    if(!string.IsNullOrEmpty(localizedValue.Value))
                    {
                        valueToSet = HttpUtility.HtmlEncode(localizedValue.Value);
                    }
                    else if(localizedValue.Values != null && localizedValue.Values.Count > 0)
                    {
                        //for classification lists, replace IDs from list with namepaths
                        if(fieldValue.DataType.Equals("ClassificationList", StringComparison.InvariantCultureIgnoreCase))
                        {
                            valueToSet = HttpUtility.HtmlEncode(string.Join(";", GetClassifications(localizedValue.Values)));
                        }
                        else if(fieldValue.DataType.Equals("optionlist", StringComparison.InvariantCultureIgnoreCase))
                        {
                            valueToSet = HttpUtility.HtmlEncode(string.Join(";", GetOptionNames(localizedValue.Values, fieldValue.FieldName)));
                        }
                        else
                        {
                            valueToSet = HttpUtility.HtmlEncode(string.Join(";", localizedValue.Values));
                        }
                        
                    }
                    if (!string.IsNullOrEmpty(valueToSet))
                    {
                        writer.WriteLine("     <field name=\"{0}\" dataType=\"{1}\">", fieldValue.FieldName, fieldValue.DataType);
                        writer.WriteLine("         <value language=\"{0}\">{1}</value>",
                            GetLanguageName(localizedValue.Language),
                            valueToSet);
                        writer.WriteLine("     </field>");
                    }
                }
            }
            writer.WriteLine("    </fields>");
            writer.WriteLine("  </classification>");
        }

        /// <summary>
        /// gets field definition names for export as replacement for field definition ids
        /// </summary>
        /// <returns>list of field definition names</returns>
        private List<string> GetFieldDefinitions(List<string> fieldDefIds)
        {
            if (fieldDefinitions == null)
            {
                throw new Exception("GetFieldDefinitions: Field Definitions are not cached");
            }
            List<string> fieldDefNames = new List<string>();
            foreach (var fieldDefId in fieldDefIds)
            {
                if (!string.IsNullOrEmpty(fieldDefId))
                {
                    if (fieldDefinitions.Any(x => x.Id.Equals(fieldDefId)))
                    {
                        fieldDefNames.Add(fieldDefinitions.Where(x => x.Id.Equals(fieldDefId)).FirstOrDefault().Name);
                    }
                }
            }
            return fieldDefNames;
        }

        /// <summary>
        /// gets field definition ids for export as replacement for field definition names
        /// </summary>
        /// <returns>list of field definition ids</returns>
        private List<string> GetFieldDefinitionIds(List<string> fieldDefNames)
        {
            if (fieldDefinitions == null)
            {
                throw new Exception("GetFieldDefinitionIds: Field Definitions are not cached");
            }
            List<string> fieldDefIds = new List<string>();
            foreach (var fieldDefName in fieldDefNames)
            {
                if (!string.IsNullOrEmpty(fieldDefName))
                {
                    if (fieldDefinitions.Any(x => x.Name.Equals(fieldDefName)))
                    {
                        fieldDefIds.Add(fieldDefinitions.Where(x => x.Name.Equals(fieldDefName)).FirstOrDefault().Id);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("GetFieldDefinitionIds: WARNING - couldn't find field definition ID at destination environment for field definition name: {0}", fieldDefName));
                    }
                }
            }
            return fieldDefIds;
        }

        /// <summary>
        /// gets watermark names for export as replacement for watermark ids
        /// </summary>
        /// <returns>list of watermark names</returns>
        private List<string> GetWatermarkNames(List<string> watermarkIds)
        {
            if (watermarks == null)
            {
                throw new Exception("GetWatermarkNames: Watermarks are not cached");
            }
            List<string> watermarkNames = new List<string>();
            if (watermarkIds == null) return watermarkNames;
            foreach (var watermarkId in watermarkIds)
            {
                if (!string.IsNullOrEmpty(watermarkId))
                {
                    if (watermarks.Any(x => x.Id.Equals(watermarkId)))
                    {
                        watermarkNames.Add(watermarks.Where(x => x.Id.Equals(watermarkId)).FirstOrDefault().Name);
                    }
                }
            }
            return watermarkNames;
        }


        /// <summary>
        /// gets watermark ids for import as replacement for watermark names
        /// </summary>
        /// <returns>list of watermark ids</returns>
        private List<string> GetWatermarkIds(List<string> watermarkNames)
        {
            if (watermarks == null)
            {
                throw new Exception("GetWatermarkIds: Watermarks are not cached");
            }
            List<string> watermarkIds = new List<string>();
            if (watermarkNames == null) return watermarkIds;
            foreach (var name in watermarkNames)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (watermarks.Any(x => x.Name.Equals(name)))
                    {
                        watermarkIds.Add(watermarks.Where(x => x.Name.Equals(name)).FirstOrDefault().Id);
                    }
                }
            }
            return watermarkIds;
        }

        /// <summary>
        /// gets language name for export to replace language ID
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        private string GetLanguageName(string languageId)
        {
            if (languages == null)
            {
                throw new Exception("GetLanguageName: Languages are not cached");
            }
            if (!string.IsNullOrEmpty(languageId))
            {
                if (languages.Any(x => x.Id.Equals(languageId)))
                {
                    return languages.Where(x => x.Id.Equals(languageId)).FirstOrDefault().Name;
                }                
            }
            return "";
        }

        /// <summary>
        /// gets language id for export to replace language name
        /// </summary>
        /// <param name="languageName"></param>
        /// <returns></returns>
        private string GetLanguageId(string languageName)
        {
            if (languages == null)
            {
                throw new Exception("GetLanguageId: Languages are not cached");
            }
            if (!string.IsNullOrEmpty(languageName))
            {
                if (languages.Any(x => x.Name.Equals(languageName)))
                {
                    return languages.Where(x => x.Name.Equals(languageName)).FirstOrDefault().Id;
                }
                else
                {
                    logger.LogInfo(string.Format("GetLanguageId: WARNING - language id not found for {0} in destination environment", languageName));
                }
            }
            return "";
        }


        #endregion

        #region Rules

        /// <summary>
        /// Reads the xml document and creates a list of classifications.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        internal List<RuleImportDTO> GetRules(XDocument document)
        {
            var rules = from r in document.Descendants("rule")
                        select new RuleImportDTO
                        {
                            Name = Attributes.GetHtmlDecodedStringValue(r.Attribute("Name")),
                            Action = Attributes.GetStringValue(r.Attribute("Action")),
                            Target = Elements.GetHtmlDecodedStringValue(r.Element("target")),
                            Enabled = Elements.ConvertStringToBoolean(r.Element("enabled")),
                            //Expression = Elements.GetHtmlDecodedStringValue(r.Element("expression")),
                            Trigger = Elements.GetHtmlDecodedStringValue(r.Element("trigger")),
                            IncludeDraftRecords = Elements.ConvertStringToBoolean(r.Element("includeDraftRecords")),
                            Version = Elements.ConvertStringToInt(r.Element("version")),
                            Conditions = GetRuleConditions(r.Element("ruleConditions")),
                            Actions = GetRuleActions(r.Element("ruleActions")),
                            Tag = Elements.GetHtmlDecodedStringValue(r.Element("tag"))
                        };

            if (rules.Any(r => String.IsNullOrEmpty(r.Name)))
            {
                throw new ApplicationException("A rule Name attribute contains an empty value");
            }
            if (rules.Any(r => String.IsNullOrEmpty(r.Target)))
            {
                throw new ApplicationException("A target element contains an empty value");
            }

            return rules.ToList();
        }

        private RuleImportDTO.ListConditionsToAddRemove GetRuleConditions(XElement parentElement)
        {
            RuleImportDTO.ListConditionsToAddRemove conditions = new RuleImportDTO.ListConditionsToAddRemove() { AddOrUpdate = new List<RuleDTO.RuleCondition>() };
            foreach (XElement item in parentElement.Descendants("ruleCondition"))
            {
                RuleDTO.RuleCondition newCondition = new RuleDTO.RuleCondition()
                {
                    ConditionType = Elements.GetStringValue(item.Element("conditionType")),
                    Index = Elements.ConvertStringToInt(item.Element("index")),
                    FieldDefinitionId = GetFieldDefinitionIds(new List<string>() { Elements.GetHtmlDecodedStringValue(item.Element("fieldDefinitionId")) }).FirstOrDefault(),
                    ClassificationId = GetClassificationIds(new List<string> { Elements.GetHtmlDecodedStringValue(item.Element("classificationId")) }).FirstOrDefault(),
                    DirectLinkOnly = Elements.ConvertStringToBoolean(item.Element("directLinkOnly")),
                    //todo: this user id needs to be addressed - convert name to id on destination
                    UserId = Elements.GetHtmlDecodedStringValue(item.Element("userId")),
                    IsUser = Elements.ConvertStringToBoolean(item.Element("isUser")),
                    Expression = Elements.GetHtmlDecodedStringValue(item.Element("expression")),
                    MoviePreviewExtension = Elements.GetStringValue(item.Element("moviePreviewExtension")),
                    Reference = Elements.GetHtmlDecodedStringValue(item.Element("reference")),
                    Status = Elements.GetStringValue(item.Element("status")),
                    ContentType = Elements.GetStringValue(item.Element("contentType"))
                };

                conditions.AddOrUpdate.Add(newCondition);
            }

            return conditions;
        }

        private RuleImportDTO.ListActionsToAddRemove GetRuleActions(XElement parentElement)
        {
            RuleImportDTO.ListActionsToAddRemove actions = new RuleImportDTO.ListActionsToAddRemove() { AddOrUpdate = new List<RuleDTO.RuleAction>() };
            foreach (XElement item in parentElement.Descendants("ruleAction"))
            {
                RuleDTO.RuleAction newAction = new RuleDTO.RuleAction()
                {
                    ActionType = Elements.GetStringValue(item.Element("actionType")),
                    Index = Elements.ConvertStringToInt(item.Element("index")),
                    FieldDefinitionId = GetFieldDefinitionIds(new List<string>() { Elements.GetHtmlDecodedStringValue(item.Element("fieldDefinitionId")) }).FirstOrDefault(),
                    ClassificationId = GetClassificationIds(new List<string> { Elements.GetHtmlDecodedStringValue(item.Element("classificationId")) }).FirstOrDefault(),
                    GettingType = Elements.GetStringValue(item.Element("gettingType")),
                    IdentifierType = Elements.GetStringValue(item.Element("identifierType")),
                    ExecutionTime = Elements.GetStringValue(item.Element("executionTime")),
                    Options = Elements.GetStringValue(item.Element("options")),
                    WatermarkId = GetWatermarkIds(new List<string>() { Elements.GetHtmlDecodedStringValue(item.Element("watermarkId")) }).FirstOrDefault(),
                    Reference = Elements.GetHtmlDecodedStringValue(item.Element("reference")),
                    ClassificationIds = GetClassificationIds(Elements.GetStringListValue(item.Element("classificationIds"))),
                    UnlinkTarget = Elements.GetStringValue(item.Element("unlinkTarget")),
                    WatermarkType = Elements.GetStringValue(item.Element("watermarkType")),
                    RenditionPresets = Elements.GetStringListValue(item.Element("renditionPresets")),
                    Status = Elements.GetStringValue(item.Element("status")),
                    ContentType = Elements.GetStringValue(item.Element("contentType"))
                };

                actions.AddOrUpdate.Add(newAction);
            }
            return actions;
        }

        // <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="fileName"></param>
        internal void ExportRulesToFile(List<RuleDTO> rules, string fileName)
        {
            Console.WriteLine("Writing to file...");
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<rules>");

                foreach (RuleDTO rule in rules.OrderBy(r => r.Name))
                {
                    WriteRule(rule, writer);
                }

                writer.WriteLine("</rules>");
                writer.Flush();
            }
        }

        /// <summary>
        /// Exports the rules to the file.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="writer"></param>
        private void WriteRule(RuleDTO item, TextWriter writer)
        {
            Console.WriteLine("Processing rule {0}", item.Name);

            writer.WriteLine("  <rule Name=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(item.Name), item.Action);
            writer.WriteLine("    <target>{0}</target>", HttpUtility.HtmlEncode(item.Target));
            writer.WriteLine("    <enabled>{0}</enabled>", item.Enabled ? "true" : "false");
            //we shouldn't need to export expression, it's based on conditions and will be genereted on the other end
           // writer.WriteLine("    <expression>{0}</expression>", HttpUtility.HtmlEncode(item.Expression));
            writer.WriteLine("    <includeDraftRecords>{0}</includeDraftRecords>", item.IncludeDraftRecords ? "true" : "false");
            writer.WriteLine("    <trigger>{0}</trigger>", HttpUtility.HtmlEncode(item.Trigger));
            writer.WriteLine("    <version>{0}</version>", item.Version);

            writer.WriteLine("    <ruleConditions>");
            foreach (RuleDTO.RuleCondition condition in item.Conditions.OrderBy(m => m.Index))
            {
                writer.WriteLine("      <ruleCondition>");
                writer.WriteLine("          <conditionType>{0}</conditionType>", condition.ConditionType);
                writer.WriteLine("          <index>{0}</index>", condition.Index);
                writer.WriteLine("          <fieldDefinitionId>{0}</fieldDefinitionId>", GetFieldDefinitions(new List<string>() { condition.FieldDefinitionId }).FirstOrDefault() );
                writer.WriteLine("          <classificationId>{0}</classificationId>", GetClassifications(new List<string> { condition.ClassificationId }).FirstOrDefault());
                writer.WriteLine("          <directLinkOnly>{0}</directLinkOnly>", condition.DirectLinkOnly ? "true" : "false");
                writer.WriteLine("          <userId>{0}</userId>", condition.UserId);
                writer.WriteLine("          <isUser>{0}</isUser>", condition.IsUser ? "true" : "false");
                writer.WriteLine("          <moviePreviewExtension>{0}</moviePreviewExtension>", condition.MoviePreviewExtension);
                writer.WriteLine("          <reference>{0}</reference>", HttpUtility.HtmlEncode(condition.Reference));
                writer.WriteLine("          <expression>{0}</expression>", HttpUtility.HtmlEncode(condition.Expression));
                writer.WriteLine("          <status>{0}</status>", HttpUtility.HtmlEncode(condition.Status));
                writer.WriteLine("          <contentType>{0}</contentType>", HttpUtility.HtmlEncode(condition.ContentType));
                writer.WriteLine("      </ruleCondition>");
            }
            writer.WriteLine("    </ruleConditions>");

            writer.WriteLine("    <ruleActions>");
            foreach (RuleDTO.RuleAction action in item.Actions.OrderBy(m => m.Index))
            {
                writer.WriteLine("      <ruleAction>");
                writer.WriteLine("          <actionType>{0}</actionType>", action.ActionType);
                writer.WriteLine("          <index>{0}</index>", action.Index);
                writer.WriteLine("          <executionTime>{0}</executionTime>", action.ExecutionTime);
                writer.WriteLine("          <options>{0}</options>", action.Options);
                writer.WriteLine("          <renditionPresets>");
                if (action.RenditionPresets != null)
                {
                    foreach (var preset in action.RenditionPresets)
                    {
                        writer.WriteLine("              <preset>{0}</preset>", preset);
                    }                    
                }
                writer.WriteLine("          </renditionPresets>");
                writer.WriteLine("          <classificationId>{0}</classificationId>", GetClassifications(new List<string> { action.ClassificationId }).FirstOrDefault());

                writer.WriteLine("          <classificationIds>");
                if (action.ClassificationIds != null)
                {                    
                    foreach (var id in GetClassifications(action.ClassificationIds))
                    {
                        writer.WriteLine("              <id>{0}</id>", id);
                    }                    
                }
                writer.WriteLine("          </classificationIds>");
                writer.WriteLine("          <unlinkTarget>{0}</unlinkTarget>", action.UnlinkTarget);
                writer.WriteLine("          <gettingType>{0}</gettingType>", action.GettingType);
                writer.WriteLine("          <identifierType>{0}</identifierType>", action.IdentifierType);
                writer.WriteLine("          <reference>{0}</reference>", HttpUtility.HtmlEncode(action.Reference));
                writer.WriteLine("          <fieldDefinitionId>{0}</fieldDefinitionId>", GetFieldDefinitions(new List<string>() { action.FieldDefinitionId }).FirstOrDefault());
                writer.WriteLine("          <watermarkId>{0}</watermarkId>", GetWatermarkNames(new List<string> { action.WatermarkId }).FirstOrDefault());
                writer.WriteLine("          <watermarkType>{0}</watermarkType>", action.WatermarkType);
                writer.WriteLine("          <status>{0}</status>", action.Status);
                writer.WriteLine("          <contentType>{0}</contentType>", action.ContentType);
                writer.WriteLine("      </ruleAction>");
            }
            writer.WriteLine("    </ruleActions>");

            if (!string.IsNullOrEmpty(item.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(item.Tag));
            else
                writer.WriteLine("    <tag></tag>");

            writer.WriteLine("  </rule>");
        }
        

        #endregion

        #region File Types

        /// <summary>
        /// Reads the xml document and converts it into a list of setting definitions.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        internal List<FileTypeImportDTO> GetFileTypes(XDocument document)
        {
            var fileTypes = new List<FileTypeImportDTO>();
            foreach (var ft in document.Descendants("fileType"))
            {
                var fileTypeToImport = new FileTypeImportDTO()
                {
                    Name = Attributes.GetHtmlDecodedStringValue(ft.Attribute("Name")),
                    Action = Attributes.GetStringValue(ft.Attribute("Action")),
                    Kind = Elements.GetStringValue(ft.Element("kind")),
                    Extension = Elements.GetStringValue(ft.Element("extension")),
                    MimeType = Elements.GetStringValue(ft.Element("mimeType")),
                    Labels = GetLabels(ft.Element("labels")),
                    EngineFormat = Elements.GetStringValue(ft.Element("engineFormat")),
                    PreviewFormat = Elements.GetStringValue(ft.Element("previewFormat")),
                    IsCatalogable = Elements.ConvertStringToBoolean(ft.Element("isCatalogable")),
                    PreviewRequired = Elements.ConvertStringToBoolean(ft.Element("previewRequired")),
                    PreviewPlayers = GetListStringItemsToAddRemove(ft.Element("previewPlayers")),
                    PreviewKeepDimensions = Elements.ConvertStringToBoolean(ft.Element("previewKeepDimensions")),
                    SupportAssetResize = Elements.ConvertStringToBoolean(ft.Element("supportAssetResize")),
                    SupportAssetWatermark = Elements.ConvertStringToBoolean(ft.Element("supportAssetWatermark")),
                    PreferredExtension = Elements.ConvertStringToBoolean(ft.Element("preferredExtension")),
                    CatalogActions = GetFileTypeActionCollection(ft.Element("catalogActions")),
                    MediaEngines = GetListStringItemsToAddRemove(ft.Element("mediaEngines")),
                    RegisteredFields = GetFieldsToRegister(ft.Element("registeredFields")),
                    RegisteredFieldGroups = GetFieldGroupsToRegister(ft.Element("registeredFieldGroups")),
                    Tag = Elements.GetHtmlDecodedStringValue(ft.Element("tag"))
                };
                fileTypes.Add(fileTypeToImport);
            }

            if (fileTypes.Any(ft => String.IsNullOrEmpty(ft.Name)))
            {
                throw new ApplicationException("A file type Name element contains an empty value");
            }

            return fileTypes;
        }

        /// <summary>
        /// Returns FileTypeActionCollection collection created from xml content
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private static ListCatalogActionsToAddRemove GetFileTypeActionCollection(XElement element)
        {
            var catalogActions = new ListCatalogActionsToAddRemove();
            if (element == null) return catalogActions;
            catalogActions.AddOrUpdate = new List<FileTypeDTO.FileTypeAction>();
            catalogActions.Remove = new List<FileTypeDTO.FileTypeAction>();
            foreach (XElement actionElem in element.Descendants("catalogAction"))
            {
                catalogActions.AddOrUpdate.Add(new FileTypeDTO.FileTypeAction() { IsCritical = Attributes.ConvertStringToBoolean(actionElem.Attribute("IsCritical")), Name = Elements.GetStringValue(actionElem) });               
            }            
            return catalogActions;
        }

        // <summary>
        /// Writes the entries to the file
        /// </summary>
        /// <param name="fileTypes"></param>
        /// <param name="fileName"></param>
        public void ExportFileTypesToFile(List<FileTypeDTO> fileTypes, string fileName, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fileTypes.Count;
            progressBar.Step = 1;
            using (TextWriter writer = File.CreateText(fileName))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<fileTypes>");

                foreach (FileTypeDTO fileType in fileTypes)
                {
                    logger.LogInfo(string.Format("Processing file type {0}", fileType.Name));
                    WriteFileType(fileType, writer);
                    progressBar.PerformStep();
                }

                writer.WriteLine("</fileTypes>");
                writer.Flush();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Writes the file types definition to the export file.
        /// </summary>
        /// <param name="currentFileType">The current file type.</param>
        /// <param name="writer">The writer.</param>
        private void WriteFileType(FileTypeDTO currentFileType, TextWriter writer)
        {
            writer.WriteLine("  <fileType Name=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(currentFileType.Name), currentFileType.Action);            
            writer.WriteLine("    <kind>{0}</kind>", HttpUtility.HtmlEncode(currentFileType.Kind));
            writer.WriteLine("    <extension>{0}</extension>", HttpUtility.HtmlEncode(currentFileType.Extension));
            writer.WriteLine("    <mimeType>{0}</mimeType>", HttpUtility.HtmlEncode(currentFileType.MimeType));
            writer.WriteLine("    <labels>");
            foreach (LabelDTO label in currentFileType.Labels)
            {
                writer.WriteLine("      <label language=\"{0}\">{1}</label>", GetLanguageName(label.Language), HttpUtility.HtmlEncode(label.Text));
            }

            writer.WriteLine("    </labels>");
            writer.WriteLine("    <engineFormat>{0}</engineFormat>", HttpUtility.HtmlEncode(currentFileType.EngineFormat));
            writer.WriteLine("    <previewFormat>{0}</previewFormat>", HttpUtility.HtmlEncode(currentFileType.PreviewFormat.ToString()));
            writer.WriteLine("    <isCatalogable>{0}</isCatalogable>", currentFileType.IsCatalogable.ToString());
            writer.WriteLine("    <previewRequired>{0}</previewRequired>", HttpUtility.HtmlEncode(currentFileType.PreviewRequired.ToString()));
            writer.WriteLine("    <previewKeepDimensions>{0}</previewKeepDimensions>", currentFileType.PreviewKeepDimensions.ToString());
            writer.WriteLine("    <supportAssetResize>{0}</supportAssetResize>", currentFileType.SupportAssetResize.ToString());
            writer.WriteLine("    <supportAssetWatermark>{0}</supportAssetWatermark>", currentFileType.SupportAssetWatermark.ToString());
            writer.WriteLine("    <preferredExtension>{0}</preferredExtension>", HttpUtility.HtmlEncode(currentFileType.PreferredExtension.ToString()));
            writer.WriteLine("    <catalogActions>");
            foreach (var catalogAction in currentFileType.CatalogActions)
            {
                writer.WriteLine("            <catalogAction IsCritical=\"{0}\">{1}</catalogAction>", catalogAction.IsCritical.ToString(), HttpUtility.HtmlEncode(catalogAction.Name));
            }
            writer.WriteLine("    </catalogActions>");
            writer.WriteLine("    <mediaEngines>");
            foreach (var item in currentFileType.MediaEngines)
            {
                writer.WriteLine("        <mediaEngine>{0}</mediaEngine>", HttpUtility.HtmlEncode(item));
            }
            writer.WriteLine("    </mediaEngines>");

            writer.WriteLine("    <previewPlayers>");
            foreach (var item in currentFileType.PreviewPlayers)
            {
                writer.WriteLine("        <previewPlayer>{0}</previewPlayer>", HttpUtility.HtmlEncode(item));
            }
            writer.WriteLine("    </previewPlayers>");

            writer.WriteLine("    <registeredFields>");
            foreach (string field in GetFieldDefinitions(currentFileType.RegisteredFields.Select(x => x.FieldId).ToList<string>()))
            {
                writer.WriteLine("      <registeredField>{0}</registeredField>", HttpUtility.HtmlEncode(field));
            }
            writer.WriteLine("    </registeredFields>");


            writer.WriteLine("    <registeredFieldGroups>");
            foreach (string fieldGroup in GetFieldGroupNames(currentFileType.RegisteredFieldGroups.Select(x => x.FieldGroupId).ToList<string>()))
            {
                writer.WriteLine("      <registeredFieldGroup>{0}</registeredFieldGroup>", HttpUtility.HtmlEncode(fieldGroup));
            }
            writer.WriteLine("    </registeredFieldGroups>");

            if (!string.IsNullOrEmpty(currentFileType.Tag))
                writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(currentFileType.Tag));
            else
                writer.WriteLine("    <tag></tag>");

            writer.WriteLine("  </fileType>");
        }

        #endregion

        //#region Translations

        ///// <summary>
        ///// Reads the xml document and converts it into a list of setting definitions.
        ///// </summary>
        ///// <param name="document"></param>
        ///// <returns></returns>
        //internal static List<TranslationDTO> GetTranslations(XDocument document)
        //{
        //    var translation = from t in document.Descendants("translation")
        //                    select new TranslationDTO
        //                    {
        //                        Name = Attributes.GetHtmlEncodedStringValue(t.Attribute("Name")),
        //                        Action = Attributes.GetHtmlEncodedStringValue(t.Attribute("Action")),
        //                        Studio = Elements.GetStringValue(t.Element("studio")),
        //                        Module = Elements.GetStringValue(t.Element("module")),
        //                        Tag = Elements.GetStringValue(t.Element("tag")),
        //                        Translations = Elements.GetLabels(t.Element("translations"))
        //                    };

        //    if (translation.Any(ft => String.IsNullOrEmpty(ft.Name)))
        //    {
        //        throw new ApplicationException("A translation Name element contains an empty value");
        //    }
        //    if (translation.Any(ft => String.IsNullOrEmpty(ft.Studio)))
        //    {
        //        throw new ApplicationException("A translation studio element contains an empty value");
        //    }
        //    if (translation.Any(ft => String.IsNullOrEmpty(ft.Module)))
        //    {
        //        throw new ApplicationException("A translation module element contains an empty value");
        //    }

        //    return translation.ToList();
        //}

        //// <summary>
        ///// Writes the entries to the file
        ///// </summary>
        ///// <param name="fileTypes"></param>
        ///// <param name="fileName"></param>
        //internal static void ExportTranslationsToFile(List<TranslationDTO> translations, string fileName)
        //{
        //    Console.WriteLine("Writing to file...");
        //    using (TextWriter writer = File.CreateText(fileName))
        //    {
        //        writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        //        writer.WriteLine("<translations>");

        //        foreach (TranslationDTO translation in translations)
        //        {
        //            WriteTranslation(translation, writer);
        //        }

        //        writer.WriteLine("</translations>");
        //        writer.Flush();
        //    }
        //}

        ///// <summary>
        ///// Writes the file types definition to the export file.
        ///// </summary>
        ///// <param name="current">The current file type.</param>
        ///// <param name="writer">The writer.</param>
        //private static void WriteTranslation(TranslationDTO current, TextWriter writer)
        //{
        //    writer.WriteLine("    <translation Name=\"{0}\" Action=\"{1}\">", HttpUtility.HtmlEncode(current.Name), current.Action);
        //    writer.WriteLine("    <studio>{0}</studio>", HttpUtility.HtmlEncode(current.Studio));
        //    writer.WriteLine("    <module>{0}</module>", HttpUtility.HtmlEncode(current.Module));

        //    writer.WriteLine("    <translations>");
        //    foreach (var item in current.Translations)
        //    {
        //        writer.WriteLine("      <translationItem language=\"{0}\">{1}</translationItem>", item.Language, HttpUtility.HtmlEncode(item.Text));
        //    }
        //    writer.WriteLine("    </translations>");
        //    if (!string.IsNullOrEmpty(current.Tag))
        //        writer.WriteLine("    <tag>{0}</tag>", HttpUtility.HtmlEncode(current.Tag));
        //    else
        //        writer.WriteLine("    <tag></tag>");
        //    writer.WriteLine("  </translation>");
        //}
        //#endregion

        //#region Watermarks

        ///// <summary>
        ///// Converts the xml document into a list of watermarks.
        ///// </summary>
        ///// <param name="document"></param>
        ///// <returns></returns>
        //internal static List<WatermarkDTO> GetWatermarks(XDocument document)
        //{
        //    var watermark = from c in document.Descendants("watermark")
        //               select new WatermarkDTO()
        //               {
        //                   Name = Attributes.GetHtmlEncodedStringValue(c.Attribute("Name")),
        //                   Action = Attributes.GetStringValue(c.Attribute("Action")),
        //                   CombineMethod = Elements.GetStringValue(c.Element("combineMethod")),
        //                   Position = Elements.GetStringValue(c.Element("position")),
        //                   Image = Elements.GetImage(c.Element("image")),
        //                   Tag = Elements.GetHtmlEncodedStringValue(c.Element("tag")),
        //                   MediaEngines = GetMediaEngines(c.Element("mediaEngines"))
        //               };

        //    if (watermark.Any(c => String.IsNullOrEmpty(c.Name)))
        //    {
        //        throw new ApplicationException("A watermark Name element contains an empty value");
        //    }

        //    return watermark.ToList();
        //}

        ///// <summary>
        ///// Gets the list of media engines
        ///// </summary>
        ///// <param name="xElement"></param>
        ///// <returns></returns>
        //private static List<MediaEngineDTO> GetMediaEngines(XElement xElement)
        //{
        //    var engines = new List<MediaEngineDTO>();

        //    foreach (var item in xElement.Descendants("engine"))
        //    {
        //        string val = Elements.GetHtmlEncodedStringValue(item);
        //        int index = Convert.ToInt32(Attributes.GetStringValue(item.Attribute("index")));
        //        engines.Add(new MediaEngineDTO() { Index = index, Name = val });
        //    }

        //    return engines;
        //}

        ///// <summary>
        ///// Writes the entries to the file
        ///// </summary>
        ///// <param name="watermarks"></param>
        ///// <param name="fileName"></param>
        //internal static void ExportWatermarksToFile(List<WatermarkDTO> watermarks, string fileName)
        //{
        //    Console.WriteLine("Writing to file....");

        //    using (TextWriter writer = File.CreateText(fileName))
        //    {
        //        writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        //        writer.WriteLine("<watermarks>");

        //        foreach (WatermarkDTO watermark in watermarks.OrderBy(g => g.Name))
        //        {
        //            WriteWatermark(watermark, writer);
        //        }

        //        writer.WriteLine("</watermarks>");
        //        writer.Flush();
        //    }
        //}

        ///// <summary>
        ///// Writes the watermark to the xml file
        ///// </summary>
        ///// <param name="item"></param>
        ///// <param name="writer"></param>
        //internal static void WriteWatermark(WatermarkDTO item, TextWriter writer)
        //{
        //    Console.WriteLine("Processing watermark {0}", item.Name);

        //    writer.WriteLine("  <watermark Name=\"{0}\" Action=\"{1}\" >", HttpUtility.HtmlEncode(item.Name), item.Action);

        //    writer.WriteLine("      <combineMethod>{0}</combineMethod>", item.CombineMethod);
        //    writer.WriteLine("      <position>{0}</position>", item.Position);

        //    if (item.Image != null && !string.IsNullOrEmpty(item.Image.ImageData))
        //    {
        //        writer.WriteLine("      <image extension=\"{0}\">{1}</image>", item.Image.Extension, HttpUtility.HtmlEncode(item.Image.ImageData));
        //    }
        //    else
        //        writer.WriteLine("      <image></image>");

        //    writer.WriteLine("      <mediaEngines>");
        //    foreach (var engine in item.MediaEngines)
        //    {
        //        writer.WriteLine("          <engine index=\"{0}\">{1}</engine>", engine.Index, HttpUtility.HtmlEncode(engine.Name));
        //    }
        //    writer.WriteLine("      </mediaEngines>");

        //    if (!string.IsNullOrEmpty(item.Tag))
        //        writer.WriteLine("      <tag>{0}</tag>", HttpUtility.HtmlEncode(item.Tag));
        //    else
        //        writer.WriteLine("      <tag></tag>");
        //    writer.WriteLine("  </watermark>");

        //}


        //#endregion


        //#region Other

        ///// <summary>
        ///// Reads the categoryname
        ///// </summary>
        ///// <param name="app"></param>
        ///// <param name="categoryId"></param>
        ///// <returns></returns>
        //internal static string GetCategoryName(Application app, Guid categoryId)
        //{
        //    var category = new SettingCategory(app);
        //    category.Load(categoryId);
        //    return category.Name;
        //}

        ///// <summary>
        ///// Converts a byte string with image data to an image file and returns the full path to the image.
        ///// </summary>
        ///// <param name="app"></param>
        ///// <param name="extension"></param>
        ///// <param name="imageData"></param>
        ///// <returns></returns>
        //internal static string ConvertToImageFile(Application app, string extension, string imageData)
        //{
        //    var ba = Convert.FromBase64String(imageData);
        //    var fileName = app.GetTemporaryFile(extension);

        //    using (var ms = new MemoryStream(ba))
        //    {
        //        var returnImage = Image.FromStream(ms);
        //        returnImage.Save(fileName);
        //        ms.Flush();
        //    }
        //    return fileName;
        //}
        //#endregion
    }
}
