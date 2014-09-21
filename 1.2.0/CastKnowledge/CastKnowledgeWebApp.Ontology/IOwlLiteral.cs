using System;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a Literal in an OWL Graph
	/// </summary>
	public interface IOwlLiteral : IOwlNode
	{
		/// <summary>
		/// When implemented by a class, gets or sets the URI specifying the datatype of this IOwlLiteral
		/// </summary>
		string Datatype
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets the value of this literal
		/// </summary>
		string Value
		{
			get;
			set;
		}
	}
}
