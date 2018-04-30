//Karen Rees-Milton. COMP60. Assignment 3
//April 27 2018
// A program to take orders for a catering company
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace milestone1
{
    public partial class Form1 : Form
    {
        string[] daysOfWeek;
        CateringOrder orderOne;
        public Form1()
        {
            InitializeComponent();
            orderOne = new CateringOrder();
            //Instantiate array and populate listbox from array
            daysOfWeek = new string[] {"Monday", "Tuesday","Wednesday","Thursday", "Friday", "Saturday", "Sunday"};
            foreach(string day in daysOfWeek)
            {
                dayOfWeekListBox.Items.Add(day);
            }

        }
        
        /// <summary>
        /// event handler function for clicking submit button after completing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            orderOne.FirstName = fNameTextBox.Text;
            orderOne.LastName = LNameTextBox.Text;
            orderOne.Street = streetTextBox.Text;
            orderOne.City = cityTextBox.Text;
            orderOne.Province = provinceMaskTextBox.Text;
            orderOne.PostalCode = postalCodeMaskTextBox.Text;
            orderOne.Phone = phoneMaskTextBox.Text;
            orderOne.Email = emailTextBox.Text;
            orderOne.Military = militaryCheckBox.Checked;
            orderOne.CardType = cardTypeListBox.SelectedItem.ToString();
            orderOne.CardName = nameOnCardTextBox.Text;
            orderOne.CardNum = cardNumTextBox.Text;
            orderOne.CardExpiry = cardExpiryTextBox.Text;
            orderOne.EventDate = dateOfEventMaskTextBox.Text;
            orderOne.EventDuration = Int32.Parse(eventDurationTextBox.Text);
            orderOne.DayOfWeek = dayOfWeekListBox.SelectedItem.ToString();
            orderOne.ChickenDish = Int32.Parse(chickenTextBox.Text);
            orderOne.BeefDish = Int32.Parse(beefTextBox.Text);
            orderOne.SeafoodDish = Int32.Parse(seafoodTextBox.Text);
            orderOne.VegetarianDish = Int32.Parse(vegetarianTextBox.Text);

            totalCostTextBox.Text = orderOne.CalculateTotalTicketCost().ToString();
        }

        /// <summary>
        /// event handler function for clicking save button to save form object content to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDialog.Filter = "Catering Order | *.tkt";
            DialogResult result = saveDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                Stream stream = new FileStream(saveDialog.FileName, FileMode.Create);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, orderOne);
                stream.Close();
            }
        }

        /// <summary>
        /// event handler function for clicking open button to populate form object from file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openButton_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "Catering Order | *.tkt";
            DialogResult result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Stream stream = new FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                orderOne = (CateringOrder)formatter.Deserialize(stream);
                stream.Close();

                //code to populate text boxes when open file
                fNameTextBox.Text = orderOne.FirstName;
                LNameTextBox.Text = orderOne.LastName;
                streetTextBox.Text = orderOne.Street;
                cityTextBox.Text = orderOne.City;
                provinceMaskTextBox.Text = orderOne.Province;
                postalCodeMaskTextBox.Text = orderOne.PostalCode;
                phoneMaskTextBox.Text = orderOne.Phone;
                emailTextBox.Text = orderOne.Email;
                militaryCheckBox.Checked = orderOne.Military;
                cardTypeListBox.SelectedItem = orderOne.CardType;
                nameOnCardTextBox.Text = orderOne.CardName;
                cardNumTextBox.Text = orderOne.CardNum;
                cardExpiryTextBox.Text = orderOne.CardExpiry;
                dateOfEventMaskTextBox.Text = orderOne.EventDate;
                eventDurationTextBox.Text = orderOne.EventDuration + "";
                dayOfWeekListBox.SelectedItem = orderOne.DayOfWeek;
                chickenTextBox.Text = orderOne.ChickenDish + "";
                beefTextBox.Text = orderOne.BeefDish + "";
                seafoodTextBox.Text = orderOne.SeafoodDish + "";
                vegetarianTextBox.Text = orderOne.VegetarianDish + "";

                totalCostTextBox.Text = orderOne.CalculateTotalTicketCost().ToString();
            }
        }
    }
}
