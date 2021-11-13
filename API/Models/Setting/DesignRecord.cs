using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Setting
{
    public class DesignRecord
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string Title { get; set; }
        public string ComponentName { get; set; }
        public string ProgressAndProblem { get; set; }
        public string CrudState { get; set; }
        public bool Finished { get; set; } = false;
        public DateTime UpdateDay { get; set; } = DateTime.Now;
    }
}
