using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.ViewModels
{
    public class HazMatRefresherList
    {
        public ObservableCollection<Member> members;
        public HazMatRefresherList()
        {
            MemberCollection memberCollection = new MemberCollection();
            members = new ObservableCollection<Member>();

            foreach (Member member in memberCollection.members)
            {
                bool addToList = true;
                foreach (TrainingActivity training in member.DepartmentTrainings)
                {
                    if (training.TrainingName == "HazMat Operations Refresher")
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
