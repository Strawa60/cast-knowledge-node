
using System;

namespace OwlDotNetApi
{
	/// <summary>
	/// Defines a generalized mechanism for processing edges in the OWL Graph
	/// </summary>
	public interface IOwlEdge
	{
		/// <summary>
		/// When implemented by a class, gets or sets the Child Node of this IOwlEdge
		/// </summary>
		IOwlNode ChildNode
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the Parent Node of this IOwlEdge
		/// </summary>
		IOwlNode ParentNode
		{
			get;
			set;
		}
		/// <summary>
		/// When implemented by a class, gets or sets the ID of this IOwlEdge
		/// </summary>
		string ID
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, gets or sets the Language ID of this IOwlEdge
		/// </summary>
		string LangID
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, attaches a Child Node to this IOwlEdge
		/// </summary>
		/// <param name="node">The IOwlNode to attach</param>
		void AttachChildNode(IOwlNode node);
		/// <summary>
		/// When implemented by a class, attaches a Parent Node to this IOwlEdge
		/// </summary>
		/// <param name="node">The IOwlNode to attach</param>
		void AttachParentNode(IOwlNode node);

		/// <summary>
		/// When implemented by a class, detachs the Child Node of this IOwlEdge
		/// </summary>
		/// <returns>The removed IOwlNode</returns>
		IOwlNode DetachChildNode();

		/// <summary>
		/// When implemented by a class, detaches the Parent Node of this IOwlEdge
		/// </summary>
		/// <returns>The removed IOwlNode</returns>
		IOwlNode DetachParentNode();

		/// <summary>
		/// When implemented by a class, it accepts a message and retransfers it back to the visitor
		/// </summary>
		/// <param name="visitor">The actual visitor in the pattern</param>
		/// <param name="parent">The parent object of the edge to be generated</param>
		void Accept(IOwlVisitor visitor, Object parent);
	}
}
