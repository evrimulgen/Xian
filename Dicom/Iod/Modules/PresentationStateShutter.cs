#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
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

using ClearCanvas.Dicom.Iod.Macros;
using ClearCanvas.Dicom.Iod.Sequences;

namespace ClearCanvas.Dicom.Iod.Modules
{
	/// <summary>
	/// PresentationStateShutter Module
	/// </summary>
	/// <remarks>As defined in the DICOM Standard 2008, Part 3, Section C.11.12 (Table C.11.12-1)</remarks>
	public class PresentationStateShutterModuleIod : IodBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PresentationStateShutterModuleIod"/> class.
		/// </summary>	
		public PresentationStateShutterModuleIod() : base() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="PresentationStateShutterModuleIod"/> class.
		/// </summary>
		public PresentationStateShutterModuleIod(IDicomAttributeProvider dicomAttributeProvider) : base(dicomAttributeProvider) { }

		/// <summary>
		/// Initializes the underlying collection to implement the module or sequence using default values.
		/// </summary>
		public void InitializeAttributes()
		{
			this.ShutterPresentationColorCielabValue = null;
			this.ShutterPresentationValue = null;
		}

		/// <summary>
		/// Gets or sets the value of ShutterPresentationValue in the underlying collection. Type 1C.
		/// </summary>
		public int? ShutterPresentationValue
		{
			get
			{
				int result;
				if (base.DicomAttributeProvider[DicomTags.ShutterPresentationValue].TryGetInt32(0, out result))
					return result;
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					base.DicomAttributeProvider[DicomTags.ShutterPresentationValue] = null;
					return;
				}
				base.DicomAttributeProvider[DicomTags.ShutterPresentationValue].SetInt32(0, value.Value);
			}
		}

		/// <summary>
		/// Gets or sets the value of ShutterPresentationColorCielabValue in the underlying collection. Type 1C.
		/// </summary>
		public int[] ShutterPresentationColorCielabValue
		{
			get
			{
				int[] result = new int[3];
				if (base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].TryGetInt32(0, out result[0]))
					if (base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].TryGetInt32(0, out result[1]))
						if (base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].TryGetInt32(0, out result[2]))
					return result;
				return null;
			}
			set
			{
				if (value == null || value.Length != 3)
				{
					base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue] = null;
					return;
				}
				base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].SetInt32(0, value[0]);
				base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].SetInt32(1, value[1]);
				base.DicomAttributeProvider[DicomTags.ShutterPresentationColorCielabValue].SetInt32(2, value[2]);
			}
		}
	}
}