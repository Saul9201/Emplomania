﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace Emplomania.UI.Infrastucture
{
    public class MultiselectBehavior:Behavior<RadComboBox>
    {
        private RadComboBox ComboBox
        {
            get
            {
                return AssociatedObject as RadComboBox;
            }
        }
        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItemsProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(MultiselectBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

        private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                ((MultiselectBehavior)target).UpdateTransfer(args.NewValue);
                collection.CollectionChanged += ((MultiselectBehavior)target).ContextSelectedItems_CollectionChanged;
            }
        }

        private void UpdateTransfer(object items)
        {
            Transfer(items as IList, ComboBox.SelectedItems);
            ComboBox.SelectionChanged += ComboSelectionChanged;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(SelectedItems as IList, ComboBox.SelectedItems);
            SubscribeToEvents();
        }

        private void ComboSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(ComboBox.SelectedItems, SelectedItems as IList);
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            ComboBox.SelectionChanged += ComboSelectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged += ContextSelectedItems_CollectionChanged;
            }
        }

        private void UnsubscribeFromEvents()
        {
            ComboBox.SelectionChanged -= ComboSelectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged -= ContextSelectedItems_CollectionChanged;
            }
        }

        public static void Transfer(IList source, IList target)
        {
            if (source == null || target == null)
                return;

            target.Clear();
            foreach (var o in source)
            {
                target.Add(o);
            }
        }
    }

    public class ListBoxMultiselectBehavior : Behavior<RadListBox>
    {
        private RadListBox ComboBox
        {
            get
            {
                return AssociatedObject as RadListBox;
            }
        }
        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItemsProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(ListBoxMultiselectBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

        private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                ((ListBoxMultiselectBehavior)target).UpdateTransfer(args.NewValue);
                collection.CollectionChanged += ((ListBoxMultiselectBehavior)target).ContextSelectedItems_CollectionChanged;
            }
        }

        private void UpdateTransfer(object items)
        {
            Transfer(items as IList, ComboBox.SelectedItems);
            ComboBox.SelectionChanged += ComboSelectionChanged;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(SelectedItems as IList, ComboBox.SelectedItems);
            SubscribeToEvents();
        }

        private void ComboSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(ComboBox.SelectedItems, SelectedItems as IList);
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            ComboBox.SelectionChanged += ComboSelectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged += ContextSelectedItems_CollectionChanged;
            }
        }

        private void UnsubscribeFromEvents()
        {
            ComboBox.SelectionChanged -= ComboSelectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged -= ContextSelectedItems_CollectionChanged;
            }
        }

        public static void Transfer(IList source, IList target)
        {
            if (source == null || target == null)
                return;

            target.Clear();
            foreach (var o in source)
            {
                target.Add(o);
            }
        }
    }


}
