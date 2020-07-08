using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;
using WFDMemberStatus.Models;

namespace WFDMemberStatus.CreateXMLFiles
{
    class Program
    {
        public const int flagInt = -1;
        public const long flagLong = -1;
        public const double flagDouble = -1.00;
        public static readonly DateTime flagDate = Convert.ToDateTime("01/01/0001");
        public static ResourceManager stringResourceManager;
        enum Cats
        {
            Roster = 0,
            Training = 1,
            Percentage = 2,
            Strings = 3
        }
        static void Main()
        {
            List<ResourceManager> resourceManagers = SetUpResourceManagers();

            if (resourceManagers[(int)Cats.Strings] != null)
            {
                stringResourceManager = resourceManagers[(int)Cats.Strings];
            }
            else
            {
                WriteMessageAndExit("String Resource Manager is null");
            }
            string path = stringResourceManager.GetString("RosterPath");
            TextFieldParser rosterParser = CreateTextFieldParser(Cats.Roster, resourceManagers, path);
            List<Member> members = CreateRosterXML(rosterParser);
            XmlSerializer rosterSerializer = new XmlSerializer(typeof(List<Member>));
            StreamWriter rosterWriter = new StreamWriter(stringResourceManager.GetString("memberXMLPath"));
            rosterSerializer.Serialize(rosterWriter, members);

            path = stringResourceManager.GetString("DepartmentTrainingPath");
            TextFieldParser departmentTrainingParser = CreateTextFieldParser(Cats.Training, resourceManagers,path);
            List<Training> departmentTrainings = CreateTrainingXML(departmentTrainingParser);
            XmlSerializer departmentTrainingSerializer = new XmlSerializer(typeof(List<Training>));
            StreamWriter departmentTrainingWriter = new StreamWriter(stringResourceManager.GetString("departmentTrainingXMLPath"));
            departmentTrainingSerializer.Serialize(departmentTrainingWriter, departmentTrainings);

            path = stringResourceManager.GetString("PESHTrainingPath");
            TextFieldParser peshTrainingParser = CreateTextFieldParser(Cats.Training, resourceManagers, path);
            List<Training> peshTrainings = CreateTrainingXML(peshTrainingParser);
            XmlSerializer peshTrainingSerializer = new XmlSerializer(typeof(List<Training>));
            StreamWriter peshTrainingWriter = new StreamWriter(stringResourceManager.GetString("peshTrainingXMLPath"));
            peshTrainingSerializer.Serialize(peshTrainingWriter, peshTrainings);

            path = stringResourceManager.GetString("RefresherTrainingPath");
            TextFieldParser refresherTrainingParser = CreateTextFieldParser(Cats.Training, resourceManagers, path);
            List<Training> refresherTrainings = CreateTrainingXML(refresherTrainingParser);
            XmlSerializer refresherTrainingSerializer = new XmlSerializer(typeof(List<Training>));
            StreamWriter refresherTrainingWriter = new StreamWriter(stringResourceManager.GetString("refresherTrainingXMLPath"));
            refresherTrainingSerializer.Serialize(refresherTrainingWriter, refresherTrainings);

            path = stringResourceManager.GetString("ProbationTrainingPath");
            TextFieldParser probationTrainingParser = CreateTextFieldParser(Cats.Training, resourceManagers, path);
            List<Training> probationTrainings = CreateTrainingXML(probationTrainingParser);
            XmlSerializer probationTrainingSerializer = new XmlSerializer(typeof(List<Training>));
            StreamWriter probationTrainingWriter = new StreamWriter(stringResourceManager.GetString("probationTrainingXMLPath"));
            probationTrainingSerializer.Serialize(probationTrainingWriter, probationTrainings);

            path = stringResourceManager.GetString("MemberPercentagePath");
            TextFieldParser memberPercentageParser = CreateTextFieldParser(Cats.Percentage, resourceManagers, path);
            List<Percentage> memberPercentages = CreatePercentageXML(memberPercentageParser);
            XmlSerializer memberPercentageSerializer = new XmlSerializer(typeof(List<Percentage>));
            StreamWriter memberPercentageWriter = new StreamWriter(stringResourceManager.GetString("memberPercentageXMLPath"));
            memberPercentageSerializer.Serialize(memberPercentageWriter, memberPercentages);

            path = stringResourceManager.GetString("ProbationPercentagePath");
            TextFieldParser probationPercentageParser = CreateTextFieldParser(Cats.Percentage, resourceManagers, path);
            List<Percentage> probationPercentages = CreatePercentageXML(probationPercentageParser);
            XmlSerializer probationPercentageSerializer = new XmlSerializer(typeof(List<Percentage>));
            StreamWriter probationPercentageWriter = new StreamWriter(stringResourceManager.GetString("probationPercentageXMLPath"));
            probationPercentageSerializer.Serialize(probationPercentageWriter, probationPercentages);

            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        private static void WriteMessageAndExit(string msg)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();
            Environment.Exit(1);
        }
        private static List<Training> CreateTrainingXML(TextFieldParser textFieldParser)
        {
            List<Training> trainings = new List<Training>();
            Training training;

            while (!textFieldParser.EndOfData)
            {
                string[] fields = textFieldParser.ReadFields();
                if (!string.IsNullOrEmpty(fields[0]))
                {
                    training = new Training() { TrainingName = fields[1] };
                    if (!string.IsNullOrEmpty(fields[0]))
                    {
                        int intResult = ParseInteger(fields[0]);
                        if (intResult != flagInt)
                        {
                            training.Badge = intResult;
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[2]))
                    {
                        DateTime dateTime = ParseDateTime(fields[2]);
                        if (dateTime != flagDate)
                        {
                            training.ActivityDate = dateTime;
                        }
                    }
                    trainings.Add(training);
                }
            }
            return trainings;
        }
        private static List<Member> CreateRosterXML(TextFieldParser textFieldParser)
        {
            List<Member> members = new List<Member>();
            Member member;

            while (!textFieldParser.EndOfData)
            {
                string[] fields = textFieldParser.ReadFields();
                if (!string.IsNullOrEmpty(fields[0]))
                {
                    member = new Member()
                    {
                        Company = fields[0],
                        LastName = fields[2],
                        FirstName = fields[3],
                        Address = fields[5],
                        Address2 = fields[6],
                        City = fields[7],
                        State = fields[8],
                        ZipCode = fields[9],
                        PhoneNumber = fields[10],
                        CellPhone = fields[11],
                        DepartmentClass = fields[12],
                        TimeOfService = fields[21]
                    };
                    if (fields[13] == "Member")
                    {
                        member.DepartmentOffice = "F/F";
                    }
                    else
                    {
                        member.DepartmentOffice = fields[13];
                    }
                    if (!string.IsNullOrEmpty(fields[1]))
                    {
                        int intResult = ParseInteger(fields[1]);
                        if (intResult != flagInt)
                        {
                            member.Badge = intResult;
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[4]))
                    {
                        DateTime dateTime = ParseDateTime(fields[4]);
                        if (dateTime != flagDate)
                        {
                            member.BirthDate = dateTime;
                            member.Age = CalculateAge(member.BirthDate);
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[15]))
                    {
                        DateTime dateTime = ParseDateTime(fields[15]);
                        if (dateTime != flagDate)
                        {
                            member.ServiceDate = dateTime;
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[16]))
                    {
                        int intResult = ParseInteger(fields[16]);
                        if (intResult != flagInt)
                        {
                            member.YearsOfService = intResult;
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[17]))
                    {
                        long longResult = ParseLong(fields[17]);
                        if (longResult != flagLong)
                        {
                            member.FSANumber = longResult;
                        }
                    }
                    if (!string.IsNullOrEmpty(fields[20]))
                    {
                        List<ApparatusQualification> qualifications = ParseQualifications(fields[20]);
                        member.Qualifications = qualifications;
                    }

                    if (member.DepartmentClass == stringResourceManager.GetString("probation"))
                    {
                        member.ProbationStartDate = member.ServiceDate;
                    }

                    members.Add(member);
                }
            }

            return members;
        }

