using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace SplitMemberXML
{
    class Program
    {
        static void Main()
        {
            MemberCollection memberCollection = new MemberCollection();
            List<Member> hookAndLadder = new List<Member>();
            List<Member> hose1 = new List<Member>();
            List<Member> probation = new List<Member>();

            ResourceManager stringResourceManager = SharedResources.Properties.StringResource.ResourceManager;

            foreach (Member member in memberCollection.members)
            {
                switch (member.Company)
                {
                    case "H&L #1":
                        hookAndLadder.Add(member);
                        break;
                    case "HOSE #1":
                        hose1.Add(member);
                        break;
                    default:
                        break;
                }
                if (member.DepartmentClass == stringResourceManager.GetString("probation"))
                {
                    probation.Add(member);
                }
            }
            XmlSerializer hAndLSerializer = new XmlSerializer(typeof(List<Member>));
            StreamWriter hAndLWriter = new StreamWriter(stringResourceManager.GetString("hookAndLadderXMLPath"));
            hAndLSerializer.Serialize(hAndLWriter, hookAndLadder);
            XmlSerializer hose1Serializer = new XmlSerializer(typeof(List<Member>));
            StreamWriter hose1Writer = new StreamWriter(stringResourceManager.GetString("hose1XMLPath"));
            hose1Serializer.Serialize(hose1Writer, hose1);
            XmlSerializer probationSerializer = new XmlSerializer(typeof(List<Member>));
            StreamWriter probationWriter = new StreamWriter(stringResourceManager.GetString("probationXMLPath"));
            probationSerializer.Serialize(probationWriter, probation);
        }
    }
}
