#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Runtime.Serialization;
using ClearCanvas.Common.Serialization;

namespace ClearCanvas.Enterprise.Common
{
	/// <summary>
	/// Defines the set of response cache sites.
	/// </summary>
	public enum ResponseCachingSite
	{
		/// <summary>
		/// The response is not cached.
		/// </summary>
		None,

		/// <summary>
		/// The response is cached on the server.
		/// </summary>
		Server,

		/// <summary>
		/// The response is cached on the client.
		/// </summary>
		Client,
	}

	/// <summary>
	/// Encapsulates information that directs how a client should cache a response.
	/// </summary>
	[DataContract]
	public class ResponseCachingDirective : DataContractBase, IEquatable<ResponseCachingDirective>
	{
		/// <summary>
		/// Defines a static Do Not Cache directive.
		/// </summary>
		public static ResponseCachingDirective DoNotCacheDirective
			= new ResponseCachingDirective();

		/// <summary>
		/// Constructor.
		/// </summary>
		public ResponseCachingDirective()
			: this(false, TimeSpan.Zero, ResponseCachingSite.None)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="enableCaching"></param>
		/// <param name="timeToLive"></param>
		/// <param name="site"></param>
		public ResponseCachingDirective(bool enableCaching, TimeSpan timeToLive, ResponseCachingSite site)
		{
			EnableCaching = enableCaching;
			TimeToLive = timeToLive;
			CacheSite = site;
		}

		/// <summary>
		/// Gets or sets a value indicated whether caching of the response is enabled.
		/// </summary>
		[DataMember]
		public bool EnableCaching { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the Time-to-Live for the cached response.
		/// </summary>
		[DataMember]
		public TimeSpan TimeToLive { get; set; }

		/// <summary>
		/// Gets or sets the cache site.
		/// </summary>
		[DataMember]
		public ResponseCachingSite CacheSite { get; set; }

		public override string ToString()
		{
			return string.Format("EnableCaching = {0} TTL = {1} Site = {2}",
				EnableCaching, TimeToLive, CacheSite);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ResponseCachingDirective);
		}

		public override int GetHashCode()
		{
			return EnableCaching.GetHashCode() ^ CacheSite.GetHashCode() ^ TimeToLive.GetHashCode();
		}

		#region IEquatable<ResponseCachingDirective> Members

		public bool Equals(ResponseCachingDirective other)
		{
			if (other == null)
				return false;
			return EnableCaching == other.EnableCaching
				&& CacheSite == other.CacheSite
				&& TimeToLive == other.TimeToLive;
		}

		#endregion
	}
}
