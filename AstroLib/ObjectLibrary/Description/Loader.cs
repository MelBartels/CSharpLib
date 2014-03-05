using System.Collections.Generic;
using System.Linq;
using FileHelpers;

namespace AstroLib.ObjectLibrary.Description
{
    public class Loader<T> where T : Record
    {
        public Loader() : this(new FileHelperEngine<T>())
        {
        }

        public Loader(FileHelperEngine<T> engine)
        {
            Engine = engine;
        }

        private FileHelperEngine<T> Engine { get; set; }

        public List<T> Load(string filename)
        {
            return Engine.ReadFile(filename).ToList();
        }
    }
}