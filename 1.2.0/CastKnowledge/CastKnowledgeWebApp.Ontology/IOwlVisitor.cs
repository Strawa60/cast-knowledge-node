using System;

namespace OwlDotNetApi
{
	/// <summary>
	/// This interface defines the type of object that the nodes and edges will 
	/// accept. The Node hierarchy classes call back a Visiting 
	/// object's Visit() methods; In so doing they identify their 
	/// type. Implementors of this interface can create algorithms 
	/// that operate differently on different type of Nodes. 
	/// </summary>
	public interface IOwlVisitor
	{	
		/// <summary>
		/// Visit function to generate a regular node, used in the visitor patterns
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlNode node, Object parent);

		/// <summary>
		/// Visit function to generate the code for an edge.
		/// </summary>
		/// <param name="edge">The actual edge which needs to be generated</param>
		/// <param name="parent">The parent object of the edge</param>
		void Visit(OwlEdge edge, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlLiteral node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlClass node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlDataRange node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlAnnotationProperty node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlDatatype node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlDatatypeProperty node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlIndividual node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlObjectProperty node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlOntology node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlOntologyProperty node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlProperty node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlRestriction node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlResource node, Object parent);

		/// <summary>
		/// Visit function to generate some output, used in the visitor pattern
		/// </summary>
		/// <param name="node">The actual node which needs to be generated</param>
		/// <param name="parent">The parent object of the node</param>
		void Visit(OwlCollection node, Object parent);
		
	}
}
