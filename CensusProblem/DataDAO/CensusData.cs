using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusProblem.DataDAO
{
    public class CensusData
    {
        /// <summary>
        /// ﻿State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy
        /// </summary>
        public string state;
        public string population;
        public string increase;
        public long area;
        public long density;
        public int sex_ratio;
        public double literacy;


        //Paramaterized constructor to initialize variables
        public CensusData(string state, string population, string increase, string area, string density, string sex_ratio, string literacy)
        {
            this.state = state;
            this.population = population;
            this.increase = increase;
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
            this.sex_ratio = Convert.ToInt32(sex_ratio);
            this.literacy = Convert.ToDouble(literacy);
            
        }
    }
}
