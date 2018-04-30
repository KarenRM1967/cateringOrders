//Karen Rees-Milton. COMP60. Assignment 3
//April 27 2018
// A program to take orders for a catering company
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milestone1
{
    [Serializable]
    class CateringOrder
    {
        private string firstName;
        private string lastName;
        private int eventDuration;

        /// <summary>
        /// properties for attributes requiring validating
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length > 2)
                    firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length > 2)
                    lastName = value;
            }
        }

        public int EventDuration
        {
            get
            {
                return eventDuration;
            }
            set
            {
                if (value > 0)
                    eventDuration = value;
            }
        }

        /// <summary>
        /// auto-implemented properties for attributes not validating
        /// </summary>
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string CardType { get; set; }
        public string CardExpiry { get; set; }
        public string EventDate { get; set; }
        public bool Military { get; set; }
        public string DayOfWeek { get; set; }
        public int ChickenDish { get; set; }
        public int BeefDish { get; set; }
        public int SeafoodDish { get; set; }
        public int VegetarianDish { get; set; }

        /// <summary>
        /// a function that calculates Total ticket cost
        /// </summary>
        /// <returns></returns>
        public int CalculateTotalTicketCost()
        {
            int totalCost = 100;
            if (EventDuration > 2)
            {
                totalCost += 100 * (EventDuration - 2);
            }
            totalCost += (ChickenDish * 15) + (BeefDish * 20) + (SeafoodDish * 20) + (VegetarianDish * 15);
            if (Military)
            {
                totalCost -= (totalCost * 25 / 100);
            }
            return totalCost;
        }
    }
}
