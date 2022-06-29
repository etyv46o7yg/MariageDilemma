using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConsoleApp1
    {
    public class VectorPair
        {
        public Vector2 a, b;

        public VectorPair(Vector2 _a, Vector2 _b)
            {
            a = _a;
            b = _b;
            }

        public float RecoitDist()
            {
            return (a - b).Length();
            }

        public override string ToString()
            {
            string res = "";
            res += "<(" + a.X + ";" + a.Y + ")(" + b.X + ";" + b.Y + ")>";
            return res;
            }
        }
    }
