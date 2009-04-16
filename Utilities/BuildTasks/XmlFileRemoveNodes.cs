using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Xml;

namespace ClearCanvas.Utilities.BuildTasks
{
	public class XmlFileRemoveNodes : Task
	{
		private string _xPath;
		private string _file;

		[Required]
		public string XPath
		{
			get { return _xPath; }
			set { _xPath = value; }
		}

		[Required]
		public string File
		{
			get { return _file; }
			set { _file = value; }
		}

		public override bool Execute()
		{
			if (String.IsNullOrEmpty(_file))
			{
				base.Log.LogMessage("Invalid input File.");
				return false;
			}

			if (!System.IO.File.Exists(_file))
			{
				base.Log.LogMessage("File does not exist: {0}", _file);
				return false;
			}

			XmlDocument doc = new XmlDocument();
			doc.Load(File);

			XmlNodeList nodes = doc.SelectNodes(XPath);
			if (nodes != null && nodes.Count > 0)
			{
				foreach (XmlNode node in nodes)
					node.ParentNode.RemoveChild(node);

				base.Log.LogMessage("Replaced {0} nodes in file: {1}", nodes.Count, File);
				doc.Save(File);
			}

			return true;
		}
	}
}
