using System;
using System.Collections.Generic;
using System.Text;

namespace Dinner.Dapper
{
    public class BaseModel:IEntity<int>
    {
        public int Id { get; set; }
    }
}
