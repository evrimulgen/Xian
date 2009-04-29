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
    using System;
    using System.Xml;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;

    public partial class AlertSelectCriteria : EntitySelectCriteria
    {
        public AlertSelectCriteria()
        : base("Alert")
        {}
        public AlertSelectCriteria(AlertSelectCriteria other)
        : base(other)
        {}
        public override object Clone()
        {
            return new AlertSelectCriteria(this);
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="AlertCategoryEnum")]
        public ISearchCondition<AlertCategoryEnum> AlertCategoryEnum
        {
            get
            {
              if (!SubCriteria.ContainsKey("AlertCategoryEnum"))
              {
                 SubCriteria["AlertCategoryEnum"] = new SearchCondition<AlertCategoryEnum>("AlertCategoryEnum");
              }
              return (ISearchCondition<AlertCategoryEnum>)SubCriteria["AlertCategoryEnum"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="AlertLevelEnum")]
        public ISearchCondition<AlertLevelEnum> AlertLevelEnum
        {
            get
            {
              if (!SubCriteria.ContainsKey("AlertLevelEnum"))
              {
                 SubCriteria["AlertLevelEnum"] = new SearchCondition<AlertLevelEnum>("AlertLevelEnum");
              }
              return (ISearchCondition<AlertLevelEnum>)SubCriteria["AlertLevelEnum"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="Component")]
        public ISearchCondition<String> Component
        {
            get
            {
              if (!SubCriteria.ContainsKey("Component"))
              {
                 SubCriteria["Component"] = new SearchCondition<String>("Component");
              }
              return (ISearchCondition<String>)SubCriteria["Component"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="Content")]
        public ISearchCondition<XmlDocument> Content
        {
            get
            {
              if (!SubCriteria.ContainsKey("Content"))
              {
                 SubCriteria["Content"] = new SearchCondition<XmlDocument>("Content");
              }
              return (ISearchCondition<XmlDocument>)SubCriteria["Content"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="InsertTime")]
        public ISearchCondition<DateTime> InsertTime
        {
            get
            {
              if (!SubCriteria.ContainsKey("InsertTime"))
              {
                 SubCriteria["InsertTime"] = new SearchCondition<DateTime>("InsertTime");
              }
              return (ISearchCondition<DateTime>)SubCriteria["InsertTime"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="Source")]
        public ISearchCondition<String> Source
        {
            get
            {
              if (!SubCriteria.ContainsKey("Source"))
              {
                 SubCriteria["Source"] = new SearchCondition<String>("Source");
              }
              return (ISearchCondition<String>)SubCriteria["Source"];
            } 
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Alert", ColumnName="TypeCode")]
        public ISearchCondition<Int32> TypeCode
        {
            get
            {
              if (!SubCriteria.ContainsKey("TypeCode"))
              {
                 SubCriteria["TypeCode"] = new SearchCondition<Int32>("TypeCode");
              }
              return (ISearchCondition<Int32>)SubCriteria["TypeCode"];
            } 
        }
    }
}
