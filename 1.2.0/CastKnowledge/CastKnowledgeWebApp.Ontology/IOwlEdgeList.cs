using System;
using System.Collections;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a collection of IOwlEdge objects
	/// </summary>
	public interface IOwlEdgeList
	{
		/// <summary>
		/// When implemented by a class, gets the total number of members in this collection
		/// </summary>
		int Count
		{
			get;
		}

		/// <summary>
		/// When implemented by a class, gets the IOwlEdge at the specified index
		/// </summary>
		IOwlEdge this[int index]
		{
			get;
			set;
		}

		/// <summary>
		/// When implemented by a class, returns an enumerator that can iterate through the collection
		/// </summary>
		IEnumerator GetEnumerator();

		/// <summary>
		/// When implemented by a class, adds an IOwlEdge object to the collection
		/// </summary>
		/// <param name="edge">The IOwlEdge to add to the collection</param>
		void Add(IOwlEdge edge);

		/// <summary>
		/// When implemented by a class, determines whether the specified IOwlEdge is a member of this collection
		/// </summary>
		/// <param name="edge">An IOwlEdge</param>
		/// <returns>True if the specified edge belongs to the collection.</returns>
		bool Contains(IOwlEdge edge);

		/// <summary>
		/// When implemented by a class, removes the specified IOwlEdge object from the collection
		/// </summary>
		/// <param name="edge">The edge to remove</param>
		void Remove(IOwlEdge edge);

		/// <summary>
		/// When implemented by a class removes all the edges from this collection
		/// </summary>
		void RemoveAll();
	}
}
