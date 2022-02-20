using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBaseLib.CommandBase;

namespace VMBaseLib.Commands
{
    public class Command : CommandBase.CommandBase
    {
        private readonly Action<object> m_execute;

        private readonly Func<object, bool> m_CanExecute;

        public Command(Func<object, bool> canExecute, Action<object> execute)
        {
            m_execute = execute ?? throw new ArgumentException(nameof(execute));

            m_CanExecute = canExecute;
        }

        public override bool CanExecute(object parameter) =>
            m_CanExecute?.Invoke(parameter) ?? true;


        public override void Execute(object parameter) =>
            m_execute.Invoke(parameter);
        
            
        
    }
}
