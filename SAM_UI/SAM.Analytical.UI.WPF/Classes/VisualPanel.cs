﻿namespace SAM.Analytical.UI.WPF
{
    public class VisualPanel : VisualSAMObject<Panel>
    {
        public VisualPanel(Panel panel)
            :base(panel)
        {

        }

        public Panel Panel
        {
            get
            {
                return jSAMObject;
            }
        }
    }
}
