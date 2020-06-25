using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.ViewModels
{
    public class NeedMaskConfidenceList
    {
        public ObservableCollection<Member> members;

        public NeedMaskConfidenceList()
        {
            MemberCollection memberCollection = new MemberCollection();
            members = new ObservableCollection<Member>();

            foreach (Member member in memberCollection.members)
            {
                bool addToList = false;
                foreach (TrainingActivity training in member.DepartmentTrainings)
                {
                    if (training.TrainingName == "SCBA Annual Mask Confidence" && member.DepartmentClass == "A")
                    {
                        if (training.TrainingDate == default)
                        {
                            addToList = true;
                        }
                    }
                }
                if (addToList) members.Add(member);
            }
        }
    }
}
