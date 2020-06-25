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
    public class NeedPSS
    {
        public ObservableCollection<Member> members;
        public NeedPSS()
        {
            MemberCollection memberCollection = new MemberCollection();
            members = new ObservableCollection<Member>();

            foreach (Member member in memberCollection.members)
            {
                bool addToList = false;
                foreach (TrainingActivity training in member.DepartmentTrainings)
                {
                    if (training.TrainingName == "P.S.S.- Refresher" && member.DepartmentClass == "A")
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
