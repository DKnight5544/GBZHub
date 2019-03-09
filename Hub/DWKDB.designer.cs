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

namespace Hub
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DWKDB")]
	public partial class DWKDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DWKDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DWKDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DWKDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<GameView> GameViews
		{
			get
			{
				return this.GetTable<GameView>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Farkle.AddGame")]
		public ISingleResult<AddGameResult> AddGame([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(1000)")] string url)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), url);
			return ((ISingleResult<AddGameResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Farkle.EndGame")]
		public int EndGame([global::System.Data.Linq.Mapping.ParameterAttribute(Name="GameId", DbType="Int")] System.Nullable<int> gameId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MoveCount", DbType="Int")] System.Nullable<int> moveCount, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Moves", DbType="VarChar(MAX)")] string moves)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), gameId, moveCount, moves);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Farkle.GetGame")]
		public ISingleResult<GameView> GetGame([global::System.Data.Linq.Mapping.ParameterAttribute(Name="GameId", DbType="Int")] System.Nullable<int> gameId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), gameId);
			return ((ISingleResult<GameView>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Farkle.GetLeaderboard")]
		public ISingleResult<GameView> GetLeaderboard()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GameView>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="GBZ.AddUpdateBot")]
		public int AddUpdateBot([global::System.Data.Linq.Mapping.ParameterAttribute(Name="URL", DbType="VarChar(1000)")] string uRL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PaymentInfo", DbType="VarChar(1000)")] string paymentInfo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="BotName", DbType="VarChar(20)")] string botName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uRL, paymentInfo, botName);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Farkle.GameView")]
	public partial class GameView
	{
		
		private int _GameId;
		
		private int _BotId;
		
		private System.DateTime _GameTime;
		
		private System.Nullable<int> _MoveCount;
		
		private string _Moves;
		
		private string _BotName;
		
		private string _PaymentInfo;
		
		private string _URL;
		
		private System.Nullable<int> _Placement;
		
		public GameView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameId", DbType="Int NOT NULL")]
		public int GameId
		{
			get
			{
				return this._GameId;
			}
			set
			{
				if ((this._GameId != value))
				{
					this._GameId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BotId", DbType="Int NOT NULL")]
		public int BotId
		{
			get
			{
				return this._BotId;
			}
			set
			{
				if ((this._BotId != value))
				{
					this._BotId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameTime", DbType="DateTime NOT NULL")]
		public System.DateTime GameTime
		{
			get
			{
				return this._GameTime;
			}
			set
			{
				if ((this._GameTime != value))
				{
					this._GameTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoveCount", DbType="Int")]
		public System.Nullable<int> MoveCount
		{
			get
			{
				return this._MoveCount;
			}
			set
			{
				if ((this._MoveCount != value))
				{
					this._MoveCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Moves", DbType="VarChar(MAX)")]
		public string Moves
		{
			get
			{
				return this._Moves;
			}
			set
			{
				if ((this._Moves != value))
				{
					this._Moves = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BotName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string BotName
		{
			get
			{
				return this._BotName;
			}
			set
			{
				if ((this._BotName != value))
				{
					this._BotName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentInfo", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string PaymentInfo
		{
			get
			{
				return this._PaymentInfo;
			}
			set
			{
				if ((this._PaymentInfo != value))
				{
					this._PaymentInfo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URL", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				if ((this._URL != value))
				{
					this._URL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Placement", DbType="Int")]
		public System.Nullable<int> Placement
		{
			get
			{
				return this._Placement;
			}
			set
			{
				if ((this._Placement != value))
				{
					this._Placement = value;
				}
			}
		}
	}
	
	public partial class AddGameResult
	{
		
		private int _GameId;
		
		private int _BotId;
		
		public AddGameResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameId", DbType="Int NOT NULL")]
		public int GameId
		{
			get
			{
				return this._GameId;
			}
			set
			{
				if ((this._GameId != value))
				{
					this._GameId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BotId", DbType="Int NOT NULL")]
		public int BotId
		{
			get
			{
				return this._BotId;
			}
			set
			{
				if ((this._BotId != value))
				{
					this._BotId = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
