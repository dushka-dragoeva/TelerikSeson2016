using PetStore.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Importer
{
    public interface IImporter

    {
        string message { get; }

        int Order { get; }

        void Import();
    }
}
