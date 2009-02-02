#region License

// Copyright (c) 2006-2009, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

// This file is auto-generated by the ClearCanvas.Model.SqlServer2005.CodeGenerator project.

namespace ClearCanvas.ImageServer.Model.EntityBrokers
{
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;

    public partial class ServerRuleSelectCriteria : EntitySelectCriteria
    {
        public ServerRuleSelectCriteria()
        : base("ServerRule")
        {}
        public ISearchCondition<System.Boolean> DefaultRule
        {
            get
            {
              if (!SubCriteria.ContainsKey("DefaultRule"))
              {
                 SubCriteria["DefaultRule"] = new SearchCondition<System.Boolean>("DefaultRule");
              }
              return (ISearchCondition<System.Boolean>)SubCriteria["DefaultRule"];
            } 
        }
        public ISearchCondition<System.Boolean> Enabled
        {
            get
            {
              if (!SubCriteria.ContainsKey("Enabled"))
              {
                 SubCriteria["Enabled"] = new SearchCondition<System.Boolean>("Enabled");
              }
              return (ISearchCondition<System.Boolean>)SubCriteria["Enabled"];
            } 
        }
        public ISearchCondition<System.Boolean> ExemptRule
        {
            get
            {
              if (!SubCriteria.ContainsKey("ExemptRule"))
              {
                 SubCriteria["ExemptRule"] = new SearchCondition<System.Boolean>("ExemptRule");
              }
              return (ISearchCondition<System.Boolean>)SubCriteria["ExemptRule"];
            } 
        }
        public ISearchCondition<System.String> RuleName
        {
            get
            {
              if (!SubCriteria.ContainsKey("RuleName"))
              {
                 SubCriteria["RuleName"] = new SearchCondition<System.String>("RuleName");
              }
              return (ISearchCondition<System.String>)SubCriteria["RuleName"];
            } 
        }
        public ISearchCondition<System.Xml.XmlDocument> RuleXml
        {
            get
            {
              if (!SubCriteria.ContainsKey("RuleXml"))
              {
                 SubCriteria["RuleXml"] = new SearchCondition<System.Xml.XmlDocument>("RuleXml");
              }
              return (ISearchCondition<System.Xml.XmlDocument>)SubCriteria["RuleXml"];
            } 
        }
        public ISearchCondition<ClearCanvas.ImageServer.Enterprise.ServerEntityKey> ServerPartitionKey
        {
            get
            {
              if (!SubCriteria.ContainsKey("ServerPartitionKey"))
              {
                 SubCriteria["ServerPartitionKey"] = new SearchCondition<ClearCanvas.ImageServer.Enterprise.ServerEntityKey>("ServerPartitionKey");
              }
              return (ISearchCondition<ClearCanvas.ImageServer.Enterprise.ServerEntityKey>)SubCriteria["ServerPartitionKey"];
            } 
        }
        public ISearchCondition<ServerRuleApplyTimeEnum> ServerRuleApplyTimeEnum
        {
            get
            {
              if (!SubCriteria.ContainsKey("ServerRuleApplyTimeEnum"))
              {
                 SubCriteria["ServerRuleApplyTimeEnum"] = new SearchCondition<ServerRuleApplyTimeEnum>("ServerRuleApplyTimeEnum");
              }
              return (ISearchCondition<ServerRuleApplyTimeEnum>)SubCriteria["ServerRuleApplyTimeEnum"];
            } 
        }
        public ISearchCondition<ServerRuleTypeEnum> ServerRuleTypeEnum
        {
            get
            {
              if (!SubCriteria.ContainsKey("ServerRuleTypeEnum"))
              {
                 SubCriteria["ServerRuleTypeEnum"] = new SearchCondition<ServerRuleTypeEnum>("ServerRuleTypeEnum");
              }
              return (ISearchCondition<ServerRuleTypeEnum>)SubCriteria["ServerRuleTypeEnum"];
            } 
        }
    }
}
