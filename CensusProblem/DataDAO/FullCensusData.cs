using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem.DataDAO
{
    public class FullCensusData
    {
        public string state;
        public string population;
        public string increase;
        public long area;
        public long density;
        public int sex_ratio;
        public double literacy;
        public int serialNum;
        public string stateName;
        public int stateCode;
        //parameterized constructor for state census data
        public FullCensusData(CensusData censusData)
        {
            this.state = censusData.state;
            this.population = censusData.population;
            this.increase = censusData.increase;
            this.area = Convert.ToUInt32(censusData.area);
            this.density = Convert.ToUInt32(censusData.density);
            this.sex_ratio = Convert.ToInt32(censusData.sex_ratio);
            this.literacy = Convert.ToDouble(censusData.literacy);
        }

        //Parameterized constructor for state code data
        public FullCensusData(StateData stateData)
        {
            this.serialNum = stateData.serialNum;
            this.stateName = stateData.stateName;
            this.stateCode = stateData.stateCode;
        }
    }
}
