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

namespace WebAPI.DATA.Hr_Register
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HR-Register")]
	public partial class Hr_RegisterDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSTEP_ONE(STEP_ONE instance);
    partial void UpdateSTEP_ONE(STEP_ONE instance);
    partial void DeleteSTEP_ONE(STEP_ONE instance);
    #endregion
		
		public Hr_RegisterDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HR_RegisterConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Hr_RegisterDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Hr_RegisterDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Hr_RegisterDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Hr_RegisterDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<STEP_ONE> STEP_ONEs
		{
			get
			{
				return this.GetTable<STEP_ONE>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.STEP_ONE")]
	public partial class STEP_ONE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _USERNO;
		
		private string _POSITION;
		
		private string _FULLNAME_TH;
		
		private string _NICKNAME_TH;
		
		private string _FULLNAME_EN;
		
		private string _NICKNAME_EN;
		
		private string _PEOPLEID;
		
		private string _ZONE;
		
		private string _PROVINCE_BIRTH;
		
		private System.Nullable<System.DateTime> _BIRTHDATE;
		
		private System.Nullable<int> _AGE;
		
		private System.Nullable<int> _WEIGHT;
		
		private System.Nullable<int> _HEIGHT;
		
		private string _ADDR_ROW1;
		
		private string _ADDR_ROW2;
		
		private string _ADDR_ROW3;
		
		private string _ADDR_HOME1;
		
		private string _ADDR_HOME2;
		
		private string _ADDR_HOME3;
		
		private string _ADDR_TEL;
		
		private string _ADDR_MOBILE;
		
		private string _ADDR_EMAIL;
		
		private string _ADDR_PHOTO;
		
		private System.Nullable<System.DateTime> _WORKDATE;
		
		private System.Nullable<int> _FLAG;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUSERNOChanging(string value);
    partial void OnUSERNOChanged();
    partial void OnPOSITIONChanging(string value);
    partial void OnPOSITIONChanged();
    partial void OnFULLNAME_THChanging(string value);
    partial void OnFULLNAME_THChanged();
    partial void OnNICKNAME_THChanging(string value);
    partial void OnNICKNAME_THChanged();
    partial void OnFULLNAME_ENChanging(string value);
    partial void OnFULLNAME_ENChanged();
    partial void OnNICKNAME_ENChanging(string value);
    partial void OnNICKNAME_ENChanged();
    partial void OnPEOPLEIDChanging(string value);
    partial void OnPEOPLEIDChanged();
    partial void OnZONEChanging(string value);
    partial void OnZONEChanged();
    partial void OnPROVINCE_BIRTHChanging(string value);
    partial void OnPROVINCE_BIRTHChanged();
    partial void OnBIRTHDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnBIRTHDATEChanged();
    partial void OnAGEChanging(System.Nullable<int> value);
    partial void OnAGEChanged();
    partial void OnWEIGHTChanging(System.Nullable<int> value);
    partial void OnWEIGHTChanged();
    partial void OnHEIGHTChanging(System.Nullable<int> value);
    partial void OnHEIGHTChanged();
    partial void OnADDR_ROW1Changing(string value);
    partial void OnADDR_ROW1Changed();
    partial void OnADDR_ROW2Changing(string value);
    partial void OnADDR_ROW2Changed();
    partial void OnADDR_ROW3Changing(string value);
    partial void OnADDR_ROW3Changed();
    partial void OnADDR_HOME1Changing(string value);
    partial void OnADDR_HOME1Changed();
    partial void OnADDR_HOME2Changing(string value);
    partial void OnADDR_HOME2Changed();
    partial void OnADDR_HOME3Changing(string value);
    partial void OnADDR_HOME3Changed();
    partial void OnADDR_TELChanging(string value);
    partial void OnADDR_TELChanged();
    partial void OnADDR_MOBILEChanging(string value);
    partial void OnADDR_MOBILEChanged();
    partial void OnADDR_EMAILChanging(string value);
    partial void OnADDR_EMAILChanged();
    partial void OnADDR_PHOTOChanging(string value);
    partial void OnADDR_PHOTOChanged();
    partial void OnWORKDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnWORKDATEChanged();
    partial void OnFLAGChanging(System.Nullable<int> value);
    partial void OnFLAGChanged();
    #endregion
		
		public STEP_ONE()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USERNO", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string USERNO
		{
			get
			{
				return this._USERNO;
			}
			set
			{
				if ((this._USERNO != value))
				{
					this.OnUSERNOChanging(value);
					this.SendPropertyChanging();
					this._USERNO = value;
					this.SendPropertyChanged("USERNO");
					this.OnUSERNOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POSITION", DbType="VarChar(100)")]
		public string POSITION
		{
			get
			{
				return this._POSITION;
			}
			set
			{
				if ((this._POSITION != value))
				{
					this.OnPOSITIONChanging(value);
					this.SendPropertyChanging();
					this._POSITION = value;
					this.SendPropertyChanged("POSITION");
					this.OnPOSITIONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULLNAME_TH", DbType="VarChar(100)")]
		public string FULLNAME_TH
		{
			get
			{
				return this._FULLNAME_TH;
			}
			set
			{
				if ((this._FULLNAME_TH != value))
				{
					this.OnFULLNAME_THChanging(value);
					this.SendPropertyChanging();
					this._FULLNAME_TH = value;
					this.SendPropertyChanged("FULLNAME_TH");
					this.OnFULLNAME_THChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NICKNAME_TH", DbType="VarChar(50)")]
		public string NICKNAME_TH
		{
			get
			{
				return this._NICKNAME_TH;
			}
			set
			{
				if ((this._NICKNAME_TH != value))
				{
					this.OnNICKNAME_THChanging(value);
					this.SendPropertyChanging();
					this._NICKNAME_TH = value;
					this.SendPropertyChanged("NICKNAME_TH");
					this.OnNICKNAME_THChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULLNAME_EN", DbType="VarChar(100)")]
		public string FULLNAME_EN
		{
			get
			{
				return this._FULLNAME_EN;
			}
			set
			{
				if ((this._FULLNAME_EN != value))
				{
					this.OnFULLNAME_ENChanging(value);
					this.SendPropertyChanging();
					this._FULLNAME_EN = value;
					this.SendPropertyChanged("FULLNAME_EN");
					this.OnFULLNAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NICKNAME_EN", DbType="VarChar(50)")]
		public string NICKNAME_EN
		{
			get
			{
				return this._NICKNAME_EN;
			}
			set
			{
				if ((this._NICKNAME_EN != value))
				{
					this.OnNICKNAME_ENChanging(value);
					this.SendPropertyChanging();
					this._NICKNAME_EN = value;
					this.SendPropertyChanged("NICKNAME_EN");
					this.OnNICKNAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PEOPLEID", DbType="VarChar(20)")]
		public string PEOPLEID
		{
			get
			{
				return this._PEOPLEID;
			}
			set
			{
				if ((this._PEOPLEID != value))
				{
					this.OnPEOPLEIDChanging(value);
					this.SendPropertyChanging();
					this._PEOPLEID = value;
					this.SendPropertyChanged("PEOPLEID");
					this.OnPEOPLEIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZONE", DbType="VarChar(50)")]
		public string ZONE
		{
			get
			{
				return this._ZONE;
			}
			set
			{
				if ((this._ZONE != value))
				{
					this.OnZONEChanging(value);
					this.SendPropertyChanging();
					this._ZONE = value;
					this.SendPropertyChanged("ZONE");
					this.OnZONEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PROVINCE_BIRTH", DbType="VarChar(50)")]
		public string PROVINCE_BIRTH
		{
			get
			{
				return this._PROVINCE_BIRTH;
			}
			set
			{
				if ((this._PROVINCE_BIRTH != value))
				{
					this.OnPROVINCE_BIRTHChanging(value);
					this.SendPropertyChanging();
					this._PROVINCE_BIRTH = value;
					this.SendPropertyChanged("PROVINCE_BIRTH");
					this.OnPROVINCE_BIRTHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTHDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> BIRTHDATE
		{
			get
			{
				return this._BIRTHDATE;
			}
			set
			{
				if ((this._BIRTHDATE != value))
				{
					this.OnBIRTHDATEChanging(value);
					this.SendPropertyChanging();
					this._BIRTHDATE = value;
					this.SendPropertyChanged("BIRTHDATE");
					this.OnBIRTHDATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AGE", DbType="Int")]
		public System.Nullable<int> AGE
		{
			get
			{
				return this._AGE;
			}
			set
			{
				if ((this._AGE != value))
				{
					this.OnAGEChanging(value);
					this.SendPropertyChanging();
					this._AGE = value;
					this.SendPropertyChanged("AGE");
					this.OnAGEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WEIGHT", DbType="Int")]
		public System.Nullable<int> WEIGHT
		{
			get
			{
				return this._WEIGHT;
			}
			set
			{
				if ((this._WEIGHT != value))
				{
					this.OnWEIGHTChanging(value);
					this.SendPropertyChanging();
					this._WEIGHT = value;
					this.SendPropertyChanged("WEIGHT");
					this.OnWEIGHTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HEIGHT", DbType="Int")]
		public System.Nullable<int> HEIGHT
		{
			get
			{
				return this._HEIGHT;
			}
			set
			{
				if ((this._HEIGHT != value))
				{
					this.OnHEIGHTChanging(value);
					this.SendPropertyChanging();
					this._HEIGHT = value;
					this.SendPropertyChanged("HEIGHT");
					this.OnHEIGHTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_ROW1", DbType="VarChar(100)")]
		public string ADDR_ROW1
		{
			get
			{
				return this._ADDR_ROW1;
			}
			set
			{
				if ((this._ADDR_ROW1 != value))
				{
					this.OnADDR_ROW1Changing(value);
					this.SendPropertyChanging();
					this._ADDR_ROW1 = value;
					this.SendPropertyChanged("ADDR_ROW1");
					this.OnADDR_ROW1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_ROW2", DbType="VarChar(100)")]
		public string ADDR_ROW2
		{
			get
			{
				return this._ADDR_ROW2;
			}
			set
			{
				if ((this._ADDR_ROW2 != value))
				{
					this.OnADDR_ROW2Changing(value);
					this.SendPropertyChanging();
					this._ADDR_ROW2 = value;
					this.SendPropertyChanged("ADDR_ROW2");
					this.OnADDR_ROW2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_ROW3", DbType="VarChar(100)")]
		public string ADDR_ROW3
		{
			get
			{
				return this._ADDR_ROW3;
			}
			set
			{
				if ((this._ADDR_ROW3 != value))
				{
					this.OnADDR_ROW3Changing(value);
					this.SendPropertyChanging();
					this._ADDR_ROW3 = value;
					this.SendPropertyChanged("ADDR_ROW3");
					this.OnADDR_ROW3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_HOME1", DbType="VarChar(100)")]
		public string ADDR_HOME1
		{
			get
			{
				return this._ADDR_HOME1;
			}
			set
			{
				if ((this._ADDR_HOME1 != value))
				{
					this.OnADDR_HOME1Changing(value);
					this.SendPropertyChanging();
					this._ADDR_HOME1 = value;
					this.SendPropertyChanged("ADDR_HOME1");
					this.OnADDR_HOME1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_HOME2", DbType="VarChar(100)")]
		public string ADDR_HOME2
		{
			get
			{
				return this._ADDR_HOME2;
			}
			set
			{
				if ((this._ADDR_HOME2 != value))
				{
					this.OnADDR_HOME2Changing(value);
					this.SendPropertyChanging();
					this._ADDR_HOME2 = value;
					this.SendPropertyChanged("ADDR_HOME2");
					this.OnADDR_HOME2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_HOME3", DbType="VarChar(100)")]
		public string ADDR_HOME3
		{
			get
			{
				return this._ADDR_HOME3;
			}
			set
			{
				if ((this._ADDR_HOME3 != value))
				{
					this.OnADDR_HOME3Changing(value);
					this.SendPropertyChanging();
					this._ADDR_HOME3 = value;
					this.SendPropertyChanged("ADDR_HOME3");
					this.OnADDR_HOME3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_TEL", DbType="VarChar(15)")]
		public string ADDR_TEL
		{
			get
			{
				return this._ADDR_TEL;
			}
			set
			{
				if ((this._ADDR_TEL != value))
				{
					this.OnADDR_TELChanging(value);
					this.SendPropertyChanging();
					this._ADDR_TEL = value;
					this.SendPropertyChanged("ADDR_TEL");
					this.OnADDR_TELChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_MOBILE", DbType="VarChar(15)")]
		public string ADDR_MOBILE
		{
			get
			{
				return this._ADDR_MOBILE;
			}
			set
			{
				if ((this._ADDR_MOBILE != value))
				{
					this.OnADDR_MOBILEChanging(value);
					this.SendPropertyChanging();
					this._ADDR_MOBILE = value;
					this.SendPropertyChanged("ADDR_MOBILE");
					this.OnADDR_MOBILEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_EMAIL", DbType="VarChar(40)")]
		public string ADDR_EMAIL
		{
			get
			{
				return this._ADDR_EMAIL;
			}
			set
			{
				if ((this._ADDR_EMAIL != value))
				{
					this.OnADDR_EMAILChanging(value);
					this.SendPropertyChanging();
					this._ADDR_EMAIL = value;
					this.SendPropertyChanged("ADDR_EMAIL");
					this.OnADDR_EMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADDR_PHOTO", DbType="VarChar(MAX)")]
		public string ADDR_PHOTO
		{
			get
			{
				return this._ADDR_PHOTO;
			}
			set
			{
				if ((this._ADDR_PHOTO != value))
				{
					this.OnADDR_PHOTOChanging(value);
					this.SendPropertyChanging();
					this._ADDR_PHOTO = value;
					this.SendPropertyChanged("ADDR_PHOTO");
					this.OnADDR_PHOTOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WORKDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> WORKDATE
		{
			get
			{
				return this._WORKDATE;
			}
			set
			{
				if ((this._WORKDATE != value))
				{
					this.OnWORKDATEChanging(value);
					this.SendPropertyChanging();
					this._WORKDATE = value;
					this.SendPropertyChanged("WORKDATE");
					this.OnWORKDATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG", DbType="Int")]
		public System.Nullable<int> FLAG
		{
			get
			{
				return this._FLAG;
			}
			set
			{
				if ((this._FLAG != value))
				{
					this.OnFLAGChanging(value);
					this.SendPropertyChanging();
					this._FLAG = value;
					this.SendPropertyChanged("FLAG");
					this.OnFLAGChanged();
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
}
#pragma warning restore 1591
