

namespace Inflexion2.UX.WPF.MVVM
{
    using AvalonDock;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Regions.Behaviors;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// Sync docked documents
    /// </summary>
    class DockingManagerDocumentsSourceSyncBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public static readonly string BehaviorKey = "DockingManagerDocumentsSourceSyncBehavior";
        private bool _updatingActiveViewsInManagerActiveContentChanged;
        private DockingManager _dockingManager;
        ObservableCollection<object> _documents = new ObservableCollection<object>();
        ReadOnlyObservableCollection<object> _readonlyDocumentsList = null;

        public DependencyObject HostControl
        {
            get
            {
                return this._dockingManager;
            }

            set
            {
                this._dockingManager = value as DockingManager;
            }
        }

        public ReadOnlyObservableCollection<object> Documents
        {
            get
            {
                if (_readonlyDocumentsList == null)
                    _readonlyDocumentsList = new ReadOnlyObservableCollection<object>(_documents);

                return _readonlyDocumentsList;
            }

        }

        /// <summary>
        /// Starts to monitor the <see cref="IRegion"/> to keep it in synch with the items of the <see cref="HostControl"/>.
        /// </summary>
        protected override void OnAttach()
        {
            bool itemsSourceIsSet = this._dockingManager.DocumentsSource != null;


            if (itemsSourceIsSet)
            {
                throw new InvalidOperationException();
            }

            this.SynchronizeItems();

            this._dockingManager.DocumentClosed += new EventHandler<DocumentClosedEventArgs>(newDockableContent_Closed);
            this._dockingManager.ActiveContentChanged += this.ManagerActiveContentChanged;
            this.Region.ActiveViews.CollectionChanged += this.ActiveViews_CollectionChanged;
            this.Region.Views.CollectionChanged += this.Views_CollectionChanged;
        }

        private void newDockableContent_Closed(object sender, DocumentClosedEventArgs e)
        {
            var dockableContent = e.Document;
            if (dockableContent != null)
            {
                if (this.Region.Views.Contains(dockableContent.Content))
                {
                    _documents.Remove(dockableContent);
                    this.Region.Remove(dockableContent.Content);
                    //this.SynchronizeItems();
                }
            }
        }

        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                int startIndex = e.NewStartingIndex;
                foreach (object newItem in e.NewItems)
                {
                    _documents.Insert(startIndex++, newItem);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object oldItem in e.OldItems)
                {
                    _documents.Remove(oldItem);
                }
            }
        }

        private void SynchronizeItems()
        {
            BindingOperations.SetBinding(
                _dockingManager,
                DockingManager.DocumentsSourceProperty,
                new Binding("Documents") { Source = this });

            foreach (object view in this.Region.Views)
            {
                _documents.Add(view);
            }
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this._updatingActiveViewsInManagerActiveContentChanged)
            {
                return;
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (this._dockingManager.ActiveContent != null
                    && this._dockingManager.ActiveContent != e.NewItems[0]
                    && this.Region.ActiveViews.Contains(this._dockingManager.ActiveContent))
                {
                    this.Region.Deactivate(this._dockingManager.ActiveContent);
                }

                this._dockingManager.ActiveContent = e.NewItems[0];
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove &&
                     e.OldItems.Contains(this._dockingManager.ActiveContent))
            {
                this._dockingManager.ActiveContent = null;
            }
        }

        private void ManagerActiveContentChanged(object sender, System.EventArgs e)
        {
            try
            {
                this._updatingActiveViewsInManagerActiveContentChanged = true;

                if (_dockingManager == sender)
                {
                    object activeContent = _dockingManager.ActiveContent;
                    foreach (var item in this.Region.ActiveViews.Where(it => it != activeContent))
                    {
                        this.Region.Deactivate(item);
                        var vm = (IRegionViewModel)((UserControl)item).DataContext;
                        if (vm != null)
                        {
                            vm.IsActive = false;
                            //vm.DeactivateChildrenCollections();
                        }
                    }

                    if (this.Region.Views.Contains(activeContent) && !this.Region.ActiveViews.Contains(activeContent))
                    {
                        // activate the view
                        this.Region.Activate(activeContent);
                        //activate his viewmodel
                        var vm = (IRegionViewModel)((UserControl)activeContent).DataContext;
                        if (vm != null)
                        {
                            vm.IsActive = true;
                        }
                    }
                }
            }
            finally
            {
                this._updatingActiveViewsInManagerActiveContentChanged = false;
            }
        }

    }
}
