using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDMemberStatus.Models
{
    public class Percentage
    {
        private int badge;

        public int Badge
        {
            get { return badge; }
            set { badge = value; }
        }

        private int fireDay;

        public int FireDay
        {
            get { return fireDay; }
            set { fireDay = value; }
        }

        private int fireNight;

        public int FireNight
        {
            get { return fireNight; }
            set { fireNight = value; }
        }

        private int rescueDay;

        public int RescueDay
        {
            get { return rescueDay; }
            set { rescueDay = value; }
        }

        private int rescueNight;

        public int RescueNight
        {
            get { return rescueNight; }
            set { rescueNight = value; }
        }

        private int autoAcc;

        public int AutoAcc
        {
            get { return autoAcc; }
            set { autoAcc = value; }
        }

        private int drillDpt;

        public int DrillDpt
        {
            get { return drillDpt; }
            set { drillDpt = value; }
        }

        private int miscCom;

        public int MiscCom
        {
            get { return miscCom; }
            set { miscCom = value; }
        }

        private int drillCom;

        public int DrillCom
        {
            get { return drillCom; }
            set { drillCom = value; }
        }

        private int meetDpt;

        public int MeetDpt
        {
            get { return meetDpt; }
            set { meetDpt = value; }
        }

        private int meetCom;

        public int MeetCom
        {
            get { return meetCom; }
            set { meetCom = value; }
        }

        private int trainDpt;

        public int TrainDpt
        {
            get { return trainDpt; }
            set { trainDpt = value; }
        }

        private int trainCom;

        public int TrainCom
        {
            get { return trainCom; }
            set { trainCom = value; }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private int silent;

        public int Silent
        {
            get { return silent; }
            set { silent = value; }
        }

        private double curMonth;

        public double CurMonth
        {
            get { return curMonth; }
            set { curMonth = value; }
        }

        private double curMonthWithSilents;

        public double CurMonthWithSilents
        {
            get { return curMonthWithSilents; }
            set { curMonthWithSilents = value; }
        }

        private double ytd;

        public double YTD
        {
            get { return ytd; }
            set { ytd = value; }
        }

        private double ytdWithSilents;

        public double YTDWithSilents
        {
            get { return ytdWithSilents; }
            set { ytdWithSilents = value; }
        }
    }
}
