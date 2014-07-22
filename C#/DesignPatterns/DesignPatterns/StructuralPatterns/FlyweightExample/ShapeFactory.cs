namespace DesignPatterns.StructuralPatterns.FlyweightExample
{
    using System;
    using System.Collections.Generic;

    public class ShapeFactory
    {
        private Dictionary<ShapeType, Shape> shapes = new Dictionary<ShapeType, Shape>(); 

        public Shape GetShape(ShapeType shapeType)
        {
            if (!this.shapes.ContainsKey(shapeType))            
            {
                Shape newShape;
                switch (shapeType)
                {
                    case ShapeType.Triangle:
                        newShape = new Triangle();
                        break;
                    case ShapeType.Rectangle:
                        newShape = new Rectangle();
                        break;
                    default:
                        throw new ArgumentException("Unsupported shape type.");
                }
                
                this.shapes.Add(shapeType, newShape);
            }

            return this.shapes[shapeType];
        }
    }
}
