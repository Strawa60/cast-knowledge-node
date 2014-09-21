using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a resource in the OWL Graph
	/// </summary>
	public abstract class OwlResource : OwlNode, IOwlResource
	{
		#region Variables
		/// <summary>
		/// The child edge that connects to a node specifying the type of the resource
		/// </summary>
		protected OwlEdge _typeEdge;

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the node that specifies the type of this resource
		/// </summary>
		/// <exception cref="ArgumentNullException">The specified value id null.</exception>
		public IOwlEdge Type
		{
			get
			{
				return _typeEdge;
			}
		}

		#endregion

		#region Manipulators
		/// <summary>
		/// This is the accept method in the visitor pattern used for performing an action on the node.
		/// </summary>
		/// <param name="visitor">The visitor object itself</param>
		/// <param name="parent">The parent object of the node</param>
		public override void Accept(IOwlVisitor visitor, Object parent) 
		{	
			visitor.Visit(this, parent);
		}

		#endregion
	}
}