        private static int CalculateAge(DateTime birthday)
        {
            int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthday.ToString("yyyyMMdd"));

            return (today - dob) / 10000;
        }
        private static List<Percentage> CreatePercentageXML(TextFieldParser textFieldParser)
        {
            List<Percentage> percentages = new List<Percentage>();
            Percentage percentage;

            while (!textFieldParser.EndOfData)
            {
                string[] fields = textFieldParser.ReadFields();
                if (!String.IsNullOrEmpty(fields[2]))
                {
                    percentage = new Percentage();

                    if (!String.IsNullOrEmpty(fields[2]))
                    {
                        int intResult = ParseInteger(fields[2]);
                        if (intResult != flagInt) percentage.Badge = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[4]))
                    {
                        int intResult = ParseInteger(fields[4]);
                        if (intResult != flagInt) percentage.AutoAcc = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[17]))
                    {
                        double doubleResult = ParseDouble(fields[17]);
                        if (doubleResult != flagInt) percentage.CurMonth = doubleResult;
                    }

                    if (!String.IsNullOrEmpty(fields[18]))
                    {
                        double doubleResult = ParseDouble(fields[18]);
                        if (doubleResult != flagInt) percentage.CurMonthWithSilents = doubleResult;
                    }

                    if (!String.IsNullOrEmpty(fields[10]))
                    {
                        int intResult = ParseInteger(fields[10]);
                        if (intResult != flagInt) percentage.DrillCom = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[8]))
                    {
                        int intResult = ParseInteger(fields[8]);
                        if (intResult != flagInt) percentage.DrillDpt = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[3]))
                    {
                        int intResult = ParseInteger(fields[3]);
                        if (intResult != flagInt) percentage.FireDay = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[4]))
                    {
                        int intResult = ParseInteger(fields[4]);
                        if (intResult != flagInt) percentage.FireNight = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[12]))
                    {
                        int intResult = ParseInteger(fields[12]);
                        if (intResult != flagInt) percentage.MeetCom = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[11]))
                    {
                        int intResult = ParseInteger(fields[11]);
                        if (intResult != flagInt) percentage.MeetDpt = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[9]))
                    {
                        int intResult = ParseInteger(fields[9]);
                        if (intResult != flagInt) percentage.MiscCom = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[5]))
                    {
                        int intResult = ParseInteger(fields[5]);
                        if (intResult != flagInt) percentage.RescueDay = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[6]))
                    {
                        int intResult = ParseInteger(fields[6]);
                        if (intResult != flagInt) percentage.RescueNight = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[16]))
                    {
                        int intResult = ParseInteger(fields[16]);
                        if (intResult != flagInt) percentage.Silent = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[15]))
                    {
                        int intResult = ParseInteger(fields[15]);
                        if (intResult != flagInt) percentage.Total = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[14]))
                    {
                        int intResult = ParseInteger(fields[14]);
                        if (intResult != flagInt) percentage.TrainCom = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[13]))
                    {
                        int intResult = ParseInteger(fields[13]);
                        if (intResult != flagInt) percentage.TrainDpt = intResult;
                    }

                    if (!String.IsNullOrEmpty(fields[19]))
                    {
                        double doubleResult = ParseDouble(fields[19]);
                        if (doubleResult != flagInt) percentage.YTD = doubleResult;
                    }

                    if (!String.IsNullOrEmpty(fields[20]))
                    {
                        double doubleResult = ParseDouble(fields[20]);
                        if (doubleResult != flagLong) percentage.YTDWithSilents = doubleResult;
                    }

                    percentages.Add(percentage);
                }
            }
            return percentages;
        }
        private static List<ResourceManager> SetUpResourceManagers()
        {
            ResourceManager rosterResourceManager = SharedResources.Properties.RosterColumnHeadings.ResourceManager;
            ResourceManager trainingResourceManager = SharedResources.Properties.TrainingColumnHeadings.ResourceManager;
            ResourceManager percentageResourceManager = SharedResources.Properties.Percentage.ResourceManager;
            ResourceManager stringResourceManager = SharedResources.Properties.StringResource.ResourceManager;

            List<ResourceManager> resourceManagers = new List<ResourceManager>
            {
                rosterResourceManager,
                trainingResourceManager,
                percentageResourceManager,
                stringResourceManager
            };

            return resourceManagers;
        }
        private static TextFieldParser CreateTextFieldParser(Cats cat, List<ResourceManager> resourceManagers, string path)
        {
            string checkPath;
            ResourceManager resourceManager;
            TextFieldParser textFieldParser = null;
            resourceManager = null;

            try
            {
                resourceManager = resourceManagers[(int)cat];
            }
            catch (Exception)
            {
                WriteMessageAndExit(stringResourceManager.GetString("badResourceManager"));
            }
            

            switch (cat)
            {
                case Cats.Roster:
                    if (resourceManager != null)
                    {
                        checkPath = CheckFilePath(path);
                        textFieldParser = SetupTextFieldParser(checkPath);
                        if (!textFieldParser.EndOfData)
                        {
                            string[] fields = textFieldParser.ReadFields();
                            if (!(CheckRosterParser(fields, resourceManager)))
                            {
                                WriteMessageAndExit(stringResourceManager.GetString("rosterParserFailedCheck"));
                            }
                        }
                    }
                    break;
                case Cats.Training:
                    if (resourceManager != null)
                    {
                        checkPath = CheckFilePath(path);
                        textFieldParser = SetupTextFieldParser(checkPath);
                        if (!textFieldParser.EndOfData)
                        {
                            string[] fields = textFieldParser.ReadFields();
                            if (!CheckTrainingParser(fields, resourceManager))
                            {
                                WriteMessageAndExit(stringResourceManager.GetString("badTrainingFile") + ": " + path);
                            }
                        }
                    }
                    break;
                case Cats.Percentage:
                    if (resourceManager != null)
                    {
                        checkPath = CheckFilePath(path);
                        textFieldParser = SetupTextFieldParser(checkPath);
                        if (!textFieldParser.EndOfData)
                        {
                            string[] fields = textFieldParser.ReadFields();
                            if (!(CheckPercentageParser(fields, resourceManager)))
                            {
                                Console.WriteLine(resourceManagers[(int)Cats.Strings].GetString("badPercentageFile"));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return textFieldParser;
        }
        private static string CheckFilePath(string checkPath)
        {
            string path = null;

            if (checkPath != null)
            {
                try
                {
                    path = Path.GetFullPath(checkPath);
                }
                catch (Exception ex)
                {
                    WriteMessageAndExit(ex.Message.ToString());
                    throw;
                }
            }
            return path;
        }
        private static TextFieldParser SetupTextFieldParser(string path)
        {
            TextFieldParser textFieldParser = null;
            //Set Up the TextFieldParser
            try
            {
                textFieldParser = FileSystem.OpenTextFieldParser(path);
            }
            catch (Exception)
            {
                WriteMessageAndExit(stringResourceManager.GetString("textFieldParserFailedOpen"));
            }
            
            textFieldParser.Delimiters = new string[] { "," };
            textFieldParser.HasFieldsEnclosedInQuotes = true;
            textFieldParser.TextFieldType = FieldType.Delimited;
            return textFieldParser;
        }
        private static bool CheckRosterParser(string[] fields, ResourceManager resourceManager)
        {
            bool ret;

            if (!(fields[0] == resourceManager.GetString("Company") &&
                                    fields[1] == resourceManager.GetString("Badge") &&
                                    fields[2] == resourceManager.GetString("LastName") &&
                                    fields[3] == resourceManager.GetString("FirstName") &&
                                    fields[4] == resourceManager.GetString("BirthDate") &&
                                    fields[5] == resourceManager.GetString("Address") &&
                                    fields[6] == resourceManager.GetString("Address2") &&
                                    fields[7] == resourceManager.GetString("City") &&
                                    fields[8] == resourceManager.GetString("State") &&
                                    fields[9] == resourceManager.GetString("ZipCode") &&
                                    fields[10] == resourceManager.GetString("PhoneNumber") &&
                                    fields[11] == resourceManager.GetString("CellNumber") &&
                                    fields[12] == resourceManager.GetString("DepartmentClass") &&
                                    fields[13] == resourceManager.GetString("DepartmentOffice") &&
                                    fields[14] == resourceManager.GetString("EmailAddress") &&
                                    fields[15] == resourceManager.GetString("ServiceDate") &&
                                    fields[16] == resourceManager.GetString("YearsOfService") &&
                                    fields[17] == resourceManager.GetString("FSANumber") &&
                                    fields[18] == resourceManager.GetString("FEMANumber") &&
                                    fields[20] == resourceManager.GetString("Qualifications") &&
                                    fields[21] == resourceManager.GetString("TimeOfService")))
            {
                ret = false;
            }
            else
            {
                ret = true;
            }
            return ret;
        }
        private static bool CheckTrainingParser(string[] fields, ResourceManager resourceManager)
        {
            bool ret = fields[1] == resourceManager.GetString("TrainingName") &&
                                    fields[0] == resourceManager.GetString("Badge") &&
                                    fields[2] == resourceManager.GetString("ActivityDate");
            return ret;
        }
        private static bool CheckPercentageParser(string[] fields, ResourceManager resourceManager)
        {
            bool ret;

            if (!(fields[7] == resourceManager.GetString("AutoAcc") &&
                                    fields[2] == resourceManager.GetString("Badge") &&
                                    fields[17] == resourceManager.GetString("CurMonth") &&
                                    fields[10] == resourceManager.GetString("DrillCom") &&
                                    fields[8] == resourceManager.GetString("DrillDpt") &&
                                    fields[3] == resourceManager.GetString("FireDay") &&
                                    fields[4] == resourceManager.GetString("FireNight") &&
                                    fields[12] == resourceManager.GetString("MeetCom") &&
                                    fields[11] == resourceManager.GetString("MeetDpt") &&
                                    fields[9] == resourceManager.GetString("MiscCom") &&
                                    fields[5] == resourceManager.GetString("RescueDay") &&
                                    fields[6] == resourceManager.GetString("RescueNight") &&
                                    fields[16] == resourceManager.GetString("Silent") &&
                                    fields[15] == resourceManager.GetString("Total") &&
                                    fields[14] == resourceManager.GetString("TrainCom") &&
                                    fields[13] == resourceManager.GetString("TrainDpt") &&
                                    fields[18] == resourceManager.GetString("YTD") &&
                                    fields[19] == resourceManager.GetString("YTDWithSilents")))
            {
                ret = false;
            }
            else
            {
                ret = true;
            }
            return ret;
        }
        private static int ParseInteger(string inputString)
        {
            int result = flagInt;

            if (!String.IsNullOrEmpty(inputString))
            {
                try
                {
                    result = Int32.Parse(inputString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    result = flagInt;
                }
            }
            return result;
        }
        private static long ParseLong(string inputString)
        {
            long result = flagLong;

            if (!String.IsNullOrEmpty(inputString))
            {
                try
                {
                    result = long.Parse(inputString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    result = flagLong;
                }
            }
            return result;
        }
        private static DateTime ParseDateTime(string inputString)
        {
            DateTime result = flagDate;

            if (!String.IsNullOrEmpty(inputString))
            {
                try
                {
                    result = Convert.ToDateTime(inputString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    result = flagDate;
                }
            }
            return result;
        }
        private static double ParseDouble(string inputString)
        {
            double result = flagDouble;

            if (!String.IsNullOrEmpty(inputString))
            {
                try
                {
                    result = double.Parse(inputString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return result;
                }
            }

            return result;
        }
        private static List<ApparatusQualification> ParseQualifications(string qualificationString)
        {
            ApparatusQualification apparatusQualification;
            int intResult = flagInt;
            List<ApparatusQualification> qualifications = new List<ApparatusQualification>();
            StringReader stringReader = new StringReader(qualificationString);
            using (TextFieldParser parser = new TextFieldParser(stringReader))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string item in fields)
                    {
                        if (!String.IsNullOrEmpty(item)) intResult = ParseInteger(item);
                        if (intResult != flagInt)
                        {
                            qualifications.Add(apparatusQualification = new ApparatusQualification() { ApparatusNumber = intResult });
                        }
                    }
                }
            }

            return qualifications;
        }
    }
}
