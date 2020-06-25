using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.ViewModels
{
    public class MemberCollection
    {
        public ObservableCollection<Member> members;
        public MemberCollection()
        {
            members = CreateMemberCollection();
        }
        public ObservableCollection<Member> CreateMemberCollection()
        {
            ResourceManager stringResourceManager = SharedResources.Properties.StringResource.ResourceManager;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Member>));
            StreamReader streamReader = new StreamReader(stringResourceManager.GetString("memberXMLPath"));
            ObservableCollection<Member> members = (ObservableCollection<Member>)xmlSerializer.Deserialize(streamReader);
            return members;
        }
    }   
}
