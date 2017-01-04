using PetStore.Importer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetStore.Data.Common;
using PetStore.Data;

using PetStore.Importer.Importers;

namespace PetStore.Importer
{
    public class DataImporter 
    {
        private IImporter data;

        public DataImporter(IImporter data)
        {
            this.data = data;
        }

        public void ImportData()
        {
            this.data.Import();
        }
    }
}