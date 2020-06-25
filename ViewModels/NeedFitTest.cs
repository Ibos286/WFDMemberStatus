using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.ViewModels
{
    public class NeedFitTest
    {
        public ObservableCollection<Member> members;
        public NeedFitTest()
        {
            MemberCollection memberCollection = new MemberCollection();
            members = new ObservableCollection<Member>();

            foreach (Member member in memberCollection.members)
            {
                bool addToList = true;
                foreach (TrainingActivity training in member.DepartmentTrainings)
                {
                    if (training.TrainingName == "SCBA Annual Fit Test")
                    {
                        if (training.TrainingDate != default)
                        {
                            addToList = false;
                        }
                    }              
                }
                if (addToList) members.Add(member);
            }
        }
    }
}
