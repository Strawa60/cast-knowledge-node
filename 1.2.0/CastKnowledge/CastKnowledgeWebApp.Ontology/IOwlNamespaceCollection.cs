using System;
using System.Collections;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents a collection of Namespaces
	/// </summary>
	public interface IOwlNamespaceCollection
	{
		/// <summary>
		/// When implemented by a class, gets or sets the namespace with the specified name
		/// </summary>
		string this[string name]
		{
			get;
			set;
		}

		/// <summary>
		/// Gets an enumerator that can iterate through this collection.
		/// </summary>
		/// <returns>An object that implements that implements the <see cref="IEnumerator"/> interface.</returns>
		IEnumerator GetEnumerator();

		/// <summary>
		/// Gets the total number of namespaces in this collection.
		/// </summary>
		int Count
		{
			get;
		}

		/// <summary>
		/// Removes a namespace from this collection
		/// </summary>
		/// <param name="name">The name of the namespace to remove</param>
		void Remove(string name);

		/// <summary>
		/// When implemented by a class removes all the namespaces from this collection
		/// </summary>
		void RemoveAll();
	}
}
