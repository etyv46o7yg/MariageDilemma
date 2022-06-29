using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
    {
    /*
     * 
     * Комент, проверка
     */
    class Program
        {
        static void Main(string [] args)
            {
            List<Vector2> posA = new List<Vector2>();
            posA.Add(new Vector2(0, 1));
            posA.Add(new Vector2(0, 2));
            posA.Add(new Vector2(0, 3));
            posA.Add(new Vector2(0, 4));
            posA.Add(new Vector2(0, 5));
            posA.Add(new Vector2(0, 6));

            List<Vector2> posB = new List<Vector2>();
            posB.Add(new Vector2(1, -2));
            posB.Add(new Vector2(1, 0));
            posB.Add(new Vector2(1, 1));
            posB.Add(new Vector2(1, 2));
            posB.Add(new Vector2(1, 3));
            posB.Add(new Vector2(1, 4));
            //posB.Add(new Vector2(1, 5));

            MariageDilemme dilemma = new MariageDilemme(posA, posB);
            dilemma.Calcouler();
            }
        }

    public class PermuteUtils
        {
        // Returns an enumeration of enumerators, one for each permutation
        // of the input.
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
            {
            if (count == 0)
                {
                yield return new T [0];
                }
            else
                {
                int startingElementIndex = 0;
                foreach (T startingElement in list)
                    {
                    IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                    foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                        {
                        yield return Concat<T>(
                            new T [] { startingElement },
                            permutationOfRemainder);
                        }
                    startingElementIndex += 1;
                    }
                }
            }

        // Enumerates over contents of both lists.
        public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
            {
            foreach (T item in a) { yield return item; }
            foreach (T item in b) { yield return item; }
            }

        // Enumerates over all items in the input, skipping over the item
        // with the specified offset.
        public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
            {
            int index = 0;
            foreach (T item in input)
                {
                if (index != indexToSkip) yield return item;
                index += 1;
                }
            }
        }

    public class MariageDilemme
        {
        List<Vector2> a, b;
        List<VectorPair> c;

        public MariageDilemme(List<Vector2> _a, List<Vector2> _b)
            {
            a = _a;
            b = _b;
            }

        public void Calcouler()
            {
            c = new List<VectorPair>();
            var tempList = new List<Vector2>(b);
            foreach (var item in a)
                {
                var temp = tempList.OrderBy(x => (x - item).Length()).First();
                tempList.RemoveAll(x => (x - temp).Length() < 0.01f);
                c.Add(new VectorPair(item, temp));
                }

            MariagePairs pairs = new MariagePairs(c);
            pairs.Show();

            //Console.WriteLine("Ближ к. 5 " + pairs.RecoirIndexProchenElement(5));

            for (int i = 0; i < pairs.pairs.Count; i++)
                {
                var indexA = pairs.ChercherIndexMaxPairesDist();
                int indexB = pairs.RecoirIndexProchenElement(indexA.Item1);
                pairs.Permutation(indexA.Item1, indexB);
                Console.WriteLine(Environment.NewLine + indexA.Item1 + " " + indexB);                 
                }

            pairs.Show();
                

            

            }

        }
    }
