using System.Collections.Generic;
namespace LightingScheme
{
    public class ModelData
    {
        public int id { get; set; }
        public string path { get; set; }
        public List<string> listFiles { get; set; }

        public ModelData(int _id, string _path, List<string> _listFiles)
        {
            id = _id;
            path = _path;
            listFiles = _listFiles;
        }
    }
}
