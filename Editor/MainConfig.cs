/// 
/// 
/// EpubEditor
/// Free and open-source EPUB editor
/// www.epubeditor.com
/// instagram: @_gabe.el
/// email: epubeditor@gmail.com
/// Gabriel Daniel
/// 2025-04-06
/// v1.0
/// 
/// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace EpubEditor.Editor
{

    /// <summary>
    /// Class representing the main configuration of the EpubEditor application.
    /// </summary>
    public class MainConfig
    {

        private List<RecentEpubFile> recentFiles;
        private List<ExternEditor> externEditors;

        public MainConfig() {

            RecentFiles = new List<RecentEpubFile>(); 
            ExternEditors = new List<ExternEditor>();

        }

        public List<RecentEpubFile> RecentFiles { get => recentFiles; set => recentFiles = value; }
        public List<ExternEditor> ExternEditors { get => externEditors; set => externEditors = value; }

        public int ReadEpubEditorConfigFile(string filePath)
        {

            if (File.Exists(filePath))
            {

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);

                //ler os epubs recentes
                XmlNodeList recentFiles = xmlDocument.SelectNodes("/main_config/recent_files/item");

                foreach (XmlNode recentFile in recentFiles)
                {

                    string dateString = recentFile.Attributes["oppened"]?.Value.Trim();
                    DateTime parsedDate;

                    if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate)) { }
                    else if (DateTime.TryParseExact(dateString, "yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)) { }
                    else
                        parsedDate = new DateTime(2000, 1, 1);

                    bool isFound = false;
                    if (File.Exists(recentFile.Attributes["directory"]?.Value)) 
                        isFound = true;

                    RecentFiles.Add(new RecentEpubFile
                    {
                        Name = recentFile.Attributes["name"]?.Value ?? "",
                        Directory = recentFile.Attributes["directory"]?.Value ?? "",
                        Openned = parsedDate,
                        IsFound = isFound
                    });

                }

                //ler os programas (editores externos)
                XmlNodeList editors = xmlDocument.SelectNodes("/main_config/editors/item");

                foreach (XmlNode editor in editors)
                {

                    if (File.Exists(editor.Attributes["directory"]?.Value))
                    {
                        ExternEditors.Add(new ExternEditor
                        {
                            Name = editor.Attributes["name"]?.Value,
                            Directory = editor.Attributes["directory"]?.Value,
                            Exec_attributes = editor.Attributes["attributes"]?.Value,
                            Icon_path = editor.Attributes["icon"]?.Value,
                            Version = editor.Attributes["version"]?.Value
                        });
                    }

                }

                return 1;

            }
            
            return 0;
        }

        public int WriteEpubRecentOpennedFileOnConfig(string configXmlFilePath, RecentEpubFile data)
        {

            if (File.Exists(configXmlFilePath))
            {

                if (data != null)
                {

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(configXmlFilePath);

                    XmlNode recentFileNode = xmlDocument.SelectSingleNode("//main_config/recent_files");
                    if (recentFileNode == null)
                    {

                        XmlNode mainConfigNode = xmlDocument.SelectSingleNode("//main_config");
                        if (mainConfigNode != null)
                        {
                            recentFileNode = xmlDocument.CreateElement("recent_files");
                            mainConfigNode.AppendChild(recentFileNode);
                        } else
                        {
                            return -2; //Tag <main_config> não encontrada, arquivo .config corrompido?
                        }

                    }

                    XmlNode existingItem = recentFileNode.SelectSingleNode($"item[@directory='{data.Directory}']");
                    if (existingItem != null)
                    {

                        existingItem.Attributes["name"].Value = data.Name;
                        existingItem.Attributes["openned"].Value = data.Openned.ToString();

                    } else
                    {

                        XmlElement newitem = xmlDocument.CreateElement("item");
                        newitem.SetAttribute("name", data.Name);
                        newitem.SetAttribute("directory", data.Directory);
                        newitem.SetAttribute("openned", data.Openned.ToString());

                        recentFileNode.PrependChild(newitem);

                    }

                    xmlDocument.Save(configXmlFilePath);

                    return 0;

                }

            }

            return 0;

        }


    }
}
