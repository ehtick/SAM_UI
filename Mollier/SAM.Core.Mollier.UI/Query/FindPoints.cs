﻿using System.Collections.Generic;
using SAM.Geometry.Mollier;
using SAM.Geometry.Planar;

namespace SAM.Core.Mollier.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Sorts points by enthalpy or temperature depends on find point type in mollier control settings
        /// Then returns a point that is in % position in the sequence 
        /// </summary>
        /// <param name="mollierPoints">Mollier points</param>
        /// <param name="mollierControlSettings">mollier control settings</param>
        /// <returns>Found point</returns>
        public static Point2D FindPoint(this List<UIMollierPoint> mollierPoints, MollierControlSettings mollierControlSettings)
        {
            bool generate = mollierControlSettings.FindPoint;
            double percent = mollierControlSettings.FindPoint_Factor;
            ChartType chartType = mollierControlSettings.ChartType;

            if (mollierPoints == null || mollierPoints.Count < 4 || generate == false || percent > 100 || percent < 0)
            {
                return null;
            }

            int index = System.Convert.ToInt32((1 - percent / 100) * mollierPoints.Count) - 1;
            if (index < 0)
            {
                index = 0;
            }

            List<UIMollierPoint> uIMollierPoints = new List<UIMollierPoint>(mollierPoints);
            switch (mollierControlSettings.FindPointType)
            {
                case ChartDataType.DryBulbTemperature:
                    uIMollierPoints.Sort((x, y) => x.DryBulbTemperature.CompareTo(y.DryBulbTemperature));
                    break;
                case ChartDataType.Enthalpy:
                    uIMollierPoints.Sort((x, y) => x.Enthalpy.CompareTo(y.Enthalpy));
                    break;
            }

            return Convert.ToSAM(uIMollierPoints[index], chartType);
        }
    }
}
