using System;

namespace OwlDotNetApi
{
	/// <summary>
	/// Represents an exception that is thrown when invalid OWL Syntax is encountered by the parser
	/// </summary>
	public class InvalidOwlException : Exception
	{
		#region Variables
		private string _message;

		#endregion

		#region Creators
		/// <summary>
		/// Initializes a new instance of the InvalidOwlException class with an empty message
		/// </summary>
		public InvalidOwlException()
		{
			_message = "";
		}

		/// <summary>
		/// Initializes a new instance of the InvalidOwlException class with the given message
		/// </summary>
		/// <param name="message">A string describing a reason for the exception</param>
		public InvalidOwlException(string message)
		{
			_message = message;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets a message describing the exeption or an empty string
		/// </summary>
		public override string Message
		{
			get
			{
				return _message;
			}
		}

		#endregion
	}
}
