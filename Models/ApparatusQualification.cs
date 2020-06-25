using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class ApparatusQualification : BaseModel
	{
		private int apparatusNumber;

		public int ApparatusNumber
		{
			get { return apparatusNumber; }
			set { apparatusNumber = value; }
		}
		public override string ToString()
		{
			return apparatusNumber.ToString();
		}

	}
}
