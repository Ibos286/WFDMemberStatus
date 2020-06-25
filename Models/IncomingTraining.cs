using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class IncomingTraining
    {
		private int badge;

		public int Badge
		{
			get { return badge; }
			set { badge = value; }
		}

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

		public IncomingTraining()
		{

		}

	}
}
