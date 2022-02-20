using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBaseLib.VMBase;
using VMBaseLib.Commands;
using System.Windows;

namespace Eye_Trainer.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private bool m_IsSettingsOpened;
        private bool m_IsTrainerOpened;
        private object m_FrameObject;
        private object m_EmptyObject;
        private Eye_Trainer.Views.Settings m_setWindow;

        private Eye_Trainer.Views.Trainer m_setTrainer;

        #endregion

        #region Properties

        public bool IsSettingsOpen 
        { 
            get=> m_IsSettingsOpened;

            set 
            {
                Set<bool>(ref m_IsSettingsOpened, value, nameof(IsSettingsOpen));

                if (IsSettingsOpen)
                {
                    FrameObject = m_setWindow;

                    IsTrainerOpened = false;
                }

                
                
            }
        }

        public bool IsTrainerOpened 
        { 
            get=> m_IsTrainerOpened;

            set
            {
                Set<bool>(ref m_IsTrainerOpened, value, nameof(IsTrainerOpened));

                if (IsTrainerOpened)
                {
                    FrameObject = m_setTrainer;

                    IsSettingsOpen = false;
                }

                
                
            }
        }

        public object FrameObject 
        {
            get=> m_FrameObject;

            set=> Set<object>(ref m_FrameObject, value, nameof(FrameObject));
        }

        #endregion

        #region Ctor
        public MainWindowViewModel()
        {            
            m_setWindow = new Views.Settings();

            m_setTrainer = new Views.Trainer();

            m_FrameObject = m_setWindow;

            m_IsSettingsOpened = true;
        }
        #endregion

        #region Methods

        

        #endregion
    }
}
