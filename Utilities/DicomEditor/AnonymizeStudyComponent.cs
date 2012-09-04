#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Dicom.Iod;
using ClearCanvas.Dicom.Utilities;
using ClearCanvas.ImageViewer.StudyManagement;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Dicom.Utilities.Anonymization;

namespace ClearCanvas.Utilities.DicomEditor
{
	/// <summary>
	/// Extension point for views onto <see cref="AnonymizeStudyComponent"/>.
	/// </summary>
	[ExtensionPoint]
	public sealed class AnonymizeStudyComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// AnonymizeStudyComponent class.
	/// </summary>
	[AssociateView(typeof(AnonymizeStudyComponentViewExtensionPoint))]
	public class AnonymizeStudyComponent : ApplicationComponent
	{
		private class ValidateAnonymizationRule : IValidationRule
		{
			private readonly AnonymizeStudyComponent _parent;
			private readonly string _property;
			private readonly ValidationFailureReason _validationReason;

			public ValidateAnonymizationRule(AnonymizeStudyComponent parent, string property, ValidationFailureReason validationReason)
			{
				_parent = parent;
				_property = property;
				_validationReason = validationReason;
			}

			#region IValidationRule Members

			public string PropertyName
			{
				get { return _property; }
			}

			public ValidationResult GetResult(IApplicationComponent component)
			{
				ReadOnlyCollection<ValidationFailureDescription> failures = _parent.GetValidationFailures();
				foreach (ValidationFailureDescription failure in failures)
				{
					if (failure.PropertyName == _property && _validationReason == failure.Reason)
					{
						if (failure.Reason == ValidationFailureReason.EmptyValue)
							return new ValidationResult(false, SR.MessageValueCannotBeEmpty);
						else
							return new ValidationResult(false, SR.MessageValueConflictsWithOriginal);
					}
				}

				return new ValidationResult(true, string.Empty);
			}

			#endregion
		}

		private readonly StudyData _original;
		private readonly StudyData _anonymized;
		private readonly DicomAnonymizer.ValidationStrategy _validator;

		private bool _preserveSeriesData;
		private bool _keepReportsAndAttachments = false;

		internal AnonymizeStudyComponent(IStudyRootData studyItem)
		{
		    _original = new StudyData
		                    {
		                        AccessionNumber = studyItem.AccessionNumber,
		                        PatientsName = new PersonName(studyItem.PatientsName),
		                        PatientId = studyItem.PatientId,
		                        StudyDescription = studyItem.StudyDescription,
		                        PatientsBirthDateRaw = studyItem.PatientsBirthDate,
		                        StudyDateRaw = studyItem.StudyDate
		                    };

		    _anonymized = _original.Clone();

			_validator = new DicomAnonymizer.ValidationStrategy();
		}

		internal StudyData OriginalData
		{
			get { return _original; }	
		}

		internal StudyData AnonymizedData
		{
			get { return _anonymized; }
		}

		public string PatientsName
		{
			get { return _anonymized.PatientsNameRaw; }
			set
			{
				if (_anonymized.PatientsNameRaw == value)
					return;

				_anonymized.PatientsNameRaw = value;
				NotifyPropertyChanged("PatientsName");
			}
		}

		public string PatientId
		{
			get { return _anonymized.PatientId; }
			set
			{
				if (_anonymized.PatientId == value)
					return;

				_anonymized.PatientId = value;
				NotifyPropertyChanged("PatientId");
			}
		}

		[ValidateLength(0, 16, Message = "MessageAccessionNumberInvalidLength")]
		public string AccessionNumber
		{
			get { return _anonymized.AccessionNumber; }
			set
			{
				if (_anonymized.AccessionNumber == value)
					return;

				_anonymized.AccessionNumber = value;
				NotifyPropertyChanged("AccessionNumber");
			}
		}

		public string StudyDescription
		{
			get { return _anonymized.StudyDescription; }
			set
			{
				if (_anonymized.StudyDescription == value)
					return;

				_anonymized.StudyDescription = value;
				NotifyPropertyChanged("StudyDescription");
			}
		}

		public DateTime? StudyDate
		{
			get { return _anonymized.StudyDate; }
			set
			{
				if (_anonymized.StudyDate == value)
					return;

				_anonymized.StudyDate = value;
				NotifyPropertyChanged("StudyDate");
			}
		}

		public DateTime? PatientsBirthDate
		{
			get { return _anonymized.PatientsBirthDate; }
			set
			{
				if (_anonymized.PatientsBirthDate == value)
					return;

				_anonymized.PatientsBirthDate = value;
				NotifyPropertyChanged("PatientsBirthDate");
			}
		}

		public bool PreserveSeriesData
		{
			get { return _preserveSeriesData; }
			set
			{
				if (_preserveSeriesData == value)
					return;

				_preserveSeriesData = value;
				NotifyPropertyChanged("PreserveSeriesDescriptions");
			}
		}

		public bool KeepReportsAndAttachments
		{
			get { return _keepReportsAndAttachments; }
			set
			{
				if (_keepReportsAndAttachments == value)
					return;

				if (value && Host != null && Host.DesktopWindow.ShowMessageBox(SR.MessageConfirmKeepReportsAndAttachments, MessageBoxActions.YesNo) != DialogBoxAction.Yes)
					value = false;

				_keepReportsAndAttachments = value;
				NotifyPropertyChanged("KeepReportsAndAttachments");
			}
		}

		public override void Start()
		{
			_anonymized.PatientsNameRaw = SR.DefaultAnonymousPatientName;
			_anonymized.PatientId = "12345678";
			_anonymized.StudyDate = Platform.Time;
			_anonymized.AccessionNumber = "00000001";
			_preserveSeriesData = true;

			// this should always be false by default
			_keepReportsAndAttachments = false;

			if (_anonymized.PatientsBirthDate != null)
			{
				_anonymized.PatientsBirthDate = new DateTime(_anonymized.PatientsBirthDate.Value.Year, 1, 1, 0, 0, 0);
				_anonymized.PatientsBirthDate = _anonymized.PatientsBirthDate.Value.AddDays(TimeSpan.FromDays(new Random().Next(0, 364)).Days);
			}

			base.Start();

			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientId", ValidationFailureReason.EmptyValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientsName", ValidationFailureReason.EmptyValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "AccessionNumber", ValidationFailureReason.EmptyValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "StudyDescription", ValidationFailureReason.EmptyValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "StudyDate", ValidationFailureReason.EmptyValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientsBirthDate", ValidationFailureReason.EmptyValue));

			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientId", ValidationFailureReason.ConflictingValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientsName", ValidationFailureReason.ConflictingValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "AccessionNumber", ValidationFailureReason.ConflictingValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "StudyDescription", ValidationFailureReason.ConflictingValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "StudyDate", ValidationFailureReason.ConflictingValue));
			base.Validation.Add(new ValidateAnonymizationRule(this, "PatientsBirthDate", ValidationFailureReason.ConflictingValue));
		}

		public void Accept()
		{
			if (this.HasValidationErrors)
			{
				base.ShowValidation(true);
			}
			else
			{
				this.ExitCode = ApplicationComponentExitCode.Accepted;
				this.Host.Exit();
			}
		}

		public void Cancel()
		{
			this.ExitCode = ApplicationComponentExitCode.None;
			this.Host.Exit();
		}

		private ReadOnlyCollection<ValidationFailureDescription> GetValidationFailures()
		{
			return _validator.GetValidationFailures(_original, _anonymized);
		}
	}	
}
