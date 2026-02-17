using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTracker.Core
{
    public interface IStorageService
    {

        public void SaveData<T>(T data);

    }
}
