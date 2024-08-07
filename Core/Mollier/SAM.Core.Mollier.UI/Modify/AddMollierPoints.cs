﻿using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using SAM.Geometry.Mollier;
using System.Windows.Forms.DataVisualization.Charting;

namespace SAM.Core.Mollier.UI
{
    public static partial class Modify
    {
        /// <summary>
        /// Creates series for all the points on the chart
        /// </summary>
        /// <param name="chart">Mollier chart</param>
        /// <param name="uIMollierPoints">Mollier points</param>
        /// <param name="mollierControlSettings">Mollier control settings</param>
        /// <returns>List of created series</returns>
        public static Series AddMollierPoints(this Chart chart, IEnumerable<UIMollierPoint> uIMollierPoints, MollierControlSettings mollierControlSettings)
        {
            if(uIMollierPoints == null || mollierControlSettings.DivisionArea) 
            {
                return null;
            }

            Series result = chart.Series.ToList().Find(x => x.Name == "MollierPoints"); 
            if (result == null)
            {
                result = chart.Series.Add("MollierPoints");
                result.IsVisibleInLegend = false;
                result.ChartType = SeriesChartType.Point;
                int index_Temp = result.Points.AddXY(1, 0); //Has to be added to properly show first point on HumidityRatio = 0
                result.Points[index_Temp].MarkerSize = 0;
            }
            else
            {
                result.Points.Clear();
            }
            ChartType chartType = mollierControlSettings.ChartType;
            result.Tag = uIMollierPoints;

            Dictionary<UIMollierPoint, Color> colorDictionary = uIMollierPoints.ColorDictionary(mollierControlSettings);

            foreach(UIMollierPoint uIMollierPoint in uIMollierPoints)
            {
                MollierPoint mollierPoint = uIMollierPoint;
                if(mollierPoint == null)
                {
                    continue;
                }

                Point2D point = Convert.ToSAM(mollierPoint, chartType);
                if(result.Contains(point.X, point.Y, Tolerance.MacroDistance))
                {
                    continue;
                }

                int index = result.Points.AddXY(point.X, point.Y);
                result.Points[index].ToolTip = Query.ToolTipText(mollierPoint, chartType);
                result.Points[index].MarkerSize = 7;
                result.Points[index].MarkerStyle = MarkerStyle.Circle;
                result.Points[index].Tag = new UIMollierPoint(uIMollierPoint);
                //result.Points[index].Tag = new UIMollierPoint(mollierPoint, new UIMollierPointAppearance(Color.Black, uIMollierPoint.UIMollierAppearance.Label));
                if (colorDictionary[uIMollierPoint] == Color.Empty)
                {
                    result.Points[index].Color = uIMollierPoint.UIMollierAppearance.Color;
                }
                else
                {
                    result.Points[index].Color = colorDictionary[uIMollierPoint];
                }

            }
            return result;
        }
    
        public static Series AddMollierPoints(this Chart chart, MollierModel mollierModel, MollierControlSettings mollierControlSettings)
        {
            if(mollierModel == null)
            {
                return null;
            }

            List<UIMollierPoint> uIMollierPoints = mollierModel.GetMollierObjects<UIMollierPoint>();

            uIMollierPoints = uIMollierPoints?.FindAll(x => x.UIMollierAppearance.Visible == true);
            return chart.AddMollierPoints(uIMollierPoints, mollierControlSettings);
        }
    }
}
