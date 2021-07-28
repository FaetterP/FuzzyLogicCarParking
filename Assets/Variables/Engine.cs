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
            x = new Variable(GetX());
            y = new Variable(GetX());

            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y),true);
            fam.RandomAM(1);
            
           // transform.Rotate(new Vector3(0, 0, (float)angle));

        }

        void Update()
        {
            fam.SetMatrix(x.GetArrWeightsInPoint(transform.localPosition.x), y.GetArrWeightsInPoint(transform.localPosition.y), false);

            double angle = fam.GetCentroid();
            transform.Rotate(new Vector3(0, 0, (float)angle));
            Vector3 coords = transform.localPosition;
            coords.x += 1 * (float)Math.Cos(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
            coords.y += 1 * (float)Math.Sin(transform.localRotation.eulerAngles.z * Math.PI / 180.0);
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
        private IFuzzySet[] GetX()
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


    }
}
