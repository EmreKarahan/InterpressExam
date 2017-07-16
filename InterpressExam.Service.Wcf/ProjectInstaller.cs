using System.ComponentModel;
using System.Configuration.Install;

namespace InterpressExam.Service.Wcf
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
