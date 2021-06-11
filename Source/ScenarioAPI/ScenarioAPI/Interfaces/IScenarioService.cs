using ScenarioAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScenarioAPI.Interfaces
{
    public interface IScenarioService
    {
        IList<Scenario> GetScenarios(string fileName);
    }
}
