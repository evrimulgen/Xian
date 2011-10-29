#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.ImageViewer.Imaging
{
	/// <summary>
	/// A 1-to-1 pass-through composable LUT (i.e. the identity transform).
	/// </summary>
	[Cloneable(true)]
	public sealed class IdentityVoiLinearLut : ComposableVoiLut, IVoiLutLinear
	{
		private int _minInputValue;
		private int _maxInputValue;

		/// <summary>
		/// Constructs a 1-to-1 pass-through composable LUT for 8-bit unsigned values.
		/// </summary>
		public IdentityVoiLinearLut()
		{
		    //TODO (CR June 2011): doesn't make sense to arbitrarily set the
            //min/max input to 8-bit values when it's dependent on the source
            //image bit depth and sign.
			_minInputValue = 0;
			_maxInputValue = 255;
		}

		/// <summary>
		/// Constructs a 1-to-1 pass-through composable LUT for unsigned values.
		/// </summary>
		/// <param name="channelBitDepth">The bit-depth of the unsigned values.</param>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if the bit-depth is not between 1 and 31, inclusive.</exception>
		public IdentityVoiLinearLut(int channelBitDepth)
		{
            //TODO (CR June 2011): this is wrong because it doesn't account for the sign
            //of the source image.  Not even sure why we're doing this because
            //it'll get set externally by LutComposer anyway?

            Platform.CheckArgumentRange(channelBitDepth, 1, 31, "channelBitDepth");
			_minInputValue = 0;
			_maxInputValue = (1 << channelBitDepth) - 1;
		}

		/// <summary>
		/// Gets an abbreviated description of the LUT.
		/// </summary>
		public override string GetDescription()
		{
			return string.Format(SR.FormatDescriptionIdentityVoiLinearLut, WindowWidth, WindowCenter);
		}

		/// <summary>
		/// Gets or sets the minimum input value.
		/// </summary>
		public override double MinInputValue
		{
			get { return _minInputValue; }
			set { _minInputValue = (int) Math.Floor(value); }
		}

		/// <summary>
		/// Gets the maximum input value.
		/// </summary>
		public override double MaxInputValue
		{
			get { return _maxInputValue; }
			set { _maxInputValue = (int) Math.Floor(value); }
		}

		/// <summary>
		/// Gets the minimum output value.
		/// </summary>
		/// <remarks>
		/// Due to the nature of a <see cref="IdentityVoiLinearLut"/>, this value is always exactly <see cref="MinInputValue"/>.
		/// </remarks>
		public override int MinOutputValue
		{
			get { return _minInputValue; }
			protected set { throw new NotSupportedException(); }
		}

		/// <summary>
		/// Gets the maximum output value.
		/// </summary>
		/// <remarks>
		/// Due to the nature of a <see cref="IdentityVoiLinearLut"/>, this value is always exactly <see cref="MaxInputValue"/>.
		/// </remarks>
		public override int MaxOutputValue
		{
			get { return _maxInputValue; }
			protected set { throw new NotSupportedException(); }
		}

		/// <summary>
		/// Gets the output value of the lut at a given input index.
		/// </summary>
		/// <remarks>
		/// Due to the nature of a <see cref="IdentityVoiLinearLut"/>, the value is always exactly <paramref name="index"/>.
		/// </remarks>
		public override int this[double index]
		{
			get { return (int) Math.Floor(index); }
		}

		/// <summary>
		/// Gets the window width.
		/// </summary>
		/// <remarks>
		/// Due to the nature of a <see cref="IdentityVoiLinearLut"/>, this value is always exactly <see cref="MaxInputValue"/>-<see cref="MinInputValue"/>+1.
		/// </remarks>
		public double WindowWidth
		{
			get { return (double) _maxInputValue - _minInputValue + 1; }
		}

		/// <summary>
		/// Gets the window centre.
		/// </summary>
		/// <remarks>
		/// Due to the nature of a <see cref="IdentityVoiLinearLut"/>, this value is always exactly (<see cref="MaxInputValue"/>-<see cref="MinInputValue"/>+1)/2.
		/// </remarks>
		public double WindowCenter
		{
			get { return this.WindowWidth/2; }
		}

		/// <summary>
		/// Gets a string key that identifies this particular LUT's characteristics, so that 
		/// an image's <see cref="IComposedLut"/> can be more efficiently determined.
		/// </summary>
		public override string GetKey()
		{
			return string.Format("IDENTITY_{0}_to_{1}", _minInputValue, _maxInputValue);
		}
	}
}