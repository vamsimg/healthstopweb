/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:49:01 PM.

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
	/// This object represents the properties and methods of a ManufacturerProduct.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("company_id: {company_id}, product_code: {product_code}")]
	public partial class ManufacturerProduct
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _company_id = int.MinValue;
		/// <summary>
		/// company_id
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int company_id
		{
			[DebuggerStepThrough()]
			get { return this._company_id; }
			set 
			{
				if (this._company_id != value) 
				{
					this._company_id = value;
					this.IsDirty = true;	
					OnPropertyChanged("company_id");
					this._company_ = null;
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
		private string _department = String.Empty;
		/// <summary>
		/// department
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string department
		{
			[DebuggerStepThrough()]
			get { return this._department; }
			set 
			{
				if (this._department != value) 
				{
					this._department = value;
					this.IsDirty = true;	
					OnPropertyChanged("department");
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
		[DataObjectField(false, false, true)]
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
		private string _picture_url = String.Empty;
		/// <summary>
		/// picture_url
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string picture_url
		{
			[DebuggerStepThrough()]
			get { return this._picture_url; }
			set 
			{
				if (this._picture_url != value) 
				{
					this._picture_url = value;
					this.IsDirty = true;	
					OnPropertyChanged("picture_url");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _info_url = String.Empty;
		/// <summary>
		/// info_url
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string info_url
		{
			[DebuggerStepThrough()]
			get { return this._info_url; }
			set 
			{
				if (this._info_url != value) 
				{
					this._info_url = value;
					this.IsDirty = true;	
					OnPropertyChanged("info_url");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastupdated_datetime = DateTime.MinValue;
		/// <summary>
		/// lastupdated_datetime
		/// </summary>
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime lastupdated_datetime
		{
			[DebuggerStepThrough()]
			get { return this._lastupdated_datetime; }
			set 
			{
				if (this._lastupdated_datetime != value) 
				{
					this._lastupdated_datetime = value;
					this.IsDirty = true;	
					OnPropertyChanged("lastupdated_datetime");
				}
			}
		}
		
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Company _company_ = null;
		/// <summary>
		/// The parent Company object
		/// </summary>
		public Company company_
		{
			get 
			{
				if (_company_ == null) 
				{
					_company_ = GetParentEntity(Company.GetCompany(this.company_id)) as Company;
				}
				return _company_;
			}
			set
			{
				if(_company_ != value) 
				{
					_company_ = value;
					
					if (value != null) 
					{
						this.company_id = value.company_id;
					}
					else 
					{
						this.company_id = int.MinValue;
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
				return typeof(ManufacturerProduct).Name + "Insert";
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
				return typeof(ManufacturerProduct).Name + "Update";
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
				return typeof(ManufacturerProduct).Name + "Delete";
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		protected ManufacturerProduct() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetManufacturerProduct(this.company_id, this.product_code));
		}

		#endregion
		
		#region Non-Public Methods
		/// <summary>
		/// This is called before an entity is saved to ensure that any parent entities keys are set properly
		/// </summary>
		protected override void EnsureParentProperties()
		{
			if (_company_ != null)
			{	
				this.company_id = this.company_.company_id;
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
	[ManufacturerProducts].[company_id],
	[ManufacturerProducts].[product_code],
	[ManufacturerProducts].[barcode],
	[ManufacturerProducts].[department],
	[ManufacturerProducts].[description],
	[ManufacturerProducts].[picture_url],
	[ManufacturerProducts].[info_url],
	[ManufacturerProducts].[lastupdated_datetime]
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
                return "ManufacturerProducts";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ManufacturerProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="department">department</param>
		/// <param name="description">description</param>
		/// <param name="picture_url">picture_url</param>
		/// <param name="info_url">info_url</param>
		/// <param name="lastupdated_datetime">lastupdated_datetime</param>
		public static void InsertManufacturerProduct(int @company_id, string @product_code, string @barcode, string @department, string @description, string @picture_url, string @info_url, DateTime @lastupdated_datetime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertManufacturerProduct(@company_id, @product_code, @barcode, @department, @description, @picture_url, @info_url, @lastupdated_datetime, helper);
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
		/// Insert a ManufacturerProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="department">department</param>
		/// <param name="description">description</param>
		/// <param name="picture_url">picture_url</param>
		/// <param name="info_url">info_url</param>
		/// <param name="lastupdated_datetime">lastupdated_datetime</param>
		/// <param name="helper">helper</param>
		internal static void InsertManufacturerProduct(int @company_id, string @product_code, string @barcode, string @department, string @description, string @picture_url, string @info_url, DateTime @lastupdated_datetime, SqlHelper @helper)
		{
			string commandText = "ManufacturerProductInsert";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", EntityBase.GetDatabaseValue(@company_id)));
			parameters.Add(new SqlParameter("@product_code", EntityBase.GetDatabaseValue(@product_code)));
			parameters.Add(new SqlParameter("@barcode", EntityBase.GetDatabaseValue(@barcode)));
			parameters.Add(new SqlParameter("@department", EntityBase.GetDatabaseValue(@department)));
			parameters.Add(new SqlParameter("@description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@picture_url", EntityBase.GetDatabaseValue(@picture_url)));
			parameters.Add(new SqlParameter("@info_url", EntityBase.GetDatabaseValue(@info_url)));
			parameters.Add(new SqlParameter("@lastupdated_datetime", EntityBase.GetDatabaseValue(@lastupdated_datetime)));
			
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Updates a ManufacturerProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="department">department</param>
		/// <param name="description">description</param>
		/// <param name="picture_url">picture_url</param>
		/// <param name="info_url">info_url</param>
		/// <param name="lastupdated_datetime">lastupdated_datetime</param>
		public static void UpdateManufacturerProduct(int @company_id, string @product_code, string @barcode, string @department, string @description, string @picture_url, string @info_url, DateTime @lastupdated_datetime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateManufacturerProduct(@company_id, @product_code, @barcode, @department, @description, @picture_url, @info_url, @lastupdated_datetime, helper);
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
		/// Updates a ManufacturerProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="barcode">barcode</param>
		/// <param name="department">department</param>
		/// <param name="description">description</param>
		/// <param name="picture_url">picture_url</param>
		/// <param name="info_url">info_url</param>
		/// <param name="lastupdated_datetime">lastupdated_datetime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateManufacturerProduct(int @company_id, string @product_code, string @barcode, string @department, string @description, string @picture_url, string @info_url, DateTime @lastupdated_datetime, SqlHelper @helper)
		{
			string commandText = "ManufacturerProductUpdate";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", EntityBase.GetDatabaseValue(@company_id)));
			parameters.Add(new SqlParameter("@product_code", EntityBase.GetDatabaseValue(@product_code)));
			parameters.Add(new SqlParameter("@barcode", EntityBase.GetDatabaseValue(@barcode)));
			parameters.Add(new SqlParameter("@department", EntityBase.GetDatabaseValue(@department)));
			parameters.Add(new SqlParameter("@description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@picture_url", EntityBase.GetDatabaseValue(@picture_url)));
			parameters.Add(new SqlParameter("@info_url", EntityBase.GetDatabaseValue(@info_url)));
			parameters.Add(new SqlParameter("@lastupdated_datetime", EntityBase.GetDatabaseValue(@lastupdated_datetime)));
			
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Deletes a ManufacturerProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		public static void DeleteManufacturerProduct(int @company_id, string @product_code)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteManufacturerProduct(@company_id, @product_code, helper);
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
		/// Deletes a ManufacturerProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <param name="helper">helper</param>
		internal static void DeleteManufacturerProduct(int @company_id, string @product_code, SqlHelper @helper)
		{
			string commandText = "ManufacturerProductDelete";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", @company_id));
			parameters.Add(new SqlParameter("@product_code", @product_code));
		
			@helper.Execute(commandText, CommandType.StoredProcedure, parameters);
		}
		
		/// <summary>
		/// Creates a new ManufacturerProduct object.
		/// </summary>
		/// <returns>The newly created ManufacturerProduct object.</returns>
		public static ManufacturerProduct CreateManufacturerProduct()
		{
			return InitializeNew<ManufacturerProduct>();
		}
		
		/// <summary>
		/// Retrieve information for a ManufacturerProduct by a ManufacturerProduct's unique identifier.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <param name="product_code">product_code</param>
		/// <returns>ManufacturerProduct</returns>
		public static ManufacturerProduct GetManufacturerProduct(int company_id, string product_code)
		{
			string commandText = "ManufacturerProductGet";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", company_id));
			parameters.Add(new SqlParameter("@product_code", product_code));
			
			return GetOne<ManufacturerProduct>(commandText, parameters);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects.
		/// </summary>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		public static EntityList<ManufacturerProduct> GetManufacturerProducts()
		{
			string commandText = "ManufacturerProductGetAll";
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ManufacturerProduct>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ManufacturerProduct objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
        protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ManufacturerProduct>(SelectFieldList, "FROM [dbo].[ManufacturerProducts]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ManufacturerProduct objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
        public static EntityList<ManufacturerProduct> GetManufacturerProducts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ManufacturerProduct>(SelectFieldList, "FROM [dbo].[ManufacturerProducts]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetManufacturerProducts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetManufacturerProducts(string.Empty, where, parameters, ManufacturerProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetManufacturerProducts(prefix, where, parameters, ManufacturerProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetManufacturerProducts(string.Empty, where, parameters, ManufacturerProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetManufacturerProducts(prefix, where, parameters, ManufacturerProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ManufacturerProduct objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ManufacturerProduct.SelectFieldList + "FROM [dbo].[ManufacturerProducts] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ManufacturerProduct>(reader);
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
        protected static EntityList<ManufacturerProduct> GetManufacturerProducts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ManufacturerProduct>(SelectFieldList, "FROM [dbo].[ManufacturerProducts] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		/// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company_">company_</param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		public static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(Company @company_) 
		{
			string commandText = "ManufacturerProductGetByCompany";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", @company_.company_id));
			
			return GetList<ManufacturerProduct>(@company_, commandText, parameters);
		}
  

		/// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company">company</param>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(Company @company_, string orderBy, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[ManufacturerProducts] 
WHERE 
	[ManufacturerProducts].[company_id] = @company_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
				
			parameters.Add(new SqlParameter("@company_id", @company_.company_id));
			
			return GetList<ManufacturerProduct>(SelectFieldList, commandText, parameters, orderBy, startRowIndex, pageSize, out totalRows);
		}

	    /// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company_id">company_id</param>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		protected static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(int @company_id, string orderBy, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[ManufacturerProducts] 
WHERE 
	[ManufacturerProducts].[company_id] = @company_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", @company_id));
			
			return GetList<ManufacturerProduct>(SelectFieldList, commandText, parameters, orderBy, startRowIndex, pageSize, out totalRows);
		}		
		
		
		/// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company">company</param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		public static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(Company @company_, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[ManufacturerProducts] 
WHERE 
	[ManufacturerProducts].[company_id] = @company_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
				
			parameters.Add(new SqlParameter("@company_id", @company_.company_id));
			
			return GetList<ManufacturerProduct>(SelectFieldList, commandText, parameters, null, startRowIndex, pageSize, out totalRows);
		}

	    /// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company_id">company_id</param>
        /// <param name="startRowIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		public static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(int @company_id, long startRowIndex, int pageSize, out long totalRows) 
		{
			string commandText = @"
FROM 
	[dbo].[ManufacturerProducts] 
WHERE 
	[ManufacturerProducts].[company_id] = @company_id ";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", @company_id));
			
			return GetList<ManufacturerProduct>(SelectFieldList, commandText, parameters, null, startRowIndex, pageSize, out totalRows);
		}
		
	
		/// <summary>
		/// Gets a collection of ManufacturerProduct objects by a Company unique identifier.
		/// </summary>
		/// <param name="company_id">company_id</param>
		/// <returns>A collection ManufacturerProduct objects.</returns>
		public static EntityList<ManufacturerProduct> GetManufacturerProductsBycompany_(int @company_id) 
		{
			string commandText = "ManufacturerProductGetByCompany";
			
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", @company_id));
			
			return GetList<ManufacturerProduct>(commandText, parameters);
		}

		/// <summary>
		/// Create a new ManufacturerProduct object from a Company object.
		/// </summary>
		/// <param name="company_">company_</param>
		/// <returns>The newly created ManufacturerProduct object.</returns>
		public static ManufacturerProduct CreateManufacturerProductBycompany_(Company @company_)
		{
			ManufacturerProduct manufacturerProduct = InitializeNew<ManufacturerProduct>();
			
			manufacturerProduct.company_id = @company_.company_id;
			
			manufacturerProduct.company_ = @company_;
			
			return manufacturerProduct;
		}
		
		/// <summary>
		/// Deletes ManufacturerProduct objects by a Company object.
		/// </summary>
		/// <param name="company">company</param>
		public static void DeleteManufacturerProductsBycompany_(Company company) 
		{
			string commandText = "ManufacturerProductDeleteByCompany";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", company.company_id));
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				helper.Execute(commandText, CommandType.StoredProcedure, parameters);
			}
		}
		
		/// <summary>
		/// Deletes ManufacturerProduct objects by a Company unique identifier.
		/// </summary>
		/// <param name="company_id">company_id</param>
		public static void DeleteManufacturerProductsBycompany_(int company_id) 
		{
			string commandText = "ManufacturerProductDeleteByCompany";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@company_id", company_id));
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				helper.Execute(commandText, CommandType.StoredProcedure, parameters);
			}
		}
		#endregion
		
		#region Subclasses
		public static partial class ManufacturerProductProperties
		{
			public const string company_id = "company_id";
			public const string product_code = "product_code";
			public const string barcode = "barcode";
			public const string department = "department";
			public const string description = "description";
			public const string picture_url = "picture_url";
			public const string info_url = "info_url";
			public const string lastupdated_datetime = "lastupdated_datetime";
		}
		#endregion
	}
}
