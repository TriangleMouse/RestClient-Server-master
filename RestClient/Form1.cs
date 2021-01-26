using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net;

namespace RestClient
{

    public partial class RestClient : Form
    {

        xNet Client;
        public RestClient()
        {
            InitializeComponent();
            Client = xNet.GetInstance();
            if (Client.Init == false)
            { MessageBox.Show("UnCaught init Error"); Environment.Exit(405); };
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.STATUS, new string[] { "0", "0" }));
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.GET, new string[] { textBoxGetFN.Text }));
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.POST, new string[] { textBoxPostFN.Text, textBoxPostText.Text }));
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.COPY, new string[] { textBoxCopyFN1.Text, textBoxCopyFN2.Text }));
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.MOVE, new string[] { textBoxMoveFN1.Text,textBoxMoveFN2.Text }));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Client.SendPost(xNet.PostMethods.DELETE, new string[] { textBoxDeleteFN.Text }));
        }
    }
}
