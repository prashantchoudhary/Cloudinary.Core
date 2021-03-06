﻿// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.TextLayer
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;
using System.Collections.Generic;
using System.Net;

namespace CloudinaryDotNet
{
    public class TextLayer : BaseLayer<TextLayer>
    {
        protected string m_fontFamily;
        protected int m_fontSize;
        protected string m_fontStyle;
        protected string m_fontWeight;
        protected string m_letterSpacing;
        protected string m_lineSpacing;
        protected string m_stroke;
        protected string m_text;
        protected string m_textAlign;
        protected string m_textDecoration;

        public TextLayer()
        {
            m_resourceType = "text";
            FontSize(12);
        }

        public TextLayer(string text)
            : this()
        {
            Text(text);
        }

        public new TextLayer ResourceType(string resourceType)
        {
            throw new InvalidOperationException("Cannot modify resourceType for text layers");
        }

        public new TextLayer Type(string type)
        {
            throw new InvalidOperationException("Cannot modify type for text layers");
        }

        public new TextLayer Format(string format)
        {
            throw new InvalidOperationException("Cannot modify format for text layers");
        }

        public TextLayer Text(string text)
        {
            m_text = OverlayTextEncode(text);
            return this;
        }

        private string OverlayTextEncode(string text)
        {
            return WebUtility.UrlEncode(text).Replace("%2f", "/").Replace("%3a", ":").Replace("+", "%20").Replace("%2c", "%e2%80%9a").Replace("/", "%e2%81%84");
        }

        public TextLayer FontFamily(string fontFamily)
        {
            m_fontFamily = fontFamily;
            return this;
        }

        public TextLayer FontSize(int fontSize)
        {
            m_fontSize = fontSize;
            return this;
        }

        public TextLayer FontWeight(string fontWeight)
        {
            m_fontWeight = fontWeight;
            return this;
        }

        public TextLayer FontStyle(string fontStyle)
        {
            m_fontStyle = fontStyle;
            return this;
        }

        public TextLayer TextDecoration(string textDecoration)
        {
            m_textDecoration = textDecoration;
            return this;
        }

        public TextLayer TextAlign(string textAlign)
        {
            m_textAlign = textAlign;
            return this;
        }

        public TextLayer Stroke(string stroke)
        {
            m_stroke = stroke;
            return this;
        }

        public TextLayer LetterSpacing(string letterSpacing)
        {
            m_letterSpacing = letterSpacing;
            return this;
        }

        public TextLayer LineSpacing(string lineSpacing)
        {
            m_lineSpacing = lineSpacing;
            return this;
        }

        public override string AdditionalParams()
        {
            var stringList = new List<string>();
            var str = TextStyleIdentifier();
            if (!string.IsNullOrEmpty(str))
                stringList.Add(str);
            if (!string.IsNullOrEmpty(m_text))
                stringList.Add(m_text);
            return string.Join(":", stringList.ToArray());
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(m_publicId) && string.IsNullOrEmpty(m_text))
                throw new ArgumentException("Must supply either text or publicId.");
            return base.ToString();
        }

        private string TextStyleIdentifier()
        {
            var stringList = new List<string>();
            if (!string.IsNullOrEmpty(m_fontWeight) && !m_fontWeight.Equals("normal"))
                stringList.Add(m_fontWeight);
            if (!string.IsNullOrEmpty(m_fontStyle) && !m_fontStyle.Equals("normal"))
                stringList.Add(m_fontStyle);
            if (!string.IsNullOrEmpty(m_textDecoration) && !m_textDecoration.Equals("none"))
                stringList.Add(m_textDecoration);
            if (!string.IsNullOrEmpty(m_textAlign))
                stringList.Add(m_textAlign);
            if (!string.IsNullOrEmpty(m_stroke) && !m_stroke.Equals("none"))
                stringList.Add(m_stroke);
            if (!string.IsNullOrEmpty(m_letterSpacing))
                stringList.Add(string.Format("letter_spacing_{0}", m_letterSpacing));
            if (!string.IsNullOrEmpty(m_lineSpacing))
                stringList.Add(string.Format("line_spacing_{0}", m_lineSpacing));
            if (string.IsNullOrEmpty(m_fontFamily) && stringList.Count == 0)
                return null;
            if (string.IsNullOrEmpty(m_fontFamily))
                throw new ArgumentException("Must supply fontFamily.");
            stringList.Insert(0, m_fontSize.ToString());
            stringList.Insert(0, m_fontFamily);
            return string.Join("_", stringList.ToArray());
        }
    }
}