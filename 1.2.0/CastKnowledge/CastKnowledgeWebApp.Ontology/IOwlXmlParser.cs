using System;
using System.IO;
using System.Xml;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents an OWL Xml Parser
	/// </summary>
	public interface IOwlXmlParser : IOwlParser
	{
		/// <summary>
		/// When implemented by a class, parses the OWL from the given XmlDocument, into an existing graph using the given xml:base uri
		/// </summary>
		/// <param name="doc">The XmlDocument to use as the source of the XML data</param>
		/// <param name="graph">An object that implements the IOwlGraph interface</param>
		/// <param name="xmlbaseUri">The xml:base Uri to use incase one is not found in the XML data or the graph</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(XmlDocument doc, IOwlGraph graph, string xmlbaseUri);

		/// <summary>
		/// When implemented by a class, parses the OWL from the given XmlDocument, using the given xml:base uri
		/// </summary>
		/// <param name="doc">The XmlDocument to use as the source of the XML data</param>
		/// <param name="xmlbaseUri">The xml:base Uri to use incase one is not found in the XML data</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(XmlDocument doc, string xmlbaseUri);

		/// <summary>
		/// When implemented by a class, parses the OWL from the given XmlDocument, into an existing graph
		/// </summary>
		/// <param name="doc">The XmlDocument to use as the source of the XML data</param>
		/// <param name="graph">An object that implements the IOwlGraph interface</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(XmlDocument doc, IOwlGraph graph);

		/// <summary>
		/// When implemented by a class, parses the OWL from the given XmlDocument
		/// </summary>
		/// <param name="doc">The XmlDocument to use as the source of the XML data</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(XmlDocument doc);
		
		/// <summary>
		/// When implemented by a class, parses the OWL from the given stream, into an existing graph using the given xml:base uri
		/// </summary>
		/// <param name="inStream">The Stream to use as the source of the XML data</param>
		/// <param name="graph">An object that implements the IOwlGraph interface</param>
		/// <param name="xmlbaseUri">The xml:base Uri to use incase one is not found in the XML data or the graph</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Stream inStream, IOwlGraph graph, string xmlbaseUri);

		/// <summary>
		/// When implemented by a class, parses the OWL from the given stream, using the given xml:base uri
		/// </summary>
		/// <param name="inStream">The Stream to use as the source of the XML data</param>
		/// <param name="xmlbaseUri">The xml:base Uri to use incase one is not found in the XML data</param>
		/// <returns>An object that implements the IOwlGraph interface</returns>
		IOwlGraph ParseOwl(Stream inStream, string xmlbaseUri);
	}
}
