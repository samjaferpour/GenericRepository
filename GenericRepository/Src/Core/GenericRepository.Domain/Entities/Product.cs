using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
