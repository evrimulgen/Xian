﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using ClearCanvas.Common;
using Crownwood.DotNetMagic.Forms;

namespace ClearCanvas.Desktop.View.WinForms
{
	/// <summary>
	/// Form used by the <see cref="DialogBoxView"/> class.
	/// </summary>
	/// <remarks>
	/// This class may be subclassed.
	/// </remarks>
	public partial class DialogBoxForm : DotNetMagicForm
	{
		private readonly Control _content;
		private DialogBoxAction _closeAction;

		internal DialogBoxForm(string title, Control content, Size exactSize, DialogSizeHint sizeHint)
			: this(title, content, exactSize, sizeHint, false) {}

		internal DialogBoxForm(string title, Control content, Size exactSize, DialogSizeHint sizeHint, bool allowResize)
		{
			InitializeComponent();
			Text = title;

			_content = content;

			// important - if we do not set a minimum size, the full content may not be displayed
			_content.MinimumSize = _content.Size;
			_content.Dock = DockStyle.Fill;

			if (exactSize != Size.Empty)
			{
				ClientSize = exactSize;
			}
			else
			{
				switch (sizeHint)
				{
					case DialogSizeHint.Auto:
						// force the dialog client size to the size of the content
						ClientSize = _content.Size;
						break;
					case DialogSizeHint.Small:
						ClientSize = new Size(320, 240);
						break;
					case DialogSizeHint.Medium:
						ClientSize = new Size(640, 480);
						break;
					case DialogSizeHint.Large:
						ClientSize = new Size(800, 600);
						break;
					default:
						break;
				}
			}

			if (allowResize)
			{
				FormBorderStyle = FormBorderStyle.Sizable;
				MinimumSize = base.SizeFromClientSize(_content.Size);
			}

			_contentPanel.Controls.Add(_content);

			// Resize the dialog if size of the underlying content changed
			_content.SizeChanged += OnContentSizeChanged;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dialogBox"></param>
		/// <param name="content"></param>
		public DialogBoxForm(DialogBox dialogBox, Control content)
			: this(dialogBox.Title, content, dialogBox.Size, dialogBox.DialogSizeHint, dialogBox.AllowUserResize)
		{
		}

		internal void DelayedClose(DialogBoxAction action)
		{
			_closeAction = action;
			_delayedCloseTimer.Enabled = true;
		}

		private void OnContentSizeChanged(object sender, EventArgs e)
		{
			if (ClientSize != _content.Size)
				ClientSize = _content.Size;
		}

		private void _delayedCloseTimer_Tick(object sender, EventArgs e)
		{
			// disable timer so it doesn't fire again
			_delayedCloseTimer.Enabled = false;

			// close the form
			switch (_closeAction)
			{
				case DialogBoxAction.Cancel:
					DialogResult = DialogResult.Cancel;
					break;
				case DialogBoxAction.Ok:
					DialogResult = DialogResult.OK;
					break;
			}
		}
	}
}