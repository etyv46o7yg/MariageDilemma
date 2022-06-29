using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConsoleApp1
    {
    class MariagePairs
        {
        public List<VectorPair> pairs;

        public MariagePairs(List<VectorPair> _pairs)
            {
            pairs = _pairs;
            }

        /// <summary>
        /// Обмен b-элементов пар по индексам
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        public void Permutation(int _a, int _b)
            {
            Vector2 temp = pairs[_a].b;
            pairs[_a].b = pairs [_b].b;
            pairs[_b].b = temp;
            }

        /// <summary>
        /// Поиск пары и наибольшим расстоянием между элементами.
        /// </summary>
        /// <returns>Индекс найденного элемента в массиве и расстояние</returns>
        public (int, float) ChercherIndexMaxPairesDist()
            {
            int indexMaxDistPairs = 0;
            float distMax = 0.0f;

            for (int i = 0; i < pairs.Count; i++)
                {
                var item = pairs [i];
                float dist = item.RecoitDist();
                if (dist > distMax)
                    {
                    indexMaxDistPairs = i;
                    distMax = dist;
                    }
                }

            return (indexMaxDistPairs, distMax);
            }

        /// <summary>
        /// Найти индекс элемента блишайшего к pairs[_index].a
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>Индекс ближайшего элемента</returns>
        public int RecoirIndexProchenElement(int _index)
            {
            float minDist = float.PositiveInfinity;
            int indexProchen = 0;
            Vector2 referenceVale = pairs[_index].a;

            for (int i = 0; i < pairs.Count; i++)
                {
                float dist = (pairs[i].a - referenceVale).Length();
                if (dist < minDist && i != _index)
                    {
                    minDist = dist;
                    indexProchen = i;
                    }
                }

            return indexProchen;
            }

        public void Show()
            {
            string res = "";

            foreach (var item in pairs)
                {
                res += Environment.NewLine + item.ToString() ;
                }

            Console.WriteLine(res);
            var temp = ChercherIndexMaxPairesDist();
            Console.WriteLine( temp.Item1 + " " + temp.Item2);
            }
        }
    }
