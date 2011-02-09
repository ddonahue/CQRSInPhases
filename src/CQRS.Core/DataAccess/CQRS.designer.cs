﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CQRS.Core.DataAccess
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CQRS")]
	public partial class CQRSDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBankAccountEntity(BankAccountEntity instance);
    partial void UpdateBankAccountEntity(BankAccountEntity instance);
    partial void DeleteBankAccountEntity(BankAccountEntity instance);
    partial void InsertTransactionEntity(TransactionEntity instance);
    partial void UpdateTransactionEntity(TransactionEntity instance);
    partial void DeleteTransactionEntity(TransactionEntity instance);
    partial void InsertAggregateEntity(AggregateEntity instance);
    partial void UpdateAggregateEntity(AggregateEntity instance);
    partial void DeleteAggregateEntity(AggregateEntity instance);
    partial void InsertEventEntity(EventEntity instance);
    partial void UpdateEventEntity(EventEntity instance);
    partial void DeleteEventEntity(EventEntity instance);
    #endregion
		
		public CQRSDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CQRSDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CQRSDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CQRSDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BankAccountEntity> BankAccountEntities
		{
			get
			{
				return this.GetTable<BankAccountEntity>();
			}
		}
		
		public System.Data.Linq.Table<TransactionEntity> TransactionEntities
		{
			get
			{
				return this.GetTable<TransactionEntity>();
			}
		}
		
		public System.Data.Linq.Table<AggregateEntity> AggregateEntities
		{
			get
			{
				return this.GetTable<AggregateEntity>();
			}
		}
		
		public System.Data.Linq.Table<EventEntity> EventEntities
		{
			get
			{
				return this.GetTable<EventEntity>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BankAccounts")]
	public partial class BankAccountEntity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _BankAccountId;
		
		private string _AccountNumber;
		
		private bool _Locked;
		
		private string _EmailAddress;
		
		private decimal _Balance;
		
		private EntitySet<TransactionEntity> _Transactions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBankAccountIdChanging(System.Guid value);
    partial void OnBankAccountIdChanged();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnLockedChanging(bool value);
    partial void OnLockedChanged();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    partial void OnBalanceChanging(decimal value);
    partial void OnBalanceChanged();
    #endregion
		
		public BankAccountEntity()
		{
			this._Transactions = new EntitySet<TransactionEntity>(new Action<TransactionEntity>(this.attach_Transactions), new Action<TransactionEntity>(this.detach_Transactions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankAccountId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid BankAccountId
		{
			get
			{
				return this._BankAccountId;
			}
			set
			{
				if ((this._BankAccountId != value))
				{
					this.OnBankAccountIdChanging(value);
					this.SendPropertyChanging();
					this._BankAccountId = value;
					this.SendPropertyChanged("BankAccountId");
					this.OnBankAccountIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Locked", DbType="Bit NOT NULL")]
		public bool Locked
		{
			get
			{
				return this._Locked;
			}
			set
			{
				if ((this._Locked != value))
				{
					this.OnLockedChanging(value);
					this.SendPropertyChanging();
					this._Locked = value;
					this.SendPropertyChanged("Locked");
					this.OnLockedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddress", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string EmailAddress
		{
			get
			{
				return this._EmailAddress;
			}
			set
			{
				if ((this._EmailAddress != value))
				{
					this.OnEmailAddressChanging(value);
					this.SendPropertyChanging();
					this._EmailAddress = value;
					this.SendPropertyChanged("EmailAddress");
					this.OnEmailAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Money NULL")]
		public decimal Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this.OnBalanceChanging(value);
					this.SendPropertyChanging();
					this._Balance = value;
					this.SendPropertyChanged("Balance");
					this.OnBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BankAccountEntity_TransactionEntity", Storage="_Transactions", ThisKey="BankAccountId", OtherKey="BankAccountId")]
		public EntitySet<TransactionEntity> TransactionEntities
		{
			get
			{
				return this._Transactions;
			}
			set
			{
				this._Transactions.Assign(value);
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
		
		private void attach_Transactions(TransactionEntity entity)
		{
			this.SendPropertyChanging();
			entity.BankAccountEntity = this;
		}
		
		private void detach_Transactions(TransactionEntity entity)
		{
			this.SendPropertyChanging();
			entity.BankAccountEntity = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Transactions")]
	public partial class TransactionEntity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TransactionId;
		
		private System.Guid _BankAccountId;
		
		private System.DateTime _TransactionDate;
		
		private decimal _Amount;
		
		private string _Description;
		
		private EntityRef<BankAccountEntity> _BankAccount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTransactionIdChanging(int value);
    partial void OnTransactionIdChanged();
    partial void OnBankAccountIdChanging(System.Guid value);
    partial void OnBankAccountIdChanged();
    partial void OnTransactionDateChanging(System.DateTime value);
    partial void OnTransactionDateChanged();
    partial void OnAmountChanging(decimal value);
    partial void OnAmountChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public TransactionEntity()
		{
			this._BankAccount = default(EntityRef<BankAccountEntity>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TransactionId
		{
			get
			{
				return this._TransactionId;
			}
			set
			{
				if ((this._TransactionId != value))
				{
					this.OnTransactionIdChanging(value);
					this.SendPropertyChanging();
					this._TransactionId = value;
					this.SendPropertyChanged("TransactionId");
					this.OnTransactionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BankAccountId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid BankAccountId
		{
			get
			{
				return this._BankAccountId;
			}
			set
			{
				if ((this._BankAccountId != value))
				{
					if (this._BankAccount.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBankAccountIdChanging(value);
					this.SendPropertyChanging();
					this._BankAccountId = value;
					this.SendPropertyChanged("BankAccountId");
					this.OnBankAccountIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransactionDate
		{
			get
			{
				return this._TransactionDate;
			}
			set
			{
				if ((this._TransactionDate != value))
				{
					this.OnTransactionDateChanging(value);
					this.SendPropertyChanging();
					this._TransactionDate = value;
					this.SendPropertyChanged("TransactionDate");
					this.OnTransactionDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Money NOT NULL")]
		public decimal Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BankAccountEntity_TransactionEntity", Storage="_BankAccount", ThisKey="BankAccountId", OtherKey="BankAccountId", IsForeignKey=true)]
		public BankAccountEntity BankAccountEntity
		{
			get
			{
				return this._BankAccount.Entity;
			}
			set
			{
				BankAccountEntity previousValue = this._BankAccount.Entity;
				if (((previousValue != value) 
							|| (this._BankAccount.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BankAccount.Entity = null;
						previousValue.TransactionEntities.Remove(this);
					}
					this._BankAccount.Entity = value;
					if ((value != null))
					{
						value.TransactionEntities.Add(this);
						this._BankAccountId = value.BankAccountId;
					}
					else
					{
						this._BankAccountId = default(System.Guid);
					}
					this.SendPropertyChanged("BankAccountEntity");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Aggregates")]
	public partial class AggregateEntity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _AggregateId;
		
		private string _DataType;
		
		private int _Version;
		
		private EntitySet<EventEntity> _Events;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAggregateIdChanging(System.Guid value);
    partial void OnAggregateIdChanged();
    partial void OnDataTypeChanging(string value);
    partial void OnDataTypeChanged();
    partial void OnVersionChanging(int value);
    partial void OnVersionChanged();
    #endregion
		
		public AggregateEntity()
		{
			this._Events = new EntitySet<EventEntity>(new Action<EventEntity>(this.attach_Events), new Action<EventEntity>(this.detach_Events));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AggregateId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid AggregateId
		{
			get
			{
				return this._AggregateId;
			}
			set
			{
				if ((this._AggregateId != value))
				{
					this.OnAggregateIdChanging(value);
					this.SendPropertyChanging();
					this._AggregateId = value;
					this.SendPropertyChanged("AggregateId");
					this.OnAggregateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataType", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string DataType
		{
			get
			{
				return this._DataType;
			}
			set
			{
				if ((this._DataType != value))
				{
					this.OnDataTypeChanging(value);
					this.SendPropertyChanging();
					this._DataType = value;
					this.SendPropertyChanged("DataType");
					this.OnDataTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Version", DbType="Int NOT NULL")]
		public int Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersionChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Version");
					this.OnVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="AggregateEntity_EventEntity", Storage="_Events", ThisKey="AggregateId", OtherKey="AggregateId")]
		public EntitySet<EventEntity> EventEntities
		{
			get
			{
				return this._Events;
			}
			set
			{
				this._Events.Assign(value);
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
		
		private void attach_Events(EventEntity entity)
		{
			this.SendPropertyChanging();
			entity.AggregateEntity = this;
		}
		
		private void detach_Events(EventEntity entity)
		{
			this.SendPropertyChanging();
			entity.AggregateEntity = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Events")]
	public partial class EventEntity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _AggregateId;
		
		private string _EventData;
		
		private int _Version;
		
		private string _EventName;
		
		private int _EventId;
		
		private EntityRef<AggregateEntity> _Aggregate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAggregateIdChanging(System.Guid value);
    partial void OnAggregateIdChanged();
    partial void OnEventDataChanging(string value);
    partial void OnEventDataChanged();
    partial void OnVersionChanging(int value);
    partial void OnVersionChanged();
    partial void OnEventNameChanging(string value);
    partial void OnEventNameChanged();
    partial void OnEventIdChanging(int value);
    partial void OnEventIdChanged();
    #endregion
		
		public EventEntity()
		{
			this._Aggregate = default(EntityRef<AggregateEntity>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AggregateId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AggregateId
		{
			get
			{
				return this._AggregateId;
			}
			set
			{
				if ((this._AggregateId != value))
				{
					if (this._Aggregate.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAggregateIdChanging(value);
					this.SendPropertyChanging();
					this._AggregateId = value;
					this.SendPropertyChanged("AggregateId");
					this.OnAggregateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventData", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string EventData
		{
			get
			{
				return this._EventData;
			}
			set
			{
				if ((this._EventData != value))
				{
					this.OnEventDataChanging(value);
					this.SendPropertyChanging();
					this._EventData = value;
					this.SendPropertyChanged("EventData");
					this.OnEventDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Version", DbType="Int NOT NULL")]
		public int Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersionChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Version");
					this.OnVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string EventName
		{
			get
			{
				return this._EventName;
			}
			set
			{
				if ((this._EventName != value))
				{
					this.OnEventNameChanging(value);
					this.SendPropertyChanging();
					this._EventName = value;
					this.SendPropertyChanged("EventName");
					this.OnEventNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EventId
		{
			get
			{
				return this._EventId;
			}
			set
			{
				if ((this._EventId != value))
				{
					this.OnEventIdChanging(value);
					this.SendPropertyChanging();
					this._EventId = value;
					this.SendPropertyChanged("EventId");
					this.OnEventIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="AggregateEntity_EventEntity", Storage="_Aggregate", ThisKey="AggregateId", OtherKey="AggregateId", IsForeignKey=true)]
		public AggregateEntity AggregateEntity
		{
			get
			{
				return this._Aggregate.Entity;
			}
			set
			{
				AggregateEntity previousValue = this._Aggregate.Entity;
				if (((previousValue != value) 
							|| (this._Aggregate.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Aggregate.Entity = null;
						previousValue.EventEntities.Remove(this);
					}
					this._Aggregate.Entity = value;
					if ((value != null))
					{
						value.EventEntities.Add(this);
						this._AggregateId = value.AggregateId;
					}
					else
					{
						this._AggregateId = default(System.Guid);
					}
					this.SendPropertyChanged("AggregateEntity");
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
