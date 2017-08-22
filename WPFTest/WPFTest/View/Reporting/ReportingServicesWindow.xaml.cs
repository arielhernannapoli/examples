using Microsoft.Reporting.WinForms;
using System;
using System.Windows;
using WPFTest.DataSources;

namespace WPFTest.View
{
    /// <summary>
    /// Interaction logic for ReportingServicesWindow.xaml
    /// </summary>
    public partial class ReportingServicesWindow : Window
    {
        #region Propiedades
        private bool _isReportViewerLoaded; 
        #endregion

        #region Constructor
        public ReportingServicesWindow()
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
                WpfTestDataSet dataset = new WpfTestDataSet();
                dataset.BeginInit();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = dataset.usuario;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "WPFTest.Reporting.testReport.rdlc";
                dataset.EndInit();
                DataSources.WpfTestDataSetTableAdapters.usuarioTableAdapter usuarioTableAdapter = new DataSources.WpfTestDataSetTableAdapters.usuarioTableAdapter();
                usuarioTableAdapter.ClearBeforeFill = true;
                usuarioTableAdapter.Fill(dataset.usuario);
                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;
            }
        } 
        #endregion
    }
}
