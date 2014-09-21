using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a node in the OWL Graph
	/// </summary>
	public class OwlNode : IOwlNode
	{
		#region Variables
		/// <summary>
		/// The URI of the node.
		/// </summary>
		private string _nodeID;

		/// <summary>
		/// Flag to detect whether a node has been visited or not.
		/// </summary>
		private bool _visited;

		/// <summary>
		/// The collection of parent edges associated with this node
		/// </summary>
		private OwlEdgeCollection _parentEdges;

		/// <summary>
		/// The collection of child edges associated with this node
		/// </summary>
		private OwlEdgeCollection _childEdges;

		/// <summary>
		/// The language identifier for this node.
		/// </summary>
		private string _langID;
		
		#endregion

		#region Creators
		/// <summary>
		/// Initializes a new instance of the OwlNode class.
		/// </summary>
		public OwlNode()
		{            
			_parentEdges = new OwlEdgeCollection();
			_childEdges = new OwlEdgeCollection();
			_nodeID = null;
			_visited = false;
			LangID = "";
		}

		/// <summary>
		/// Initializes a new instance of the OwlNode class with the specified URI.
		/// </summary>
		/// <param name="nodeUri">A string representing the URI of this node.</param>
		/// <exception cref="UriFormatException">The specified URI is a not a well formed URI.</exception>
		public OwlNode(string nodeUri)
		{            
			_parentEdges = new OwlEdgeCollection();
			_childEdges = new OwlEdgeCollection();
			//if the nodeUri is not a well formed Uri then throw a UriFormatException
			Uri u = new Uri(nodeUri);
			_nodeID = nodeUri;
			_visited = false;
			LangID = "";
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ID of this node
		/// </summary>
		/// <exception cref="UriFormatException">Attempt to set the ID to a value that is not a well formed URI.</exception>
		public virtual string ID
		{
			get
			{
				return _nodeID;
			}
			set
			{
				 Uri u = new Uri(value);
				_nodeID = value;
			}
		}

		/// <summary>
		/// Gets or sets the visited flag.
		/// </summary>
		public virtual bool Visited
		{
			get
			{
				return _visited;
			}
			set
			{
				_visited = value;
			}
		}

		/// <summary>
		/// Gets the parent edges of this Node.
		/// </summary>
		public IOwlEdgeCollection ParentEdges
		{
			get
			{
				return _parentEdges;
			}
		}

		/// <summary>
		/// Gets the Child Edges of this node.
		/// </summary>
		public IOwlEdgeCollection ChildEdges
		{
			get
			{
				return _childEdges;
			}
		}

		/// <summary>
		/// Gets or stes the language identifier for this node.
		/// </summary>
		public string LangID
		{
			get
			{
				return _langID;
			}
			set
			{
				_langID = value;
			}
		}

		#endregion

		#region Manipulators
		/// <summary>
		/// Attaches a child edge to this node.
		/// </summary>
		/// <param name="edge">An object that implements the IOwlEdge interface. This is the new edge to attach.</param>
		/// <exception cref="ArgumentNullException">The specified edge is a null reference.</exception>
		public void AttachChildEdge(IOwlEdge edge)
		{
			if(edge == null)
				throw (new ArgumentNullException());
			ChildEdges.Add(edge);
			edge.ParentNode = this;
		}

		/// <summary>
		/// Detaches a child edge from this node.
		/// </summary>
		/// <param name="edge">An object that implements the IOwlEdge interface.</param>
		/// <exception cref="ArgumentNullException">The specified edge is a null reference.</exception>
		public void DetachChildEdge(IOwlEdge edge)
		{
			if(edge == null)
				throw (new ArgumentNullException());
			if(ChildEdges.Contains(edge))
			{
				ChildEdges.Remove(edge);
				edge.ParentNode = null;
			}
		}

		/// <summary>
		/// Attaches a parent edge to this node.
		/// </summary>
		/// <param name="edge">An object that implements the IOwlEdge interface.</param>
		/// <exception cref="ArgumentNullException">The specified edge is a null reference.</exception>
		public void AttachParentEdge(IOwlEdge edge)
		{
			if(edge == null)
				throw (new ArgumentNullException());
			bool exists = false;
			IOwlEdgeList edgeList = ParentEdges[edge.ID];
			foreach(OwlEdge e in edgeList) 
			{
				// First, we will look for an edge which is having the same parent and
				// child as the one we want to add
				if(e.ParentNode == edge.ParentNode) 
				{
					exists = true;
				}
			}

			// If there is none, then we add the edge to this node
			if(! exists) 
			{
				ParentEdges.Add(edge);
				edge.ChildNode = this;
			}
			// If not, then do nothing
		}

		/// <summary>
		/// Detaches a parent edge from this node.
		/// </summary>
		/// <param name="edge">An object that implements the IOwlNode interface.</param>
		/// <exception cref="ArgumentNullException">The specified edge is a null reference.</exception>
		public void DetachParentEdge(IOwlEdge edge)
		{
			if(edge == null)
				throw (new ArgumentNullException());
			if(ParentEdges.Contains(edge))
			{
				ParentEdges.Remove(edge);
				edge.ChildNode = null;
			}
		}

		/// <summary>
		/// Detects if the node is anonymous or not.
		/// </summary>
		/// <returns>True if the node is an anonymous one, and false otherwise.</returns>
		public bool IsAnonymous() 
		{
			if(ID.StartsWith("blankID")) 
				return true;
			return false;
		}

		/// <summary>
		/// Detects if the node is a literal or not.
		/// </summary>
		/// <returns>True if the node is a literal, and false otherwise.</returns>
		public bool IsLiteral() 
		{
			if(this is OwlLiteral)
				return true;
			return false;
		}

		/// <summary>
		/// Returns an string representation of this Node
		/// </summary>
		/// <returns>A string containing the string representation of this Node.</returns>
		public override string ToString()
		{
			return ID;
		}

		/// <summary>
		/// The virtual accept method which needs to be overridden by the subclasses in order to have a functional visitor
		/// </summary>
		/// <param name="visitor">The visitor doing all the work</param>
		/// <param name="parent">The parent object of the node to be generated</param>
		public virtual void Accept(IOwlVisitor visitor, Object parent) 
		{
			visitor.Visit(this, parent);
		}

		#endregion
	}
}
