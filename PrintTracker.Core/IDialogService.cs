using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTracker.Core
{
    public interface IDialogService
    {
        PrintProject? ShowAddProjectDialog();
    }
}
