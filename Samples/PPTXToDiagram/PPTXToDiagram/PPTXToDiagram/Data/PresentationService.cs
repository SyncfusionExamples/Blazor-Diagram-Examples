using System.Net.NetworkInformation;
using Syncfusion.Presentation;
using System;
using System.IO;
using Syncfusion.OfficeChart;
using Syncfusion.Blazor.Diagram;
using Syncfusion.Blazor.Inputs;
using System.Drawing;
using Syncfusion.Drawing;
using static System.Net.WebRequestMethods;
using System.Globalization;


namespace BlazorApp34.Data
{
    public class PresentationService
    {
       public DiagramObjectCollection<Node>nodes= new DiagramObjectCollection<Node>();
        public DiagramObjectCollection<Connector> connetors = new DiagramObjectCollection<Connector>();
       
        public  void PPTtoDiagram() {
            string path = Path.GetFullPath("Data");
            FileStream fileStreamPath = new FileStream((@path+@"/Template.pptx"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Open an existing PowerPoint file
            using (IPresentation pptxDoc = Presentation.Open(fileStreamPath))
            {

                // //Iterates all the slides of PowerPoint
                foreach (ISlide slide in pptxDoc.Slides)
                {
                    //Iterates all the shapes from first slide and print connector shape.
                    foreach (IShape shape in slide.Shapes)
                    {
                       
                        // Print the begin and end shapes based on connector shape
                        if (shape.SlideItemType == SlideItemType.ConnectionShape)
                        {
                            
                            //PrintShape(shape);
                            System.Drawing.Color conectorStyle = System.Drawing.Color.FromArgb(shape.LineFormat.Fill.SolidFill.Color.R, shape.Fill.SolidFill.Color.G, shape.Fill.SolidFill.Color.B);
                            string hex = conectorStyle.R.ToString("X2") + conectorStyle.G.ToString("X2") + conectorStyle.B.ToString("X2");


                            IConnector connector1= (shape as IConnector);
                            Connector connector = new Connector()
                            {
                                ID = shape.ShapeName,
                                Style=new ShapeStyle() { StrokeColor= "#" + hex },
                                TargetDecorator=new DecoratorSettings() { Style =new ShapeStyle() { Fill="#"+ hex, StrokeColor= "#" + hex, } },
                                SourcePortID= connector1.BeginConnectionSiteIndex.ToString(),
                                TargetPortID= connector1.EndConnectionSiteIndex.ToString(),
                                Type = connector1.Type.ToString().Contains("straight")?ConnectorSegmentType.Straight:ConnectorSegmentType.Orthogonal,
                                SourceID = connector1.BeginConnectedShape != null ? connector1.BeginConnectedShape.ShapeName : "",
                                TargetID= connector1.EndConnectedShape!=null? connector1.EndConnectedShape.ShapeName:"",
                            };
                           
                            connetors.Add(connector);
                         }
                        else
                        {
                           System.Drawing.Color ShapeColor = System.Drawing.Color.FromArgb(shape.Fill.SolidFill.Color.R, shape.Fill.SolidFill.Color.G, shape.Fill.SolidFill.Color.B);
                            string NodeShapeColor = ShapeColor.R.ToString("X2") + ShapeColor.G.ToString("X2") + ShapeColor.B.ToString("X2");

                            System.Drawing.Color fontcolor = System.Drawing.Color.FromArgb((shape.TextBody.Paragraphs as IParagraphs)[0].Font.Color.R, (shape.TextBody.Paragraphs as IParagraphs)[0].Font.Color.G, (shape.TextBody.Paragraphs as IParagraphs)[0].Font.Color.B);
                            string fontColorValue = fontcolor.R.ToString("X2") + fontcolor.G.ToString("X2") + fontcolor.B.ToString("X2");
                            //string s = (shape.Fill.SolidFill.Color.R * 65536 + shape.Fill.SolidFill.Color.G * 256 + shape.Fill.SolidFill.Color.B).ToString();
                            System.Drawing.Color myColor1 = System.Drawing.Color.FromArgb(shape.LineFormat.Fill.SolidFill.Color.R, shape.LineFormat.Fill.SolidFill.Color.G, shape.LineFormat.Fill.SolidFill.Color.B);
                            string strokeColor = myColor1.R.ToString("X2") + myColor1.G.ToString("X2") + myColor1.B.ToString("X2");

                            Node node = new Node()
                            {
                                ID = shape.ShapeName,
                                Style = new ShapeStyle() {

                                    Fill = "#" + NodeShapeColor,
                                    StrokeColor = "#" + strokeColor,
                                    StrokeWidth = shape.LineFormat.Weight,
                                },
                                Width = shape.Width,
                                Height = shape.Height,
                                OffsetX = shape.Left,
                                OffsetY = shape.Top,
                                Ports=Createports(),
                                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                                {
                                    new ShapeAnnotation()
                                    {
                                        Content=shape.TextBody.Text,
                                        Style=new TextStyle()
                                        {
                                          Color="#"+fontColorValue,
                                          Bold=(shape.TextBody.Paragraphs as IParagraphs)[0].Font.Bold,
                                          
                                          FontSize=(shape.TextBody.Paragraphs as IParagraphs)[0].Font.FontSize,
                                          FontFamily=(shape.TextBody.Paragraphs as IParagraphs)[0].Font.FontName,
                                        }
                                    }
                                }
                            };
                            if (shape.AutoShapeType.ToString().Contains("Terminator"))
                            {
                                node.Shape = new FlowShape() { Shape = NodeFlowShapes.Terminator, Type = NodeShapes.Flow };
                                
                               
                            }
                            if (shape.AutoShapeType.ToString().Contains("Process"))
                            {
                                node.Shape = new FlowShape() { Shape = NodeFlowShapes.Process, Type = NodeShapes.Flow };
                            }
                            if (shape.AutoShapeType.ToString().Contains("Diamond"))
                            {
                                node.Shape = new BasicShape() { Shape = NodeBasicShapes.Diamond, Type = NodeShapes.Basic };
                            }
                            if (shape.AutoShapeType.ToString().Contains("Oval"))
                            {
                                node.Shape = new BasicShape() { Shape = NodeBasicShapes.Ellipse, Type = NodeShapes.Basic,CornerRadius=5 };
                            }
                            if (shape.AutoShapeType.ToString().Contains("Rectangle"))
                            {
                                node.Shape = new BasicShape() { Shape = NodeBasicShapes.Rectangle, Type = NodeShapes.Basic,CornerRadius=5};
                            }
                            nodes.Add(node);
                        }
                           
                        }
                    }
                              
            }            
        }

        private DiagramObjectCollection<PointPort> Createports()
        {
            DiagramObjectCollection<PointPort> ports = new DiagramObjectCollection<PointPort>() {
           new PointPort()
            {
                ID = "0",
                Offset = new DiagramPoint() { X = 0.5, Y = 0 },
            },
           new PointPort() {
                ID = "1",
               Offset = new DiagramPoint() { X = 0, Y = 0.5 }
           },
           new PointPort() {
                ID = "2",
               Offset = new DiagramPoint() { X = 0.5, Y = 1 }
           },
           new PointPort() {
            ID = "3",
               Offset = new DiagramPoint() { X = 1, Y = 0.5 }}
            };
            return ports;

        }

       
}
}
