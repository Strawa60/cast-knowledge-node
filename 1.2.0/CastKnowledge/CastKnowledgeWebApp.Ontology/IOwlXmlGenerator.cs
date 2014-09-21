using System;
using System.IO;
using System.Xml;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents an OWL Xml Generator
	/// </summary>
	public interface IOwlXmlGenerator : IOwlGenerator
	{
		/// <summary>
		/// When implemented by a class, it generates the OWL graph into an existing Xml Document
		/// </summary>
		/// <param name="graph">An object that implements the IOwlGraph interface which needs to be generated</param>
		/// <param name="doc">The XmlDocument to use as a destination document</param>
		void GenerateOwl(IOwlGraph graph, XmlDocument doc);
	}
}
