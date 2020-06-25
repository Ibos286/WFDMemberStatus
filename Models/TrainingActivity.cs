using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class TrainingActivity
    {
		private string trainingName;

		public string TrainingName
		{
			get { return trainingName; }
			set { trainingName = value; }
		}

		private DateTime trainingDate;

		public DateTime TrainingDate
		{
			get { return trainingDate; }
			set { trainingDate = value; }
		}

	}
}
