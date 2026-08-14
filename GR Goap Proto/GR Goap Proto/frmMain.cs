using GR_Goap_Proto.Simulator;

namespace GR_Goap_Proto
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            PopulateCharacterList();



        }

        private void PopulateCharacterList()
        {
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var sim = new Simulation();
            sim.RunSimulation();
        }
    }
}
