namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Windows.Media;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// String To PathGeometry Converter
    /// </summary>
    public class StringToPathGeometryConverter : IValueConverter
    {
        #region Const & Private Variables
        const bool AllowSign = true;
        const bool AllowComma = true;
        const bool IsFilled = true;
        const bool IsClosed = true;

        IFormatProvider _formatProvider;

        PathFigure _figure = null;     
        string _pathString;       
        int _pathLength;
        int _curIndex;        
        bool _figureStarted;     

        Point _lastStart;        
        Point _lastPoint;         
        Point _secondLastPoint;  

        char _token;             
        #endregion

        #region Public Functionality

        /// <summary>
        /// converter from string to file path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public PathGeometry Convert(string path)
        {
            if (null == path)
                throw new ArgumentException("Path string cannot be null!");

            if (path.Length == 0)
                throw new ArgumentException("Path string cannot be empty!");

            return parse(path);
        }

        /// <summary>
        /// not implemented
        /// </summary>
        /// <param name="geometry"></param>
        /// <returns></returns>
        public string ConvertBack(PathGeometry geometry)
        {
            if (null == geometry)
                throw new ArgumentException("Path Geometry cannot be null!");

            return parseBack(geometry);
        }
        #endregion

        #region Private Functionality

        private PathGeometry parse(string path)
        {
            PathGeometry _pathGeometry = null;


            _formatProvider = CultureInfo.InvariantCulture;
            _pathString = path;
            _pathLength = path.Length;
            _curIndex = 0;

            _secondLastPoint = new Point(0, 0);
            _lastPoint = new Point(0, 0);
            _lastStart = new Point(0, 0);

            _figureStarted = false;

            bool first = true;

            char last_cmd = ' ';

            while (ReadToken())
            {
                char cmd = _token;

                if (first)
                {
                    if ((cmd != 'M') && (cmd != 'm')) 
                    {
                        ThrowBadToken();
                    }

                    first = false;
                }

                switch (cmd)
                {
                    case 'm':
                    case 'M':
                        _lastPoint = ReadPoint(cmd, !AllowComma);

                        _figure = new PathFigure();
                        _figure.StartPoint = _lastPoint;
                        _figure.IsFilled = IsFilled;
                        _figure.IsClosed = !IsClosed;
       
                        _figureStarted = true;
                        _lastStart = _lastPoint;
                        last_cmd = 'M';

                        while (IsNumber(AllowComma))
                        {
                            _lastPoint = ReadPoint(cmd, !AllowComma);

                            LineSegment _lineSegment = new LineSegment();
                            _lineSegment.Point = _lastPoint;
                            _figure.Segments.Add(_lineSegment);
                            last_cmd = 'L';
                        }
                        break;

                    case 'l':
                    case 'L':
                    case 'h':
                    case 'H':
                    case 'v':
                    case 'V':
                        EnsureFigure();

                        do
                        {
                            switch (cmd)
                            {
                                case 'l': _lastPoint = ReadPoint(cmd, !AllowComma); break;
                                case 'L': _lastPoint = ReadPoint(cmd, !AllowComma); break;
                                case 'h': _lastPoint.X += ReadNumber(!AllowComma); break;
                                case 'H': _lastPoint.X = ReadNumber(!AllowComma); break;
                                case 'v': _lastPoint.Y += ReadNumber(!AllowComma); break;
                                case 'V': _lastPoint.Y = ReadNumber(!AllowComma); break;
                            }

                            LineSegment _lineSegment = new LineSegment();
                            _lineSegment.Point = _lastPoint;
                            _figure.Segments.Add(_lineSegment);

                        }
                        while (IsNumber(AllowComma));

                        last_cmd = 'L';
                        break;

                    case 'c':
                    case 'C': 
                    case 's':
                    case 'S': 
                        EnsureFigure();

                        do
                        {
                            Point p;

                            if ((cmd == 's') || (cmd == 'S'))
                            {
                                if (last_cmd == 'C')
                                {
                                    p = Reflect();
                                }
                                else
                                {
                                    p = _lastPoint;
                                }

                                _secondLastPoint = ReadPoint(cmd, !AllowComma);
                            }
                            else
                            {
                                p = ReadPoint(cmd, !AllowComma);

                                _secondLastPoint = ReadPoint(cmd, AllowComma);
                            }

                            _lastPoint = ReadPoint(cmd, AllowComma);

                            BezierSegment _bizierSegment = new BezierSegment();
                            _bizierSegment.Point1 = p;
                            _bizierSegment.Point2 = _secondLastPoint;
                            _bizierSegment.Point3 = _lastPoint;
                            _figure.Segments.Add(_bizierSegment);
                         
                            last_cmd = 'C';
                        }
                        while (IsNumber(AllowComma));

                        break;

                    case 'q':
                    case 'Q': 
                    case 't':
                    case 'T': 
                        EnsureFigure();

                        do
                        {
                            if ((cmd == 't') || (cmd == 'T'))
                            {
                                if (last_cmd == 'Q')
                                {
                                    _secondLastPoint = Reflect();
                                }
                                else
                                {
                                    _secondLastPoint = _lastPoint;
                                }

                                _lastPoint = ReadPoint(cmd, !AllowComma);
                            }
                            else
                            {
                                _secondLastPoint = ReadPoint(cmd, !AllowComma);
                                _lastPoint = ReadPoint(cmd, AllowComma);
                            }

                            QuadraticBezierSegment _quadraticBezierSegment = new QuadraticBezierSegment();
                            _quadraticBezierSegment.Point1 = _secondLastPoint;
                            _quadraticBezierSegment.Point2 = _lastPoint;
                            _figure.Segments.Add(_quadraticBezierSegment);
                         
                            last_cmd = 'Q';
                        }
                        while (IsNumber(AllowComma));

                        break;

                    case 'a':
                    case 'A':
                        EnsureFigure();

                        do
                        {
                            double w = ReadNumber(!AllowComma);
                            double h = ReadNumber(AllowComma);
                            double rotation = ReadNumber(AllowComma);
                            bool large = ReadBool();
                            bool sweep = ReadBool();

                            _lastPoint = ReadPoint(cmd, AllowComma);

                            ArcSegment _arcSegment = new ArcSegment();
                            _arcSegment.Point = _lastPoint;
                            _arcSegment.Size = new Size(w, h);
                            _arcSegment.RotationAngle = rotation;
                            _arcSegment.IsLargeArc = large;
                            _arcSegment.SweepDirection = sweep ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                            _figure.Segments.Add(_arcSegment);

                        }
                        while (IsNumber(AllowComma));

                        last_cmd = 'A';
                        break;

                    case 'z':
                    case 'Z':
                        EnsureFigure();
                        _figure.IsClosed = IsClosed;

                        _figureStarted = false;
                        last_cmd = 'Z';

                        _lastPoint = _lastStart; 
                        break;

                    default:
                        ThrowBadToken();
                        break;
                }
            }

            if (null != _figure)
            {
                _pathGeometry = new PathGeometry();
                _pathGeometry.Figures.Add(_figure);

            }
            return _pathGeometry;
        }

        void SkipDigits(bool signAllowed)
        {
            if (signAllowed && More() && ((_pathString[_curIndex] == '-') || _pathString[_curIndex] == '+'))
            {
                _curIndex++;
            }

            while (More() && (_pathString[_curIndex] >= '0') && (_pathString[_curIndex] <= '9'))
            {
                _curIndex++;
            }
        }

        bool ReadBool()
        {
            SkipWhiteSpace(AllowComma);

            if (More())
            {
                _token = _pathString[_curIndex++];

                if (_token == '0')
                {
                    return false;
                }
                else if (_token == '1')
                {
                    return true;
                }
            }

            ThrowBadToken();

            return false;
        }

        private Point Reflect()
        {
            return new Point(2 * _lastPoint.X - _secondLastPoint.X,
                             2 * _lastPoint.Y - _secondLastPoint.Y);
        }

        private void EnsureFigure()
        {
            if (!_figureStarted)
            {
                _figure = new PathFigure();
                _figure.StartPoint = _lastStart;
                _figureStarted = true;
            }
        }

        double ReadNumber(bool allowComma)
        {
            if (!IsNumber(allowComma))
            {
                ThrowBadToken();
            }

            bool simple = true;
            int start = _curIndex;

            if (More() && ((_pathString[_curIndex] == '-') || _pathString[_curIndex] == '+'))
            {
                _curIndex++;
            }

            if (More() && (_pathString[_curIndex] == 'I'))
            {
                _curIndex = Math.Min(_curIndex + 8, _pathLength); 
                simple = false;
            }

            else if (More() && (_pathString[_curIndex] == 'N'))
            {

                _curIndex = Math.Min(_curIndex + 3, _pathLength);
                simple = false;
            }
            else
            {
                SkipDigits(!AllowSign);

                if (More() && (_pathString[_curIndex] == '.'))
                {
                    simple = false;
                    _curIndex++;
                    SkipDigits(!AllowSign);
                }

                if (More() && ((_pathString[_curIndex] == 'E') || (_pathString[_curIndex] == 'e')))
                {
                    simple = false;
                    _curIndex++;
                    SkipDigits(AllowSign);
                }
            }

            if (simple && (_curIndex <= (start + 8))) 
            {
                int sign = 1;

                if (_pathString[start] == '+')
                {
                    start++;
                }
                else if (_pathString[start] == '-')
                {
                    start++;
                    sign = -1;
                }

                int value = 0;

                while (start < _curIndex)
                {
                    value = value * 10 + (_pathString[start] - '0');
                    start++;
                }

                return value * sign;
            }
            else
            {
                string subString = _pathString.Substring(start, _curIndex - start);

                try
                {
                    return System.Convert.ToDouble(subString, _formatProvider);
                }
                catch (FormatException except)
                {
                    throw new FormatException(string.Format("Unexpected character in path '{0}' at position {1}", _pathString, _curIndex - 1), except);
                }
            }
        }

        private bool IsNumber(bool allowComma)
        {
            bool commaMet = SkipWhiteSpace(allowComma);

            if (More())
            {
                _token = _pathString[_curIndex];

                if ((_token == '.') || (_token == '-') || (_token == '+') || ((_token >= '0') && (_token <= '9'))
                    || (_token == 'I') 
                    || (_token == 'N')) 
                {
                    return true;
                }
            }

            if (commaMet) 
            {
                ThrowBadToken();
            }

            return false;
        }

        private Point ReadPoint(char cmd, bool allowcomma)
        {
            double x = ReadNumber(allowcomma);
            double y = ReadNumber(AllowComma);

            if (cmd >= 'a') 
            {
                x += _lastPoint.X;
                y += _lastPoint.Y;
            }

            return new Point(x, y);
        }

        private bool ReadToken()
        {
            SkipWhiteSpace(!AllowComma);

            if (More())
            {
                _token = _pathString[_curIndex++];

                return true;
            }
            else
            {
                return false;
            }
        }

        bool More()
        {
            return _curIndex < _pathLength;
        }

        private bool SkipWhiteSpace(bool allowComma)
        {
            bool commaMet = false;

            while (More())
            {
                char ch = _pathString[_curIndex];

                switch (ch)
                {
                    case ' ':
                    case '\n':
                    case '\r':
                    case '\t':
                        break;

                    case ',':
                        if (allowComma)
                        {
                            commaMet = true;
                            allowComma = false; 
                        }
                        else
                        {
                            ThrowBadToken();
                        }
                        break;

                    default:
                  
                        if (((ch > ' ') && (ch <= 'z')) || !Char.IsWhiteSpace(ch))
                        {
                            return commaMet;
                        }
                        break;
                }

                _curIndex++;
            }

            return commaMet;
        }

        private void ThrowBadToken()
        {
            throw new FormatException(string.Format("Unexpected character in path '{0}' at position {1}", _pathString, _curIndex - 1));
        }

        static internal char GetNumericListSeparator(IFormatProvider provider)
        {
            char numericSeparator = ',';

            NumberFormatInfo numberFormat = NumberFormatInfo.GetInstance(provider);

            if ((numberFormat.NumberDecimalSeparator.Length > 0) && (numericSeparator == numberFormat.NumberDecimalSeparator[0]))
            {
                numericSeparator = ';';
            }

            return numericSeparator;
        }

        private string parseBack(PathGeometry geometry)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            IFormatProvider provider = new System.Globalization.CultureInfo("en-us");
            string format = null;

            foreach (PathFigure figure in geometry.Figures)
            {
                sb.Append("M " + ((IFormattable)figure.StartPoint).ToString(format, provider) + " ");

                foreach (PathSegment segment in figure.Segments)
                {
                    char separator = GetNumericListSeparator(provider);

                    if (segment.GetType() == typeof(LineSegment))
                    {
                        LineSegment _lineSegment = segment as LineSegment;

                        sb.Append("L " + ((IFormattable)_lineSegment.Point).ToString(format, provider) + " ");
                    }
                    else if (segment.GetType() == typeof(BezierSegment))
                    {
                        BezierSegment _bezierSegment = segment as BezierSegment;

                        sb.Append(String.Format(provider,
                             "C{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "} ",
                             separator,
                             _bezierSegment.Point1,
                             _bezierSegment.Point2,
                             _bezierSegment.Point3
                             ));
                    }
                    else if (segment.GetType() == typeof(QuadraticBezierSegment))
                    {
                        QuadraticBezierSegment _quadraticBezierSegment = segment as QuadraticBezierSegment;

                        sb.Append(String.Format(provider,
                             "Q{1:" + format + "}{0}{2:" + format + "} ",
                             separator,
                             _quadraticBezierSegment.Point1,
                             _quadraticBezierSegment.Point2));
                    }
                    else if (segment.GetType() == typeof(ArcSegment))
                    {
                        ArcSegment _arcSegment = segment as ArcSegment;

                        sb.Append(String.Format(provider,
                             "A{1:" + format + "}{0}{2:" + format + "}{0}{3}{0}{4}{0}{5:" + format + "} ",
                             separator,
                             _arcSegment.Size,
                             _arcSegment.RotationAngle,
                             _arcSegment.IsLargeArc ? "1" : "0",
                             _arcSegment.SweepDirection == SweepDirection.Clockwise ? "1" : "0",
                             _arcSegment.Point));
                    }
                }

                if (figure.IsClosed)
                    sb.Append("Z");
            }

            return sb.ToString();
        }
        #endregion

        #region IValueConverter Members

        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (null != path)
                return Convert(path);
            else
                return null;
        }

        /// <summary>
        /// reverse converter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PathGeometry geometry = value as PathGeometry;

            if (null != geometry)
                return ConvertBack(geometry);
            else
                return default(string);
        }

        #endregion
    }
}
