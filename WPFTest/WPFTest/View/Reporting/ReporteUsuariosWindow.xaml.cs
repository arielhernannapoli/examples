using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
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
                Uri reportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportingServices.Url"].ToString());
                this._reportViewer.ProcessingMode = ProcessingMode.Remote;
                this._reportViewer.ServerReport.ReportServerUrl = reportServerUrl;
                this._reportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportingServices.ReporteUsuarios.Path"].ToString();
                this._reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        #endregion
    }
}
