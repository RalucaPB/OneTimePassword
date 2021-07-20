using OneTimePassword.Interfaces;
using OneTimePassword.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneTimePassword
{
    public partial class Form1 : Form
    {
        readonly ICryptographyService _cryptographyService;
        public Form1(ICryptographyService cryptographyService)
        {
            InitializeComponent();
           
            _cryptographyService = cryptographyService;

            HideElements(); 
        }
        
        private void HideElements()
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button2.Visible = false;
            label5.ForeColor = Color.White;
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            HideElements();
            string userId = textBox1.Text;
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string validatorResult = validatorUserId.Validate(userId);
            if (validatorResult != "Valid")
            {
                MessageBox.Show(validatorResult, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime dateTime = DateTime.Now;
            string message = userId + "#" + dateTime;
            string oneTimePassword = _cryptographyService.Encrypt(message);
            label4.Text = oneTimePassword;
            label3.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string oneTimePassword = label4.Text;
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            string message = _cryptographyService.Decrypt(oneTimePassword);
            DateTime dateTime = utils.GetDateTime(message);
            if(utils.ValidateOneTimePassword(dateTime))
            {
                label5.Text = "The one time password is valid";
            }
            else
            {
                label5.Text = "The one time password is not valid";
                label5.ForeColor = Color.FromArgb(94,0,0);
            }
            label5.Visible = true;

        }

       
    }
}
