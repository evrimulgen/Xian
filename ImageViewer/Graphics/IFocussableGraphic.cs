#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

namespace ClearCanvas.ImageViewer.Graphics
{
	/// <summary>
	/// Provides focus support.
	/// </summary>
	public interface IFocussableGraphic : IGraphic
	{
		/// <summary>
		/// Gets or set a value indicating whether the <see cref="IGraphic"/> is in focus.
		/// </summary>
		bool Focussed { get; set; }
	}
}
