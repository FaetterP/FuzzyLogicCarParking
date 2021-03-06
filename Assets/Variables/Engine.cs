using Assets.Constructor;
using Assets.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Variables
{
    class Engine : MonoBehaviour
    {
        private Variable x;
        private Variable y;
        public FAM fam;
        private bool isDead = false;
        private bool isReached = false;
        private double best_dist = int.MaxValue;
        
        void Awake()
        {
            fam = new FAM(GetFAM());
            x = new Variable(GetX(Settings.SizeX, Settings.CellX));
            y = new Variable(GetX(Settings.SizeY, Settings.CellY));

            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y), true);

        }

        void Update()
        {
            if (isNeedRestart()) { return; }

            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y), false);

            double angle = fam.GetCentroid();
            transform.Rotate(new Vector3(0, 0, (float)angle));
            Vector3 coords = transform.localPosition;
            coords.x += Settings.speed * (float)Math.Cos(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
            coords.y += Settings.speed * (float)Math.Sin(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
            transform.localPosition = coords;

            if(coords.x < -Settings.SizeX / 2 || coords.x > Settings.SizeX / 2 || coords.y < -Settings.SizeY / 2 || coords.y > Settings.SizeY / 2)
            {
                isDead = true;
            }

            double curr_dist = FindObjectOfType<Finish>().GetDistance(transform.localPosition);
            best_dist = Math.Min(curr_dist, best_dist);
            if (best_dist < Settings.distance_to_finish) { isReached = true; }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            isDead = true;
        }
        private IFuzzySet[] GetFAM()
        {
            IFuzzySet[] ret = new IFuzzySet[7];
            ret[0] = new TriangleSet(-30, -30, -15, 0, 1);
            ret[1] = new TriangleSet(-25, -15, -5, 0, 1);
            ret[2] = new TriangleSet(-12, -6, 0, 0, 1);
            ret[3] = new TriangleSet(-5, 0, 5, 0, 1);
            ret[4] = new TriangleSet(0, 6, 12, 0, 1);
            ret[5] = new TriangleSet(5, 15, 25, 0, 1);
            ret[6] = new TriangleSet(18, 30, 30, 0, 1);
            return ret;
        }
        private IFuzzySet[] GetX(int size, int cell)
        {
            IFuzzySet[] ret = new IFuzzySet[size/cell];
            for(int i = 0; i < ret.Length; i++)
            {
                switch (Settings.FuzzyType)
                {
                    case FuzzyType.Rectangle:
                        ret[i] = new RectangleSet( i*cell-Settings.RectangleParam/2 - size / 2, i * cell + Settings.RectangleParam / 2 - size / 2, 0, 1);
                        break;
                    case FuzzyType.Triangle:
                        ret[i] = new TriangleSet(i * cell -Settings.TriangleParam/2 - size / 2, i*cell - size / 2, i * cell + Settings.TriangleParam / 2 - size / 2, 0 ,1);
                        break;
                    case FuzzyType.Trapezoid:
                        ret[i] = new TrapezoidSet(i * cell - Settings.TrapezoidParam2 / 2 - size / 2, i * cell - Settings.TrapezoidParam1 / 2 - size / 2, i * cell + Settings.TrapezoidParam1 / 2 - size / 2, i * cell + Settings.TrapezoidParam2 / 2 - size / 2, 0, 1);
                        break;
                    case FuzzyType.Normal:
                        ret[i] = new NormalSet(i * cell - size / 2, Settings.NormalParam, 1);
                        break;
                }
                
            }
            return ret;
        }

        public bool isNeedRestart()
        {
            return isDead || isReached;
        }

        public double getScore()
        {
            double ret = 1 / best_dist;
            if (isDead) { ret /= Settings.dead_coeff; }
            if (isReached) { ret *= Settings.reach_coeff; }
            return ret;
        }

        public double[,] getFAMAngles()
        {
            double[,] ret = new double[x.GetLength(), y.GetLength()];
            for (int i = 0; i < x.GetLength(); i++)
            {
                for (int j = 0; j < y.GetLength(); j++)
                {
                    double[] xarr = new double[x.GetLength()];
                    xarr[i] = 1;
                    double[] yarr = new double[y.GetLength()];
                    yarr[j] = 1;
                    fam.SetMatrix(xarr, yarr, false);
                    ret[i, j] = fam.GetCentroid();
                }
            }
            return ret;
        }
    }
}
