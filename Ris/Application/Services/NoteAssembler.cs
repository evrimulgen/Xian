#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Application.Services.Admin
{
    public class NoteAssembler
    {
        public NoteDetail CreateNoteDetail(Note note, IPersistenceContext context)
        {
            if (note == null)
                return null;

            NoteDetail detail = new NoteDetail();

            detail.Comment = note.Comment;
            detail.TimeStamp = note.TimeStamp;
            detail.ValidRangeFrom = note.ValidRange.From;
            detail.ValidRangeUntil = note.ValidRange.Until;

            NoteCategoryAssembler categoryAssembler = new NoteCategoryAssembler();
            detail.Category = categoryAssembler.CreateNoteCategorySummary(note.Category, context);

            StaffAssembler staffAssembler = new StaffAssembler();
            detail.CreatedBy = staffAssembler.CreateStaffSummary(note.CreatedBy, context);

            return detail;
        }

        public Note CreateNote(NoteDetail detail, IPersistenceContext context)
        {
            Note newNote = new Note();

            newNote.Comment = detail.Comment;
            newNote.ValidRange.From = detail.ValidRangeFrom;
            newNote.ValidRange.Until = detail.ValidRangeUntil;

            if (detail.TimeStamp != null)
                newNote.TimeStamp = detail.TimeStamp.Value;
            else
                newNote.TimeStamp = Platform.Time;

            if (detail.Category != null)
                newNote.Category = context.Load<NoteCategory>(detail.Category.NoteCategoryRef, EntityLoadFlags.Proxy);

            if (detail.CreatedBy != null)
                newNote.CreatedBy = context.Load<Staff>(detail.CreatedBy.StaffRef, EntityLoadFlags.Proxy);
            else
            {
                //TODO: Services should know which staff is invoking the operation, use that staff instead
                newNote.CreatedBy = context.GetBroker<IStaffBroker>().FindOne(new StaffSearchCriteria());
            }

            return newNote;
        }
    }
}
