using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// A WrapperProperty is property that is originated in some class and the wrapper keeps all the information
    /// about his origin to be able to read or update.
    /// </summary>
    public class WrapperProperty /*: INotifyPropertyChanged*/
    {
        private Type sourceClass;
        private int id;
        private string propertyName;
        private object propertyValue;
        private int parentId;

        //private readonly WeakEvent<Action> _wrapperPropertyChanged = new WeakEvent<Action>();

        //public event Action WrapperPropertyChanged
        //{
        //    add { this._wrapperPropertyChanged.AddHandler(value); }
        //    remove { this._wrapperPropertyChanged.RemoveHandler(value); }
        //}

        public object PropertyValue
        {
            get
            {
                return propertyValue;
            }

            set
            {
                propertyValue = value;
                //this._wrapperPropertyChanged.RaiseEvent();
            }
        }

        public WrapperProperty()
        { }

        public WrapperProperty(Type sourceClass, int id, string propertyName, dynamic propertyValue, int parentId = 0)
        {
            this.sourceClass = sourceClass;
            this.id = id;
            this.propertyValue = propertyValue;
            this.propertyName = propertyName;
            this.parentId = parentId;
        }

        public Type GetInternalType()
        {
            return sourceClass;
        }
        public int GetId()
        {
            return id;
        }

        public string GetPropertyName()
        {
            return this.propertyName;
        }


        #region INotifyPropertyChanged implementation
        //public static event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// https://www.danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/
        ///// </summary>
        ///// <param name="propertyName"></param>
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="field"></param>
        ///// <param name="value"></param>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value))
        //        return false;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
        #endregion

    }
}
