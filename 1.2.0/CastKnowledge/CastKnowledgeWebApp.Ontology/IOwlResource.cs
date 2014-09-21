using System;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a OWL Node of type owl:Resource
	/// </summary>
	public interface IOwlResource : IOwlNode
	{
		/// <summary>
		/// The edge specifying the type of this collection
		/// </summary>
		IOwlEdge Type
		{
			get;
		}
	}
}
