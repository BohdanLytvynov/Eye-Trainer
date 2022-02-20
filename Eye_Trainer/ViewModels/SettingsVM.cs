using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBaseLib.VMBase;
using Eye_Trainer.Settings;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Input;
using System.Drawing;
using VMBaseLib.Commands;

namespace Eye_Trainer.ViewModels
{
    public class SettingsVM : ViewModelBase
    {
        #region Fields

        private SolidColorBrush m_backColor;

        private SolidColorBrush m_Pointcolor;

        private int m_count;
        
        private ColorDialog m_colDialog;

        #endregion

        #region Properties

        public SolidColorBrush BackColor 
        {
            get=> m_backColor;
            
            set => Set(ref m_backColor , value, nameof(BackColor)); 
        }

        public SolidColorBrush PointColor
        {
            get => m_Pointcolor;

            set => Set(ref m_Pointcolor, value, nameof(PointColor));
        }

        public int Count
        {
            get => m_count;

            set { m_count = value; OnPropertyChanged(nameof(Count)); Configuration.Ex_Count = m_count; }
        }

        #endregion

        #region CommandsPropeties

        public ICommand OnOpenClolorSelectorPressed { get; }

        public ICommand OnOpenClolorSelectorPointPressed { get; }

        #endregion

        #region Ctor
        public SettingsVM()
        {
            m_backColor = new SolidColorBrush();

            m_Pointcolor = new SolidColorBrush();

            OnOpenClolorSelectorPressed = new Command(
                CanOnOpenColorSelectorPressedExecute,
                OnOpenColorSelectorPressedExecute
                );

            OnOpenClolorSelectorPointPressed = new Command(
                CanOnOpenColorSelectorPointPressedExecute,
                OnOpenColorSelectorPointPressedExecute
                );
        }
        #endregion

        #region Methods

        #region OpenColorButtonPressed

        private bool CanOnOpenColorSelectorPressedExecute(object p) =>
        true;

        private void OnOpenColorSelectorPressedExecute(object p)
        {
            m_colDialog = new ColorDialog();

            if (m_colDialog.ShowDialog() == DialogResult.OK)
            {
                Configuration.BackGroundColor = System.Windows.Media.Color.FromArgb(
                    m_colDialog.Color.A, m_colDialog.Color.R, m_colDialog.Color.G,
                    m_colDialog.Color.B
                    );

                BackColor = new SolidColorBrush(Configuration.BackGroundColor);
                    
            }
        }

        #endregion

        #region Open Color Button Pressed Point

        private bool CanOnOpenColorSelectorPointPressedExecute(object p) =>
        true;

        private void OnOpenColorSelectorPointPressedExecute(object p)
        {
            m_colDialog = new ColorDialog();

            if (m_colDialog.ShowDialog() == DialogResult.OK)
            {
                Configuration.EllipseColor = System.Windows.Media.Color.FromArgb(
                    m_colDialog.Color.A, m_colDialog.Color.R, m_colDialog.Color.G,
                    m_colDialog.Color.B
                    );

                PointColor = new SolidColorBrush(Configuration.EllipseColor);

            }
        }

        #endregion

        #endregion
    }
}
