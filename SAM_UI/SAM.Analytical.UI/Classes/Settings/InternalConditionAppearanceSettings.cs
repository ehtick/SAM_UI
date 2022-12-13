﻿using Newtonsoft.Json.Linq;

namespace SAM.Analytical.UI
{
    public class InternalConditionAppearanceSettings : Geometry.UI.ParameterAppearanceSettings
    {

        public InternalConditionAppearanceSettings(string parameterName)
            :base(parameterName)
        {
            ParameterName = parameterName;
        }

        public InternalConditionAppearanceSettings(InternalConditionAppearanceSettings internalConditionAppearanceSettings)
            :base(internalConditionAppearanceSettings)
        {

        }

        public InternalConditionAppearanceSettings(JObject jObject)
            :base(jObject)
        {
        }

        public override bool FromJObject(JObject jObject)
        {
            if(!base.FromJObject(jObject))
            {
                return false;
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = base.ToJObject();

            return result;
        }
    }
}