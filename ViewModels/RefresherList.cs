using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.ViewModels
{
    public class RefresherList
    {
        public ObservableCollection<Member> refresherListCollection;
        public RefresherList()
        {
           
            MemberCollection memberCollection = new MemberCollection();
            refresherListCollection = new ObservableCollection<Member>();
            foreach (Member member in memberCollection.members)
            {
                bool needsRefresher = true;
                if (member.YearsOfService < 20)
                {
                    foreach (TrainingActivity training in member.RefresherAttendance)
                    {
                        if (training.TrainingDate != default)
                        {
                            needsRefresher = false;
                        }
                    }
                    if (needsRefresher)
                    {
                        refresherListCollection.Add(member);
                    }
                }
            }
        }
    }
}
