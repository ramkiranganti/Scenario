using ScenarioAPI.DTO;
using ScenarioAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ScenarioAPI.Services
{
    public class ScenarioService : IScenarioService
    {

        public IList<Scenario> GetScenarios(string filePath)
        {
            try
            {               
                string docPath = Directory.GetCurrentDirectory().Replace(@"\bin\debug", string.Empty) + filePath;

                // Loading from a file
                var xml = XDocument.Load(docPath);

                // Query the data and write out a subset of Data
                var elements = from s in xml.Root.Descendants("Scenario")
                                    select s;
                IList<Scenario> scenarios = new List<Scenario>();
                foreach (XElement element in elements)
                {
                    Scenario scenario = new Scenario();

                    if (element.Element("ScenarioID") != null)
                    {
                        if (int.TryParse(element.Element("ScenarioID").Value, out int sid))
                        {
                            scenario.ScenarioID = sid;
                        }
                    }

                    if (element.Element("Name") != null)
                    {
                        scenario.Name = element.Element("Name").Value;
                    }

                    if (element.Element("Forename") != null)
                    {
                        scenario.Forename = element.Element("Forename").Value;
                    }

                    if (element.Element("UserID") != null)
                    {
                        scenario.UserID = element.Element("UserID").Value;
                    }

                    if (element.Element("SampleDate") != null)
                    {
                        if (DateTime.TryParse(element.Element("SampleDate").Value, out DateTime sdate))
                        {
                            scenario.SampleDate = sdate;
                        }
                    }                       

                    if (element.Element("CreationDate") != null)
                    {
                        if (DateTime.TryParse(element.Element("CreationDate").Value, out DateTime cdate))
                        {
                            scenario.CreationDate = cdate;
                        }
                    }

                    if (element.Element("NumMonths") != null)
                    {
                        if (int.TryParse(element.Element("NumMonths").Value, out int numMonths))
                        {
                            scenario.NumMonths = numMonths;
                        }
                    }

                    if(element.Element("MarketID") != null)
                    {
                        if (int.TryParse(element.Element("MarketID").Value, out int mid))
                        {
                            scenario.MarketID = mid;
                        }
                    }

                    if (element.Element("NetworkLayerID") != null)
                    {
                        if (int.TryParse(element.Element("NetworkLayerID").Value, out int nlid))
                        {
                            scenario.NetworkLayerID = nlid;
                        }
                    }

                    scenarios.Add(scenario);
                }
                return scenarios;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}
