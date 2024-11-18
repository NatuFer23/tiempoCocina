//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Timers;

namespace Full_GRASP_And_SOLID
{
    public class Recipe : IRecipeContent,TimerClient // Modificado por DIP
    {
        // Cambiado por OCP
        private IList<BaseStep> steps = new List<BaseStep>();

        public Product FinalProduct { get; set; }

        // Agregado por Creator
        public void AddStep(Product input, double quantity, Equipment equipment, int time)
        {
            Step step = new Step(input, quantity, equipment, time);
            this.steps.Add(step);
        }

        // Agregado por OCP y Creator
        public void AddStep(string description, int time)
        {
            WaitStep step = new WaitStep(description, time);
            this.steps.Add(step);
        }

        public void RemoveStep(BaseStep step)
        {
            this.steps.Remove(step);
        }

        // Agregado por SRP
        public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (BaseStep step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }

        // Agregado por Expert
        public double GetProductionCost()
        {
            double result = 0;

            foreach (BaseStep step in this.steps)
            {
                result = result + step.GetStepCost();
            }

            return result;
        }

        public int GetCookTime()
        {
            int tiempoTotal = 0;
            foreach (BaseStep step in steps)
            {
                tiempoTotal += step.Time;
            }

            return tiempoTotal;
        }

        private CountdownTimer timer = new CountdownTimer();
        private bool EstadoCook = false;


        public bool Cooked
        {
            get { return EstadoCook; }
            private set { EstadoCook = value; }
        }

        public void Cook()
        {
            if (this.Cooked)
            {
                Console.WriteLine("la receta ya se cocino");
                return;
            }

            Console.WriteLine("cocinando");
            int tiempoTotal = this.GetCookTime();
            timer.Register(GetCookTime(), this);
        }

        
        public void TimeOut()
        {
            this.Cooked = true;
            Console.WriteLine("se termino de hacer!!");
        }
        
        
    }
    
    
    
}
