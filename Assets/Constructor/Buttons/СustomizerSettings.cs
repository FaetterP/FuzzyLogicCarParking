using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Buttons
{
    class СustomizerSettings : MonoBehaviour
    {
        [SerializeField] private Slider size_population, speed, reach_coeff, dead_coeff, integral_step, mutation_probability, distance_to_finish;

        void Awake()
        {
            size_population.onValueChanged.AddListener(delegate { Settings.size_population = (int)size_population.value; });
            speed.onValueChanged.AddListener(delegate { Settings.speed = speed.value; });
            integral_step.onValueChanged.AddListener(delegate { Settings.integral_step = integral_step.value; });
            distance_to_finish.onValueChanged.AddListener(delegate { Settings.distance_to_finish = distance_to_finish.value; });
            mutation_probability.onValueChanged.AddListener(delegate { Settings.mutation_probability = mutation_probability.value; });
            reach_coeff.onValueChanged.AddListener(delegate { Settings.reach_coeff = reach_coeff.value; });
            dead_coeff.onValueChanged.AddListener(delegate { Settings.dead_coeff = dead_coeff.value; });
        }
    }
}
