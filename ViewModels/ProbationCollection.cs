using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.ViewModels
{
    public class ProbationCollection
    {
        private ResourceManager stringResourceManager = SharedResources.Properties.StringResource.ResourceManager;
        public ObservableCollection<Member> members;
        public ProbationCollection()
        {
            members = CreateProbationMembers();
        }
        private ObservableCollection<Member> CreateProbationMembers()
        {
            MemberCollection allMembers = new MemberCollection();
            List<Member> probationMembers = allMembers.members.Where(x => x.DepartmentClass == stringResourceManager.GetString("probation")).ToList();
            return new ObservableCollection<Member>( probationMembers);
        }
    }
}
