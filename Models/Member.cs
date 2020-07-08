using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class Member : BaseModel
    {
		private string company;

		public string Company
		{
			get { return company; }
			set { company = value; }
		}

		private int badge;

		public int Badge
		{
			get { return badge; }
			set { badge = value; }
		}

		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		private string firstName;

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		private DateTime birthDate;

		public DateTime BirthDate
		{
			get { return birthDate; }
			set { birthDate = value; }
		}

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        private string address;

		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		private string address2;

		public string Address2
		{
			get { return address2; }
			set { address2 = value; }
		}

		private string city;

		public string City
		{
			get { return city; }
			set { city = value; }
		}

		private string state;

		public string State
		{
			get { return state; }
			set { state = value; }
		}

		private string zipCode;

		public string ZipCode
		{
			get { return zipCode; }
			set { zipCode = value; }
		}

		private string phoneNumber;

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		private string cellPhone;

		public string CellPhone
		{
			get { return cellPhone; }
			set { cellPhone = value; }
		}

		private string departmentClass;

		public string DepartmentClass
		{
			get { return departmentClass; }
			set { departmentClass = value; }
		}

		private string departmentOffice;

		public string DepartmentOffice
		{
			get { return departmentOffice; }
			set { departmentOffice = value; }
		}

		private string emailAddress;

		public string EmailAddress
		{
			get { return emailAddress; }
			set { emailAddress = value; }
		}

		private DateTime serviceDate;

		public DateTime ServiceDate
		{
			get { return serviceDate; }
			set { serviceDate = value; }
		}

		private int yearsOfService;

		public int YearsOfService
		{
			get { return yearsOfService; }
			set { yearsOfService = value; }
		}

		private long fsaNumber;

		public long FSANumber
		{
			get { return fsaNumber; }
			set { fsaNumber = value; }
		}

		private long femaNumber;

		public long FEMANumber
		{
			get { return femaNumber; }
			set { femaNumber = value; }
		}

		private string faStateNumber;

		public string FAStateNumber
		{
			get { return faStateNumber; }
			set { faStateNumber = value; }
		}
		private List<ApparatusQualification> qualifications;

		public List<ApparatusQualification> Qualifications
		{
			get { return qualifications; }
			set { qualifications = value; }
		}

		private string timeOfService;

		public string  TimeOfService
		{
			get { return timeOfService; }
			set { timeOfService = value; }
		}


		private List<TrainingActivity> peshTrainings;

		public List<TrainingActivity> PESHTrainings
		{
			get { return peshTrainings; }
			set { peshTrainings = value; }
		}

		private List<TrainingActivity> departmentTrainings;

		public List<TrainingActivity> DepartmentTrainings
		{
			get { return departmentTrainings; }
			set { departmentTrainings = value; }
		}

		private List<TrainingActivity> refresherAttendance;

		public List<TrainingActivity> RefresherAttendance
		{
			get { return refresherAttendance; }
			set { refresherAttendance = value; }
		}

		private Percentage currentPercentage;

		public Percentage CurrentPercentage
		{
			get { return currentPercentage; }
			set { currentPercentage = value; }
		}

		private DateTime probationStartDate;

		public DateTime ProbationStartDate
		{
			get { return probationStartDate; }
			set { probationStartDate = value; }
		}


		private Percentage probationPercentage ;

		public Percentage ProbationPercentage
		{
			get { return probationPercentage; }
			set { probationPercentage = value; }
		}

		private List<Training> probationTraining;

		public List<Training> ProbationTraining
		{
			get { return probationTraining; }
			set { probationTraining = value; }
		}

		private ProbationDrillAttendance probationDrill;

		public ProbationDrillAttendance ProbationDrill
		{
			get { return probationDrill; }
			set { probationDrill = value; }
		}

		private ProbationTrainingRequirements probationTrainingList;

		public ProbationTrainingRequirements ProbationTrainingList
		{
			get { return probationTrainingList; }
			set { probationTrainingList = value; }
		}


	}
}
