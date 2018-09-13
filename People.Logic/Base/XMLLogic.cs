using System.IO;
using System.Xml.Linq;

namespace People.Logic.Base
{
   public class XMLLogic
   {
      protected XDocument xdoc;
      protected string path;

      public XMLLogic()
      {
         this.xdoc = new XDocument();
      }

      public XMLLogic(string path)
      {
         this.path = path;
         this.xdoc = XDocument.Load(this.path);
      }

      public void Load(string path)
      {
         this.path = path;
         this.xdoc = XDocument.Load(this.path);
      }

      public void Parse(string xml)
      {
         this.xdoc = XDocument.Parse(xml);
      }

      public void Save()
      {
         this.xdoc.Save(this.path);
      }

      public void Save(string path)
      {
         this.xdoc.Save(path);
      }

      public static void CreateXMLFileIfNotExists(string path, string rootName)
      {
         XDocument xmlFile;
         if (!File.Exists(path))
         {
            xmlFile = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xmlFile.Add(new XElement(rootName));
            xmlFile.Save(path);
         }
      }
   }
}