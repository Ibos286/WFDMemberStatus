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

namespace AttachTrainingsAndPercentages
{
    class Program
    {
        public static readonly DateTime flagDate = Convert.ToDateTime("01/01/0001");

        static private List<Member> members;

        static private List<Training> departmentTrainings;
        static private List<Training> peshTrainings;
        static private List<Training> probationTrainings;
        static private List<Training> refresherTrainings;

        static private List<Percentage> memberPercentages;
        static private List<Percentage> probationPercentages;

        private static readonly ResourceManager stringResourceManager = SharedResources.Properties.StringResource.ResourceManager;
        private static readonly ResourceManager drillResourceManager = SharedResources.Properties.ProbationDrillDates.ResourceManager;

        static void Main()
        {
            XmlSerializer memberSerializer = new XmlSerializer(typeof(List<Member>));
            StreamReader memberStreamReader = new StreamReader(stringResourceManager.GetString("memberXMLPath"));
            members = (List<Member>)memberSerializer.Deserialize(memberStreamReader);
            memberStreamReader.Close();

            XmlSerializer trainingSerializer = new XmlSerializer(typeof(List<Training>));
            StreamReader departmentTrainingStreamReader = new StreamReader(stringResourceManager.GetString("departmentTrainingXMLPath"));
            departmentTrainings = (List<Training>)trainingSerializer.Deserialize(departmentTrainingStreamReader);

            StreamReader peshTrainingStreamReader = new StreamReader(stringResourceManager.GetString("peshTrainingXMLPath"));
            peshTrainings = (List<Training>)trainingSerializer.Deserialize(peshTrainingStreamReader);

            StreamReader probationTrainingStreamReader = new StreamReader(stringResourceManager.GetString("probationTrainingXMLPath"));
            probationTrainings = (List<Training>)trainingSerializer.Deserialize(probationTrainingStreamReader);

            StreamReader refresherTrainingStreamReader = new StreamReader(stringResourceManager.GetString("refresherTrainingXMLPath"));
            refresherTrainings = (List<Training>)trainingSerializer.Deserialize(refresherTrainingStreamReader);

            XmlSerializer percentageSerializer = new XmlSerializer(typeof(List<Percentage>));
            StreamReader memberPercentageStreamReader = new StreamReader(stringResourceManager.GetString("memberPercentageXMLPath"));
            memberPercentages = (List<Percentage>)percentageSerializer.Deserialize(memberPercentageStreamReader);

            StreamReader probationPercentageStreamReader = new StreamReader(stringResourceManager.GetString("probationPercentageXMLPath"));
            probationPercentages = (List<Percentage>)percentageSerializer.Deserialize(probationPercentageStreamReader);

            List<Training> foundTrainings;
            foreach (Member member in members)
            {
                foundTrainings = departmentTrainings.FindAll(delegate (Training training) { return training.Badge == member.Badge; });
                if (foundTrainings.Count > 0)
                {
                    IEnumerable<Training> trainingList = foundTrainings.GroupBy(x => x.TrainingName).Select(x => x.Last());
                    foreach (Training training in foundTrainings)
                    {
                        member.DepartmentTrainings.Add(new TrainingActivity { TrainingDate = training.ActivityDate, TrainingName = training.TrainingName });                    
                    }
                }

                foundTrainings = peshTrainings.FindAll(delegate (Training training) { return training.Badge == member.Badge; });
                if (foundTrainings.Count > 0)
                {
                    IEnumerable<Training> trainingList = foundTrainings.GroupBy(x => x.TrainingName).Select(x => x.Last());
                    foreach (Training training in trainingList)
                    {
                        member.PESHTrainings.Add(new TrainingActivity { TrainingDate = training.ActivityDate, TrainingName = training.TrainingName });                     
                    }
                }

                foundTrainings = refresherTrainings.FindAll(delegate (Training training) { return training.Badge == member.Badge; });
                if (foundTrainings.Count > 0)
                {
                    IEnumerable<Training> trainingList = foundTrainings.GroupBy(x => x.TrainingName).Select(x => x.Last());
                    foreach (Training training in foundTrainings)
                    {
                        member.RefresherAttendance.Add(new TrainingActivity { TrainingDate = training.ActivityDate, TrainingName = training.TrainingName });
                    }
                }

                member.CurrentPercentage = memberPercentages.Find(delegate (Percentage findPercentage) { return findPercentage.Badge == member.Badge; });

                if (member.DepartmentClass == stringResourceManager.GetString("probation"))
                {
                    member.ProbationPercentage = probationPercentages.Find(delegate (Percentage findPercentage) { return findPercentage.Badge == member.Badge; });
                    foundTrainings = probationTrainings.FindAll(delegate (Training training) { return training.Badge == member.Badge; });
                    if (foundTrainings.Count > 0)
                    {
                        member.ProbationDrill = new Models.ProbationDrillAttendance();
                        member.ProbationTrainingList = new Models.ProbationTrainingRequirements();
                        foreach (Training training in foundTrainings)
                        {
                            switch (training.TrainingName)
                            {
                                case "January Probationary Drill":
                                    member.ProbationDrill.JanDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "February Probationary Drill":
                                    member.ProbationDrill.FebDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "March Probationary Drill":
                                    member.ProbationDrill.MarDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "April Probationary Drill":
                                    member.ProbationDrill.AprDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "May Probationary Drill":
                                    member.ProbationDrill.MayDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "June Probationary Drill":
                                    member.ProbationDrill.JunDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "July Probationary Drill":
                                    member.ProbationDrill.JulDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "August Probationary Drill":
                                    member.ProbationDrill.AugDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "September Probationary Drill":
                                    member.ProbationDrill.SepDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "October Probationary Drill":
                                    member.ProbationDrill.OctDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "November Probationary Drill":
                                    member.ProbationDrill.NovDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "December Probationary Drill":
                                    member.ProbationDrill.DecDrill = SetProbationDrillAttendance(training.TrainingName, training.ActivityDate, member.ProbationStartDate);
                                    break;
                                case "CPR":
                                    member.ProbationTrainingList.CPR = training.ActivityDate;
                                    break;
                                case "Essentials of Firefighting":
                                    member.ProbationTrainingList.Essentials = training.ActivityDate;
                                    break;
                                case "Firefighter I":
                                    member.ProbationTrainingList.FirefighterI = training.ActivityDate;
                                    break;
                                case "Flash Hood Training Video":
                                    member.ProbationTrainingList.FlashHood = training.ActivityDate;
                                    break;
                                case "NIMS 100":
                                    member.ProbationTrainingList.NIMS100 = training.ActivityDate;
                                    break;
                                case "NIMS 200":
                                    member.ProbationTrainingList.NIMS200 = training.ActivityDate;
                                    break;
                                case "NIMS 700":
                                    member.ProbationTrainingList.NIMS700 = training.ActivityDate;
                                    break;
                                case "NIMS 800":
                                    member.ProbationTrainingList.NIMS800 = training.ActivityDate;
                                    break;
                                case "Orientation":
                                    member.ProbationTrainingList.Orientation = training.ActivityDate;
                                    break;
                                case "Primary Training":
                                    member.ProbationTrainingList.PrimaryTraining = training.ActivityDate;
                                    break;
                                case "SCBA Annual Fit Test":
                                    member.ProbationTrainingList.SCBAFitTest = training.ActivityDate;
                                    break;
                                case "SCBA Initial Mask Confidence":
                                    member.ProbationTrainingList.SCBAConfidence = training.ActivityDate;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            StreamWriter memberStreamWriter = new StreamWriter(stringResourceManager.GetString("memberXMLPath"));
            memberSerializer.Serialize(memberStreamWriter, members);

            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        }
        private static string SetProbationDrillAttendance(string trainingName, DateTime trainingDate, DateTime probationStartDate)
        {
            DateTime actualDrillDate;
            DateTime today = DateTime.Now;
            DateTime flagDate = Convert.ToDateTime("01/01/0001");
            string attendance;

            actualDrillDate = Convert.ToDateTime(drillResourceManager.GetString(trainingName));

            if (trainingDate != flagDate)
            {
                attendance = trainingDate.Date.ToString("d");
            }
            else
            {
                if (probationStartDate < actualDrillDate && trainingDate == flagDate && actualDrillDate < today)
                {

                    attendance = "Absent";
                }
                else
                {
                    TimeSpan timeSpan = actualDrillDate - probationStartDate;
                    double days = timeSpan.TotalDays;
                    if (days > 365)
                    {
                        attendance = "Absent";
                    }
                    else
                    {
                        attendance = "N/A";
                    }
                }
            }
            return attendance;
        }
    }
}
