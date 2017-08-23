using Microsoft.Reporting.WinForms;
using System;
using System.Windows;

namespace WPFTest.View.Reporting
{
    /// <summary>
    /// Interaction logic for ReporteUsuariosWindow.xaml
    /// </summary>
    public partial class ReporteUsuariosWindow : Window
    {
        #region Propiedades
        private bool _isReportViewerLoaded;
        #endregion

        #region Constructor
        public ReporteUsuariosWindow()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }
        #endregion

        #region Metodos Privados
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                ReportDataSource reportDataSource = new ReportDataSource();
                Uri reportServerUrl = new Uri(@"http://bue-h47lqc2/ReportServer_SQLEXPRESS");
                this._reportViewer.ProcessingMode = ProcessingMode.Remote;
                this._reportViewer.ServerReport.ReportServerUrl = reportServerUrl;
                this._reportViewer.ServerReport.ReportPath = "/Test/reporteUsuarios";
                this._reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        #endregion
    }
}
