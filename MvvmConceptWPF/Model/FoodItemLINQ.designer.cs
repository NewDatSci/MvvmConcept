﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvvmConceptWPF.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="FoodOrder")]
	public partial class FoodItemLINQDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCategorisedItem(CategorisedItem instance);
    partial void UpdateCategorisedItem(CategorisedItem instance);
    partial void DeleteCategorisedItem(CategorisedItem instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertMenuItem(MenuItem instance);
    partial void UpdateMenuItem(MenuItem instance);
    partial void DeleteMenuItem(MenuItem instance);
    #endregion
		
		public FoodItemLINQDataContext() : 
				base(global::MvvmConceptWPF.Properties.Settings.Default.FoodOrderConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FoodItemLINQDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodItemLINQDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodItemLINQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodItemLINQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CategorisedItem> CategorisedItems
		{
			get
			{
				return this.GetTable<CategorisedItem>();
			}
		}
		
		public System.Data.Linq.Table<Category> Categories
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<MenuItem> MenuItems
		{
			get
			{
				return this.GetTable<MenuItem>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetFoodItems")]
		public ISingleResult<GetFoodItemsResult> GetFoodItems()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetFoodItemsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.UpdateFoodItem")]
		public int UpdateFoodItem([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FoodName", DbType="NVarChar(50)")] string foodName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ItemPrice", DbType="Decimal(18,0)")] System.Nullable<decimal> itemPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ItemId", DbType="Int")] System.Nullable<int> itemId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), foodName, itemPrice, itemId);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CategorisedItems")]
	public partial class CategorisedItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ItemId;
		
		private int _CategoryID;
		
		private EntityRef<Category> _Category;
		
		private EntityRef<MenuItem> _MenuItem;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItemIdChanging(int value);
    partial void OnItemIdChanged();
    partial void OnCategoryIDChanging(int value);
    partial void OnCategoryIDChanged();
    #endregion
		
		public CategorisedItem()
		{
			this._Category = default(EntityRef<Category>);
			this._MenuItem = default(EntityRef<MenuItem>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ItemId
		{
			get
			{
				return this._ItemId;
			}
			set
			{
				if ((this._ItemId != value))
				{
					if (this._MenuItem.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnItemIdChanging(value);
					this.SendPropertyChanging();
					this._ItemId = value;
					this.SendPropertyChanged("ItemId");
					this.OnItemIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					if (this._Category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_CategorisedItem", Storage="_Category", ThisKey="CategoryID", OtherKey="CategoryID", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.CategorisedItems.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.CategorisedItems.Add(this);
						this._CategoryID = value.CategoryID;
					}
					else
					{
						this._CategoryID = default(int);
					}
					this.SendPropertyChanged("Category");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MenuItem_CategorisedItem", Storage="_MenuItem", ThisKey="ItemId", OtherKey="ItemId", IsForeignKey=true)]
		public MenuItem MenuItem
		{
			get
			{
				return this._MenuItem.Entity;
			}
			set
			{
				MenuItem previousValue = this._MenuItem.Entity;
				if (((previousValue != value) 
							|| (this._MenuItem.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._MenuItem.Entity = null;
						previousValue.CategorisedItems.Remove(this);
					}
					this._MenuItem.Entity = value;
					if ((value != null))
					{
						value.CategorisedItems.Add(this);
						this._ItemId = value.ItemId;
					}
					else
					{
						this._ItemId = default(int);
					}
					this.SendPropertyChanged("MenuItem");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CategoryID;
		
		private string _Category1;
		
		private EntitySet<CategorisedItem> _CategorisedItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCategoryIDChanging(int value);
    partial void OnCategoryIDChanged();
    partial void OnCategory1Changing(string value);
    partial void OnCategory1Changed();
    #endregion
		
		public Category()
		{
			this._CategorisedItems = new EntitySet<CategorisedItem>(new Action<CategorisedItem>(this.attach_CategorisedItems), new Action<CategorisedItem>(this.detach_CategorisedItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Category", Storage="_Category1", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Category1
		{
			get
			{
				return this._Category1;
			}
			set
			{
				if ((this._Category1 != value))
				{
					this.OnCategory1Changing(value);
					this.SendPropertyChanging();
					this._Category1 = value;
					this.SendPropertyChanged("Category1");
					this.OnCategory1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_CategorisedItem", Storage="_CategorisedItems", ThisKey="CategoryID", OtherKey="CategoryID")]
		public EntitySet<CategorisedItem> CategorisedItems
		{
			get
			{
				return this._CategorisedItems;
			}
			set
			{
				this._CategorisedItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CategorisedItems(CategorisedItem entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_CategorisedItems(CategorisedItem entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MenuItems")]
	public partial class MenuItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ItemId;
		
		private string _FoodName;
		
		private System.Nullable<decimal> _Price1;
		
		private System.Nullable<decimal> _Price2;
		
		private string _ChineseName;
		
		private System.Nullable<int> _ItemCount;
		
		private string _MenuID;
		
		private string _ShortName;
		
		private int _CategoryID;
		
		private string _Description;
		
		private EntitySet<CategorisedItem> _CategorisedItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnItemIdChanging(int value);
    partial void OnItemIdChanged();
    partial void OnFoodNameChanging(string value);
    partial void OnFoodNameChanged();
    partial void OnPrice1Changing(System.Nullable<decimal> value);
    partial void OnPrice1Changed();
    partial void OnPrice2Changing(System.Nullable<decimal> value);
    partial void OnPrice2Changed();
    partial void OnChineseNameChanging(string value);
    partial void OnChineseNameChanged();
    partial void OnItemCountChanging(System.Nullable<int> value);
    partial void OnItemCountChanged();
    partial void OnMenuIDChanging(string value);
    partial void OnMenuIDChanged();
    partial void OnShortNameChanging(string value);
    partial void OnShortNameChanged();
    partial void OnCategoryIDChanging(int value);
    partial void OnCategoryIDChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public MenuItem()
		{
			this._CategorisedItems = new EntitySet<CategorisedItem>(new Action<CategorisedItem>(this.attach_CategorisedItems), new Action<CategorisedItem>(this.detach_CategorisedItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ItemId
		{
			get
			{
				return this._ItemId;
			}
			set
			{
				if ((this._ItemId != value))
				{
					this.OnItemIdChanging(value);
					this.SendPropertyChanging();
					this._ItemId = value;
					this.SendPropertyChanged("ItemId");
					this.OnItemIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FoodName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string FoodName
		{
			get
			{
				return this._FoodName;
			}
			set
			{
				if ((this._FoodName != value))
				{
					this.OnFoodNameChanging(value);
					this.SendPropertyChanging();
					this._FoodName = value;
					this.SendPropertyChanged("FoodName");
					this.OnFoodNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price1", DbType="Money")]
		public System.Nullable<decimal> Price1
		{
			get
			{
				return this._Price1;
			}
			set
			{
				if ((this._Price1 != value))
				{
					this.OnPrice1Changing(value);
					this.SendPropertyChanging();
					this._Price1 = value;
					this.SendPropertyChanged("Price1");
					this.OnPrice1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price2", DbType="Money")]
		public System.Nullable<decimal> Price2
		{
			get
			{
				return this._Price2;
			}
			set
			{
				if ((this._Price2 != value))
				{
					this.OnPrice2Changing(value);
					this.SendPropertyChanging();
					this._Price2 = value;
					this.SendPropertyChanged("Price2");
					this.OnPrice2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChineseName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ChineseName
		{
			get
			{
				return this._ChineseName;
			}
			set
			{
				if ((this._ChineseName != value))
				{
					this.OnChineseNameChanging(value);
					this.SendPropertyChanging();
					this._ChineseName = value;
					this.SendPropertyChanged("ChineseName");
					this.OnChineseNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemCount", DbType="Int")]
		public System.Nullable<int> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
			set
			{
				if ((this._ItemCount != value))
				{
					this.OnItemCountChanging(value);
					this.SendPropertyChanging();
					this._ItemCount = value;
					this.SendPropertyChanged("ItemCount");
					this.OnItemCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuID", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string MenuID
		{
			get
			{
				return this._MenuID;
			}
			set
			{
				if ((this._MenuID != value))
				{
					this.OnMenuIDChanging(value);
					this.SendPropertyChanging();
					this._MenuID = value;
					this.SendPropertyChanged("MenuID");
					this.OnMenuIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ShortName
		{
			get
			{
				return this._ShortName;
			}
			set
			{
				if ((this._ShortName != value))
				{
					this.OnShortNameChanging(value);
					this.SendPropertyChanging();
					this._ShortName = value;
					this.SendPropertyChanged("ShortName");
					this.OnShortNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="Int NOT NULL")]
		public int CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MenuItem_CategorisedItem", Storage="_CategorisedItems", ThisKey="ItemId", OtherKey="ItemId")]
		public EntitySet<CategorisedItem> CategorisedItems
		{
			get
			{
				return this._CategorisedItems;
			}
			set
			{
				this._CategorisedItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CategorisedItems(CategorisedItem entity)
		{
			this.SendPropertyChanging();
			entity.MenuItem = this;
		}
		
		private void detach_CategorisedItems(CategorisedItem entity)
		{
			this.SendPropertyChanging();
			entity.MenuItem = null;
		}
	}
	
	public partial class GetFoodItemsResult
	{
		
		private int _ItemId;
		
		private string _FoodName;
		
		private System.Nullable<decimal> _Price1;
		
		private System.Nullable<decimal> _Price2;
		
		private string _ChineseName;
		
		private System.Nullable<int> _ItemCount;
		
		private string _MenuID;
		
		private string _ShortName;
		
		private int _CategoryID;
		
		private string _Description;
		
		public GetFoodItemsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemId", DbType="Int NOT NULL")]
		public int ItemId
		{
			get
			{
				return this._ItemId;
			}
			set
			{
				if ((this._ItemId != value))
				{
					this._ItemId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FoodName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string FoodName
		{
			get
			{
				return this._FoodName;
			}
			set
			{
				if ((this._FoodName != value))
				{
					this._FoodName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price1", DbType="Money")]
		public System.Nullable<decimal> Price1
		{
			get
			{
				return this._Price1;
			}
			set
			{
				if ((this._Price1 != value))
				{
					this._Price1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price2", DbType="Money")]
		public System.Nullable<decimal> Price2
		{
			get
			{
				return this._Price2;
			}
			set
			{
				if ((this._Price2 != value))
				{
					this._Price2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChineseName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ChineseName
		{
			get
			{
				return this._ChineseName;
			}
			set
			{
				if ((this._ChineseName != value))
				{
					this._ChineseName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemCount", DbType="Int")]
		public System.Nullable<int> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
			set
			{
				if ((this._ItemCount != value))
				{
					this._ItemCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MenuID", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string MenuID
		{
			get
			{
				return this._MenuID;
			}
			set
			{
				if ((this._MenuID != value))
				{
					this._MenuID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ShortName
		{
			get
			{
				return this._ShortName;
			}
			set
			{
				if ((this._ShortName != value))
				{
					this._ShortName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="Int NOT NULL")]
		public int CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this._CategoryID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
