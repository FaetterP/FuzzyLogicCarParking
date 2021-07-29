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
        private FAM fam;

        void Awake()
        {
            fam = new FAM(GetFAM());
            x = new Variable(GetX(Settings.SizeX, Settings.CellX));
            y = new Variable(GetX(Settings.SizeY, Settings.CellY));

            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y), true);
            fam.RandomAM(1);

        }

        void Update()
        {
            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y), false);

            double angle = fam.GetCentroid();
            transform.Rotate(new Vector3(0, 0, (float)angle));
            Vector3 coords = transform.localPosition;
            coords.x += Settings.speed * (float)Math.Cos(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
            coords.y += Settings.speed * (float)Math.Sin(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
            transform.localPosition = coords;
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
                ret[i] = new TriangleSet((i - 1) * cell-size/2, i * cell - size / 2, (i + 1) * cell - size / 2, 0, 1);
            }
            return ret;
        }


    }
}
