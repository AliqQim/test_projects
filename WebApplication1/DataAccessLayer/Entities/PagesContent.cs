using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliksoft.DataAccessLayer.Entities
{
    public class PagesContent
    {
        public PageId PageId { get; set; }

        public string Content { get; set; } = null!;
    }

    public enum PageId
    {
        Main = 1
    };
}
