using System;
using System.Data;

namespace TelnetingMythTv
{
	public class TelnetConnection : IDbConnection
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}
		
		public ConnectionState State
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		
		public string Database
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		
		public int ConnectionTimeout
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		
		public string ConnectionString
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
		
		public void Open()
		{
			throw new NotImplementedException();
		}
		
		public IDbCommand CreateCommand()
		{
			throw new NotImplementedException();
		}
		
		public void Close()
		{
			throw new NotImplementedException();
		}
		
		public void ChangeDatabase(string datebaseName)
		{
			throw new NotImplementedException();
		}
		
		public IDbTransaction BeginTransaction()
		{
			throw new NotImplementedException();
		}
		
		public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
		{
			throw new NotImplementedException();
		}
	}
}
