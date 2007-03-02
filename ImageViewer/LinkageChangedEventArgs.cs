using System;

namespace ClearCanvas.ImageViewer
{
	/// <summary>
	/// 
	/// </summary>
	public class LinkageChangedEventArgs : EventArgs
	{
		private bool _isLinked;

		internal LinkageChangedEventArgs(bool isLinked)
		{
			_isLinked = isLinked;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsLinked { get { return _isLinked; } }
	}
}
