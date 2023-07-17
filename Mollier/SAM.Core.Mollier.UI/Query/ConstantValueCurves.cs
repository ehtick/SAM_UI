﻿using System;
using System.Collections.Generic;

namespace SAM.Core.Mollier.UI
{
    public static partial class Query
    {
        public static List<ConstantValueCurve> ConstantValueCurves(this ChartDataType chartDataType, MollierControlSettings mollierControlSettings)
        {
            if(mollierControlSettings == null)
            {
                return null;
            }

            double pressure = mollierControlSettings.Pressure;
            if(double.IsNaN(pressure))
            {
                return null;
            }

            double dryBulbTemperature_Min = double.NaN;
            double dryBulbTemperature_Max = double.NaN;
            double step = double.NaN;

            switch (chartDataType)
            {
                case Mollier.ChartDataType.DryBulbTemperature:
                    dryBulbTemperature_Min = mollierControlSettings.Temperature_Min;
                    dryBulbTemperature_Max = mollierControlSettings.Temperature_Max;
                    step = 1;

                    return Mollier.Query.ConstantValueCurves_DryBulbTemperature(new Range<double>(dryBulbTemperature_Min, dryBulbTemperature_Max), step, pressure);


                case Mollier.ChartDataType.DiagramTemperature:
                    dryBulbTemperature_Min = mollierControlSettings.Temperature_Min;
                    dryBulbTemperature_Max = mollierControlSettings.Temperature_Max;
                    step = 1;

                    return Mollier.Query.ConstantValueCurves_DiagramTemperature(new Range<double>(dryBulbTemperature_Min, dryBulbTemperature_Max), step, pressure);


                case Mollier.ChartDataType.Density:
                    if(!mollierControlSettings.Density_line)
                    {
                        return null;
                    }

                    double denisty_Min = mollierControlSettings.Density_Min;
                    double denisty_Max = mollierControlSettings.Density_Max;
                    step = mollierControlSettings.Density_Interval;

                    Range<double> denistyRange = new Range<double>(denisty_Min, denisty_Max);

                    return Mollier.Query.ConstantValueCurves_Density(denistyRange, step, pressure);

                case Mollier.ChartDataType.RelativeHumidity:
                    dryBulbTemperature_Min = mollierControlSettings.Temperature_Min;
                    dryBulbTemperature_Max = mollierControlSettings.Temperature_Max;
                    step = 10;

                    return Mollier.Query.ConstantValueCurves_RelativeHumidity(new Range<double>(0, 100), step, pressure, new Range<double>(dryBulbTemperature_Min, dryBulbTemperature_Max));

                case Mollier.ChartDataType.Enthalpy:
                    if (!mollierControlSettings.Enthalpy_line)
                    {
                        return null;
                    }

                    double enthalpy_Min = mollierControlSettings.Enthalpy_Min;
                    double enthalpy_Max = mollierControlSettings.Enthalpy_Max;
                    step = mollierControlSettings.Enthalpy_Interval;

                    return Mollier.Query.ConstantValueCurves_Enthalpy(new Range<double>(enthalpy_Min, enthalpy_Max), step, pressure);

                case Mollier.ChartDataType.WetBulbTemperature:
                    if (!mollierControlSettings.WetBulbTemperature_line)
                    {
                        return null;
                    }
                    dryBulbTemperature_Min = mollierControlSettings.Temperature_Min;
                    dryBulbTemperature_Max = mollierControlSettings.Temperature_Max;
                    step = 5;

                    return Mollier.Query.ConstantValueCurves_WetBulbTemperature(new Range<double>(dryBulbTemperature_Min, dryBulbTemperature_Max), step, pressure);

                case Mollier.ChartDataType.SpecificVolume:
                    if (!mollierControlSettings.SpecificVolume_line)
                    {
                        return null;
                    }

                    double specificVolume_Min = mollierControlSettings.SpecificVolume_Min;
                    double specificVolume_Max = mollierControlSettings.SpecificVolume_Max;
                    step = mollierControlSettings.SpecificVolume_Interval;

                    return Mollier.Query.ConstantValueCurves_SpecificVolume(new Range<double>(specificVolume_Min, specificVolume_Max), step, pressure);




                default:
                    return null;
            }
        }
    }
}
