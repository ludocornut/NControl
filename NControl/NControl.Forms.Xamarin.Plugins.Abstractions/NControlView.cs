﻿/************************************************************************
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2025 - Christian Falch
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the 
 * "Software"), to deal in the Software without restriction, including 
 * without limitation the rights to use, copy, modify, merge, publish, 
 * distribute, sublicense, and/or sell copies of the Software, and to 
 * permit persons to whom the Software is furnished to do so, subject 
 * to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be 
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 ************************************************************************/

using System;
using Xamarin.Forms;
using NGraphics;
using System.Collections.Generic;

namespace NControl.Plugins.Abstractions
{
	/// <summary>
	/// NControlView Definition
	/// </summary>
    public class NControlView: ContentView
	{
        #region Private Members

        /// <summary>
        /// The color of the background.
        /// </summary>
        private Xamarin.Forms.Color _backgroundColor;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when on invalidate.
        /// </summary>
        public event System.EventHandler OnInvalidate;

        #endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="NControl.Forms.Xamarin.Plugins.iOS.NControlNativeView"/> class.
		/// </summary>
		public NControlView()
		{
			base.BackgroundColor = Xamarin.Forms.Color.Transparent;
            BackgroundColor = Xamarin.Forms.Color.Transparent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NControl.Forms.Xamarin.Plugins.iOS.NControlNativeView"/> class with
		/// a callback action for drawing
		/// </summary>
		/// <param name="drawingFunc">Drawing func.</param>
        public NControlView(Action<ICanvas, Rect> drawingFunc): this()
		{
			DrawingFunction = drawingFunc;
		}

		#endregion

        #region Properties

		/// <summary>
		/// Gets the drawing function.
		/// </summary>
		/// <value>The drawing function.</value>
        public Action<ICanvas, Rect> DrawingFunction {get; set;}

        /// <summary>
        /// Gets or sets the color which will fill the background of a VisualElement. This is a bindable property.
        /// </summary>
        /// <value>The color of the background.</value>
        public new Xamarin.Forms.Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

		#endregion

        /// <summary>
        /// Invalidate this instance.
        /// </summary>
        protected void Invalidate()
        {
            if (OnInvalidate != null)
                OnInvalidate(this, EventArgs.Empty);
        }

		/// <summary>
		/// Draw the specified canvas.
		/// </summary>
		/// <param name="canvas">Canvas.</param>
        public virtual void Draw(ICanvas canvas, Rect rect)
		{
            if(_backgroundColor != Xamarin.Forms.Color.Transparent)
                canvas.FillRectangle(rect, new NGraphics.Color(
                    _backgroundColor.R, _backgroundColor.G, _backgroundColor.B));
            
            if (DrawingFunction != null)
                DrawingFunction(canvas, rect);
		}

        /// <summary>
        /// Touchs down.
        /// </summary>
        /// <param name="point">Point.</param>
        public virtual void TouchesBegan(IEnumerable<NGraphics.Point> points)
        {
        }

        /// <summary>
        /// Toucheses the moved.
        /// </summary>
        /// <param name="point">Point.</param>
        public virtual void TouchesMoved(IEnumerable<NGraphics.Point> points)
        {
        }

        /// <summary>
        /// Toucheses the cancelled.
        /// </summary>
        public virtual void TouchesCancelled(IEnumerable<NGraphics.Point> points)
        {
        }

        /// <summary>
        /// Toucheses the ended.
        /// </summary>
        public virtual void TouchesEnded(IEnumerable<NGraphics.Point> points)
        {
        }
	}
}

