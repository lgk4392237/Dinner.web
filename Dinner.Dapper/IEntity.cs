using System;
using System.Collections.Generic;
using System.Text;

namespace Dinner.Dapper
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
