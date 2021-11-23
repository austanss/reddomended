using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reddomended
{
    internal class PostCategory
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }

        public Post[] Posts { get; internal set; }
    }
}
