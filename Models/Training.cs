using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class Training : BaseModel
    {
		private int badge;

		public int Badge
		{
			get { return badge; }
			set { badge = value; }
		}

		private DateTime activityDate;

		public DateTime ActivityDate
		{
			get { return activityDate; }
			set { activityDate = value; }
		}

		private string trainingName;

		public string TrainingName
		{
			get { return trainingName; }
			set { trainingName = value; }
		}

		public Training()
		{
		}
	}
}
