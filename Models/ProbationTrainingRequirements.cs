using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProbationTrainingRequirements
    {
		private DateTime cpr;

		public DateTime CPR
		{
			get { return cpr; }
			set { cpr = value; }
		}

		private DateTime essentials;

		public DateTime Essentials
		{
			get { return essentials; }
			set { essentials = value; }
		}

		private DateTime firefighterI;

		public DateTime FirefighterI
		{
			get { return firefighterI; }
			set { firefighterI = value; }
		}

		private DateTime flashHood;

		public DateTime FlashHood
		{
			get { return flashHood; }
			set { flashHood = value; }
		}

		private DateTime nims100;

		public DateTime NIMS100
		{
			get { return nims100; }
			set { nims100 = value; }
		}

		private DateTime nims200;

		public DateTime NIMS200
		{
			get { return nims200; }
			set { nims200 = value; }
		}

		private DateTime nims700;

		public DateTime NIMS700
		{
			get { return nims700; }
			set { nims700 = value; }
		}

		private DateTime nims800;

		public DateTime NIMS800
		{
			get { return nims800; }
			set { nims800 = value; }
		}

		private DateTime orientation;

		public DateTime Orientation
		{
			get { return orientation; }
			set { orientation = value; }
		}

		private DateTime primaryTraining;

		public DateTime PrimaryTraining
		{
			get { return primaryTraining; }
			set { primaryTraining = value; }
		}

		private DateTime scbaFitTest;

		public DateTime SCBAFitTest
		{
			get { return scbaFitTest; }
			set { scbaFitTest = value; }
		}

		private DateTime scbaConfidence;

		public DateTime SCBAConfidence
		{
			get { return scbaConfidence; }
			set { scbaConfidence = value; }
		}
	}
}
