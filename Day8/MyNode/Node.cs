using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNode
{
    public class Node
    {
        public int MetadataSum;

        public Node(string metaData)
        {
            string[] md = metaData.Split(new[] { ' ' });

            foreach (var meta in md)
            {
                MetadataSum += int.Parse(meta);
            }
        }
    }
}
