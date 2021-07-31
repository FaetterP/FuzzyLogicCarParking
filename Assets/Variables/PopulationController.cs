using Assets.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Variables
{
    class PopulationController : MonoBehaviour
    {
        [SerializeField] private Engine car_to_create;
        private Engine[] population;
        private bool isNeedRetart;

        void Start()
        {
            car_to_create.transform.position = new Vector2(Settings.start_x, Settings.start_y);
            population = new Engine[Settings.size_population];

            for (int i = 0; i < population.Length; i++)
            {
                population[i] = Instantiate(car_to_create, transform);
                population[i].fam.RandomAM(1);
            }
        }

        void Update()
        {
            isNeedRetart = true;
            foreach(Engine car in population)
            {
                if (!car.isNeedRestart()) { isNeedRetart = false; }
            }

            if (!isNeedRetart) { return; }

            FAM best_fam = GetBestFAM();

            foreach(Engine car in population)
            {
                Destroy(car.gameObject);
            }

            CreatePopulation(best_fam);
            isNeedRetart = false;
        }

        private void CreatePopulation(FAM parent_fam)
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = Instantiate(car_to_create, transform);
                Array.Copy(parent_fam.AMatrix, population[i].fam.AMatrix, parent_fam.AMatrix.Length);
                population[i].fam.RandomAM(Settings.mutation_probability);
            }
            Array.Copy(parent_fam.AMatrix, population[0].fam.AMatrix, parent_fam.AMatrix.Length);
            population[0].GetComponent<Image>().color = Color.red;
            population[0].transform.SetAsLastSibling();
        }

        private FAM GetBestFAM()
        {
            double best_score = population[0].getScore();
            FAM best_fam = population[0].fam;
            foreach(Engine car in population)
            {
                if (car.getScore() > best_score)
                {
                    best_score = car.getScore();
                    best_fam = car.fam;
                }
            }
            return best_fam;
        }
    }
}
