/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:03 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using HealthStop.Business.Framework;


namespace HealthStop.Business
{
	/// <summary>
	/// This object represents the properties and methods of a PurchaseOrderItem.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("purchaseorder_id: {purchaseorder_id}, product_code: {product_code}")]
	public partial class PurchaseOrderItem
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _purchaseorder_id = int.MinValue;
		/// <summary>
		/// purchaseorder_id
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int purchaseorder_id
		{
			[DebuggerStepThrough()]
			get { return this._purchaseorder_id; }
			set 
			{
				if (this._purchaseorder_id != value) 
				{
					this._purchaseorder_id = value;
					this.IsDirty = true;	
					OnPropertyChanged("purchaseorder_id");
					this._purchaseorder_ = null;
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _product_code = String.Empty;
		/// <summary>
		/// product_code
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public string product_code
		{
			[DebuggerStepThrough()]
			get { return this._product_code; }
			set 
			{
				if (this._product_code != value) 
				{
					this._product_code = value;
					this.IsDirty = true;	
					OnPropertyChanged("product_code");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _barcode = String.Empty;
		/// <summary>
		/// barcode
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string barcode
		{
			[DebuggerStepThrough()]
			get { return this._barcode; }
			set 
			{
				if (this._barcode != value) 
				{
					this._barcode = value;
					this.IsDirty = true;	
					OnPropertyChanged("barcode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// description
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _quantity;
		/// <summary>
		/// quantity
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public double quantity
		{
			[DebuggerStepThrough()]
			get { return this._quantity; }
			set 
			{
				if (this._quantity != value) 
				{
					this._quantity = value;
					this.IsDirty = true;	
					OnPropertyChanged("quantity");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _cost_price = decimal.MinValue;
		/// <summary>
		/// cost_price
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal cost_price
		{
			[DebuggerStepThrough()]
			get { return this._cost_price; }
			set 
			{
				if (this._cost_price != value) 
				{
					this._cost_price = value;
					this.IsDirty = true;	
					OnPropertyChanged("cost_price");
				}
			}
		}
		
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PurchaseOrder _purchaseorder_ = null;
		/// <summary>
		/// The parent PurchaseOrder object
		/// </summary>
		public PurchaseOrder purchaseorder_
		{
			get 
			{
				if (_purchaseorder_ == null) 
				{
					_purchaseorder_ = GetParentEntity(PurchaseOrder.GetPurchaseOrder(this.purchaseorder_id)) as PurchaseOrder;
				}
				return _purchaseorder_;
			}
			set
			{
				if(_purchaseorder_ != value) 
				{
					_purchaseorder_ = value;
					
					if (value != null) 
					{
						this.purchaseorder_id = value.purchaseorder_id;
					}
					else 
					{
						this.purchaseorder_id = int.MinValue;
					}
				}
			}
		}
		
		
		#endregion
		
		#region Non-Public Properties
		/// <summary>
		/// Gets the SQL statement for an insert
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string InsertSPName
		{
			get 
			{
				return typeof(PurchaseOrderItem).Name + "Insert";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for an update by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string UpdateSPName
		{
			get
			{
				return typeof(PurchaseOrderItem).Name + "Update";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for a delete by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string DeleteSPName
		{
			get
			{
				return typeof(PurchaseOrderItem).Name + "Delete";
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		protected PurchaseOrderItem() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPurchaseOrderItem(this.purchaseorder_id, this.product_code));
		}

		#endregion
		
		#region Non-Public Methods
		/// <summary>
		/// This is called before an entity is saved to ensure that any parent entities keys are set properly
		/// </summary>
		protected override void EnsureParentProperties()
		{
			if (_purchaseorder_ != null)
			{	
				this.purchaseorder_id = this.purchaseorder_.purchaseorder_id;
			}
			
		}
		#endregion
		
		#region Static Properties
		/// <summary>
		/// A list of all fields for this entity in the database. It does not include the 
		/// select keyword, or the table information - just the fields. This can be used
		/// for new dynamic methods.
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static string SelectFieldList 
		{
			get 
			{
				return @"
	[PurchaseOrderItems].[purchaseorder_id],
	[PurchaseOrderItems].[product_code],
	[PurchaseOrderItems].[barcode],
	[PurchaseOrderItems].[description],
	[PurchaseOrderItems].[quantity],
	[PurchaseOrderItems].[cost_price]
";
			}
		}
		
		
		/// <summary>
        /// Table Name
        /// </summary>
        public new static string TableName
        {
            get
            {
                return "PurchaseOrderItems";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PurchaseOrderItem into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="description">description</param>
		/// <param name="quantity">quantity</param>
		/// <param name="cost_price">cost_price</param>
		public static void InsertPurchaseOrderItem(int @purchaseorder_id, string @product_code, string @barcode, string @description, double @quantity, decimal @cost_price)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPurchaseOrderItem(@purchaseorder_id, @product_code, @barcode, @description, @quantity, @cost_price, helper);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
		}

		/// <summary>
		/// Insert a PurchaseOrderItem into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="description">description</param>
		/// <param name="quantity">quantity</param>
		/// <param name="cost_price">cost_price</param>
		/// <param name="helper">helper</param>
		internal static void InsertPurchaseOrderItem(int @purchaseorder_id, string @product_code, string @barcode, string @description, double @quantity, decimal @cost_price, SqlHelper @helper)
		{
			string commandText = "PurchaseOrderItemInsert";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", EntityBase.GetDatabaseValue(@purchaseorder_id)));
			parameters.Add(new SqlParameter("@product_code", EntityBase.GetDatabaseValue(@product_code)));
			parameters.Add(new SqlParameter("@barcode", EntityBase.GetDatabaseValue(@barcode)));
			parameters.Add(new SqlParameter("@description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@quantity", @quantity));
			parameters.Add(new SqlParameter("@cost_price", EntityBase.GetDatabaseValue(@cost_price)));
			
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Updates a PurchaseOrderItem into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="description">description</param>
		/// <param name="quantity">quantity</param>
		/// <param name="cost_price">cost_price</param>
		public static void UpdatePurchaseOrderItem(int @purchaseorder_id, string @product_code, string @barcode, string @description, double @quantity, decimal @cost_price)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePurchaseOrderItem(@purchaseorder_id, @product_code, @barcode, @description, @quantity, @cost_price, helper);
					helper.Commit();
				}
				catch 
				{
					helper.Rollback();	
					throw;
				}
			}
		}
		
		/// <summary>
		/// Updates a PurchaseOrderItem into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="description">description</param>
		/// <param name="quantity">quantity</param>
		/// <param name="cost_price">cost_price</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePurchaseOrderItem(int @purchaseorder_id, string @product_code, string @barcode, string @description, double @quantity, decimal @cost_price, SqlHelper @helper)
		{
			string commandText = "PurchaseOrderItemUpdate";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", EntityBase.GetDatabaseValue(@purchaseorder_id)));
			parameters.Add(new SqlParameter("@product_code", EntityBase.GetDatabaseValue(@product_code)));
			parameters.Add(new SqlParameter("@barcode", EntityBase.GetDatabaseValue(@barcode)));
			parameters.Add(new SqlParameter("@description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@quantity", @quantity));
			parameters.Add(new SqlParameter("@cost_price", EntityBase.GetDatabaseValue(@cost_price)));
			
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Deletes a PurchaseOrderItem from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		public static void DeletePurchaseOrderItem(int @purchaseorder_id, string @product_code)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePurchaseOrderItem(@purchaseorder_id, @product_code, helper);
					helper.Commit();
				} 
				catch 
				{
					helper.Rollback();
					throw;
				}
			}
		}
		
		/// <summary>
		/// Deletes a PurchaseOrderItem from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="helper">helper</param>
		internal static void DeletePurchaseOrderItem(int @purchaseorder_id, string @product_code, SqlHelper @helper)
		{
			string commandText = "PurchaseOrderItemDelete";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_id));
			parameters.Add(new SqlParameter("@product_code", @product_code));
		
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Creates a new PurchaseOrderItem object.
		/// </summary>
		/// <returns>The newly created PurchaseOrderItem object.</returns>
		public static PurchaseOrderItem CreatePurchaseOrderItem()
		{
			return InitializeNew<PurchaseOrderItem>();
		}
		
		/// <summary>
		/// Retrieve information for a PurchaseOrderItem by a PurchaseOrderItem's unique identifier.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <param name="product_code">product_code</param>
		/// <returns>PurchaseOrderItem</returns>
		public static PurchaseOrderItem GetPurchaseOrderItem(int purchaseorder_id, string product_code)
		{
			string commandText = "PurchaseOrderItemGet";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", purchaseorder_id));
			parameters.Add(new SqlParameter("@product_code", product_code));
			
			return GetOne<PurchaseOrderItem>(commandText, parameters);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects.
		/// </summary>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		public static EntityList<PurchaseOrderItem> GetPurchaseOrderItems()
		{
			string commandText = "PurchaseOrderItemGetAll";
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PurchaseOrderItem>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PurchaseOrderItem objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
        protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PurchaseOrderItem>(SelectFieldList, "FROM [dbo].[PurchaseOrderItems]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PurchaseOrderItem objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
        public static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PurchaseOrderItem>(SelectFieldList, "FROM [dbo].[PurchaseOrderItems]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPurchaseOrderItems(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPurchaseOrderItems(string.Empty, where, parameters, PurchaseOrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPurchaseOrderItems(prefix, where, parameters, PurchaseOrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPurchaseOrderItems(string.Empty, where, parameters, PurchaseOrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPurchaseOrderItems(prefix, where, parameters, PurchaseOrderItem.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PurchaseOrderItem objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PurchaseOrderItem.SelectFieldList + "FROM [dbo].[PurchaseOrderItems] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PurchaseOrderItem>(reader);
				}
			}
		}		
		
		/// <summary>
        /// Gets a collection Address objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="where">where</param>
		/// <param name=parameters">parameters</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Address objects.</returns>
        protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItems(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PurchaseOrderItem>(SelectFieldList, "FROM [dbo].[PurchaseOrderItems] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		/// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseorder_">purchaseorder_</param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		public static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(PurchaseOrder @purchaseorder_) 
		{
			string commandText = "PurchaseOrderItemGetByPurchaseOrder";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_.purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(@purchaseorder_, commandText, parameters);
		}
  

		/// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseOrder">purchaseOrder</param>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(PurchaseOrder @purchaseorder_, string orderBy, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[PurchaseOrderItems] 
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
				
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_.purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(SelectFieldList, commandText, parameters, orderBy, startRowIndex, pageSize, out totalRows);
		}

	    /// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		protected static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(int @purchaseorder_id, string orderBy, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[PurchaseOrderItems] 
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(SelectFieldList, commandText, parameters, orderBy, startRowIndex, pageSize, out totalRows);
		}		
		
		
		/// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseOrder">purchaseOrder</param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		public static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(PurchaseOrder @purchaseorder_, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[PurchaseOrderItems] 
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
				
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_.purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(SelectFieldList, commandText, parameters, null, startRowIndex, pageSize, out totalRows);
		}

	    /// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		public static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(int @purchaseorder_id, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[PurchaseOrderItems] 
WHERE 
	[PurchaseOrderItems].[purchaseorder_id] = @purchaseorder_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(SelectFieldList, commandText, parameters, null, startRowIndex, pageSize, out totalRows);
		}
		
	
		/// <summary>
		/// Gets a collection of PurchaseOrderItem objects by a PurchaseOrder unique identifier.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		/// <returns>A collection PurchaseOrderItem objects.</returns>
		public static EntityList<PurchaseOrderItem> GetPurchaseOrderItemsBypurchaseorder_(int @purchaseorder_id) 
		{
			string commandText = "PurchaseOrderItemGetByPurchaseOrder";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", @purchaseorder_id));
			
			return GetList<PurchaseOrderItem>(commandText, parameters);
		}

		/// <summary>
		/// Create a new PurchaseOrderItem object from a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseorder_">purchaseorder_</param>
		/// <returns>The newly created PurchaseOrderItem object.</returns>
		public static PurchaseOrderItem CreatePurchaseOrderItemBypurchaseorder_(PurchaseOrder @purchaseorder_)
		{
			PurchaseOrderItem purchaseOrderItem = InitializeNew<PurchaseOrderItem>();
			
			purchaseOrderItem.purchaseorder_id = @purchaseorder_.purchaseorder_id;
			
			purchaseOrderItem.purchaseorder_ = @purchaseorder_;
			
			return purchaseOrderItem;
		}
		
		/// <summary>
		/// Deletes PurchaseOrderItem objects by a PurchaseOrder object.
		/// </summary>
		/// <param name="purchaseOrder">purchaseOrder</param>
		public static void DeletePurchaseOrderItemsBypurchaseorder_(PurchaseOrder purchaseOrder) 
		{
			string commandText = "PurchaseOrderItemDeleteByPurchaseOrder";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", purchaseOrder.purchaseorder_id));
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				helper.Execute(commandText, CommandType.StoredProcedure, parameters);
			}
		}
		
		/// <summary>
		/// Deletes PurchaseOrderItem objects by a PurchaseOrder unique identifier.
		/// </summary>
		/// <param name="purchaseorder_id">purchaseorder_id</param>
		public static void DeletePurchaseOrderItemsBypurchaseorder_(int purchaseorder_id) 
		{
			string commandText = "PurchaseOrderItemDeleteByPurchaseOrder";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@purchaseorder_id", purchaseorder_id));
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				helper.Execute(commandText, CommandType.StoredProcedure, parameters);
			}
		}
		#endregion
		
		#region Subclasses
		public static partial class PurchaseOrderItemProperties
		{
			public const string purchaseorder_id = "purchaseorder_id";
			public const string product_code = "product_code";
			public const string barcode = "barcode";
			public const string description = "description";
			public const string quantity = "quantity";
			public const string cost_price = "cost_price";
		}
		#endregion
	}
}
