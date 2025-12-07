using System.Data;

namespace Project
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        DateTime date = DateTime.UtcNow.Date;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Notes", typeof(String));
            table.Columns.Add("Category", typeof(String));
            table.Columns.Add("Date", typeof(String));
            
            DataTable tb = new DataTable();

            tb.Columns.Add("id");
            tb.Columns.Add("val");

            tb.Rows.Add("Personal", "Personal");
            tb.Rows.Add("Journal", "Journal");
            tb.Rows.Add("School", "School");
            tb.Rows.Add("Sport", "Sport");
            tb.Rows.Add("Random", "Random");

            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "val";
            comboBox1.ValueMember = "id";

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Notes"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtBody.Clear();
            comboBox1.SelectedItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtBody.Text, comboBox1.SelectedValue, date.ToString());
            txtTitle.Clear();
            txtBody.Clear();
            comboBox1.SelectedItem = null;

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if(index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtBody.Text= table.Rows[index].ItemArray[1].ToString();
                comboBox1.SelectedValue = table.Rows[index].ItemArray[2].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex; 

            table.Rows[index].Delete();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Title LIKE '%{0}%' OR Category LIKE '%{0}%' OR Date LIKE '%{0}%' ", txtSearch.Text);
        }
    }
}