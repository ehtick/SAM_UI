﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SAM.Analytical.UI.WPF
{
    /// <summary>
    /// Interaction logic for View3DForm.xaml
    /// </summary>
    public partial class View3DControl : UserControl
    {
        private UIAnalyticalModel uIAnalyticalModel;

        private IVisualSAMObject visualSAMObject_Highlight;

        private Point point_Mouse;

        public View3DControl()
        {
            InitializeComponent();
        }

        private void LoadAnalyticalModel(AnalyticalModel analyticalModel)
        {
            Clear();

            List<Panel> panels = analyticalModel?.GetPanels();
            if(panels != null)
            {
                foreach(Panel panel in panels)
                {
                    VisualPanel visualPanel = panel?.ToMedia3D();
                    if(visualPanel == null)
                    {
                        continue;
                    }

                    Viewport.Children.Add(visualPanel);

                    List<Aperture> apertures = panel.Apertures;
                    if(apertures != null)
                    {
                        foreach(Aperture aperture in apertures)
                        {
                            VisualAperture visualAperture = aperture?.ToMedia3D();
                            if (visualAperture == null)
                            {
                                continue;
                            }

                            Viewport.Children.Add(visualAperture);
                        }
                    }
                }
            }

            //AdjacencyCluster adjacencyCluster = analyticalModel.AdjacencyCluster;

            //List<Space> spaces = analyticalModel.GetSpaces();
            //if (spaces != null)
            //{
            //    foreach(Space space in spaces)
            //    {
            //        VisualSpace visualSpace = space.ToMedia3D(adjacencyCluster);
            //        if (visualSpace == null)
            //        {
            //            continue;
            //        }

            //        Viewport.Children.Add(visualSpace);
            //    }
            //}

        }
        
        private void Clear()
        {
            Visual3DCollection visual3DCollection = Viewport.Children;
            if (visual3DCollection == null)
            {
                return;
            }

            List<Visual3D> visual3Ds = new List<Visual3D>();
            foreach (Visual3D visual3D in visual3DCollection)
            {
                if (!(visual3D is IVisualSAMObject))
                {
                    continue;
                }

                visual3Ds.Add(visual3D);
            }

            foreach(Visual3D visual3D in visual3Ds)
            {
                Viewport.Children.Remove(visual3D);
            }
        }

        public List<T> GetVisualSAMObjects<T>() where T : IVisualSAMObject
        {
            Visual3DCollection visual3DCollection = Viewport.Children;
            if (visual3DCollection == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach (object @object in visual3DCollection)
            {
                if (!(@object is T))
                {
                    continue;
                }

                result.Add((T)@object);
            }

            return result;
        }

        public UIAnalyticalModel UIAnalyticalModel
        {
            get
            {
                return uIAnalyticalModel;
            }

            set
            {
                uIAnalyticalModel = value;
                if(uIAnalyticalModel != null)
                {
                    uIAnalyticalModel.Modified -= UIAnalyticalModel_Modified;
                    uIAnalyticalModel.Modified += UIAnalyticalModel_Modified;

                    uIAnalyticalModel.Closed -= UIAnalyticalModel_Closed;
                    uIAnalyticalModel.Closed += UIAnalyticalModel_Closed;

                    uIAnalyticalModel.Opened -= UIAnalyticalModel_Opened;
                    uIAnalyticalModel.Opened += UIAnalyticalModel_Opened;
                }
            }
        }

        private void UIAnalyticalModel_Opened(object sender, EventArgs e)
        {
            LoadAnalyticalModel(uIAnalyticalModel?.JSAMObject);
        }

        private void UIAnalyticalModel_Closed(object sender, EventArgs e)
        {
            LoadAnalyticalModel(uIAnalyticalModel?.JSAMObject);
        }

        private void UIAnalyticalModel_Modified(object sender, EventArgs e)
        {
            LoadAnalyticalModel(uIAnalyticalModel?.JSAMObject);
        }

        private void UserControl_MouseWeel(object sender, MouseWheelEventArgs e)
        {
            MainCamera.Position = new Point3D(MainCamera.Position.X - e.Delta / 360D, MainCamera.Position.Y - e.Delta / 360D, MainCamera.Position.Z - e.Delta / 360D);
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point point_Current = e.GetPosition(Viewport);

                RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = VisualTreeHelper.HitTest(Viewport, point_Current) as RayMeshGeometry3DHitTestResult;

                VisualPanel visualPanel = rayMeshGeometry3DHitTestResult?.VisualHit as VisualPanel;
                if (visualPanel == null)
                {
                    return;
                }

                UI.Modify.EditPanel(uIAnalyticalModel, visualPanel.Panel);
            }
        }

        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point point_Current = e.GetPosition(Viewport);

            visualSAMObject_Highlight?.SetHighlight(false);
            visualSAMObject_Highlight = null;

            Information.Text = string.Format("Mouse: X={0}, Y={1}", Core.Query.Round(point_Current.X, 0.1), Core.Query.Round(point_Current.Y, 0.1));
            RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = VisualTreeHelper.HitTest(Viewport, point_Current) as RayMeshGeometry3DHitTestResult;
            if (rayMeshGeometry3DHitTestResult != null)
            {
                IVisualSAMObject visualSAMObject_Highlight_Current = rayMeshGeometry3DHitTestResult?.VisualHit as IVisualSAMObject;
                if(visualSAMObject_Highlight_Current != null)
                {
                    visualSAMObject_Highlight_Current.SetHighlight(true);
                    visualSAMObject_Highlight = visualSAMObject_Highlight_Current;

                    if (visualSAMObject_Highlight_Current is VisualPanel)
                    {
                        VisualPanel visualPanel = (VisualPanel)visualSAMObject_Highlight_Current;
                        Information.Text += string.Format("\n{0} Panel Guid: {1}\nPoint: X={2}, Y={3}, Z={4}", visualPanel?.Panel?.Name, visualPanel?.Panel?.Guid, Core.Query.Round(rayMeshGeometry3DHitTestResult.PointHit.X, 0.01), Core.Query.Round(rayMeshGeometry3DHitTestResult.PointHit.Y, 0.01), Core.Query.Round(rayMeshGeometry3DHitTestResult.PointHit.Z, 0.01));
                    }
                }
            }

            double dx = point_Current.X - point_Mouse.X;
            double dy = point_Current.Y - point_Mouse.Y;
            point_Mouse = point_Current;

            var distance = dx * dx + dy * dy;
            if (distance <= 0)
                return;

            PerspectiveCamera perspectiveCamera = Viewport.Camera as PerspectiveCamera;
            if (perspectiveCamera == null)
            {
                return;
            }

            distance = distance / 10;

            Geometry.Spatial.Plane plane = Query.Plane(MainCamera);
            Geometry.Spatial.Vector3D vector3D = Geometry.Spatial.Query.Convert(plane, new Geometry.Planar.Vector2D(dx, dy));

            if (e.MouseDevice.MiddleButton is MouseButtonState.Pressed)
            {
                vector3D = vector3D.CrossProduct(plane.Normal);
                double angle = distance / perspectiveCamera.FieldOfView % 45;
                perspectiveCamera.Rotate(Convert.ToMedia3D(vector3D.GetNegated()), angle);
            }
            else if(e.MouseDevice.LeftButton is MouseButtonState.Pressed)
            {
                perspectiveCamera.Move(Convert.ToMedia3D(vector3D), 0.005);
            }
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PerspectiveCamera perspectiveCamera = Viewport.Camera as PerspectiveCamera;
            if (perspectiveCamera == null)
            {
                return;
            }

            perspectiveCamera.Move(e.Key).Rotate(e.Key);
        }

        private void Grid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            ContextMenu_Grid.Items.Clear();

            Point point_Current = Mouse.GetPosition(Viewport);
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(Viewport, point_Current);
            ModelVisual3D modelVisual3D_Current = hitTestResult?.VisualHit as ModelVisual3D;

            MenuItem menuItem = new MenuItem();
            menuItem.Name = "MenuItem_CenterView";
            menuItem.Header = "Center View";
            menuItem.Click += MenuItem_CenterView_Click;
            menuItem.Tag = hitTestResult;
            ContextMenu_Grid.Items.Add(menuItem);


            if (modelVisual3D_Current != null)
            {
                menuItem = new MenuItem();
                menuItem.Name = "MenuItem_Properties";
                menuItem.Header = "Properties";
                menuItem.Click += MenuItem_Properties_Click;
                menuItem.Tag = hitTestResult;
                ContextMenu_Grid.Items.Add(menuItem);
            }
        }

        private void MenuItem_Properties_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem == null)
            {
                return;
            }

            RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = menuItem.Tag as RayMeshGeometry3DHitTestResult;

            VisualPanel visualPanel = rayMeshGeometry3DHitTestResult?.VisualHit as VisualPanel;
            if(visualPanel == null)
            {
                return;
            }

            UI.Modify.EditPanel(uIAnalyticalModel, visualPanel.Panel);
        }

        private void MenuItem_CenterView_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if(menuItem == null)
            {
                return;
            }

            RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = menuItem.Tag as RayMeshGeometry3DHitTestResult;

            ModelVisual3D modelVisual3D_Current = rayMeshGeometry3DHitTestResult?.VisualHit as ModelVisual3D;

            Point3D point3D = new Point3D(double.NaN, double.NaN, double.NaN);
            if (modelVisual3D_Current != null)
            {
                point3D = rayMeshGeometry3DHitTestResult.PointHit;
            }
            else
            {
                List<IVisualSAMObject> visualSAMObjects = GetVisualSAMObjects<IVisualSAMObject>();
                if(visualSAMObjects == null)
                {
                    return;
                }

                Rect3D rect3D = Rect3D.Empty;
                foreach(IVisualSAMObject visualSAMObject in visualSAMObjects)
                {
                    Rect3D rect3D_VisualPanel = visualSAMObject.GeometryModel3D.Bounds;
                    if(rect3D == Rect3D.Empty)
                    {
                        rect3D = rect3D_VisualPanel;
                    }
                    else
                    {
                        rect3D.Union(rect3D_VisualPanel);
                    }
                }

                point3D = rect3D.Center();
            }

            if(point3D.IsNaN())
            {
                return;
            }

            Vector3D lookDirection = Query.LookDirection(point3D, MainCamera.Position, out Vector3D upDirection);
            MainCamera.LookDirection = lookDirection;
        }

        private void MainCamera_Changed(object sender, EventArgs e)
        {
            if(DirectionalLight != null)
            {
                DirectionalLight.Direction = MainCamera.LookDirection;
            }

        }
    }
}
