using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LSystemPackage
{
    public class FractalPlantDrawer : MonoBehaviour
    {
        public Material lineMaterial;
        public float length = 20;
        public float angle = 25;
        public Color color = Color.green;
        public float lineWidth = 1f;

        Vector3 direction = Vector3.forward;
        Vector3 currentPosition = Vector3.zero;

        struct PositionAngle
        {
            public Vector3 position;
            public Vector3 direction;
            public float length;
        }

        private Stack<PositionAngle> posAngleStack = new Stack<PositionAngle>();

        public void DrawForward(char symbol)
        {
            Assert.AreEqual('F', symbol);

            Vector3 tempPosition = currentPosition;
            currentPosition += direction * length;
            DrawLine(tempPosition, currentPosition, color);
        }

        public void TurnRight(char symbol)
        {
            Assert.AreEqual('-', symbol);

            direction = Quaternion.AngleAxis(angle, Vector3.up) * direction;
        }

        public void TurnLeft(char symbol)
        {
            Assert.AreEqual('+', symbol);

            direction = Quaternion.AngleAxis(-angle, Vector3.up) * direction;
        }

        public void Save(char symbol)
        {
            Assert.AreEqual('[', symbol);

            posAngleStack.Push(new PositionAngle
            {
                position = currentPosition,
                direction = direction,
                length = length
            });
        }

        public void Restore(char symbol)
        {
            Assert.AreEqual(']', symbol);

            if (posAngleStack.Count > 0)
            {
                PositionAngle param = posAngleStack.Pop();
                currentPosition = param.position;
                direction = param.direction;
                length = param.length;
            }
            else
            {
                throw new Exception("Dont have saved point in our stack");
            }
        }

        private void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            GameObject line = new GameObject("line");
            line.transform.position = start;
            var lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            lineRenderer.SetPosition(0, end);
            lineRenderer.SetPosition(1, start);
        }
    }
}