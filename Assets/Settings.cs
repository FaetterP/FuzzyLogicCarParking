using Assets.Constructor.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    enum FuzzyType { Rectangle, Triangle, Trapezoid, Normal }
    class Settings
    {
        public static int SizeX = 500;
        public static int SizeY = 500;
        public static int CellX = 50;
        public static int CellY = 50;

        public static float start_x = 0;
        public static float start_y = 0;
        public static float speed = 5;
        public static double distance_to_finish = 20;

        public static int size_population = 25;
        public static double integral_step = 0.5;
        public static double dead_coeff = 50;
        public static double reach_coeff = 50;
        public static double mutation_probability = 0.1;

        public static SpawnedObject SelectedSpawnedObject = SpawnedObject.Empty;

        public static FuzzyType FuzzyType;
        public static double RectangleParam = 25;
        public static double TriangleParam = 25;
        public static double TrapezoidParam1 = 25;
        public static double TrapezoidParam2 = 25;
        public static double NormalParam = 25;
    }
}
